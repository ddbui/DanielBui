using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using DgvFilterPopup;
using FlightDataModel;
using GenericParsing;
using SharedLibrary;

namespace WindowsFormsClientApplication
{
    public partial class frmStats : Form
    {
        private readonly clsDB DB = new clsDB();
        private List<clsFilter> ListFilter = new List<clsFilter>();
        DataTable dtFlights = new DataTable();
        int faultIdSelected = -1;
        DgvFilterManager fm = new DgvFilterManager();
        private bool checkedState = false;

        public frmStats()
        {
            InitializeComponent();
        }

        private void frmStats_Load(object sender, EventArgs e)
        {
            DB.connStr = Properties.Settings.Default["DBConnectionString"].ToString();

            this.dgvSelectFlight.AutoGenerateColumns = false;
            this.dgvFaults.AutoGenerateColumns = false;

            //dtFlights = DB.GetTable("EXEC sp_GetTailFlightRootTableChk");
            //dtFlights = DB.GetTable("EXEC sp_GetTailFlightRootTableChk_Test");


            string sql = "SELECT [fault_id],[fault_name] FROM [ASI_Flight_Data].[dbo].[_Faults]";
            DataTable dtFaults = DB.GetTable(sql);
            dgvFaults.DataSource = dtFaults;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();

            if (faultIdSelected == -1)
            {
                MessageBox.Show("Must First Select A Fault", "No Fault Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            pBar.Maximum = dtFlights.Rows.Count;
            DataTable dtAllResults = new DataTable();


            List<DataGridViewRow> list = dgvSelectFlight.Rows.Cast<DataGridViewRow>().Where(k => Convert.ToBoolean(k.Cells["colChkBox"].Value) == true).ToList();
            if (this.dtFlights.Rows.Count > 0)
            {
                this.pBar.Maximum = list.Count;
            }
            else
            {
                this.pBar.Maximum = 1;
            }




            int rowCnt = 1;
            bool firstTableCreated = false;


            stopWatch.Start();
            foreach (DataGridViewRow row in this.dgvSelectFlight.Rows)
            {

                DataGridViewCheckBoxCell cell = row.Cells["colChkBox"] as DataGridViewCheckBoxCell;

                if (cell.Value.ToString().ToUpper() == "1" && row.Visible == true)
                {
                    string sFaultId = this.faultIdSelected.ToString();
                    string rootTable = row.Cells["colFlightData"].Value.ToString();
                    rootTable = rootTable.Substring(2, rootTable.Length - 6);
                    string tail = row.Cells["colTail"].Value.ToString();
                    string label = row.Cells["colClassification"].Value.ToString();
                    string flight = row.Cells["colFlight"].Value.ToString();
                    string seq = row.Cells["colGroupId"].Value.ToString();
                    double flthrs = Convert.ToDouble(row.Cells["colFlightHours"].Value);
                    string version = row.Cells["colVersion"].Value.ToString();
                    
                    string fltdate = row.Cells["colDate"].Value.ToString();

                    //'''00188'' AS [TAIL], ''171'' AS [Flight], ''573'' AS [Seq#], 5.54 AS [FltHrs], ''6/17/2005 12:26:26 PM'' AS [FltDate]'
                    string bascis = "'''" + sFaultId + "'' AS [FaultId], ''" + label + "'' AS [Label], ''" + tail + "'' AS [TAIL], ''" + flight + "'' AS [Flight], ''" + seq + "'' AS [Seq#], ''" + version + "'' AS [version], " + flthrs.ToString("0.00") + " AS [FltHrs], ''" + fltdate + "'' AS [FltDate]'";

                    string whereCond = GetWhereCondition(rootTable);

                    string sql = "EXEC sp_Get_Averages 'RRRRR', FFFFF, 'WWWWW', SSSSSS";
                    sql = sql.Replace("RRRRR", rootTable);
                    sql = sql.Replace("FFFFF", this.faultIdSelected.ToString());
                    sql = sql.Replace("WWWWW", whereCond);
                    sql = sql.Replace("SSSSSS", bascis);

                    lblCurrentFile.Text = rootTable;
                    lblCurrentFile.Refresh();
                    Application.DoEvents();

                    var t = Task<DataTable>.Factory.StartNew(() =>
                    {
                        DataTable dtResult = DB.GetTable(sql);
                        return dtResult;
                    });

                    DataTable dtFlightResult = t.Result;

                    if (dtFlightResult.Rows.Count > 0)
                    {
                        foreach(DataColumn dc in dtFlightResult.Columns)
                        {
                            if (dtFlightResult.Rows[0][dc.ColumnName].ToString().Trim() == "")
                            {
                                dtFlightResult.Rows[0][dc.ColumnName] = DBNull.Value;
                            }
                        }
                    }

                    if (dtFlightResult.Rows.Count > 0)
                    {
                        if (firstTableCreated == false)
                        {
                            dtAllResults = dtFlightResult;
                            firstTableCreated = true;
                        }
                        else
                        {
                            if (dtFlightResult.Columns.Count == dtAllResults.Columns.Count)
                            {
                                dtAllResults.Merge(dtFlightResult,true, MissingSchemaAction.Ignore);
                            }
                        }
                    }


                    pBar.Value = rowCnt;
                    rowCnt++;

                }
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);

            lblCurrentFile.Text = "Process Time: " + elapsedTime;
            this.dgvResults.DataSource = dtAllResults;
            Cursor.Current = Cursors.Default;

        }

        private DataTable GetColumnsAssociatedWithAZipFile(string zipFile, string fileType)
        {
            zipFile = zipFile.ToUpper();
            if (zipFile.Contains(".ZIP"))
            {
                zipFile = zipFile.Replace(".ZIP", "");
            }
            //zipFile = fileType + "_" + zipFile;

            string sql = "EXEC sp_GetColumnIndexesForZipFile '" + zipFile + "'";
            DataTable dt = DB.GetTable(sql);
            return dt;
        }
        private DataTable FindTableAndMappedColForChannel(string channelName, DataTable dtSearchTable)
        {

            var results = dtSearchTable.AsEnumerable()
                                        .Where(r => r.Field<string>("RootChannelName") == channelName && r.Field<string>("TABLE_NAME").StartsWith("M"));

            DataTable dtResults = new DataTable();

            if (results != null && results.Count() != 0)
            {
                dtResults = results.CopyToDataTable();
            }

            return dtResults;

        }

        private DataTable FindTableAndMappedColForChannelWithBracket(string channelName, DataTable dtSearchTable)
        {

            var results = dtSearchTable.AsEnumerable()
                                        .Where(r => r.Field<string>("RootChannelName_B") == channelName && r.Field<string>("TABLE_NAME").StartsWith("M"));

            DataTable dtResults = new DataTable();

            if (results != null && results.Count() != 0)
            {
                dtResults = results.CopyToDataTable();
            }

            return dtResults;

        }

        private string GetWhereCondition(string rootWithNoDotZip)
        {
            string retVal = "";
            if (chkBxUseFilter.Checked == true && this.lblFilter.Text.Length >= 10)
            {
                string whereCondition = this.lblFilter.Text;
                foreach (clsFilter f in ListFilter)
                {
                    string channelName = "[" + f.Channel + "]";
                    DataTable dtMappedSensorColumns = GetColumnsAssociatedWithAZipFile(rootWithNoDotZip, f.DataType);
                    DataTable dtMatchResults = FindTableAndMappedColForChannelWithBracket(channelName, dtMappedSensorColumns);
                    if (dtMatchResults.Rows.Count > 0)
                    {
                        string replaceWithName = "[" + dtMatchResults.Rows[0]["COLUMN_NAME"].ToString() + "]";

                        if (replaceWithName == "[Time_id 0]")
                        {
                            whereCondition = whereCondition.Replace("[Time_id]", "p1.[Time_id 0]");
                        }
                        else
                        {
                            whereCondition = whereCondition.Replace(channelName, replaceWithName);
                        }

                    }
                }

                return whereCondition;

            }

            return retVal;
        }



        private void btnCopy_Click(object sender, EventArgs e)
        {
            this.dgvResults.SelectAll();

            if (dgvResults.Rows.Count > 0 && dgvResults.SelectedRows.Count > 0)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    this.dgvResults.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                    DataObject dataObj = dgvResults.GetClipboardContent();
                    Clipboard.SetDataObject(dataObj, true);
                    string sData = Clipboard.GetText();
                    sData = this.lblSelectedFault.Text + "  " +   lblFilter.Text + "\n\n" + sData;
                    Clipboard.SetText(sData);

                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(" Results Successfully Copied to Clipboard");

                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message, "Copy Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dgvResults.ClearSelection();
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void btnDataFilter_Click(object sender, EventArgs e)
        {
            frmConditions fc = new frmConditions();
            fc.ListFilter = this.ListFilter;
            fc.ShowDialog();

            this.ListFilter = fc.ListFilter;
            this.lblFilter.Text = fc.lblFilter.Text;

            fc.Dispose();
        }

        private void dgvFaults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvFaults.Columns[e.ColumnIndex].Name == "colSelect")
            {
                Cursor.Current = Cursors.WaitCursor;
                this.faultIdSelected = Convert.ToInt32(dgvFaults.Rows[e.RowIndex].Cells["colFaultId"].Value);
                this.lblSelectedFault.Text = dgvFaults.Rows[e.RowIndex].Cells["colFaultName"].Value.ToString();
                string isTrainingSet = "1";

                if (this.rbValidation.Checked == true)
                {
                    isTrainingSet = "0";
                }

                dtFlights = DB.GetTable("EXEC sp_GetTailFlightRootTableChkWithFault " + faultIdSelected.ToString() + ", " + isTrainingSet);
                this.dgvSelectFlight.DataSource = dtFlights;

                fm = new DgvFilterManager(this.dgvSelectFlight, false);
                //fm.FilterHost.Popup.Closed += Popup_Closed;

                fm.HeaderBackcolor = Color.DarkRed;
                fm.HeaderFontcolor = Color.White;

                fm["colTail"] = new DgvTextBoxColumnFilter();
                fm["colClassification"] = new DgvTextBoxColumnFilter();
                fm["colFlight"] = new DgvTextBoxColumnFilter();
                fm["colDate"] = new DgvTextBoxColumnFilter();
                fm["colMonth"] = new DgvTextBoxColumnFilter();
                fm["colYear"] = new DgvTextBoxColumnFilter();
                fm["colProduct"] = new DgvTextBoxColumnFilter();
                fm["colVersion"] = new DgvTextBoxColumnFilter();
                fm["colGroupId"] = new DgvTextBoxColumnFilter();
                fm["colFlightHours"] = new DgvTextBoxColumnFilter();

                Cursor.Current = Cursors.Default;



            }
            if (dgvFaults.Columns[e.ColumnIndex].Name == "colInfo")
            {
                DataTable dtInfo = new DataTable();
                string faultId = dgvFaults.Rows[e.RowIndex].Cells["colFaultId"].Value.ToString();
                var t = Task<DataTable>.Factory.StartNew(() =>
                {
                    DataTable dtResult = DB.GetTable("SELECT [root_channel_name], [dataType] from [dbo].[_FaultRootChannels] where fault_id = " + faultId);
                    return dtResult;
                });

                dtInfo = t.Result;

                string faultName = dgvFaults.Rows[e.RowIndex].Cells["colFaultName"].Value.ToString();
                if (dtInfo.Rows.Count > 0)
                {
                    string msg = "";
                    foreach (DataRow dr in dtInfo.Rows)
                    {
                        msg = msg + dr["root_channel_name"].ToString() + "\n";
                    }

                    MessageBox.Show(msg, "Channels Associted with " + faultName,MessageBoxButtons.OK,MessageBoxIcon.Information);

                }
            }

        }

        private void btnChkUnChk2_Click(object sender, EventArgs e)
        {
            if (this.dgvSelectFlight.Rows.Count == 0) { return; }
            if (checkedState == false)
            {
                CheckUnCheck(true, this.dgvSelectFlight, "colChkBox");
                checkedState = true;
            }
            else
            {
                CheckUnCheck(false, this.dgvSelectFlight, "colChkBox");
                checkedState = false;
            }
        }

        private void CheckUnCheck(bool checkAll, DataGridView dgv, string colName)
        {
            Cursor.Current = Cursors.WaitCursor;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataGridViewCheckBoxCell cell = row.Cells[colName] as DataGridViewCheckBoxCell;
                if (checkAll == false)
                {
                    cell.Value = cell.FalseValue;
                }
                else
                {
                    cell.Value = cell.TrueValue;
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private DataTable _dataReadFromCsvFile;
        private DataTable _dtGoodFlights;
        private DataTable _dtBadFlights;
        private readonly List<Item> _dataList  = new List<Item>();
        private readonly List<string> _columns = new List<string>();

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (!GetDataFromFile()) return;

            BuildAverageDataList();
            PopulateInputDataGridView();
            PopulateOutputDataGridView();
        }

        private bool GetDataFromFile()
        {
            var dlg = new OpenFileDialog
            {
                Title  = "Open CSV File",
                Filter = "CSV Files|*.csv"
            };

            if (dlg.ShowDialog() != DialogResult.OK) return false;

            using (var parser = new GenericParserAdapter(dlg.FileName))
            {
                parser.FirstRowHasHeader = true;
                _dataReadFromCsvFile = parser.GetDataTable();
            }

            if (_dataReadFromCsvFile.Rows.Count == 0) return false;

            var dtCloned = _dataReadFromCsvFile.Clone();

            SetColumnDataType(dtCloned);
            SetDefaultData(dtCloned);

            BuildGoodFlightDataTable(dtCloned);
            BuildBadFlightDataTable(dtCloned);

            return true;
        }

        private void BuildBadFlightDataTable(DataTable dtCloned)
        {
            const string expression = "TAIL <> 4071";
            var rows                = dtCloned.Select(expression);
            _dtBadFlights           = rows.CopyToDataTable();
        }

        private void BuildGoodFlightDataTable(DataTable dtCloned)
        {
            const string expression = "TAIL = 4071";
            var rows                = dtCloned.Select(expression);
            _dtGoodFlights          = rows.CopyToDataTable();
        }

        private void SetDefaultData(DataTable dtCloned)
        {
            // The reason why we're not using foreeach here is we need to set the cell to "0"
            for (var row = 0; row < _dataReadFromCsvFile.Rows.Count; row++)
            {
                // We cannot allow empty string so we replace them, if any, with "0"
                for (var column = 0; column < _dataReadFromCsvFile.Rows[row].ItemArray.Length; column++)
                {
                    if (string.IsNullOrEmpty(_dataReadFromCsvFile.Rows[row][column].ToString()) ||
                        string.IsNullOrWhiteSpace(_dataReadFromCsvFile.Rows[row][column].ToString()))
                    {
                        _dataReadFromCsvFile.Rows[row][column] = "0";
                    }
                }

                dtCloned.ImportRow(_dataReadFromCsvFile.Rows[row]);
            }
        }

        private static void SetColumnDataType(DataTable dtCloned)
        {
            foreach (DataColumn column in dtCloned.Columns)
            {
                if (column != null && column.ColumnName.Contains("_"))
                    column.DataType = typeof(double);
            }
        }

        private void GetAllColumnNames()
        {
            foreach (var column in _dataReadFromCsvFile.Columns)
            {
                _columns.Add(column.ToString());
            }
        }

        private void BuildAverageDataList()
        {
            GetAllColumnNames();

            if (_columns.Count <= 0) return;

            var goodFlightAverageRow = _dtGoodFlights.NewRow();
            var badFlightAverageRow  = _dtBadFlights.NewRow();

            foreach (var column in _columns)
            {
                if (_dtGoodFlights.Columns[column].DataType.Name != "Double" ||
                    _dtBadFlights.Columns[column].DataType.Name != "Double")
                {
                    continue;
                }

                var goodChannelAverage = _dtGoodFlights.AsEnumerable().Average(r => r.Field<double>(column));
                var badChannelAverage  = _dtBadFlights.AsEnumerable().Average(r => r.Field<double>(column));
                var item               = new Item(column, goodChannelAverage, badChannelAverage);

                goodFlightAverageRow[column] = goodChannelAverage;
                badFlightAverageRow[column]  = badChannelAverage;

                _dataList.Add(item);
            }

            _dtGoodFlights.Rows.Add(goodFlightAverageRow);
            _dtBadFlights.Rows.Add(badFlightAverageRow);
        }

        private void PopulateInputDataGridView()
        {
            dgvResults.DataSource = _dataReadFromCsvFile;
        }

        private void PopulateOutputDataGridView()
        {
            var bindingList              = new SortableBindingList<Item>(_dataList);
            var source                   = new BindingSource(bindingList, null);
            inputDataGridView.DataSource = source;

            goodFlightDataGridView.DataSource = _dtGoodFlights;
            badFlightDataGridView.DataSource  = _dtBadFlights;
        }
    }
}
