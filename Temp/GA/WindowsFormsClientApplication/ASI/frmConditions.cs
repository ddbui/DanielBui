using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Charts;

namespace WindowsFormsClientApplication
{
    public partial class frmConditions : Form
    {
        private clsDB DB = new clsDB();
        public DataTable dtRootChannels = new DataTable();
        public List<clsFilter> ListFilter = new List<clsFilter>();
        private DataTable dtOper = new DataTable();
        private DataTable dtLogic = new DataTable();


        public frmConditions()
        {
            InitializeComponent();
        }

        private void frmConditions_Load(object sender, EventArgs e)
        {
            MakeOperLogicDataTables();

            this.dgvConditions.AutoGenerateColumns = false;
            DB.connStr = Properties.Settings.Default["DBConnectionString"].ToString();
            string sql = "Select * FROM _Filter_Template ORDER by id";
            DataTable dtConditions = DB.GetTable(sql);
            this.dgvConditions.DataSource = dtConditions;

            foreach (DataGridViewRow dgvr in this.dgvConditions.Rows)
            {
                dgvr.Cells["col_Channels"].Value = "Up_Sawtooth";

                DataGridViewComboBoxCell dgvcmb1 = (DataGridViewComboBoxCell)dgvr.Cells["col_operator"];
                dgvcmb1.DataSource = null;
                dgvcmb1.DisplayMember = "oper";
                dgvcmb1.ValueMember = "oper";
                dgvcmb1.DataSource = dtOper;
                dgvr.Cells["col_operator"].Value = dtOper.Rows[4]["oper"].ToString();

                DataGridViewComboBoxCell dgvcmb2 = (DataGridViewComboBoxCell)dgvr.Cells["col_logic"];
                dgvcmb2.DataSource = null;
                dgvcmb2.DisplayMember = "logic";
                dgvcmb2.ValueMember = "logic";
                dgvcmb2.DataSource = dtLogic;
                dgvr.Cells["col_logic"].Value = dtLogic.Rows[0]["logic"].ToString();

            }

            //specify existing Filter if Exists
            if (ListFilter.Count > 0)
            {
                IEnumerable<clsFilter> OrderedByColId = ListFilter.OrderBy(p => p.ColId);
                List<clsFilter> OrderedList = OrderedByColId.ToList();

                int ndx = 0;
                foreach (DataGridViewRow dgvr in this.dgvConditions.Rows)
                {
                    dgvr.Cells["colChkBox"].Value = OrderedList[ndx].UseIt;
                    dgvr.Cells["col_Channels"].Value = OrderedList[ndx].Channel;
                    dgvr.Cells["col_operator"].Value = OrderedList[ndx].Operator;
                    dgvr.Cells["col_limit"].Value = OrderedList[ndx].LimitValue;
                    dgvr.Cells["col_logic"].Value = OrderedList[ndx].Logic;
                    ndx++;
                }
            }


        }

        private void MakeOperLogicDataTables()
        {
            dtOper.Columns.Add("oper", typeof(String));
            dtLogic.Columns.Add("logic", typeof(String));

            DataRow d1 = dtOper.NewRow(); d1["oper"] = " = "; dtOper.Rows.Add(d1);
            DataRow d2 = dtOper.NewRow(); d2["oper"] = " != "; dtOper.Rows.Add(d2);
            DataRow d3 = dtOper.NewRow(); d3["oper"] = " < "; dtOper.Rows.Add(d3);
            DataRow d4 = dtOper.NewRow(); d4["oper"] = " <= "; dtOper.Rows.Add(d4);
            DataRow d5 = dtOper.NewRow(); d5["oper"] = " > "; dtOper.Rows.Add(d5);
            DataRow d6 = dtOper.NewRow(); d6["oper"] = " >= "; dtOper.Rows.Add(d6);

            DataRow d1a = dtLogic.NewRow(); d1a["logic"] = " AND "; dtLogic.Rows.Add(d1a);
            DataRow d2a = dtLogic.NewRow(); d2a["logic"] = " OR "; dtLogic.Rows.Add(d2a);


        }

        private void dgvConditions_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(LimitValue_KeyPress);
            if (dgvConditions.CurrentCell.ColumnIndex == 4) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(LimitValue_KeyPress);
                }
            }
        }

        private void LimitValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox1 = sender as TextBox;
            char ch = e.KeyChar;
            if (ch == 46 && textBox1.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            ListFilter.Clear();
            int ndx = 0;
            foreach (DataGridViewRow dgvr in this.dgvConditions.Rows)
            {
                clsFilter f = new clsFilter();
                f.UseIt = Convert.ToBoolean(dgvr.Cells["colChkBox"].Value);
                f.ColId = Convert.ToInt32(dgvr.Cells["col_id"].Value);
                f.Channel = dgvr.Cells["col_Channels"].Value.ToString();
                f.DataType = dgvr.Cells["colDataType"].Value.ToString();
                f.Operator = dgvr.Cells["col_operator"].Value.ToString();
                f.LimitValue = Convert.ToDouble(dgvr.Cells["col_limit"].Value);
                f.Logic = dgvr.Cells["col_logic"].Value.ToString();

                ListFilter.Add(f);
                ndx++;
            }

            this.Close();
        }


        private void MakeFilterString()
        {

            string filter = "WHERE ";
            foreach (DataGridViewRow row in this.dgvConditions.Rows)
            {
                DataGridViewCheckBoxCell cell = row.Cells["colChkBox"] as DataGridViewCheckBoxCell;

                string xx = cell.Value.ToString();
                string ff = cell.TrueValue.ToString();

                if (cell.Value.ToString() == cell.TrueValue.ToString())
                {
                    string channel = "[" + row.Cells["col_Channels"].Value.ToString() + "]";
                    string oper = row.Cells["col_operator"].Value.ToString();
                    string limit = row.Cells["col_limit"].Value.ToString();
                    string logic = row.Cells["col_logic"].Value.ToString();
                    filter = filter + channel + oper + limit + logic;
                }
            }

            if(filter.EndsWith(" AND ")) { filter = filter.Substring(0, filter.Length - 5);}
            if (filter.EndsWith(" OR ")) { filter = filter.Substring(0, filter.Length - 4); }
            lblFilter.Text = filter;

        }

        private void dgvConditions_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            MakeFilterString();
        }

        private void dgvConditions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dgvConditions_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            int RowIndex = dgvConditions.CurrentRow.Index;
            if (RowIndex < 0) { return; }
            if (this.dgvConditions.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                dgvConditions.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvConditions_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvConditions.Columns[e.ColumnIndex].Name == "col_Channels" && e.RowIndex >= 0)
            {
                frmSelectChannel fs = new frmSelectChannel();
                fs.dgvChannels.DataSource = Global.dtListOfChannels;
                fs.ShowDialog();

                if (fs.channelSeleted != "none")
                {
                    dgvConditions.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = fs.channelSeleted;
                    dgvConditions.Rows[e.RowIndex].Cells["colDataType"].Value = fs.dataTypeSeleted;
                }

                fs.Dispose();
            }
        }
    }
}
