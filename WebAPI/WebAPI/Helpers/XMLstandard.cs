// using RestSharp;
using System.IO;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using WebAPI.Models;

namespace WebAPI.Helpers
{
    public static class XMLstandard
    {
        public static T XmlDeserialize<T>(this string toDeserialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringReader textReader = new StringReader(toDeserialize))
            {
                return (T)xmlSerializer.Deserialize(textReader);
            }
        }

        public static string XmlSerialize<T>(this T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }

        public static string serializaXML(businessClass _business, urlClass _url)
        {
            P p = new P();
            p.business = _business;
            p.url = _url;

            string regresa = XMLstandard.XmlSerialize(p);
            return regresa;
        }

        public static void deserializaXML(string _Xml)
        {
            P p = new P();
            p = XMLstandard.XmlDeserialize<P>(_Xml);
        }

        public static string encriptarPaso1(string _xml)
        {
            string originalString = _xml;
            string key = "5DCC67393750523CD165F17E1EFADD21";
            string encryptedString =
              AESCrypto.encrypt(originalString, key);
            string finalString = encryptedString.Replace("%", "%25").Replace(" ", "%20").Replace("+", "%2B").Replace("=", "%3D").Replace("/", "%2F");

            return finalString;
        }

        public static string desencriptarRecepcion(string token)
        {
            string originalString = token;
            string key = "5DCC67393750523CD165F17E1EFADD21";
            string decryptedString = AESCrypto.decrypt(key, originalString);
            return decryptedString;
        }

        public static string leerXml(string _Xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(_Xml);

            XmlNodeList elemList = doc.GetElementsByTagName("nb_url");
            return elemList[0].InnerText;
        }
        /*
        public static string SendPost(string _cadena)
        {
            string encodedString = HttpUtility.UrlEncode("<pgs><data0>SNDBX123</data0><data>" + _cadena + "</data></pgs>");
            string postParam = "xml=" + encodedString;
            var client = new RestClient("https://wppsandbox.mit.com.mx/gen");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddQueryParameter(postParam, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            return content;
        }*/
    }
}
