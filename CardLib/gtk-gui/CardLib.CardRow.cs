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
        
        private Gtk.DrawingArea drawingarea1;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget CardLib.CardRow
            Stetic.BinContainer.Attach(this);
            this.WidthRequest = 491;
            this.HeightRequest = 98;
            this.Name = "CardLib.CardRow";
            // Container child CardLib.CardRow.Gtk.Container+ContainerChild
            this.drawingarea1 = new Gtk.DrawingArea();
            this.drawingarea1.Name = "drawingarea1";
            this.Add(this.drawingarea1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Hide();
            this.drawingarea1.ExposeEvent += new Gtk.ExposeEventHandler(this.OnDrawingarea1ExposeEvent);
        }
    }
}