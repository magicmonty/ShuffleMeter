using System;
using System.Drawing;

namespace CardLib.Cards
{

	public abstract class AbstractCard
	{
		public static int MARK_NONE = -1;
		public static CardValue DEFAULT_CARD_VALUE = CardValue.Ace;
		public static Suit DEFAULT_SUIT = Suit.Clubs;
		public static Color DEFAULT_BACK_COLOR = Color.Blue;

		protected AbstractSide faceSide { get; set; }
		protected AbstractSide backSide { get; set; }

		public int mark { get; set; }
		public bool faceUp { get; set; }

		public AbstractCard ()
		{
			this.faceSide = null;
			this.backSide = null;
			this.mark = MARK_NONE;
			this.faceUp = true;
		}

		public void Draw (Graphics context, int x, int y, double scale)
		{
			if ((this.faceSide != null) && (this.faceUp)) {
				this.faceSide.Draw (context, x, y, scale);
			} else if ((this.backSide != null) && (!this.faceUp)) {
				this.backSide.Draw (context, x, y, scale);
			}
		}
		
		public void Assign (AbstractCard card)
		{
			if ((this.faceSide == null) || (!(this.faceSide.GetType ().Equals (card.faceSide.GetType ()))))
			{
				this.faceSide = card.faceSide;
			}
			else 
			{
				this.faceSide.Assign (card.faceSide);

			}
			if ((this.backSide == null) || (!(this.backSide.GetType ().Equals (card.backSide.GetType ())))) {
				this.backSide = card.backSide;
			} else {
				this.backSide.Assign (card.backSide);
			}
		}
		
	}
	
}