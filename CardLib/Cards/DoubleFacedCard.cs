
using System;

namespace CardLib
{
	public class DoubleFacedCard : AbstractCard
	{
		public CardValue faceValue {
			get { return this.faceSide != null ? ((CardSide)this.faceSide).cardValue : DEFAULT_CARD_VALUE; }
			set {
				if (this.faceSide == null) {
					this.faceSide = new CardSide ();
				}
				
				((CardSide)this.faceSide).cardValue = value;
			}
		}

		public Suit faceSuit {
			get { return this.faceSide != null ? ((CardSide)this.faceSide).suit : DEFAULT_SUIT; }
			set {
				if (this.faceSide == null) {
					this.faceSide = new CardSide ();
				}
				((CardSide)this.faceSide).suit = value;
			}
		}

		public CardValue backValue {
			get { return this.backSide != null ? ((CardSide)this.backSide).cardValue : DEFAULT_CARD_VALUE; }
			set {
				if (this.backSide == null) {
					this.backSide = new CardSide ();
				}
				
				((CardSide)this.backSide).cardValue = value;
			}
		}

		public Suit backSuit {
			get { return this.backSide != null ? ((CardSide)this.backSide).suit : DEFAULT_SUIT; }
			set {
				if (this.backSide == null) {
					this.backSide = new CardSide ();
				}
				((CardSide)this.backSide).suit = value;
			}
		}

		public DoubleFacedCard (CardValue cardValue1, Suit cardSuit1, CardValue cardValue2, Suit cardSuit2) : base()
		{
			this.faceSide = new CardSide (cardValue1, cardSuit1);
			this.backSide = new CardSide (cardValue2, cardSuit2);
		}

		public DoubleFacedCard () : this(DEFAULT_CARD_VALUE, DEFAULT_SUIT, DEFAULT_CARD_VALUE, DEFAULT_SUIT)
		{
		}
		
		public override string ToString ()
		{
			return string.Format ("DoubleFace: {0} / {1}", this.faceSide.ToString(), this.backSide.ToString ());
		}

	}
}
