using System;
using System.Drawing;

namespace CardLib
{
	public class DoubleBackedCard : AbstractCard
	{
		public Color faceColor {
			get { return this.faceSide != null ? ((BackSide)this.faceSide).backColor : DEFAULT_BACK_COLOR; }
			set {
				if (this.faceSide == null) {
					this.faceSide = new BackSide ();
				}
				((BackSide)this.faceSide).backColor = value; 
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

		public DoubleBackedCard (Color backColor1, Color backColor2) : base()
		{
			this.faceSide = new BackSide (backColor1);
			this.backSide = new BackSide (backColor2);
		}
		
		public DoubleBackedCard(): this(DEFAULT_BACK_COLOR, DEFAULT_BACK_COLOR)
		{
		}
	}
}
