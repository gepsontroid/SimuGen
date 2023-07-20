using Newtonsoft.Json;
using System.Data;
using System.Text;

namespace ExportJSON
{
    public class Exporter
    {
        protected DataTable _dtExport { get; set; }
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
        public string ExportToJSON()
        {
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(_dtExport);
            return JSONString;
        }
    }
}
