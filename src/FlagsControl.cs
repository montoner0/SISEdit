using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace sisedit
{
    public partial class FlagsControl : UserControl
    {
        private bool _cancelled;
        private uint _flags;
        private readonly uint _oldFlags;

        public FlagsControl(uint fl)
        {
            InitializeComponent();

            //Trace.WriteLine("Flags init");
            _flags = fl;
            _oldFlags = _flags;
            Trace.WriteLine($"Flags init {_oldFlags} {_flags}");
            _cancelled = true;
            //int i = 0;
            SetChecks();
        }

        public uint Flags
        {
            get {
                _flags = 0;

                foreach (int idx in checkedListBox1.CheckedIndices) {
                    _flags |= 1u << idx;
                }

                return _flags;
            }
            set {
                _flags = value;
                SetChecks();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Trace.WriteLine("OK pressed");
            _cancelled = false;
            ((IWindowsFormsEditorService)Tag).CloseDropDown();
        }

        private void FlagsControl_Leave(object sender, EventArgs e)
        {
            Trace.WriteLine("Focus leave");
            if (_cancelled) {
                _flags = _oldFlags;
                SetChecks();
            }
        }

        private void SetChecks()
        {
            for (var i = 0; i < checkedListBox1.Items.Count; i++) {
                checkedListBox1.SetItemChecked(i, (_flags & (1u << i)) != 0);
                //i++;
            }
        }
    }
}
