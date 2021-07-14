using RestSharp;
using System.IO;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using WebAPI.Models;
using System.Net.Http;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System;
using Newtonsoft.Json;
using System.Threading.Tasks;

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
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces(); // Agregado 13-Jul-21
            ns.Add("", ""); // Agregado 13-Jul-21
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringWriter textWriter = new Utf8StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize, ns); // Modificado 13-Jul-21
                return textWriter.ToString();
            }
        }

        public class Utf8StringWriter : StringWriter // Agregado 13-Jul-21
        {
            public override Encoding Encoding => Encoding.UTF8;
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

        public static string CifrarCadena(string _xml) // Renombrado para coincidir con la guía de integración
        {
            string originalString = _xml;
            string key = "5DCC67393750523CD165F17E1EFADD21";
            string encryptedString =
              AESCrypto.encrypt(originalString, key);
            string finalString = encryptedString.Replace("%", "%25").Replace(" ", "%20").Replace("+", "%2B").Replace("=", "%3D").Replace("/", "%2F");

            return finalString;
        }

        public static string DescifrarRespuesta(string token)
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
        
        public static string ServicioDeGeneracion(string _cadena)
        {
            string miCadena = "7htA3FqdvDT9zU+Y7YKi3RJPNLXr1Gl6TpHbl6aNtdD9DJ4XEzKSKkoJzLzcPhYTPOxU6CYTYzG3WJG67tBMex5MMausxmybcTkrh2Q+sOYVGh3MuhVMSOWP3RpynigirvwlmIOT8YErCK/+5Tr5jNlClm0GIiVY3OLsQ9KRTixlO6WnPRkkBFByoAPUeBTwdkr/VmN3T/65nxbA9lPfJMY+CpbWj6ry/IxgktOtZBvmrzSjSF1V6XfRr8W0kdQWc82wi6iBf7jRhFBPxJC3ct7KMUuYzzfpk63LPjgF6tFq3j7DTJMMw+2b+eDgzu1QUJzXeN8XTSQmSboBOF9cgDR2BNVYZB/gFP9N/VSq8Ips0gX+QMX4gr38QoH1UW5WzD7FZ6EN+JHwcJQIHjNxo+aR/H2lHlH44Pr+kBgb4oL5erKgpRmDGrAKSfGlmtrT2rA3LZ5XoM9NglznJiHvY2ceaaRLgp3c4c691JfW0tnVQvQnQ8iNKKl5ssJv7IevkER0W1VRQUGEjUTeI5RZWcvv38MDk1xBmQz3y4Yhf+qxc3Q+DyjalI0hAitfJaDusLaoS4G87RbKqDgj0hbXFNJKrsFfJN3pQqQzZtaIyXjLn0auNEbjc1AYGmhFmFqykbZJlJ8dDQPkFr6TO8WR9qPiKq4zH+T/HV07Wr1VZUjwQoa/JYTU14UVNyG8dJrMoxQAUCW/3RmqWuNLk+g7RLNGdXcMaCgS3/VWzc2t/2zfbS8hsORMOIgdgYu1LJ+rzLVw9UQy8lCzA9nA9a6/0KucTzfQK0eRwhSuxfX9NGJWqf29B+GJYZ22MB0Lw6KFk7/pXtuiMxYuNOLSvMpNjjBVJt0pJ53dkrzvWHhg65XmQYVY/9TenrSnXj1iX70Oxw0aDZj+YU2ljgqABxqPM92MRI2PZs4Lrrp5PVWsy8i491/TSNJx9tQaUlr9N17GbmGCN7Bm7KyLJV9Zaq49onXOnTzR12ba7Zn5uGnGXQbCQJ0wIFIixswjwLeiJ82fXRkzRZoz53YEF/kwJr+IsFwJtlkYOKV1GNUN9DWlL+ySy/ykymRQFh9WVCNDXSo10fy4loBmbnklkW0f+09GWdDFOaq05j0iA19ZhJbHmn4=";

            // Cadena fija, asignada al comercio continua estando hardcodeada
            // La implementación en la guía de integración utiliza http://restsharp.org v105

            string encodedString = HttpUtility.UrlEncode("<pgs><data0>SNDBX123</data0><data>" + miCadena + "</data></pgs>");
            string postParam = "xml=" + encodedString;

            // HttpClient
            /*
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = true };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            client.BaseAddress = new Uri("https://wppsandbox.mit.com.mx/gen");
            */

            // RestSharp
            var client = new RestClient("https://wppsandbox.mit.com.mx/gen");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", postParam, ParameterType.RequestBody);
            
            IRestResponse response = client.Execute(request);
            var content = response.Content;

            return content;
        }
    }
}
