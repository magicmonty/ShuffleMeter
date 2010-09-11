using System;
using System.Drawing;
using Gtk;
using Gdk;

namespace CardLib.Cards {

	public abstract class AbstractSide {
		public abstract void Assign(AbstractSide source);
		public abstract Gdk.Pixbuf GetPixbuf();
		public abstract Gtk.Image GetImage();
		
		protected Gtk.Image GetImageFromResource(string resourceName) {
			Gtk.Image result = null;
			try {
				result = Gtk.Image.LoadFromResource(resourceName);
			} catch {
				result = null;
			}
			
			return result;
		}
		
		protected Gdk.Pixbuf GetPixbufFromResource(string resourceName) {
			Gdk.Pixbuf result = null;
			Gtk.Image resImg = GetImageFromResource(resourceName);

			if (resImg != null) {
				try {
					result = resImg.Pixbuf;
				} catch {
					result = null;
				}
			} else {
				result = null;
			}
			
			return result;
		}
	}

	class CardSide : AbstractSide {
		public Suit suit { get; set; }
		public CardValue cardValue { get; set; }

		public CardSide() : this(CardValue.Ace, Suit.Clubs) {
		}

		public CardSide(CardValue aCardValue, Suit aCardSuit) {
			this.cardValue = aCardValue;
			this.suit = aCardSuit;
		}

		public override string ToString() {
			return string.Format("{0} of {1}", cardValue.ToString(), suit.ToString());
		}

		public override void Assign(AbstractSide source) {
			if (source is CardSide) {
				this.cardValue = ((CardSide) source).cardValue;
				this.suit = ((CardSide) source).suit;
			}
		}

		public override Gdk.Pixbuf GetPixbuf () {
			return GetPixbufFromResource(string.Format("{0}{1}.png", cardValue.ToString(), suit.ToString()));
		}
		
		public override Gtk.Image GetImage () {
			return GetImageFromResource(string.Format("{0}{1}.png", cardValue.ToString(), suit.ToString()));
		}
	}

	class BackSide : AbstractSide {
		public System.Drawing.Color backColor { get; set; }

		public BackSide() : this(System.Drawing.Color.Blue) {
			
		}

		public BackSide(System.Drawing.Color aColor) {
			this.backColor = aColor;
		}

		public override string ToString() {			
			return string.Format("{0} back", backColor.Name);
		}

		public override void Assign(AbstractSide source) {
			if (source is BackSide) {
				this.backColor = ((BackSide) source).backColor;
			}
		}

		public override Gdk.Pixbuf GetPixbuf () {
			return GetPixbufFromResource(string.Format("CardLib.CardImages.Back{0}.png", backColor.Name));
		}
		
		public override Gtk.Image GetImage () {
			return GetImageFromResource(string.Format("CardLib.CardImages.Back{0}.png", backColor.Name));
		}
	}
	
	
}
