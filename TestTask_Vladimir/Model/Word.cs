using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask_Vladimir.Model
{
    //implementing word model
    public class Word
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Lang { get; set; }

        public string Confidence { get; set; }
    }
}