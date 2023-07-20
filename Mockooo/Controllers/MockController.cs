using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Mockooo.Models;
using Mockooo.Service;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;

namespace Mockooo.Controllers
{
    public class MockController : Controller
    {

        #region Properties, Variables
        Random randomGenerator = new Random();
        DataTable dt = new DataTable();
        int recordsToGenerate = 1000;
        #endregion



        [HttpPost("GetMockData/{Count}/{fileFormat}")]
        public async Task<IActionResult> PostAsync(int Count,string fileFormat, [FromBody] List<UserDataModel> model)
        {
            //var body = new StreamReader(Request.Body);
            ////The modelbinder has already read the stream and need to reset the stream index
            //body.BaseStream.Seek(0, SeekOrigin.Begin);
            //var requestBody = body.ReadToEnd();

            if (model==null)
            {
                return BadRequest();
            }
            MQTT mQTT = new MQTT();
           // await mQTT.ConnectToClient("172.17.0.2", "mytopic", "Payload");

            //DataModel model = new DataModel() { ColumnName = "Age", MockDataType = "int", MockMinValue = 10, MockMaxValue = 80 };

            DataTable dt = new DataTable();
            foreach (var item in model)
            {
                DataModel dm = CreateDataModelProperty(item.MockFieldName, item.MockFieldDataType,
                    item.MockMinValue, item.MockMaxValue, item.MockPrecision);

                dt.Columns.Add(dm); 

            }
            string resultSet = GenerateData(dt, Count);

            ExporterCSVSTV objExportData = new ExporterCSVSTV(dt);
        
            var bytes= getExportedDataBytes(fileFormat, dt);

            return File(bytes, "Application/octet-string", $"Mock_{fileFormat}_{DateTime.Now}.{fileFormat}");
            //return new JsonResult(resultSet);
        }

        private byte[] getExportedDataBytes(string fileFormat, DataTable dtDatatoExport)
        {
            byte[] strSampleBytes = null;
            fileFormat = fileFormat.ToUpper();
            switch (fileFormat)
            {
                case "CSV":
                    ExporterCSVSTV objCSVExportData = new ExporterCSVSTV(dtDatatoExport);

                    strSampleBytes = System.Text.Encoding.UTF8.GetBytes(objCSVExportData.ExportToCSV_TSV(","));
                    break;

                case "TSV":
                    ExporterCSVSTV objTSVExportData = new ExporterCSVSTV(dtDatatoExport);

                    strSampleBytes = System.Text.Encoding.UTF8.GetBytes(objTSVExportData.ExportToCSV_TSV("t"));
                    break;
                case "JSON":
                    ExportJSON.ExportJSON objJSONExportData = new ExportJSON.ExportJSON(dtDatatoExport);

                    strSampleBytes = System.Text.Encoding.UTF8.GetBytes(objJSONExportData.ExportToJSON());
                    break;
                case "XML":
                    ExportXML.ExportXML objXMLExportData = new ExportXML.ExportXML(dtDatatoExport);

                    strSampleBytes = System.Text.Encoding.UTF8.GetBytes(objXMLExportData.ExportToXML());
                    break;

            }

            return strSampleBytes;
        }
        private DataModel CreateDataModelProperty(string fieldName, string dataType,
            object minValue, object maxValue, int precision)
        {
            DataModel dc = new DataModel();
            dc.ColumnName = fieldName;
       
            try
            {
                switch (dataType)
                {
                    case "string":
                        
                        dc.DataType = typeof(string);
                        
                        break;

                    case "int":
                       
                        dc.DataType = typeof(int);
                        
                        if (int.TryParse(Convert.ToString(minValue), out int minInt)) { dc.MockMinValue = minInt; }
                        
                        else
                            dc.MockMinValue = int.MinValue;

                        if (int.TryParse(Convert.ToString(maxValue), out int maxInt)) { dc.MockMaxValue = maxInt; }
                        
                        else
                            dc.MockMaxValue = int.MaxValue;
                        
                        break;

                    case "decimal":

                        dc.DataType = typeof(decimal);
                        
                        if (decimal.TryParse(Convert.ToString(minValue), out decimal minDecimal)) { dc.MockMinValue = minDecimal; }
                        
                        else
                            dc.MockMinValue = int.MinValue;

                        if (decimal.TryParse(Convert.ToString(maxValue), out decimal maxDecimal)) { dc.MockMaxValue = maxDecimal; }
                        
                        else
                            dc.MockMaxValue = int.MaxValue;

                        if (int.TryParse(Convert.ToString(precision), out int precisions)) { dc.MockPrecision = precisions; }
                        
                        break;
                    
                    case "datetime":
                        
                        dc.DataType = typeof(DateTime);

                        if (DateTime.TryParse(Convert.ToString(minValue), out DateTime minDate)) { dc.MockMinValue = minDate; }

                        else
                            dc.MockMinValue = new DateTime(1900, 1, 1, 0, 0, 0);


                        if (DateTime.TryParse(Convert.ToString(maxValue), out DateTime maxDate)) { dc.MockMaxValue = maxDate; }
                        
                        else
                            dc.MockMaxValue = new DateTime(2100, 12, 31, 11, 59, 59);

                        break;
                                           
                    default:
                        dc.DataType = typeof(object);
                        break;
                }

            }
            catch (Exception ex)
            {
            }

