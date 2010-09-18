using System;
using CardLib;
using CardLib.Cards;
using Gtk;
using Gdk;

namespace CardLib {
  public enum DeckQuarter {
    First = 0,
    Second = 1,
    Third = 2,
    Fourth = 3
  }

  public delegate void CardClickedEventHandler(object sender, int cardIndex);
  
  [System.ComponentModel.ToolboxItem(true)]
  public partial class CardRow : Gtk.Bin {
    private CardDeck Deck;
    private int FromIndex;
    private int ToIndex;
    private int CardCount;
    private int CardOffset;

    public event CardClickedEventHandler OnCardClicked;

    public CardRow() {
      this.Deck = CardDeck.FromNewDeckOrder();
      this.FromIndex = 0;
      this.ToIndex = Deck.Count - 1;

      this.Build();
    }

    public void SetDeck(CardDeck Deck) {
      this.Deck.assign(Deck);
      this.Invalidate();
    }

    public void Invalidate() {
      UpdateCardCount();
    }

    private void UpdateCardCount() {
      if ((this.ToIndex == -1) || (this.FromIndex == -1)) {
        this.CardCount = 0;
      } else {
        this.CardCount = this.ToIndex - this.FromIndex + 1;
      }
      UpdateCardOffset();
    }

    private void UpdateCardOffset() {
      if ((this.ToIndex == -1) || (this.FromIndex == -1) || (this.CardCount <= 1)) {
        this.CardOffset = 0;
      } else {
        if (this.Parent != null)
          this.CardOffset = ((this.Parent.SizeRequest().Width - 2 * (int) this.eventbox1.BorderWidth) - AbstractCard.CARD_WIDTH) / (this.CardCount - 1);
        else
          this.CardOffset = ((this.SizeRequest().Width - 2 * (int) this.eventbox1.BorderWidth) - AbstractCard.CARD_WIDTH) / (this.CardCount - 1);
        if (this.CardOffset < 10) {
          this.CardOffset = 10;
        }
        if (this.CardOffset > 35) {
          this.CardOffset = 35;
        }
      }

      UpdateWidthRequest();
    }

    private void UpdateWidthRequest() {
      this.WidthRequest = AbstractCard.CARD_WIDTH + this.CardOffset * (this.CardCount - 1) + 2 * (int)this.eventbox1.BorderWidth;
      this.QueueDraw();
    }

    public void SetQuarter(DeckQuarter Quarter) {
      if (this.Deck.Count > 0) {
        int quarterSize = this.Deck.Count / 4;
        if (this.Deck.Count % 4 > 0)
          quarterSize++;

        if ((Quarter == DeckQuarter.First) || ((quarterSize * (int) Quarter) < this.Deck.Count)) {
          this.SetFromIndexInternal((int) Quarter * quarterSize);

          if (Quarter == DeckQuarter.Fourth) {
            this.SetToIndexInternal(this.FromIndex + quarterSize - (this.Deck.Count % 4) + 1);
          } else {
            this.SetToIndexInternal(this.FromIndex + quarterSize - 1);
          }
        } else {
          this.SetFromIndexInternal(-1);
          this.SetToIndexInternal(-1);
        }
        this.Invalidate();
      }
    }

    private void SetFromIndexInternal(int FromIndex) {
      this.FromIndex = FromIndex;
      if (this.Deck.Count > 0) {
        if (this.FromIndex < 0) {
          this.FromIndex = -1;
        } else if (this.FromIndex > this.Deck.Count - 1) {
          this.FromIndex = this.Deck.Count - 1;
        }
      } else {
        this.FromIndex = -1;
      }
    }

    public void SetFromIndex(int FromIndex) {
      this.SetFromIndexInternal(FromIndex);
      this.Invalidate();
    }

    public void SetToIndexInternal(int ToIndex) {
      this.ToIndex = ToIndex;
      if (this.Deck.Count > 0) {
        if (this.ToIndex < 0) {
          this.ToIndex = -1;
        } else if (this.ToIndex > this.Deck.Count - 1) {
          this.ToIndex = this.Deck.Count - 1;
        }

        if (this.ToIndex < this.FromIndex) {
          this.ToIndex = this.FromIndex;
        }
      } else {
        this.ToIndex = -1;
      }
    }

    public void SetToIndex(int ToIndex) {
      this.SetToIndexInternal(ToIndex);
      this.Invalidate();
    }

    private int GetCardIndexByMousePosition(double X, double Y) {
      if (
        (this.CardOffset > 0)
        &&
        (Y >= 0) && (Y <= this.SizeRequest().Height)
        &&
        (X >= 0) && (X <= this.SizeRequest().Width)
      ) {
        int result = (int) X / this.CardOffset;


        if (result > this.ToIndex - this.FromIndex) {
          result = this.ToIndex - this.FromIndex;
        }

        return this.FromIndex + result;
      }

      return -1;

    }

    protected virtual void OnDrawingarea1ExposeEvent(object o, Gtk.ExposeEventArgs args) {
      if (this.Deck != null) {
        Gdk.Window win = args.Event.Window;
        Gdk.GC gc = Style.BaseGC(StateType.Normal);
        
        if (
          (this.Deck.Count > 0)
          && (this.FromIndex >= 0)
          && (this.ToIndex >= 0)
        ) {
          for (int i = 0; i < this.CardCount; i++) {
            AbstractCard card = this.Deck.getCardAt(this.FromIndex + i);
            
            if (card != null) {
              win.DrawPixbuf(gc, card.GetPixbuf(), 0, 0, i * this.CardOffset, 0, 71, 98, Gdk.RgbDither.Normal, 0,
              0);
            }
          }
        }
        
        args.RetVal = true;
      }
    }

    protected virtual void OnEventbox1MotionNotifyEvent(object o, Gtk.MotionNotifyEventArgs args) {
      int index = GetCardIndexByMousePosition(args.Event.X, args.Event.Y);
      for (int i = 0; i < this.Deck.Count; i++) {
        this.Deck.getCardAt(i).hover = (index == i);
      }

      this.QueueDraw();
    }

    protected virtual void OnEventbox1LeaveNotifyEvent(object o, Gtk.LeaveNotifyEventArgs args) {
      for (int i = 0; i < this.Deck.Count; i++) {
        this.Deck.getCardAt(i).hover = false;
      }
      this.QueueDraw();
    }

    protected virtual void OnEventbox1ButtonPressEvent (object o, Gtk.ButtonPressEventArgs args)
    {
      int index = GetCardIndexByMousePosition(args.Event.X, args.Event.Y);
      if ((index >= 0) && (OnCardClicked != null)) {
        OnCardClicked(this, index);
      }
    }
  }
}
