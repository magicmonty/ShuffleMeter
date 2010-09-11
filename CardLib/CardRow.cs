using System;
using CardLib;
using CardLib.Cards;
using Gtk;
using Gdk;

namespace CardLib {
	[System.ComponentModel.ToolboxItem(true)]
	public partial class CardRow : Gtk.Bin {
		private CardDeck Deck;
		private int Quarter;

		public void SetDeck(CardDeck Deck) {
			this.Deck.assign(Deck);
		}

		public void SetQuarter(int Quarter) {
			this.Quarter = Quarter;
			if (this.Quarter < 0) {
				this.Quarter = 0;
			} else if (this.Quarter > 3) {
				this.Quarter = 3;
			}
		}

		public CardRow() {
			this.Deck = new CardDeck();
			this.Quarter = 0;
			this.Build();
		}

		protected virtual void OnDrawingarea1ExposeEvent(object o, Gtk.ExposeEventArgs args) {
			if (this.Deck != null) {
				Gdk.Window win = args.Event.Window;
				Gdk.GC gc = Style.BaseGC(StateType.Normal);
				
				int startIndex = this.Quarter * 13;
				for (int i = 0; i < 13; i++) {
					AbstractCard card = this.Deck.getCardAt(i + startIndex);
					
					if (card != null) {
						win.DrawPixbuf(gc, card.GetPixbuf(), 0, 0, i * 35, 0, 71, 98, Gdk.RgbDither.Normal, 0, 0);
					}
				}
				
				args.RetVal = true;
			}
		}
		
		protected virtual void OnEventbox1MotionNotifyEvent (object o, Gtk.MotionNotifyEventArgs args)
		{
			int index = GetCardIndexByMousePosition(args.Event.X, args.Event.Y);
			for (int i = 0; i < this.Deck.Count; i++) {				
				this.Deck.getCardAt(i).hover = (index == i);
			}
			this.QueueDraw();
		}
		
		private int GetCardIndexByMousePosition(double X, double Y) {
			if ((Y >= 0) 
			    && (Y <= this.SizeRequest().Height) 
			    && (X >= 0) 
			    && (X <= this.SizeRequest().Width)) {
				int result = (int) X / 35;
			
				if (result > 12) {
					result = 12;
				}
				
				return 13 * this.Quarter + result;
			}
				
			return -1;
			
		}
		
		protected virtual void OnEventbox1LeaveNotifyEvent (object o, Gtk.LeaveNotifyEventArgs args)
		{
			for (int i = 0; i < this.Deck.Count; i++) {				
				this.Deck.getCardAt(i).hover = false;
			}
			this.QueueDraw();
		}
		
		
		
	}
}
