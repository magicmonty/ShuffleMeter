using System;
using System.Drawing;

namespace CardLib.Cards
{

	public abstract class AbstractSide
	{
		public abstract void Draw (Graphics context, int x, int y, double scale);
		public abstract void Assign(AbstractSide source);
	}

	class CardSide : AbstractSide
	{
		public Suit suit { get; set; }
		public CardValue cardValue { get; set; }

		public CardSide () : this(CardValue.Ace, Suit.Clubs)
		{
		}

		public CardSide (CardValue aCardValue, Suit aCardSuit)
		{
			this.cardValue = aCardValue;
			this.suit = aCardSuit;
		}

		public override void Draw (Graphics context, int x, int y, double scale)
		{
			throw new System.NotImplementedException ();
		}
		
		public override string ToString ()
		{
			return string.Format ("{0} of {1}", cardValue.ToString (), suit.ToString ());
		}
		
		public override void Assign (AbstractSide source)
		{
			if (source is CardSide) {
				this.cardValue = ((CardSide)source).cardValue;
				this.suit = ((CardSide)source).suit;
			}
		}
	}

	class BackSide : AbstractSide
	{
		public Color backColor { get; set; }

		public BackSide () : this(Color.Blue)
		{
			
		}

		public BackSide (Color aColor)
		{
			this.backColor = aColor;
		}

		public override void Draw (Graphics context, int x, int y, double scale)
		{
			throw new System.NotImplementedException ();
		}
		
		public override string ToString ()
		{
			
			return string.Format ("{0} back", backColor.Name);
		}

		public override void Assign (AbstractSide source)
		{
			if (source is BackSide) {
				this.backColor = ((BackSide)source).backColor;
			}
		}
	}
	
	
}
