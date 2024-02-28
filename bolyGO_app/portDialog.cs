using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bolyGO_app {
	public partial class portDialog : Form {
		public portDialog() {
			InitializeComponent();
		}

		private void label2_Click(object sender, EventArgs e) {

		}

		private void btnOK_Click(object sender, EventArgs e) {
			nudPort.Value = decimal.Round(nudPort.Value, 0);
		}
	}
}
