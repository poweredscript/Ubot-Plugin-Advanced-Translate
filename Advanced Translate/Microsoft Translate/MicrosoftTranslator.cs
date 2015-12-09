using System;
using System.IO;
using System.Net;

namespace MicrosoftTranslatorSdk
{
    class MicrosoftTranslator
    {
        public MicrosoftTranslator(string clientId, string clientSecret)
        {
            _auth = new AdmAuthentication(clientId, clientSecret);
        }
        private AdmAuthentication _auth;

        public string Translate(string text, string from, string to)
        {
            string uri = "http://api.microsofttranslator.com/v2/Http.svc/Translate?text=" + System.Web.HttpUtility.UrlEncode(text) + "&from=" + from + "&to=" + to;
            string authToken = "Bearer" + " " + _auth.GetAccessToken().access_token;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Headers.Add("Authorization", authToken);

            WebResponse response = null;
            try
            {
                response = httpWebRequest.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    System.Runtime.Serialization.DataContractSerializer dcs = new System.Runtime.Serialization.DataContractSerializer(Type.GetType("System.String"));
                    string translation = (string)dcs.ReadObject(stream);
                    //Console.WriteLine("Translation for source text '{0}' from {1} to {2} is", text, from, to);
                    return translation;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}