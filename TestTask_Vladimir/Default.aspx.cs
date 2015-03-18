using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Script.Services;
using System.Web.Services;
using TestTask_Vladimir.Logic;

namespace TestTask_Vladimir
{
    public partial class _Default : Page
    {
        private static readonly string IdentifyError = "Could not identify language";

        protected void Page_Load(object sender, EventArgs e)
        {
        }     

        [WebMethod]
        [ScriptMethod]
        public static string LangIdentify(string langBoxText)
        {
            var langRecognizer = new LangRecognizer();

            string lang = langRecognizer.Recognize(langBoxText);

            return lang;            
        }
    }
}