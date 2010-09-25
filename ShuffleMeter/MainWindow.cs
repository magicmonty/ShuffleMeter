using System;
using Gtk;
using CardLib;
using CardLib.Cards;
using System.Drawing;
using Gdk;

public partial class MainWindow : Gtk.Window {
	private CardDeck deck;

	public MainWindow() : base(Gtk.WindowType.Toplevel) {
		Build();
		deck = CardDeck.FromNewDeckOrder();

    for (int i = 0; i < deck.Count; i++) {
      deck.getCardAt(i).mark = i;
    }

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

 }
