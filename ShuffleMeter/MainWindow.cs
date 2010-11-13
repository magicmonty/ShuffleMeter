using System;
using Gtk;
using CardLib;
using CardLib.Cards;
using System.Drawing;
using Gdk;
using ShuffleMeter;

public partial class MainWindow : Gtk.Window {
	private CardDeck deck;

	public MainWindow() : base(Gtk.WindowType.Toplevel) {
		Build();
		deck = CardDeck.FromNewDeckOrder();
		updateDeckView();
	}

	private void updateDeckView() {
	  cardrow1.SetDeck(this.deck);
	  cardrow2.SetDeck(this.deck);
	  cardrow3.SetDeck(this.deck);
	  cardrow4.SetDeck(this.deck);
	  cardrow1.SetQuarter(DeckQuarter.First);
    cardrow2.SetQuarter(DeckQuarter.Second);
    cardrow3.SetQuarter(DeckQuarter.Third);
    cardrow4.SetQuarter(DeckQuarter.Fourth);

	}
	protected void OnDeleteEvent(object sender, DeleteEventArgs a) {
		Application.Quit();
		a.RetVal = true;
	}

	protected virtual void OnRegularShuffleActionActivated(object sender, System.EventArgs e) {
		this.deck.shuffleStrategy = new RegularShuffleStrategy();
		
		this.deck.shuffle();
		this.updateDeckView();
	}

	protected virtual void OnOutFaroActionActivated(object sender, System.EventArgs e) {
		this.deck.shuffleStrategy = new FaroShuffleStrategy(true, false);
		
		this.deck.shuffle();
		this.updateDeckView();
	}

	protected virtual void OnAntiOutFaroActionActivated(object sender, System.EventArgs e) {
		this.deck.shuffleStrategy = new FaroShuffleStrategy(true, true);
		
		this.deck.shuffle();
		this.updateDeckView();
	}

	protected virtual void OnInFaroActionActivated(object sender, System.EventArgs e) {
		this.deck.shuffleStrategy = new FaroShuffleStrategy(false, false);
		
		this.deck.shuffle();
		this.updateDeckView();
	}

	protected virtual void OnAntiInFaroActionActivated(object sender, System.EventArgs e) {
		this.deck.shuffleStrategy = new FaroShuffleStrategy(false, true);
		
		this.deck.shuffle();
		this.updateDeckView();
	}

  protected virtual void OnCardrowCardClicked (object sender, int cardIndex)
  {
    this.deck.getCardAt(cardIndex).faceUp = !this.deck.getCardAt(cardIndex).faceUp;
    this.updateDeckView();
  }

  protected virtual void OnNewDeckOrderActionActivated (object sender, System.EventArgs e)
  {
    this.deck.shuffleStrategy = new NewDeckOrderStrategy();

    this.deck.shuffle();
    this.updateDeckView();
  }

  protected virtual void OnCardrowContextMenu (object sender, int cardIndex)
  {
    Menu popupMenu = new Menu();
    MenuItem markItem = new MenuItem("Mark");
    Menu subMenu = new Menu();
    MenuItem unmarkItem = new MenuItem( "None" );
    unmarkItem.Activated += delegate {
      this.deck.getCardAt(cardIndex).mark = AbstractCard.MARK_NONE;
     };

    subMenu.Add(unmarkItem);
    subMenu.Add(new SeparatorMenuItem());

    for (int i = 0; i < AbstractCard.MARK_COLORS.Length; i++) {
      ColorMenuItem colorItem = new ColorMenuItem(i, AbstractCard.MARK_COLORS[i]);
      colorItem.Activated += delegate {
        this.deck.getCardAt(cardIndex).mark = colorItem.markIndex;
        updateDeckView();
      };

      subMenu.Add(colorItem);
    }

    markItem.Submenu = subMenu;
    popupMenu.Add(markItem);

    MenuItem cutItem = new MenuItem("Cut here");
    cutItem.Activated += delegate {
      this.deck.shuffleStrategy = new CutShuffleStrategy(cardIndex);
      this.deck.shuffle();
      updateDeckView();
    };
    popupMenu.Add(cutItem);

    popupMenu.Add(new SeparatorMenuItem());

    MenuItem reverseToHereItem = new MenuItem("Reverse to here");
    reverseToHereItem.Activated += delegate {
      this.deck.shuffleStrategy = new ReverseShuffleStrategy(0, cardIndex);
      this.deck.shuffle();
      updateDeckView();
    };
    popupMenu.Add(reverseToHereItem);

    MenuItem reverseFromHereItem = new MenuItem("Reverse from here");
    reverseFromHereItem.Activated += delegate {
      this.deck.shuffleStrategy = new ReverseShuffleStrategy(cardIndex, this.deck.Count - 1);
      this.deck.shuffle();
      updateDeckView();
    };
    popupMenu.Add(reverseFromHereItem);

    popupMenu.ShowAll();
    popupMenu.Popup();
  }
}
