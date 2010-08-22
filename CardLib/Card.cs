using System;
using System.Drawing;

namespace CardLib
{

	public abstract class AbstractSide
	{
		
	}

	class CardSide : AbstractSide
	{
		public Suit suit { get; set; }
		public CardValue cardValue { get; set; }

		public CardSide (CardValue aCardValue, Suit aCardSuit)
		{
			this.cardValue = aCardValue;
			this.suit = aCardSuit;
		}
	}

	class BackSide : AbstractSide
	{
		public Color backColor { get; set; }

		public BackSide (Color aColor)
		{
			this.backColor = aColor;
		}
	}

	public abstract class AbstractCard
	{
		public static int MARK_NONE = -1;

		public AbstractSide faceSide { get; set; }
		public AbstractSide backSide { get; set; }
		public int mark { get; set; }
		public bool faceUp { get; set; }

		public AbstractCard (AbstractSide aFrontSide, AbstractSide aBackSide)
		{
			this.frontSide = aFrontSide;
			this.backSide = aBackSide;
			this.mark = MARK_NONE;
		}
	}

	public class NormalCard : AbstractCard
	{
		private new CardSide faceSide { get; set; }
		private BackSide backSide { get; set; }

		public CardValue cardValue {
			get { return this.faceSide.cardValue; }
			set { this.faceSide.cardValue = value; }
		}

		public Suit suit {
			get { return this.faceSide.suit; }
			set { this.faceSide.suit = value; }
		}

		public Color backColor {
			get { return this.faceSide.backColor; }
			set { this.faceSide.backColor = value; }
		}

		public NormalCard (CardValue aCardValue, Suit aCardSuit, Color backColor)
		{
			this.faceSide = new CardSide (aCardValue, aCardSuit);
			this.backSide = new BackSide (backColor);
		}
	}

	public class DoubleFacedCard : AbstractCard
	{
		public CardSide faceSide { get; set; }
		public CardSide backSide { get; set; }

		public CardValue faceValue {
			get { return this.faceSide.cardValue; }
			set { this.faceSide.cardValue = value; }
		}

		public Suit faceSuit {
			get { return this.faceSide.suit; }
			set { this.faceSide.suit = value; }
		}

		public CardValue backValue {
			get { return this.backSide.cardValue; }
			set { this.backSide.cardValue = value; }
		}

		public Suit backSuit {
			get { return this.backSide.suit; }
			set { this.backSide.suit = value; }
		}

		public DoubleFacedCard (CardValue cardValue1, Suit cardSuit1, CardValue cardValue2, Suit cardSuit2)
		{
			this.faceSide = new CardSide (cardValue1, cardSuit1);
			this.backSide = new CardSide (cardValue2, cardSuit2);
		}
	}

	public class DoubleBackedCard : AbstractCard
	{
		public BackSide faceSide { get; set; }
		public BackSide backSide { get; set; }

		public Color faceColor {
			get { return this.faceSide.backColor; }
			set { this.faceSide.backColor = value; }
		}

		public Color backColor {
			get { return this.backSide.backColor; }
			set { this.backSide.backColor = value; }
		}

		public DoubleBackedCard (Color backColor1, Color backColor2)
		{
			this.faceSide = new BackSide (backColor1);
			this.backSide = new BackSide (backColor2);
		}
	}
}
