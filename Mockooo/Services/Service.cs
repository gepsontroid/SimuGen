using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Mockooo.Services
{
    public class Service
    {




        //        private void btnLoad_Click(object sender, EventArgs e)
        //        {

        //        }

        //        private void Form1_Load(object sender, EventArgs e)
        //        {
        //            cmbDataTypes.Items.AddRange(new string[] { "int", "decimal", "string", "datetime", "custom" });

        //            cmbDataTypes.SelectedIndex = 0;


        //            dateTimePicker1.MinDate = new DateTime(1900, 1, 1, 0, 0, 0);
        //            dateTimePicker1.MaxDate = new DateTime(2100, 12, 31, 11, 59, 59);
        //            dateTimePicker1.Value = dateTimePicker1.MinDate;

        //            dateTimePicker2.MinDate = new DateTime(1900, 1, 1, 0, 0, 0);
        //            dateTimePicker2.MaxDate = new DateTime(2100, 12, 31, 11, 59, 59);
        //            dateTimePicker2.Value = dateTimePicker1.MinDate;
        //        }

        //        private void cmbDataTypes_SelectedIndexChanged(object sender, EventArgs e)
        //        {
        //            txtPrecision.Visible = false;
        //            lblPrecision.Visible = false;

        //            txtMin.BringToFront();
        //            txtMax.BringToFront();

        //            switch (cmbDataTypes.SelectedIndex)
        //            {
        //                case 1:
        //                    lblPrecision.Visible = true;
        //                    txtPrecision.Visible = true;
        //                    break;
        //                case 3:
        //                    txtMin.SendToBack();
        //                    txtMax.SendToBack();
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }

        //        private void btnGenerate_Click(object sender, EventArgs e)
        //        {
        //          }




        //        private void btnAdd_Click(object sender, EventArgs e)
        //        {
        //            string selectedDatatype = cmbDataTypes.SelectedItem.ToString();
        //            string fieldName = n.Text;// $"Param{keyValuePairs.Count + 1}";
        //                                                 //string fieldValue = txtValue.Text;

        //            BaseParameter baseParameter = null;
        //            ExtendedDataColumn dc = new ExtendedDataColumn();
        //            try
        //            {
        //                switch (selectedDatatype)
        //                {
        //                    case "string":
        //                        // keyValuePairs[fieldName] = Convert.ChangeType(fieldValue, typeof(string));
        //                        dc = new ExtendedDataColumn() { ColumnName = fieldName, DataType = typeof(string) };
        //                        // baseParameter = new BaseParameter(typeof(string), fieldValue);
        //                        break;
        //                    case "int":
        //                        // keyValuePairs[fieldName] = Convert.ChangeType(fieldValue, typeof(int));
        //                        dc = new ExtendedDataColumn()
        //                        {
        //                            ColumnName = fieldName,
        //                            DataType = typeof(int),
        //                            MockMinValue = int.MinValue,
        //                            MockMaxValue = int.MaxValue
        //                        };
        //                        if (int.TryParse(txtMin.Text, out int minInt)) { dc.MockMinValue = minInt; }
        //                        if (int.TryParse(txtMax.Text, out int maxInt)) { dc.MockMaxValue = maxInt; }

        //                        // baseParameter = new BaseParameter(fieldName, typeof(int), fieldValue, 10, 20);
        //                        break;
        //                    case "decimal":
        //                        // keyValuePairs[fieldName] = Convert.ChangeType(fieldValue, typeof(int));
        //                        dc = new ExtendedDataColumn()
        //                        {
        //                            ColumnName = fieldName,
        //                            DataType = typeof(decimal),
        //                            MockMinValue = decimal.MinValue,
        //                            MockMaxValue = decimal.MaxValue,
        //                            MockPrecision = 2
        //                        };

        //                        if (decimal.TryParse(txtMin.Text, out decimal minDecimal)) { dc.MockMinValue = minDecimal; }
        //                        if (decimal.TryParse(txtMax.Text, out decimal maxDecimal)) { dc.MockMaxValue = maxDecimal; }
        //                        if (int.TryParse(txtPrecision.Text, out int precision)) { dc.MockPrecision = precision; }

        //                        // baseParameter = new BaseParameter(typeof(int), fieldValue);
        //                        break;
        //                    case "datetime":
        //                        // keyValuePairs[fieldName] = Convert.ChangeType(fieldValue, typeof(int));
        //                        dc = new ExtendedDataColumn()
        //                        {
        //                            ColumnName = fieldName,
        //                            DataType = typeof(DateTime),
        //                            MockMinValue = new DateTime(1900, 1, 1, 0, 0, 0),
        //                            MockMaxValue = new DateTime(2100, 12, 31, 11, 59, 59)
        //                        };


        //                        dc.MockMinValue = dateTimePicker1.Value;
        //                        dc.MockMaxValue = dateTimePicker2.Value;

        //                        // baseParameter = new BaseParameter(typeof(int), fieldValue);
        //                        break;

        //                    case "custom":
        //                        // keyValuePairs[fieldName] = Convert.ChangeType(fieldValue, typeof(int));
        //                        dc = new ExtendedDataColumn() { ColumnName = fieldName, DataType = typeof(int), MockMinValue = 10, MockMaxValue = 100 };

        //                        // baseParameter = new BaseParameter(typeof(int), fieldValue);
        //                        break;
        //                    default:
        //                        //keyValuePairs[fieldName] = Convert.ChangeType(fieldValue, typeof(object));
        //                        dc = new ExtendedDataColumn() { ColumnName = fieldName, DataType = typeof(object) };

        //                        // baseParameter = new BaseParameter(typeof(object), fieldValue);
        //                        break;
        //                }
        //                //  keyValuePairs[fieldName] = baseParameter;
        //                dt.Columns.Add(dc);
        //                dataGridView1.DataSource = dt;

        //                parameters.Add(baseParameter);

        //            }
        //            catch (Exception ex)
        //            {
        //                rtbOutput.Text += $"{Environment.NewLine}{ex.Message}";
        //            }

        //            new EmployeeDataModel() { Age = 10 };
        //        }


        //        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        //        {
        //            dt = new DataTable();
        //        }

        //        private void cSVToolStripMenuItem_Click(object sender, EventArgs e)
        //        {
        //            ExportToCSV_TSV(",", GetFileName("CSV"));
        //        }

        //        private void tSVToolStripMenuItem_Click(object sender, EventArgs e)
        //        {
        //            ExportToCSV_TSV("\t", GetFileName("TSV"));
        //        }

        //        private void jSONToolStripMenuItem_Click(object sender, EventArgs e)
        //        {
        //            ExportToJSON(dt, GetFileName("JSON"));
        //        }

        //        private void button1_Click(object sender, EventArgs e)
        //        {
        //            dt = new DataTable();
        //            //dr["MockFieldName"] = extendedDataColumn.ColumnName;
        //            //dr["MockFieldDataType"] = extendedDataColumn.DataType;
        //            //dr["MockDataFormat"] = extendedDataColumn.MockDataFormat;
        //            //dr["MockMinValue"] = extendedDataColumn.MockMinValue;
        //            //dr["MockMaxValue"] = extendedDataColumn.MockMaxValue;
        //            //dr["MockPrecision"] = extendedDataColumn.MockPrecision;

        //            try
        //            {
        //                string JSONString = File.ReadAllText("schema.json");

        //                List<DataModelTemplate> lst = JsonConvert.DeserializeObject<List<DataModelTemplate>>(JSONString);

        //                DataTable newDatatable = new DataTable();
        //                foreach (var col in lst)
        //                {
        //                    ExtendedDataColumn dc = new ExtendedDataColumn()
        //                    {
        //                        ColumnName = col.MockFieldName,
        //                        DataType = col.MockFieldDataType,
        //                        MockDataFormat = col.MockDataFormat,
        //                        MockMinValue = col.MockMinValue,
        //                        MockMaxValue = col.MockMaxValue,
        //                        MockPrecision = col.MockPrecision,
        //                    };
        //                    dt.Columns.Add(dc);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message);
        //            }
        //        }
        //}

        //    #region Classes

        //    public class DataModelTemplate
        //    {
        //        public string MockFieldName { get; set; }
        //        public Type MockFieldDataType { get; set; }
        //        public object MockMinValue { get; set; }
        //        public object MockMaxValue { get; set; }
        //        public int MockPrecision { get; set; }
        //        public string MockDataFormat { get; set; }
        //    }


        //    //public class ExtendedDataColumn : DataColumn
        //    //{
        //    //    public object MockMinValue { get; set; }
        //    //    public object MockMaxValue { get; set; }
        //    //    public int MockPrecision { get; set; }
        //    //    public string MockDataFormat { get; set; }
        //    //}

        //    public class BaseParameter
        //    {
        //        public Type DefinedDatatype { get; set; }
        //        public object DefinedValue { get; set; }
        //        public string FieldName { get; set; }
        //        public object? MinValue { get; set; }
        //        public object? MaxValue { get; set; }


        //        public BaseParameter(string fieldName, Type definedDatatype, object definedValue, object? minValue = null, object? maxValue = null)
        //        {
        //            FieldName = fieldName;
        //            DefinedDatatype = definedDatatype;
        //            DefinedValue = Convert.ChangeType(definedValue, definedDatatype);
        //            MinValue = minValue;
        //            MaxValue = maxValue;
        //        }
        //    }

        //    public class ColumnParameter
        //    {
        //        /// <summary>
        //        /// 
        //        /// </summary>
        //        KeyValuePair<string, object>[] Properties { get; set; }
        //    }

        //    public class OutputRecords
        //    {
        //        public List<ColumnParameter> Parameters { get; set; }
        //    }
        //    #endregion

        //    #region Data Model
        //    public class EmployeeDataModel
        //    {
        //        public int Age { get; set; }
        //        public string PSNo { get; set; }

        //        public DateTime DOB { get; set; }
        //    }
        //    #endregion
    }
}


