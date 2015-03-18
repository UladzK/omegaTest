using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask_Vladimir.Logic.LanguageDetectionUtils
{
    //represents entity of ws.detectlanguage response
    public class Detection
    {
        public string language { get; set; }
        public bool isReliable { get; set; }
        public float confidence { get; set; }
    }
}