using System;
using System.Drawing;

namespace CardLib.Cards {

	public abstract class AbstractCard {
		public static int CARD_WIDTH = 71;
		public static int CARD_HEIGHT = 98;
		
		public static int MARK_NONE = -1;
		public static CardValue DEFAULT_CARD_VALUE = CardValue.Ace;
		public static Suit DEFAULT_SUIT = Suit.Clubs;
		public static Color DEFAULT_BACK_COLOR = Color.Blue;

		protected AbstractSide faceSide { get; set; }
		protected AbstractSide backSide { get; set; }

		public int mark { get; set; }
		public bool faceUp { get; set; }
		public bool hover { get; set; }

		public AbstractCard() {
			this.faceSide = null;
			this.backSide = null;
			this.mark = MARK_NONE;
			this.faceUp = true;
			this.hover = false;
		}

		public Gdk.Pixbuf GetPixbuf() {
			Gdk.Pixbuf result = null;
			Gdk.Pixbuf original = null;
			
			
			if ((this.faceSide != null) && (this.faceUp)) {
				original = this.faceSide.GetPixbuf();
			} else if ((this.backSide != null) && (!this.faceUp)) {
				original = this.backSide.GetPixbuf();
			}
			
			if (original != null) {
				result = (Gdk.Pixbuf) original.Clone();
				
				if (hover) {					
					Gtk.Image tint = new Gtk.Image((Gdk.Pixbuf) result.Clone());
					tint.Pixbuf.Fill(0x0000ff80);
					tint.Pixbuf.Composite(result, 0, 0, result.Width, result.Height, 0, 0, 1, 1, Gdk.InterpType.Bilinear, 128);
				}
			}
			
			return result;
		}

		public void Assign(AbstractCard card) {
			if ((this.faceSide == null) || (!(this.faceSide.GetType().Equals(card.faceSide.GetType())))) {
				this.faceSide = card.faceSide;
			} else {
				this.faceSide.Assign(card.faceSide);
				
			}
			if ((this.backSide == null) || (!(this.backSide.GetType().Equals(card.backSide.GetType())))) {
				this.backSide = card.backSide;
			} else {
				this.backSide.Assign(card.backSide);
			}
		}
		
	}
	
}
