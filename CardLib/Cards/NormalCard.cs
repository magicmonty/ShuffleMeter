using System;
using System.Drawing;

namespace CardLib.Cards
{
	public class NormalCard : AbstractCard
	{
		public CardValue cardValue {
			get { return this.faceSide != null ? ((CardSide)this.faceSide).cardValue : DEFAULT_CARD_VALUE; }
			set {
				if (this.faceSide == null) {
					this.faceSide = new CardSide ();
				}
				((CardSide)this.faceSide).cardValue = value;
			}
		}

		public Suit suit {
			get { return this.faceSide != null ? ((CardSide)this.faceSide).suit : DEFAULT_SUIT; }
			set {
				if (this.faceSide == null) {
					this.faceSide = new CardSide ();
				}
				((CardSide)this.faceSide).suit = value;
			}
		}

		public Color backColor {
			get { return this.backSide != null ? ((BackSide)this.backSide).backColor : DEFAULT_BACK_COLOR; }
			set {
				if (this.backSide == null) {
					this.backSide = new BackSide ();
				}
				
				((BackSide)this.backSide).backColor = value;
			}
		}

		public NormalCard (CardValue aCardValue, Suit aCardSuit, Color backColor) : base()
		{
			this.faceSide = new CardSide (aCardValue, aCardSuit);
			this.backSide = new BackSide (backColor);
		}

		public NormalCard () : this(DEFAULT_CARD_VALUE, DEFAULT_SUIT, DEFAULT_BACK_COLOR)
		{
		}
		
		public override string ToString ()
		{
			return string.Format("{0} ({1})", faceSide.ToString(), backSide.ToString());
		}

	}
}
