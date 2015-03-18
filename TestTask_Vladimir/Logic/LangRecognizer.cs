using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Microsoft.Ajax.Utilities;
using RestSharp;
using TestTask_Vladimir.Logic.LanguageDetectionUtils;
using TestTask_Vladimir.Model;

namespace TestTask_Vladimir.Logic
{
    public class LangRecognizer
    {
        private WordsRepository rep;
        private RestClient client;
        private RestRequest request;
        //api key for ws.detectlanguage
        private readonly string apiKey = "181452bb35f1431da5287e48c95747bf";

        public LangRecognizer()
        {
            rep = WordsRepository.Instance;
            client = new RestClient("http://ws.detectlanguage.com");
            request = new RestRequest("/0.2/detect", Method.POST);
            request.AddParameter("key", apiKey);
        }

        public string Recognize(string word)
        {
            //try to get already recognized language of cached word
            var w = rep.GetWord(word);
            
            if (w != null)
            {
                return w.Lang;
            }

            request.AddParameter("q", word);

            IRestResponse response = client.Execute(request);

            var deserializer = new RestSharp.Deserializers.JsonDeserializer();

            var result = deserializer.Deserialize<Result>(response);

            Detection detection = result.data.detections[0];

            if (detection != null)
            {
                CacheWord(word, detection.language, detection.confidence);

                return detection.language;
            }
               
            return null;                           
        }

        private void CacheWord(string word, string lang, float confidence)
        {
            rep.AddWord(word, lang, confidence.ToString());
        }

    }
}