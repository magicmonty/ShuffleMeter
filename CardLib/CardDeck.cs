using System;
using System.Collections.Generic;

namespace CardLib
{
	public class CardDeck
	{
		protected List<AbstractCard> cardStack;
		public AbstractShuffleStrategy shuffleStrategy;

		public int Count {
			get { return this.cardStack.Count; }
		}
		
		public CardDeck ()
		{
			cardStack = new List<AbstractCard> ();
			this.shuffleStrategy = new RegularShuffleStrategy ();
		}

		public void addCard (AbstractCard card)
		{
			cardStack.Add (card);
		}

		public void shuffle ()
		{
			if (this.shuffleStrategy != null) {
				this.shuffleStrategy.shuffle (this);
			}
		}
		
		public void assign (CardDeck source)
		{
			this.clear ();
			foreach (AbstractCard card in source.cardStack)
			{
				this.cardStack.Add (card);
			}
		}
		
		public void clear ()
		{
			this.cardStack.Clear();
		}
		
		public AbstractCard getCardAt(int index) {
			return this.cardStack[index];
		}
		
		public void removeCardAt (int index)
		{
			this.cardStack.RemoveAt (index);
		}
		
	}
}
