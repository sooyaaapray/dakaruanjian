using ClockIn.Client.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.IDAL
{
    public interface IWebDataBase
    {
        Task<ResultData> PostDatas(string uri, Dictionary<string, HttpContent> contents);
        MultipartFormDataContent GetFormData(Dictionary<string, HttpContent> contents);
        Task<ResultData> GetDatas(string uri);

    }
}
