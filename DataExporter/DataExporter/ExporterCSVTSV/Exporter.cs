using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Text;

namespace MockDataExporter
{
    public class Exporter
    {
        protected DataTable _dtExport { get; set; }
        public Exporter(DataTable dtExport)
        {
            _dtExport = dtExport;
        }

    }

    /// <summary>
    /// class for exporting datatable to CSV ot TSV
    /// </summary>
    public class ExporterCSVTSV : Exporter
    {
        public ExporterCSVTSV(DataTable dtExport) : base(dtExport)
        {
        }

        /// <summary>
        /// function for exporting to CSV and TSV
        /// </summary>
        /// <param name="delimiter">CSV or TSV</param>
        /// <param name="fileName">name of the file with exported data</param>
        public string ExportToCSV_TSV(string delimiter)
        {
            string strExportedData = string.Empty;
                if (_dtExport != null && _dtExport.Columns.Count > 0)
                {
                    int columnCount = _dtExport.Columns.Count;
                    StringBuilder sb = new StringBuilder();
                    for (int colIndex = 0; colIndex < columnCount; colIndex++)
                    {
                        sb.Append($"{_dtExport.Columns[colIndex].ColumnName}");
                        if (colIndex < columnCount - 1)
                            sb.Append(delimiter);
                    }
                    sb.AppendLine();

                    foreach (DataRow dr in _dtExport.Rows)
                    {
                        for (int colIndex = 0; colIndex < columnCount; colIndex++)
                        {
                            sb.Append($"{dr[colIndex]}");
                            if (colIndex < columnCount - 1)
                                sb.Append(delimiter);
                        }
                        sb.AppendLine();
                    }

                strExportedData = sb.ToString();
                }

            return strExportedData;
        }
    }

}
