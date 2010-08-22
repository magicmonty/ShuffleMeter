using System;
using System.Drawing;

namespace CardLib
{

	public abstract class AbstractSide
	{
		public abstract void Draw (Graphics context, int x, int y, double scale);
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
			
		}
	}
	
	
}
