using DevExpress.XtraTab;
namespace LTN.CS.Base
{
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup1 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup2 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup3 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            this.mainRibbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barAndDockingController = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.biAbout = new DevExpress.XtraBars.BarButtonItem();
            this.bsSkins = new DevExpress.XtraBars.BarSubItem();
            this.biExit = new DevExpress.XtraBars.BarButtonItem();
            this.skinGalleryBarItem = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.print = new DevExpress.XtraBars.BarButtonItem();
            this.export = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonGroupLeft = new DevExpress.XtraBars.BarButtonGroup();
            this.barStaticItemleft = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonGroupRight = new DevExpress.XtraBars.BarButtonGroup();
            this.barStaticItemRight = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemCenter = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.defaultToolTipController1 = new DevExpress.Utils.DefaultToolTipController(this.components);
            this.ribbonMiniToolbar1 = new DevExpress.XtraBars.Ribbon.RibbonMiniToolbar(this.components);
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.popupMenu2 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).BeginInit();
            this.SuspendLayout();
            // 
            // mainRibbon
            // 
            this.mainRibbon.ApplicationButtonDropDownControl = this.applicationMenu1;
            resources.ApplyResources(this.mainRibbon, "mainRibbon");
            this.mainRibbon.Controller = this.barAndDockingController;
            this.mainRibbon.ExpandCollapseItem.Id = 0;
            this.mainRibbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mainRibbon.ExpandCollapseItem,
            this.biAbout,
            this.bsSkins,
            this.biExit,
            this.skinGalleryBarItem,
            this.print,
            this.export,
            this.barButtonGroupLeft,
            this.barStaticItemleft,
            this.barButtonGroupRight,
            this.barStaticItemRight,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barStaticItemCenter});
            this.mainRibbon.MaxItemId = 62;
            this.mainRibbon.Name = "mainRibbon";
            this.mainRibbon.PageCategoryAlignment = DevExpress.XtraBars.Ribbon.RibbonPageCategoryAlignment.Right;
            this.mainRibbon.PageHeaderItemLinks.Add(this.biAbout);
            this.mainRibbon.QuickToolbarItemLinks.Add(this.print, "答应");
            this.mainRibbon.QuickToolbarItemLinks.Add(this.export, "导出");
            this.mainRibbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.mainRibbon.StatusBar = this.ribbonStatusBar1;
            this.mainRibbon.TransparentEditors = true;
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.ItemLinks.Add(this.barButtonItem2, true);
            this.applicationMenu1.ItemLinks.Add(this.barButtonItem1);
            this.applicationMenu1.ItemLinks.Add(this.barButtonItem3);
            this.applicationMenu1.ItemLinks.Add(this.barButtonItem4);
            this.applicationMenu1.Name = "applicationMenu1";
            this.applicationMenu1.Ribbon = this.mainRibbon;
            // 
            // barButtonItem2
            // 
            resources.ApplyResources(this.barButtonItem2, "barButtonItem2");
            this.barButtonItem2.Id = 51;
            this.barButtonItem2.ImageOptions.Image = global::LTN.CS.Base.Properties.Resources.Lock_32;
            this.barButtonItem2.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F1));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem1
            // 
            resources.ApplyResources(this.barButtonItem1, "barButtonItem1");
            this.barButtonItem1.Id = 49;
            this.barButtonItem1.ImageOptions.Image = global::LTN.CS.Base.Properties.Resources.exit_32;
            this.barButtonItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem3
            // 
            resources.ApplyResources(this.barButtonItem3, "barButtonItem3");
            this.barButtonItem3.Id = 52;
            this.barButtonItem3.ImageOptions.Image = global::LTN.CS.Base.Properties.Resources.Refresh;
            this.barButtonItem3.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F5));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barButtonItem4
            // 
            resources.ApplyResources(this.barButtonItem4, "barButtonItem4");
            this.barButtonItem4.Id = 53;
            this.barButtonItem4.ImageOptions.Image = global::LTN.CS.Base.Properties.Resources.ChangePassword_32;
            this.barButtonItem4.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F6));
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // barAndDockingController
            // 
            this.barAndDockingController.PropertiesBar.DefaultGlyphSize = new System.Drawing.Size(16, 16);
            this.barAndDockingController.PropertiesBar.DefaultLargeGlyphSize = new System.Drawing.Size(32, 32);
            // 
            // biAbout
            // 
            resources.ApplyResources(this.biAbout, "biAbout");
            this.biAbout.Id = 6;
            this.biAbout.ImageOptions.Image = global::LTN.CS.Base.Properties.Resources.Help_16x16;
            this.biAbout.ImageOptions.LargeImage = global::LTN.CS.Base.Properties.Resources.Help_32x32;
            this.biAbout.Name = "biAbout";
            this.biAbout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OnAboutItemClick);
            // 
            // bsSkins
            // 
            resources.ApplyResources(this.bsSkins, "bsSkins");
            this.bsSkins.Id = 7;
            this.bsSkins.Name = "bsSkins";
            // 
            // biExit
            // 
            resources.ApplyResources(this.biExit, "biExit");
            this.biExit.Id = 12;
            this.biExit.Name = "biExit";
            // 
            // skinGalleryBarItem
            // 
            // 
            // 
            // 
            this.skinGalleryBarItem.Gallery.AllowHoverImages = true;
            this.skinGalleryBarItem.Gallery.FixedHoverImageSize = false;
            galleryItemGroup2.Visible = false;
            galleryItemGroup3.Visible = false;
            this.skinGalleryBarItem.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            galleryItemGroup1,
            galleryItemGroup2,
            galleryItemGroup3});
            this.skinGalleryBarItem.Gallery.ImageSize = new System.Drawing.Size(58, 43);
            this.skinGalleryBarItem.Gallery.ItemCheckMode = DevExpress.XtraBars.Ribbon.Gallery.ItemCheckMode.SingleRadio;
            this.skinGalleryBarItem.Id = 1;
            this.skinGalleryBarItem.Name = "skinGalleryBarItem";
            // 
            // print
            // 
            this.print.Id = 43;
            this.print.ImageOptions.Image = global::LTN.CS.Base.Properties.Resources.Print_24;
            this.print.ImageOptions.LargeImage = global::LTN.CS.Base.Properties.Resources.BtnPrint;
            this.print.Name = "print";
            resources.ApplyResources(this.print, "print");
            this.print.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.print_ItemClick);
            // 
            // export
            // 
            this.export.Id = 44;
            this.export.ImageOptions.Image = global::LTN.CS.Base.Properties.Resources.Export_24;
            this.export.Name = "export";
            resources.ApplyResources(this.export, "export");
            this.export.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.export_ItemClick);
            // 
            // barButtonGroupLeft
            // 
            resources.ApplyResources(this.barButtonGroupLeft, "barButtonGroupLeft");
            this.barButtonGroupLeft.Id = 45;
            this.barButtonGroupLeft.ItemLinks.Add(this.barStaticItemleft);
            this.barButtonGroupLeft.Name = "barButtonGroupLeft";
            // 
            // barStaticItemleft
            // 
            resources.ApplyResources(this.barStaticItemleft, "barStaticItemleft");
            this.barStaticItemleft.Id = 46;
            this.barStaticItemleft.Name = "barStaticItemleft";
            this.barStaticItemleft.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonGroupRight
            // 
            this.barButtonGroupRight.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            resources.ApplyResources(this.barButtonGroupRight, "barButtonGroupRight");
            this.barButtonGroupRight.Id = 47;
            this.barButtonGroupRight.ItemLinks.Add(this.barStaticItemRight);
            this.barButtonGroupRight.Name = "barButtonGroupRight";
            // 
            // barStaticItemRight
            // 
            resources.ApplyResources(this.barStaticItemRight, "barStaticItemRight");
            this.barStaticItemRight.Id = 48;
            this.barStaticItemRight.Name = "barStaticItemRight";
            this.barStaticItemRight.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItemCenter
            // 
            resources.ApplyResources(this.barStaticItemCenter, "barStaticItemCenter");
            this.barStaticItemCenter.Id = 60;
            this.barStaticItemCenter.Name = "barStaticItemCenter";
            this.barStaticItemCenter.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.barButtonGroupLeft);
            this.ribbonStatusBar1.ItemLinks.Add(this.barButtonGroupRight);
            resources.ApplyResources(this.ribbonStatusBar1, "ribbonStatusBar1");
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.mainRibbon;
            // 
            // ribbonMiniToolbar1
            // 
            this.ribbonMiniToolbar1.Alignment = System.Drawing.ContentAlignment.TopRight;
            this.ribbonMiniToolbar1.ParentControl = this;
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.AllowDragDrop = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPagesAndTabControlHeader;
            this.xtraTabbedMdiManager1.CloseTabOnMiddleClick = DevExpress.XtraTabbedMdi.CloseTabOnMiddleClick.OnMouseDown;
            this.xtraTabbedMdiManager1.Controller = this.barAndDockingController;
            this.xtraTabbedMdiManager1.FloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabbedMdiManager1.FloatOnDrag = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabbedMdiManager1.FloatPageDragMode = DevExpress.XtraTabbedMdi.FloatPageDragMode.Preview;
            this.xtraTabbedMdiManager1.HeaderButtonsShowMode = DevExpress.XtraTab.TabButtonShowMode.Always;
            this.xtraTabbedMdiManager1.MdiParent = this;
            this.xtraTabbedMdiManager1.ToolTipController = this.defaultToolTipController1.DefaultController;
            this.xtraTabbedMdiManager1.SelectedPageChanged += new System.EventHandler(this.xtraTabbedMdiManager1_SelectedPageChanged);
            this.xtraTabbedMdiManager1.BeginFloating += new DevExpress.XtraTabbedMdi.FloatingCancelEventHandler(this.xtraTabbedMdiManager1_BeginFloating);
            // 
            // popupMenu1
            // 
            this.popupMenu1.Name = "popupMenu1";
            this.popupMenu1.Ribbon = this.mainRibbon;
            // 
            // popupMenu2
            // 
            this.popupMenu2.Name = "popupMenu2";
            this.popupMenu2.Ribbon = this.mainRibbon;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("$this.AllowHtmlText"))));
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.mainRibbon);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Ribbon = this.mainRibbon;
            this.StatusBar = this.ribbonStatusBar1;
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem biAbout;
        private DevExpress.XtraBars.BarSubItem bsSkins;
        private DevExpress.XtraBars.BarButtonItem biExit;
        private DevExpress.Utils.DefaultToolTipController defaultToolTipController1;
        private DevExpress.XtraBars.Ribbon.RibbonControl mainRibbon;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
        private DevExpress.XtraBars.RibbonGalleryBarItem skinGalleryBarItem;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController;
        private DevExpress.XtraBars.Ribbon.RibbonMiniToolbar ribbonMiniToolbar1;
        private DevExpress.XtraBars.BarButtonItem print;
        private DevExpress.XtraBars.BarButtonItem export;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarButtonGroup barButtonGroupLeft;
        private DevExpress.XtraBars.BarStaticItem barStaticItemleft;
        private DevExpress.XtraBars.BarButtonGroup barButtonGroupRight;
        private DevExpress.XtraBars.BarStaticItem barStaticItemRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.PopupMenu popupMenu2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarStaticItem barStaticItemCenter;
        private System.Windows.Forms.Timer timer1;
    }
}
