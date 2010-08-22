using System;
using System.Drawing;
using CardLib;
using CardLib.Cards;

namespace ShuffleMeterTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			CardDeck deck = new CardDeck ();
			Color back = Color.Blue;
			
			for (Suit s = Suit.Clubs; s <= Suit.Diamonds; s++) {
				for (CardValue v = CardValue.Ace; v <= CardValue.King; v++) {
					back = back == Color.Blue ? Color.Red : Color.Blue;
					NormalCard card = new NormalCard (v, s, back);
					deck.addCard (card);
				}
			}
			
			deck.shuffleStrategy = new FaroShuffleStrategy (true, false);
			deck.shuffle ();
			Console.WriteLine (deck.ToString ());
		}
	}
}
