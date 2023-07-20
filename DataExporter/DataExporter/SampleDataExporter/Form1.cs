using MockDataExporter;
using System.Data;

namespace SampleDataExporter
{
    public partial class Form1 : Form
    {

        DataTable dt = new DataTable();
        Random randomGenerator = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                CreateTable();

                ExporterCSVTSV objExportDataCSV = new ExporterCSVTSV(dt);
                objExportDataCSV.filePath = $"{Directory.GetCurrentDirectory()}\\GeneratedData";
                Directory.CreateDirectory(objExportDataCSV.filePath);
                objExportDataCSV.ExportToCSV_TSV(",", "mockData.CSV");

                MessageBox.Show("Data Generated Succesfully");
            }
            catch (Exception ex)
            {
            }
        }

        private DateTime GetRandomDate(DateTime dtStart, DateTime dtEnd)
        {
            return dtStart.AddDays(randomGenerator.Next((dtEnd - dtStart).Days));
        }

        private void btnTab_Click(object sender, EventArgs e)
        {
            CreateTable();

            ExporterCSVTSV objExportDataCSV = new ExporterCSVTSV(dt);
            objExportDataCSV.filePath = $"{Directory.GetCurrentDirectory()}\\GeneratedData";
            Directory.CreateDirectory(objExportDataCSV.filePath);
            objExportDataCSV.ExportToCSV_TSV("\t", "mockData.TSV");
            MessageBox.Show("Data Generated Succesfully");

        }

        private void btJSON_Click(object sender, EventArgs e)
        {
            CreateTable();

            ExportJSON objExportDataCSV = new ExportJSON(dt);
            objExportDataCSV.filePath = $"{Directory.GetCurrentDirectory()}\\GeneratedData";
            Directory.CreateDirectory(objExportDataCSV.filePath);
            objExportDataCSV.ExportToJSON("mockData.JSON");
            MessageBox.Show("Data Generated Succesfully");

        }

        private void CreateTable()
        {
            dt = new DataTable();
            dt.Columns.Add("SampleInt");
            dt.Columns.Add("SampleDate");
            dt.Columns.Add("SampleString");

            for (int i = 0; i < 5000000; i++)
            {
                DataRow dtRow = dt.NewRow();
                dtRow["SampleInt"] = randomGenerator.Next(-1000000, 1000000);
                dtRow["SampleDate"] = GetRandomDate(DateTime.Now.AddYears(-5), DateTime.Now.AddDays(5));
                dtRow["SampleString"] = $"Value {randomGenerator.Next(-1000000, 1000000)}";
                dt.Rows.Add(dtRow);
            }
        }

        private void btnSQL_Click(object sender, EventArgs e)
        {
            CreateTable();



            ExportMSSQL objExportSQSQL = new ExportMSSQL(dt);
            objExportSQSQL.strDataSource = "DESKTOP-MDA6AMN\\SQLEXPRESS";
            objExportSQSQL.strInitialCatalog = "MockData";
            objExportSQSQL.strUserID = "sa";
            objExportSQSQL.strPassword = "Test@123";

            string strCreateTable = ExportMSSQL.CreateTABLEStatement("tblTest", dt);

            objExportSQSQL.ExecuteNonQuery("DROP TABLE tblTest");

            objExportSQSQL.ExecuteNonQuery(strCreateTable);

            objExportSQSQL.ExporttoDB("tblTest");

            MessageBox.Show("Export to SQL Success.");
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            CreateTable();

            ExportXML objExportXML = new ExportXML(dt);
            objExportXML.filePath = $"{Directory.GetCurrentDirectory()}\\GeneratedData";
            Directory.CreateDirectory(objExportXML.filePath);
            objExportXML.ExportToXML("mockData.xml");
            MessageBox.Show("Data Generated Succesfully");
        }
    }
}