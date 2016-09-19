using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DgvFilterPopup;

namespace Charts
{
    public partial class frmSelectChannel : Form
    {

        public string channelSeleted="none";
        public string dataTypeSeleted = "none";
        public frmSelectChannel()
        {
            InitializeComponent();
        }

        private void frmSelectChannel_Load(object sender, EventArgs e)
        {
            DgvFilterManager fm = new DgvFilterManager(this.dgvChannels, false);

            fm.HeaderBackcolor = Color.DarkRed;
            fm.HeaderFontcolor = Color.White;

            fm["colChannel"] = new DgvTextBoxColumnFilter();
            fm["colDataType"] = new DgvTextBoxColumnFilter();
        }

        private void dgvChannels_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvChannels.Columns[e.ColumnIndex].Name == "colBtn" && e.RowIndex >= 0)
            {
                this.channelSeleted = dgvChannels.Rows[e.RowIndex].Cells["colChannel"].Value.ToString();
                this.dataTypeSeleted = dgvChannels.Rows[e.RowIndex].Cells["colDataType"].Value.ToString();
                this.Close();
            }
        }
    }
}
