using System;
using Gtk;
using CardLib;
using CardLib.Cards;
using System.Drawing;

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
		
		deck.shuffleStrategy = new FaroShuffleStrategy (true, false);
		
		Build ();
		image2.Pixbuf = deck.getCardAt (0).GetImage ().Pixbuf;
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	
	protected virtual void OnEventbox1ButtonReleaseEvent (object o, Gtk.ButtonReleaseEventArgs args)
	{
		deck.shuffle ();
		image2.Pixbuf = deck.getCardAt (2).GetImage ().Pixbuf;
	}
	
	
	
	
}
