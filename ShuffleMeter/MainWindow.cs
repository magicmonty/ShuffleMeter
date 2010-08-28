using System;
using Gtk;
using CardLib;
using CardLib.Cards;
using System.Drawing;
using Gdk;

public partial class MainWindow : Gtk.Window
{	
	private CardDeck deck;
	
	public MainWindow () : base(Gtk.WindowType.Toplevel)
	{
		deck = new CardDeck ();
		for (Suit s = Suit.Clubs; s <= Suit.Spades; s++)
		{
			for (CardValue v = CardValue.Ace; v <= CardValue.King; v++)
			{
				NormalCard card = new NormalCard (v, s, AbstractCard.DEFAULT_BACK_COLOR);
				deck.addCard (card);
			}
		}
		
		// deck.shuffleStrategy = new FaroShuffleStrategy (true, false);
		
		Build ();
		
		cardrow1.SetQuarter(0);
		cardrow1.SetDeck(deck);
		
		cardrow2.SetQuarter(1);
		cardrow2.SetDeck(deck);
		
		cardrow3.SetQuarter(2);
		cardrow3.SetDeck(deck);
		
		cardrow4.SetQuarter(3);
		cardrow4.SetDeck(deck);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}