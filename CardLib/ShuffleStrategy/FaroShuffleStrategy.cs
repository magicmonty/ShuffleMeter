using System;
using CardLib.Cards;
using System.Collections.Generic;

namespace CardLib {
	public class FaroShuffleStrategy : AbstractShuffleStrategy {
		private bool OutFaro;
		private bool AntiFaro;

		public FaroShuffleStrategy(bool OutFaro, bool AntiFaro) : base() {
			this.OutFaro = OutFaro;
			this.AntiFaro = AntiFaro;
		}

		public override void shuffle(CardDeck deck) {
			List<AbstractCard> help = new List<AbstractCard>();
			for (int i = 0; i < deck.Count; i++) {
				help.Add(new NormalCard());
			}
			
			for (int i = 0; i < deck.Count; i++) {
				if (this.OutFaro) {
					if (!this.AntiFaro) {
						if (2 * i < deck.Count) {
							help[2 * i].Assign(deck.getCardAt(i));
						} else {
							help[(2 * i) - (deck.Count - 1)].Assign(deck.getCardAt(i));
						}
					} else {
						if (2 * i < deck.Count) {
							help[i].Assign(deck.getCardAt(2 * i));
						} else {
							help[i].Assign(deck.getCardAt(2 * i - (deck.Count - 1)));
						}
					}
				} else {
					if (!this.AntiFaro) {
						if (2 * i + 1 < deck.Count) {
							help[2 * i + 1].Assign(deck.getCardAt(i));
						} else {
							help[2 * i - deck.Count].Assign(deck.getCardAt(i));
						}
					} else {
						if (2 * i + 1 < deck.Count) {
							help[i].Assign(deck.getCardAt(2 * i + 1));
						} else {
							help[i].Assign(deck.getCardAt(2 * i - deck.Count));
						}
					}
				}
			}
			
			deck.clear();
			foreach (AbstractCard card in help) {
				deck.addCard(card);
			}
		}
	}
}
