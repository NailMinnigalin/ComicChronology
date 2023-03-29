using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ComicChronology
{
    internal static class Utils
    {
        public static DataTable DictionaryToDataTable(Dictionary<int, string> dict)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns.Add("title", typeof(string));

            foreach (var pair in dict)
            {
                dataTable.Rows.Add(pair.Key, pair.Value);
            }

            return dataTable;
        }
    }
}
