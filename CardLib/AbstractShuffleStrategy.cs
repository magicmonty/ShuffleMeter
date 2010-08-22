
using System;

namespace CardLib
{
	public abstract class AbstractShuffleStrategy
	{

		public AbstractShuffleStrategy ()
		{
		}

		public abstract void shuffle (CardDeck deck);
	}
}
