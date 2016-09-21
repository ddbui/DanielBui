using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using GenericParsing;

namespace DataParser
{
    public class DataParser
    {
        private readonly string _filename;

        public DataTable RawData { get; private set; }

        public DataTable GoodFlights { get; private set; }

        public DataTable BadFlights { get; private set; }

        public List<Item> AverageData { get; private set; }

        private readonly List<string> _columns = new List<string>();

        public DataParser(string filename)
        {
            _filename   = filename;
            AverageData = new List<Item>();
        }

        public bool Parse()
        {
            using (var parser = new GenericParserAdapter(_filename))
            {
                parser.FirstRowHasHeader = true;
                RawData = parser.GetDataTable();
            }

            var dtCloned = RawData.Clone();

            SetColumnDataType(dtCloned);
            SetDefaultData(dtCloned);

            BuildGoodFlightDataTable(dtCloned);
            BuildBadFlightDataTable(dtCloned);
            BuildAverageDataList();

            return true;
        }

        private void SetDefaultData(DataTable dtCloned)
        {
            // The reason why we're not using foreeach here is we need to set the cell to "0"
            for (var row = 0; row < RawData.Rows.Count; row++)
            {
                // We cannot allow empty string so we replace them, if any, with "0"
                for (var column = 0; column < RawData.Rows[row].ItemArray.Length; column++)
                {
                    if (string.IsNullOrEmpty(RawData.Rows[row][column].ToString()) ||
                        string.IsNullOrWhiteSpace(RawData.Rows[row][column].ToString()))
                    {
                        RawData.Rows[row][column] = "0";
                    }
                }

                dtCloned.ImportRow(RawData.Rows[row]);
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

        private void BuildBadFlightDataTable(DataTable dtCloned)
        {
            const string expression = "TAIL <> '4071'";
            var rows                = dtCloned.Select(expression);
            BadFlights              = rows.CopyToDataTable();
        }

        private void BuildGoodFlightDataTable(DataTable dtCloned)
        {
            const string expression = "TAIL = '4071'";
            var rows                = dtCloned.Select(expression);
            GoodFlights             = rows.CopyToDataTable();
        }

        private void GetAllColumnNames()
        {
            foreach (var column in RawData.Columns)
            {
                _columns.Add(column.ToString());
            }
        }

        private void BuildAverageDataList()
        {
            GetAllColumnNames();

            if (_columns.Count <= 0) return;

            var goodFlightAverageRow = GoodFlights.NewRow();
            var badFlightAverageRow = BadFlights.NewRow();

            foreach (var column in _columns)
            {
                if (GoodFlights.Columns[column].DataType.Name != "Double" ||
                    BadFlights.Columns[column].DataType.Name != "Double")
                {
                    continue;
                }

                var goodChannelAverage = GoodFlights.AsEnumerable().Average(r => r.Field<double>(column));
                var badChannelAverage = BadFlights.AsEnumerable().Average(r => r.Field<double>(column));
                var item = new Item(column, goodChannelAverage, badChannelAverage);

                goodFlightAverageRow[column] = goodChannelAverage;
                badFlightAverageRow[column] = badChannelAverage;

                AverageData.Add(item);
            }

            GoodFlights.Rows.Add(goodFlightAverageRow);
            BadFlights.Rows.Add(badFlightAverageRow);
        }
    }
}
