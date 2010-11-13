
using System;
using System.Drawing;
using Gtk;
using Gdk;

namespace ShuffleMeter {


  public class ColorMenuItem: Gtk.ImageMenuItem {

    public int markIndex {
      get;
      set;
    }

    public System.Drawing.Color color {
      get;
      set;
    }

    public ColorMenuItem(int markIndex, System.Drawing.Color color): base(color.Name) {
      this.markIndex = markIndex;
      this.color = color;

      int fillColor = (color.R << 24) + (color.G << 16) + (color.B << 8) + 255;
      Pixbuf pixbuf = new Pixbuf(Colorspace.Rgb, false, 24, 120, 120);
      pixbuf.Fill((uint) fillColor);
      Gtk.Image markImage = new Gtk.Image(pixbuf);
      this.Image = markImage;
    }
  }
}
