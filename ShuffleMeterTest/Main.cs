using System;
using CardLib;

namespace ShuffleMeterTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			CardDeck deck = new CardDeck ();
			
			for (Suit s = Suit.Clubs; s <= Suit.Diamonds; s++) {
				for (CardValue v = CardValue.Ace; v <= CardValue.King; v++) {
					NormalCard card = new NormalCard (v, s, AbstractCard.DEFAULT_BACK_COLOR);
					deck.addCard (card);
				}
			}
			
			deck.shuffle ();
			Console.WriteLine (deck.ToString ());
		}
	}
}
