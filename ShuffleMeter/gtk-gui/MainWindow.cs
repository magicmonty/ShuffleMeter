// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------



public partial class MainWindow {
    
    private Gtk.UIManager UIManager;
    
    private Gtk.Action DateiAction;
    
    private Gtk.Action ExitAction;
    
    private Gtk.Action ShuffleAction;
    
    private Gtk.Action RegularShuffleAction;
    
    private Gtk.Action InFaroAction;
    
    private Gtk.Action OutFaroAction;
    
    private Gtk.Action AntiInFaroAction;
    
    private Gtk.Action AntiOutFaroAction;
    
    private Gtk.Action NewDeckOrderAction;
    
    private Gtk.VBox vbox1;
    
    private Gtk.MenuBar menubar1;
    
    private CardLib.CardRow cardrow1;
    
    private CardLib.CardRow cardrow2;
    
    private CardLib.CardRow cardrow3;
    
    private CardLib.CardRow cardrow4;
    
    private Gtk.Statusbar statusbar1;
    
    protected virtual void Build() {
        Stetic.Gui.Initialize(this);
        // Widget MainWindow
        this.UIManager = new Gtk.UIManager();
        Gtk.ActionGroup w1 = new Gtk.ActionGroup("Default");
        this.DateiAction = new Gtk.Action("DateiAction", Mono.Unix.Catalog.GetString("Datei"), null, null);
        this.DateiAction.ShortLabel = Mono.Unix.Catalog.GetString("Datei");
        w1.Add(this.DateiAction, null);
        this.ExitAction = new Gtk.Action("ExitAction", Mono.Unix.Catalog.GetString("Exit"), null, null);
        this.ExitAction.ShortLabel = Mono.Unix.Catalog.GetString("Exit");
        w1.Add(this.ExitAction, null);
        this.ShuffleAction = new Gtk.Action("ShuffleAction", Mono.Unix.Catalog.GetString("Shuffle"), null, null);
        this.ShuffleAction.ShortLabel = Mono.Unix.Catalog.GetString("Shuffle");
        w1.Add(this.ShuffleAction, null);
        this.RegularShuffleAction = new Gtk.Action("RegularShuffleAction", Mono.Unix.Catalog.GetString("Regular Shuffle"), null, null);
        this.RegularShuffleAction.ShortLabel = Mono.Unix.Catalog.GetString("Regular Shuffle");
        w1.Add(this.RegularShuffleAction, null);
        this.InFaroAction = new Gtk.Action("InFaroAction", Mono.Unix.Catalog.GetString("In Faro"), null, null);
        this.InFaroAction.ShortLabel = Mono.Unix.Catalog.GetString("In Faro");
        w1.Add(this.InFaroAction, null);
        this.OutFaroAction = new Gtk.Action("OutFaroAction", Mono.Unix.Catalog.GetString("Out Faro"), null, null);
        this.OutFaroAction.ShortLabel = Mono.Unix.Catalog.GetString("Out Faro");
        w1.Add(this.OutFaroAction, null);
        this.AntiInFaroAction = new Gtk.Action("AntiInFaroAction", Mono.Unix.Catalog.GetString("Anti In Faro"), null, null);
        this.AntiInFaroAction.ShortLabel = Mono.Unix.Catalog.GetString("Anti In Faro");
        w1.Add(this.AntiInFaroAction, null);
        this.AntiOutFaroAction = new Gtk.Action("AntiOutFaroAction", Mono.Unix.Catalog.GetString("Anti Out Faro"), null, null);
        this.AntiOutFaroAction.ShortLabel = Mono.Unix.Catalog.GetString("Anti Out Faro");
        w1.Add(this.AntiOutFaroAction, null);
        this.NewDeckOrderAction = new Gtk.Action("NewDeckOrderAction", Mono.Unix.Catalog.GetString("New Deck Order"), null, null);
        this.NewDeckOrderAction.ShortLabel = Mono.Unix.Catalog.GetString("New Deck Order");
        w1.Add(this.NewDeckOrderAction, null);
        this.UIManager.InsertActionGroup(w1, 0);
        this.AddAccelGroup(this.UIManager.AccelGroup);
        this.Name = "MainWindow";
        this.Title = Mono.Unix.Catalog.GetString("MainWindow");
        this.WindowPosition = ((Gtk.WindowPosition)(4));
        // Container child MainWindow.Gtk.Container+ContainerChild
        this.vbox1 = new Gtk.VBox();
        this.vbox1.Name = "vbox1";
        this.vbox1.Spacing = 3;
        // Container child vbox1.Gtk.Box+BoxChild
        this.UIManager.AddUiFromString("<ui><menubar name='menubar1'><menu name='DateiAction' action='DateiAction'><menuitem name='ExitAction' action='ExitAction'/></menu><menu name='ShuffleAction' action='ShuffleAction'><menuitem name='RegularShuffleAction' action='RegularShuffleAction'/><menuitem name='InFaroAction' action='InFaroAction'/><menuitem name='AntiInFaroAction' action='AntiInFaroAction'/><menuitem name='OutFaroAction' action='OutFaroAction'/><menuitem name='AntiOutFaroAction' action='AntiOutFaroAction'/><menuitem name='NewDeckOrderAction' action='NewDeckOrderAction'/></menu></menubar></ui>");
        this.menubar1 = ((Gtk.MenuBar)(this.UIManager.GetWidget("/menubar1")));
        this.menubar1.Name = "menubar1";
        this.vbox1.Add(this.menubar1);
        Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox1[this.menubar1]));
        w2.Position = 0;
        w2.Expand = false;
        w2.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.cardrow1 = new CardLib.CardRow();
        this.cardrow1.HeightRequest = 108;
        this.cardrow1.Events = ((Gdk.EventMask)(256));
        this.cardrow1.Name = "cardrow1";
        this.vbox1.Add(this.cardrow1);
        Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox1[this.cardrow1]));
        w3.Position = 1;
        w3.Expand = false;
        w3.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.cardrow2 = new CardLib.CardRow();
        this.cardrow2.HeightRequest = 108;
        this.cardrow2.Events = ((Gdk.EventMask)(256));
        this.cardrow2.Name = "cardrow2";
        this.vbox1.Add(this.cardrow2);
        Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.vbox1[this.cardrow2]));
        w4.Position = 2;
        w4.Expand = false;
        w4.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.cardrow3 = new CardLib.CardRow();
        this.cardrow3.HeightRequest = 108;
        this.cardrow3.Events = ((Gdk.EventMask)(256));
        this.cardrow3.Name = "cardrow3";
        this.vbox1.Add(this.cardrow3);
        Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.vbox1[this.cardrow3]));
        w5.Position = 3;
        w5.Expand = false;
        w5.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.cardrow4 = new CardLib.CardRow();
        this.cardrow4.HeightRequest = 108;
        this.cardrow4.Events = ((Gdk.EventMask)(256));
        this.cardrow4.Name = "cardrow4";
        this.vbox1.Add(this.cardrow4);
        Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.vbox1[this.cardrow4]));
        w6.Position = 4;
        w6.Expand = false;
        w6.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.statusbar1 = new Gtk.Statusbar();
        this.statusbar1.Name = "statusbar1";
        this.statusbar1.Spacing = 6;
        this.vbox1.Add(this.statusbar1);
        Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.vbox1[this.statusbar1]));
        w7.PackType = ((Gtk.PackType)(1));
        w7.Position = 5;
        w7.Expand = false;
        w7.Fill = false;
        this.Add(this.vbox1);
        if ((this.Child != null)) {
            this.Child.ShowAll();
        }
        this.DefaultWidth = 628;
        this.DefaultHeight = 525;
        this.Show();
        this.DeleteEvent += new Gtk.DeleteEventHandler(this.OnDeleteEvent);
        this.RegularShuffleAction.Activated += new System.EventHandler(this.OnRegularShuffleActionActivated);
        this.InFaroAction.Activated += new System.EventHandler(this.OnInFaroActionActivated);
        this.OutFaroAction.Activated += new System.EventHandler(this.OnOutFaroActionActivated);
        this.AntiInFaroAction.Activated += new System.EventHandler(this.OnAntiInFaroActionActivated);
        this.AntiOutFaroAction.Activated += new System.EventHandler(this.OnAntiOutFaroActionActivated);
        this.NewDeckOrderAction.Activated += new System.EventHandler(this.OnNewDeckOrderActionActivated);
        this.cardrow1.OnCardClicked += new CardLib.CardClickedEventHandler(this.OnCardrowCardClicked);
        this.cardrow1.OnCardContextMenu += new CardLib.CardClickedEventHandler(this.OnCardrowContextMenu);
        this.cardrow2.OnCardClicked += new CardLib.CardClickedEventHandler(this.OnCardrowCardClicked);
        this.cardrow2.OnCardContextMenu += new CardLib.CardClickedEventHandler(this.OnCardrowContextMenu);
        this.cardrow3.OnCardClicked += new CardLib.CardClickedEventHandler(this.OnCardrowCardClicked);
        this.cardrow3.OnCardContextMenu += new CardLib.CardClickedEventHandler(this.OnCardrowContextMenu);
        this.cardrow4.OnCardClicked += new CardLib.CardClickedEventHandler(this.OnCardrowCardClicked);
        this.cardrow4.OnCardContextMenu += new CardLib.CardClickedEventHandler(this.OnCardrowContextMenu);
    }
}
