using System;
using CardLib.Cards;

namespace CardLib {
	public class RegularShuffleStrategy : AbstractShuffleStrategy {
		public RegularShuffleStrategy() {
		}

		public override void shuffle(CardDeck deck) {
			CardDeck tempDeck = new CardDeck();
			tempDeck.assign(deck);
			
			deck.clear();
			
			Random rnd = new Random();
			int randomIndex;
			
			while (tempDeck.Count > 0) {
				randomIndex = rnd.Next(tempDeck.Count);
				
				AbstractCard card = tempDeck.getCardAt(randomIndex);
				deck.addCard(card);
				tempDeck.removeCardAt(randomIndex);
			}
		}
	}
}
