// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace CardLib {
    
    
    public partial class CardRow {
        
        private Gtk.EventBox eventbox1;
        
        private Gtk.DrawingArea drawingarea1;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget CardLib.CardRow
            Stetic.BinContainer.Attach(this);
            this.HeightRequest = 108;
            this.Name = "CardLib.CardRow";
            // Container child CardLib.CardRow.Gtk.Container+ContainerChild
            this.eventbox1 = new Gtk.EventBox();
            this.eventbox1.Events = ((Gdk.EventMask)(4));
            this.eventbox1.Name = "eventbox1";
            this.eventbox1.BorderWidth = ((uint)(5));
            // Container child eventbox1.Gtk.Container+ContainerChild
            this.drawingarea1 = new Gtk.DrawingArea();
            this.drawingarea1.HeightRequest = 98;
            this.drawingarea1.Name = "drawingarea1";
            this.eventbox1.Add(this.drawingarea1);
            this.Add(this.eventbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Hide();
            this.eventbox1.MotionNotifyEvent += new Gtk.MotionNotifyEventHandler(this.OnEventbox1MotionNotifyEvent);
            this.eventbox1.LeaveNotifyEvent += new Gtk.LeaveNotifyEventHandler(this.OnEventbox1LeaveNotifyEvent);
            this.eventbox1.ButtonPressEvent += new Gtk.ButtonPressEventHandler(this.OnEventbox1ButtonPressEvent);
            this.drawingarea1.ExposeEvent += new Gtk.ExposeEventHandler(this.OnDrawingarea1ExposeEvent);
        }
    }
}
