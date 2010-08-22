using System;
using System.Collections.Generic;
using CardLib.Cards;

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
		
		public override string ToString ()
		{
			String tmp = "";
			foreach (AbstractCard card in cardStack)
			{
				tmp = tmp + card.ToString() + "\n";
			}

			tmp = tmp.Trim ();
			return tmp.Equals("") ? "Empty deck" : tmp;
		}

		public void initEmptyDeck (int count)
		{
			this.clear();
			if (count > 0)
			{
				for (int i = 0; i < count; i++)
				{
					this.addCard (new NormalCard ());
				}
			}
		}
	}
}
