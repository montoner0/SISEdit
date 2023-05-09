using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace sisedit
{
    public class FlagsDropDownEditor : UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if ((context != null) && (provider != null)) {
                // Access the Property Browser's UI display service
                var svc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

                if (svc != null) {
                    var flctrl = new FlagsControl(Convert.ToUInt32(value));
                    //ipTextBox.Text = value.ToString();
                    flctrl.Tag = svc;

                    svc.DropDownControl(flctrl);

                    value = Convert.ToInt32(flctrl.Flags);
                }
            }

            return base.EditValue(context, provider, value);
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
            => context == null ? base.GetEditStyle(context) : UITypeEditorEditStyle.DropDown;
    }
}
