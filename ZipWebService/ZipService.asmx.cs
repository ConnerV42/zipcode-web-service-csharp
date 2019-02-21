using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ZipWebService.App_Code;
using System.Xml;
using System.Web.Script.Services;

namespace ZipWebService
{
    [WebService(Namespace = "http://thatman.connercodes.com/ZipService")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ZipService : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetZip(string zip)
        {
            return Service.ReadZipFromDatabase(zip);
        }
    }
}
