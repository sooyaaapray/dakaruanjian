using ClockIn.Client.Entity;
using System.Net;

namespace ClockIn.Client.Common
{
    public class ResultData
    {
        public ResultData(string resultData, HttpStatusCode statusCode)
        {
            _resultData= resultData; ;
            _statusCode = statusCode;
        }

        public string _resultData;
        public string Result 
        {
            get { return _resultData; }
            set { _resultData = value; }
        }

        public HttpStatusCode _statusCode;
        public HttpStatusCode StatusCode
        {
            get { return _statusCode; }
            set { _statusCode = value; }
        }
    }
}
