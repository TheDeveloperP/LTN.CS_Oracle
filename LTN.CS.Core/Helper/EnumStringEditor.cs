using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Linq;

namespace LTN.CS.Core.Helper
{
    /// <summary>
    /// 自定义控件属性编辑器，
    /// 例如可以将枚举类型提供给Text属性来选择
    /// </summary>
    public class EnumStringEditor : UITypeEditor
    {
        private IList _dataList;
        private readonly ListBox _listBox;

        private Boolean _escKeyPressed;
        private IWindowsFormsEditorService _editorService;

        public EnumStringEditor()
        {
            _listBox = new ListBox();
            _listBox.BorderStyle = BorderStyle.None;

            // Events
            _listBox.Click += new EventHandler((o, e) =>
            {
                if (_editorService != null) _editorService.CloseDropDown();
            });

            _listBox.PreviewKeyDown += new PreviewKeyDownEventHandler((o, e) =>
            {
                if (e.KeyCode == Keys.Escape) _escKeyPressed = true;
            });
        }
        protected IList DataList
        {
            get { return (_dataList); }
            set { _dataList = value; }
        }

        private void PopulateListBox(ITypeDescriptorContext context, Object currentValue)
        {
            _listBox.Items.Clear();
            if (_dataList == null) RetrieveDataList(context);

            if (_dataList != null)
            {
                foreach (object obj in _dataList)
                {
                    _listBox.Items.Add(obj.ToString());
                }
                if (currentValue != null)
                    _listBox.SelectedItem = currentValue;
            }

            _listBox.Height = _listBox.PreferredHeight;
        }
        protected virtual void RetrieveDataList(ITypeDescriptorContext context)
        {
            AssociationTypeAttribute _listAttribute = null;
            // Find the Attribute that has the path to the Enumerations list
            foreach (Attribute attribute in context.PropertyDescriptor.Attributes)
            {
                if (attribute is AssociationTypeAttribute)
                {
                    _listAttribute = attribute as AssociationTypeAttribute;
                    break;
                }
            }

            // If we found the Attribute, find the Data List
            if (_listAttribute != null && _listAttribute.AssociationType.IsEnum)
            {
                _dataList = Enum.GetValues(_listAttribute.AssociationType);
            }
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if ((context != null) && (provider != null))
            {
                _editorService = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;

                if (_editorService != null)
                {
                    _escKeyPressed = false;
                    PopulateListBox(context, value);
                    _editorService.DropDownControl(_listBox);

                    if (!_escKeyPressed)
                    {
                        object obj = this._listBox.SelectedItem;
                        if (obj != null) return obj;
                    }
                }
            }

            return (value);
        }
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return (UITypeEditorEditStyle.DropDown);
        }

    }

    /// <summary>
    /// 关联类型属性标签
    /// </summary>
    public class AssociationTypeAttribute : Attribute
    {
        private readonly Type m_Type;
        public AssociationTypeAttribute(Type p_type)
        {
            m_Type = p_type; 
        }

        public Type AssociationType
        {
            get { return m_Type; }
        }
    }
}