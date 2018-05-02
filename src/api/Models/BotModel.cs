using System.Collections.Generic;


namespace api.Models
{
    public class ReportSourceOfData
    {
        public string source_of_data_eng { get; set; }
        public string source_of_data_th { get; set; }
    }

    public class ReportRemark
    {
        public string report_remark_eng { get; set; }
        public string report_remark_th { get; set; }
    }

    public class DataHeader
    {
        public string report_name_eng { get; set; }
        public string report_name_th { get; set; }
        public string report_uoq_name_eng { get; set; }
        public string report_uoq_name_th { get; set; }
        public List<ReportSourceOfData> report_source_of_data { get; set; }
        public List<ReportRemark> report_remark { get; set; }
        public string last_updated { get; set; }
    }

    public class DataDetail
    {
        public string period { get; set; }
        public string currency_id { get; set; }
        public string currency_name_th { get; set; }
        public string currency_name_eng { get; set; }
        public string buying_sight { get; set; }
        public string buying_transfer { get; set; }
        public string selling { get; set; }
        public string mid_rate { get; set; }
    }

    public class Data
    {
        public DataHeader data_header { get; set; }
        public List<DataDetail> data_detail { get; set; }
    }

    public class Result
    {
        public string success { get; set; }
        public string api { get; set; }
        public string timestamp { get; set; }
        public Data data { get; set; }
    }

    public class RootObject
    {
        public Result result { get; set; }
    }
}