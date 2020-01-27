using System.Collections.Generic;
using System.Windows.Forms;
using KeePass.UI;

namespace KeePass.Forms {
    public partial class StartForm : UserControl {
        private MruList _mruList;

        public StartForm() {
            InitializeComponent();
            VisibleChanged += StartForm_VisibleChanged;
        }

        public void Init(MruList mruList) {
            _mruList = mruList;
        }

        private void StartForm_VisibleChanged(object sender, System.EventArgs e) {
            if (_mruList == null) return;
            if (!Visible) return;

            m_flow.Controls.Clear();
            var listViewItems = new List<Button>();
            foreach(var item in _mruList.Items) {
                listViewItems.Add(new Button() {
                    Text = item.Key,
                    AutoSize = true
                });               
            }

            m_flow.Controls.AddRange(listViewItems.ToArray());
        }
    }
}