            return dc;
        }

        private string GenerateData(DataTable dt, long recordsToGenerate)
        {
            string resultSet = string.Empty;
            try
            {

                dt.TableName = "data";

                if (dt.Columns.Count > 0)
                {
                    for (long i = 0; i < recordsToGenerate; i++)
                    {
                        DataRow dr = dt.NewRow();
                        foreach (DataModel dataColumn in dt.Columns)
                        {
                            if (dataColumn.DataType == typeof(int))
                            {
                                dr[dataColumn] = randomGenerator.Next(int.Parse(dataColumn.MockMinValue.ToString()), int.Parse(dataColumn.MockMaxValue.ToString()));
                            }
                            if (dataColumn.DataType == typeof(decimal))
                            {
                                dr[dataColumn] = randomGenerator.Next((int)dataColumn.MockMinValue, (int)dataColumn.MockMaxValue);
                            }
                            if (dataColumn.DataType == typeof(string))
                            {
                                dr[dataColumn] = $"Value {i}";
                            }
                            if (dataColumn.DataType == typeof(DateTime))
                            {
                                dr[dataColumn] = GetRandomDate((DateTime)dataColumn.MockMinValue, (DateTime)dataColumn.MockMaxValue);
                            }
                        }
                        dt.Rows.Add(dr);
                    }

                }
                else
                {
                }

            }
            catch (Exception ex)
            {
            }
            return resultSet;
        }

        #region Private methods
        //private string GenerateDataModelTemplate()
        //{
        //    string resultSet = string.Empty;
        //    try
        //    {
        //        List<DataModelTemplate> dataModelTemplates = new List<DataModelTemplate>();

        //        DataTable modelDataTable = new DataTable();
        //        modelDataTable.Columns.Add("MockFieldName");
        //        modelDataTable.Columns.Add("MockFieldDataType");
        //        modelDataTable.Columns.Add("MockDataFormat");
        //        modelDataTable.Columns.Add("MockMinValue");
        //        modelDataTable.Columns.Add("MockMaxValue");
        //        modelDataTable.Columns.Add("MockPrecision");

        //        foreach (DataModel extendedDataColumn in dt.Columns)
        //        {
        //            DataRow dr = modelDataTable.NewRow();
        //            DataModelTemplate template = new DataModelTemplate()
        //            {
        //                MockFieldName = extendedDataColumn.ColumnName,
        //                MockFieldDataType = extendedDataColumn.DataType,
        //                MockMinValue = extendedDataColumn.MockMinValue,
        //                MockMaxValue = extendedDataColumn.MockMaxValue,
        //                MockPrecision = extendedDataColumn.MockPrecision
        //            };
        //            dataModelTemplates.Add(template);


        //            dr["MockFieldName"] = extendedDataColumn.ColumnName;
        //            dr["MockFieldDataType"] = extendedDataColumn.DataType;
        //            dr["MockMinValue"] = extendedDataColumn.MockMinValue;
        //            dr["MockMaxValue"] = extendedDataColumn.MockMaxValue;
        //            dr["MockPrecision"] = extendedDataColumn.MockPrecision;
        //            modelDataTable.Rows.Add(dr);
        //        }
        //        resultSet = ExportToJSON(modelDataTable, "schema.json");
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //    return resultSet;
        //}

        private DateTime GetRandomDate(DateTime dtStart, DateTime dtEnd)
        {
            return dtStart.AddDays(randomGenerator.Next((dtEnd - dtStart).Days));
        }

        //private decimal GetRandomDecimal(int minDecimal, int maxDecimal)
        //{
        //    return randomGenerator.Next(minDecimal, maxDecimal);
        //}


        //private void ExportToCSV_TSV(string delimiter, string fileName = "mockdata.txt")
        //{
        //    try
        //    {
        //        if (dt != null && dt.Columns.Count > 0)
        //        {
        //            int columnCount = dt.Columns.Count;
        //            StringBuilder sb = new StringBuilder();
        //            for (int colIndex = 0; colIndex < columnCount; colIndex++)
        //            {
        //                sb.Append($"{dt.Columns[colIndex].ColumnName}");
        //                if (colIndex < columnCount - 1)
        //                    sb.Append(delimiter);
        //            }
        //            sb.AppendLine();

        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                for (int colIndex = 0; colIndex < columnCount; colIndex++)
        //                {
        //                    sb.Append($"{dr[colIndex]}");
        //                    if (colIndex < columnCount - 1)
        //                        sb.Append(delimiter);
        //                }
        //                sb.AppendLine();
        //            }

        //            //  File.WriteAllText(fileName, sb.ToString());
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //private string ExportToJSON(DataTable dt, string fileName = "mockdata.txt")
        //{
        //    string JSONString = string.Empty;

        //    try
        //    {
        //        JSONString = JsonConvert.SerializeObject(dt);
        //        //rtbOutput.Text = JSONString;
        //        //  File.WriteAllText(fileName, JSONString);
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //    return JSONString;
        //}

       
        //public class DataModelTemplate
        //{
        //    public string MockFieldName { get; set; }
        //    public Type MockFieldDataType { get; set; }
        //    public object MockMinValue { get; set; }
        //    public object MockMaxValue { get; set; }
        //    public int MockPrecision { get; set; }
        //}
       
        #endregion
    }
}
