using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Azure;

namespace MockDataExporter
{
    public class Exporter
    {
        protected DataTable _dtExport { get; set; }
        public string filePath { get; set; }
        public Exporter(DataTable dtExport)
        {
            _dtExport = dtExport;
        }

        /// <summary>
        /// get the name of the file to be generated
        /// </summary>
        /// <param name="fileType">type of file to generate</param>
        /// <param name="fileName">name of file to generate</param>
        /// <returns></returns>
        protected string getFileName(string fileType, string fileName = "MockData")
        {
            string fileExtension = "txt";
            switch (fileType)
            {
                case "CSV":
                    fileExtension = "csv";
                    break;
                case "TSV":
                    fileExtension = "tsv";
                    break;
                case "JSON":
                    fileExtension = "json";
                    break;
                default:
                    fileExtension = "txt";
                    break;
            }

            return $"{fileName}_{DateTime.Now.ToString("yyMMddHHmmssfff")}.{fileExtension}";
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
        public void ExportToCSV_TSV(string delimiter, string fileName = "mockdata.txt")
        {

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

                    File.WriteAllText($"{filePath}\\{fileName}", sb.ToString());
                }

        }
    }

    /// <summary>
    /// class for exporting datatable to JSON
    /// </summary>
    public class ExportJSON : Exporter
    {
        public ExportJSON(DataTable dtExport) : base(dtExport)
        {
        }

        /// <summary>
        /// function for exporting datatable to JSON
        /// </summary>
        /// <param name="fileName">name of the file with exported data</param>
        public void ExportToJSON(string fileName = "mockdata.txt")
        {
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(_dtExport);
                File.WriteAllText($"{filePath}\\{fileName}", JSONString);
        }
    }

    /// <summary>
    /// class for exporting datatable to MSSQL Table
    /// </summary>
    public class ExportMSSQL : Exporter
    {
        public ExportMSSQL(DataTable dtExport) : base(dtExport)
        {
        }

        public string strDataSource { get; set; }

        public string strInitialCatalog { get; set; }

        public string strUserID { get; set; }

        public string strPassword { get; set; }
        public bool ExporttoDB(string strTableName)
        {
            bool isExportSuccess = false;

            string connection = $"Data Source={strDataSource};Initial Catalog={strInitialCatalog};User Id = {strUserID}; Password = {strPassword};TrustServerCertificate=True;Connection Timeout=3600";
            SqlConnection con = new SqlConnection(connection);
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            con.Open();
            using (SqlBulkCopy sqlbc = new SqlBulkCopy(con))
            {
                sqlbc.DestinationTableName = strTableName;
                sqlbc.BulkCopyTimeout = 600;
                sqlbc.ColumnMappings.Add("SampleInt", "SampleInt");
                sqlbc.ColumnMappings.Add("SampleDate", "SampleDate");
                sqlbc.ColumnMappings.Add("SampleString", "SampleString");
                sqlbc.WriteToServer(_dtExport);
            }


            return isExportSuccess;
        }

        /// <summary>
        /// functio for executing data definition language 
        /// </summary>
        /// <param name="strSQLCreateTable">DDL statement to be executed</param>
        /// <returns></returns>
        public bool ExecuteNonQuery(string strSQLCreateTable)
        {
            bool isCreateSuccess = false;
            try
            {
                string connection = $"Data Source={strDataSource};Initial Catalog={strInitialCatalog};User Id = {strUserID}; Password = {strPassword};TrustServerCertificate=True";
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand(strSQLCreateTable, con))
                        command.ExecuteNonQuery();
                }

                isCreateSuccess = true;
            }
            catch (Exception ex)
            {

            }
            return isCreateSuccess;
        }

        /// <summary>
        /// create table string generation
        /// </summary>
        /// <param name="tableName">name of the table to be created</param>
        /// <param name="table">Datatable for which SQL table to be created</param>
        /// <returns></returns>
        public static string CreateTABLEStatement(string tableName, DataTable table)
        {
            string sqlsc;
            sqlsc = "CREATE TABLE " + tableName + "(";
            for (int i = 0; i < table.Columns.Count; i++)
            {
                sqlsc += "\n [" + table.Columns[i].ColumnName + "] ";
                string columnType = table.Columns[i].DataType.ToString();
                switch (columnType)
                {
                    case "System.Int32":
                        sqlsc += " int ";
                        break;
                    case "System.Int64":
                        sqlsc += " bigint ";
                        break;
                    case "System.Int16":
                        sqlsc += " smallint";
                        break;
                    case "System.Byte":
                        sqlsc += " tinyint";
                        break;
                    case "System.Decimal":
                        sqlsc += " decimal ";
                        break;
                    case "System.DateTime":
                        sqlsc += " datetime ";
                        break;
                    case "System.String":
                    default:
                        sqlsc += string.Format(" nvarchar({0}) ", table.Columns[i].MaxLength == -1 ? "max" : table.Columns[i].MaxLength.ToString());
                        break;
                }
                if (table.Columns[i].AutoIncrement)
                    sqlsc += " IDENTITY(" + table.Columns[i].AutoIncrementSeed.ToString() + "," + table.Columns[i].AutoIncrementStep.ToString() + ") ";
                if (!table.Columns[i].AllowDBNull)
                    sqlsc += " NOT NULL ";
                sqlsc += ",";
            }
            return sqlsc.Substring(0, sqlsc.Length - 1) + "\n)";
        }
    }

    public class ExportXML : Exporter
    {
        public ExportXML(DataTable dtExport) : base(dtExport)
        {
        }

        public void ExportToXML(string fileName = "mockdata.xml")
        {
            _dtExport.TableName = fileName;
            _dtExport.WriteXml($"{filePath}\\{fileName}");
        }
    }
}
