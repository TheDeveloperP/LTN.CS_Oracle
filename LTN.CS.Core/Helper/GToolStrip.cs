using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using DevExpress.Utils.Design;
using DevExpress.Utils;
using System.Reflection;
using System.Windows.Forms.Design;
using DevExpress.XtraEditors;

namespace LTN.CS.Core.Helper
{
    #region GToolStrip

    /// <summary>
    /// 扩展ToolStrip，支援Images
    /// </summary>
    [ToolboxBitmap(typeof(ToolStrip))]
    public class GToolStrip : ToolStrip
    {
        public GToolStrip()
        {
            this.Renderer = new GToolStripRender();
            this.GripStyle = ToolStripGripStyle.Hidden;
            //this.Font = new Font("Tahoma", 13, FontStyle.Bold);
            this.Font = new Font("Tahoma", 10);
            this.AutoSize = false;
            this.Height = 20;

        }

        object images;
        [Browsable(true)]
        [DefaultValue(null)]
        [TypeConverter(typeof(ImageCollectionImagesConverter))]
        public object Images
        {
            get
            {
                return images;
            }
            set
            {
                images = value;
                //if (value is ImageCollection)
                //{
                //    var imglst = new ImageList(this.Container);
                //    imglst.Images.AddRange((value as ImageCollection).Images.ToArray());
                //    base.ImageList = imglst;
                //}
                //else
                //{
                //    base.ImageList = value as ImageList;
                //}
            }
        }

        //protected override void OnResize(EventArgs e)
        //{
        //    this.Height = 28;
        //    this.Refresh();
        //}
    }

    #endregion

    #region GToolStripButton

    /// <summary>
    /// 扩展ToolStripButton，支援ImageIndex
    /// </summary>
    [ToolboxBitmap(typeof(ToolStripButton))]
    public class GToolStripButton : ToolStripButton
    {
        int imageidex = -1;

        [Browsable(false)]
        public object Images
        {
            get
            {
                if (this.Owner != null)
                {
                    return (this.Owner as GToolStrip).Images;
                }
                return null;
            }
        }

        [Browsable(true)]
        [DefaultValue(-1)]
        [DevExpress.Utils.ImageList("Images")]
        [Editor(typeof(ImageIndexesEditor), typeof(UITypeEditor))]
        public new int ImageIndex
        {
            get { return imageidex; }
            set
            {
                imageidex = value;

                if (Images is ImageCollection)
                {
                    var img = Images as ImageCollection;
                    base.Image = value < 0 ? null : img.Images[value];
                }
                else if (Images is ImageList)
                {
                    var img = Images as ImageList;
                    base.Image = value < 0 ? null : img.Images[value];
                }
            }
        }

        [DefaultValue("")]
        [AssociationType(typeof(EnumButtonText))]
        [Editor(typeof(EnumStringEditor), typeof(UITypeEditor))]
        public new string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                if (!Text.ToLower().Contains("toolstrip"))
                    DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.Text.ToLower().StartsWith("gtoolstripbutton"))
            {
                this.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            }
        }

    }

    #endregion

    #region 扩展ToolStrip控件（ToolStripControlHost）

    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip)]
    public abstract class GToolStripBaseEdit<E> : ToolStripControlHost where E : System.Windows.Forms.Control
    {
        public GToolStripBaseEdit()
            : base(Activator.CreateInstance<E>())
        {
        }

        public E InnerEditor
        {
            get { return base.Control as E; }
        }
    }

    [ToolboxBitmap(typeof(TextEdit))]
    public class GToolStripTextEdit : GToolStripBaseEdit<TextEdit>
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.Text.ToLower().StartsWith("gtoolstriptextedit"))
            {
                this.InnerEditor.Text = string.Empty;
            }
        }
    }

    [ToolboxBitmap(typeof(DateEdit))]
    public class GToolStripDateTime : GToolStripBaseEdit<DateEdit>
    {
    }

    [ToolboxBitmap(typeof(CheckEdit))]
    public class GToolStripCheckEdit : GToolStripBaseEdit<CheckEdit>
    {
    }

    [ToolboxBitmap(typeof(ImageComboBoxEdit))]
    public class GToolStripImageComboBoxEdit : GToolStripBaseEdit<ImageComboBoxEdit>
    {
    }

    #endregion

    #region GButtonType

    /// <summary>
    /// 按钮文本集合
    /// </summary>
    public enum EnumButtonText
    {
        查询, 添加, 创建, 删除, 保存, 刷新, 提交, 计算, 复制,
        导出, 返回, 帮助, 提示, 设置, 警告, 取消, 全选, 反选, 验证, 审核, 反审
    }

    #endregion

}
