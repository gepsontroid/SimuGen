using System.Data;

namespace Mockooo.Models
{
    public class DataModel :DataColumn
    {
        public string MockColumnName { get; set; }
        public string MockDataType { get; set; }
        public Object MockMinValue { get; set; }
        public Object MockMaxValue { get; set; }
        public int MockPrecision { get; set; } = 2;


    }
    public class UserDataModel
    {
        public string MockFieldName { get; set; }
        public string MockFieldDataType { get; set; }
        public object MockMinValue { get; set; }
        public object MockMaxValue { get; set; }
        public int MockPrecision { get; set; }
    }
}
