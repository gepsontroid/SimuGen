using System.Data;
using System.Text;

namespace ExportXML
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
    /// class for exporting datatable to XML
    /// </summary>
    public class ExportXML : Exporter
    {
        public ExportXML(DataTable dtExport) : base(dtExport)
        {
        }

        /// <summary>
        /// function for exporting to XML
        /// </summary>
        /// <param name="fileName">filename to which the data to be exported</param>
        /// <returns></returns>
        public string ExportToXML(string fileName = "mockdata.xml")
        {
            _dtExport.TableName = fileName;

            MemoryStream str = new MemoryStream();
            _dtExport.WriteXml(str, true);
            str.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(str);
            string xmlstr;
            xmlstr = sr.ReadToEnd();
            return (xmlstr);
        }
    }
}
