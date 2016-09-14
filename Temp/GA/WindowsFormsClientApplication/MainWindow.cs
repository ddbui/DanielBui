using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using FlightDataModel;
using SharedLibrary;
using System.Reflection;
using System.Linq.Dynamic;
using System.Linq.Expressions;

namespace WindowsFormsClientApplication
{
    public partial class MainWindow : Form
    {
        private List<Item> _dataList = new List<Item>();
        private List<string> _columns = new List<string>();

        private List<View_RawNoRegime_Good> _goodList;
        private List<View_RawNoRegime_Bad> _badList;

        private View_RawNoRegime_Good _goodChannelAverage = new View_RawNoRegime_Good();
        private View_RawNoRegime_Bad _badChannelAverage = new View_RawNoRegime_Bad();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void getDataButton_Click(object sender, EventArgs e)
        {
            GetDataFromDatabase();
            GetAllColumnNames();
            BuildDataList();

            Debug.WriteLine("There are {0} items on the list", _dataList.Count);

            PopulateMainListView();
            PopulateGoodChannelView();
            PopulateBadChannelView();
        }

        private void GetDataFromDatabase()
        {
            using (FlightDataEntities db = new FlightDataEntities())
            {
                _goodList = db.View_RawNoRegime_Good.ToList();
                _badList = db.View_RawNoRegime_Bad.ToList();

                Debug.WriteLine("There are {0} good items", _goodList.Count());
                Debug.WriteLine("There are {0} bad items", _badList.Count());
            }
        }

        private void GetAllColumnNames()
        {
            if (_goodList.Count <= 0) return;

            foreach (PropertyInfo pi in _goodList[0].GetType().GetProperties())
            {
                _columns.Add(pi.Name);
            }
        }

        /// <summary>
        /// Get average for a particular column specified by the property name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryableData"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private double? GetAverage<T>(IQueryable<T> queryableData, string propertyName)
        {
            var arg            = Expression.Parameter(typeof(T), "x");
            var pi             = typeof(T).GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            var expr           = Expression.Property(arg, pi);
            var lambda         = Expression.Lambda(expr, arg);
            var funcExpression = (Expression<Func<T, double?>>) lambda;
            var result         = queryableData.Average(funcExpression);

            return result;
        }

        /// <summary>
        /// dbui: There must be a better way than this. But I don't know expression tree well enough to utilize it for this.
        /// </summary>
        private void BuildDataList()
        {
            if (_columns.Count <= 0) return;

            foreach (var column in _columns)
            {
                // TODO: Find a better to exclude columns that we're not going to calculate an average for.
                if (column == "Index" || column == "TAIL" || column == "Flight" || column == "Seq_" ||
                    column == "Version" || column == "FltHrs" || column == "FltDate" || column == "FREQ" ||
                    column == "min_System_Amp__A_" || column == "max_System_Amp__A_" || column == "µ_System_Amp__A_" || column == "s_System_Amp__A_")
                    continue;

                var goodChannelAverage = GetAverage(_goodList.AsQueryable(), column);
                var badChannelAverage  = GetAverage(_badList.AsQueryable(), column);
                var item               = new Item(column, goodChannelAverage, badChannelAverage);

                var property = typeof(View_RawNoRegime_Good).GetProperty(column);
                property.SetValue(_goodChannelAverage, goodChannelAverage);

                property = typeof(View_RawNoRegime_Bad).GetProperty(column);
                property.SetValue(_badChannelAverage, badChannelAverage);

                _dataList.Add(item);
            }            
        }

        private void PopulateMainListView()
        {
            // TODO: These PopulateView are similar. Refactor them when I have a chance!
            // Main list
            var bindingList = new SortableBindingList<Item>(_dataList);
            var source = new BindingSource(bindingList, null);
            dataGridView.DataSource = source;
        }

        private void PopulateGoodChannelView()
        {
            // Good
            _goodList.Add(_goodChannelAverage);
            var goodBindingList = new SortableBindingList<View_RawNoRegime_Good>(_goodList);
            var goodBindingSource = new BindingSource(goodBindingList, null);
            goodDataGridView.DataSource = goodBindingSource;
        }

        private void PopulateBadChannelView()
        {
            // Bad
            _badList.Add(_badChannelAverage);
            var badBindingList = new SortableBindingList<View_RawNoRegime_Bad>(_badList);
            var badBindingSource = new BindingSource(badBindingList, null);
            badDataGridView.DataSource = badBindingSource;
        }
    }

    public class Item
    {
        public string Channel { get; private set; }
        public double? Good { get; private set; }
        public double? Bad { get; private set; }
        public double? Diff { get; private set; }

        public double? Absolute { get; private set; }

        public Item(string name, double? good, double? bad)
        {
            // TODO: Check for NULL (Not sure if we need too!)
            Channel = name;
            Good    = good;
            Bad     = bad;
            Diff    = (Good - Bad) / Bad;

            if (Diff != null)
            {
                Absolute = Math.Abs((double) Diff);
            }
        }
    }
}
