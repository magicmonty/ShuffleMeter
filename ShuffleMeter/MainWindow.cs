using System;
using Gtk;
using CardLib;
using CardLib.Cards;
using System.Drawing;
using Gdk;

public partial class MainWindow : Gtk.Window
{	
	private CardDeck deck;
	
	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		deck = new CardDeck();
		for (Suit s = Suit.Clubs; s <= Suit.Spades; s++)
		{
			for (CardValue v = CardValue.Ace; v <= CardValue.King; v++)
			{
				NormalCard card = new NormalCard(v, s, AbstractCard.DEFAULT_BACK_COLOR);
				deck.addCard(card);
			}
		}
		
		
		Build();
		
		cardrow1.SetQuarter(0);
		cardrow2.SetQuarter(1);
		cardrow3.SetQuarter(2);
		cardrow4.SetQuarter(2);
		
		updateDeckView();
	}

	private void updateDeckView() {
		cardrow1.SetDeck(this.deck);
		cardrow2.SetDeck(this.deck);
		cardrow3.SetDeck(this.deck);
		cardrow4.SetDeck(this.deck);
		
		cardrow1.QueueDraw();
		cardrow2.QueueDraw();
		cardrow3.QueueDraw();
		cardrow4.QueueDraw();
	}
	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}
	
	protected virtual void OnRegularShuffleActionActivated(object sender, System.EventArgs e)
	{
		this.deck.shuffleStrategy = new RegularShuffleStrategy();
		
		this.deck.shuffle();		
		this.updateDeckView();
	}
	
	protected virtual void OnOutFaroActionActivated(object sender, System.EventArgs e)
	{
		this.deck.shuffleStrategy = new FaroShuffleStrategy(true, false);
		
		this.deck.shuffle();
		this.updateDeckView();
	}
	
	protected virtual void OnAntiOutFaroActionActivated(object sender, System.EventArgs e)
	{
		this.deck.shuffleStrategy = new FaroShuffleStrategy(true, true);
		
		this.deck.shuffle();
		this.updateDeckView();
	}
	
	protected virtual void OnInFaroActionActivated(object sender, System.EventArgs e)
	{
		this.deck.shuffleStrategy = new FaroShuffleStrategy(false, false);
		
		this.deck.shuffle();
		this.updateDeckView();
	}
	
	protected virtual void OnAntiInFaroActionActivated(object sender, System.EventArgs e)
	{
		this.deck.shuffleStrategy = new FaroShuffleStrategy(false, true);
		
		this.deck.shuffle();
		this.updateDeckView();
	}	
}