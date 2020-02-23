using System;
using System.IO;
using System.Net;
using System.Xml;

namespace WebServices.ConsoleClient
{
	public static class Helpers
	{
		private static readonly log4net.ILog log =
			   log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		public static HttpWebRequest CreateSOAPWebRequest()
		{
			//Making Web Request    
			HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(@"https://localhost:44322/WebServices.asmx");
			//SOAPAction    
			Req.Headers.Add(@"SOAPAction:http://tempuri.org/Fibonacci");
			//Content_type    
			Req.ContentType = "text/xml;charset=\"utf-8\"";
			Req.Accept = "text/xml";
			//HTTP method    
			Req.Method = "POST";
			//return HttpWebRequest    
			return Req;
		}

		public static string InvokeFibonacciService(int a)
		{
			log.Info($"Calculating Fibonaccifor {a}");
			string result;
			//Calling CreateSOAPWebRequest method    
			HttpWebRequest request = CreateSOAPWebRequest();

			XmlDocument SOAPReqBody = new XmlDocument();
			string query = String.Format($"<?xml version=\"1.0\" encoding=\"utf-8\"?><soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"><soap:Body><Fibonacci xmlns=\"http://tempuri.org/\"><n>{a}</n></Fibonacci></soap:Body></soap:Envelope>");
			SOAPReqBody.LoadXml(query);

			using (Stream stream = request.GetRequestStream())
			{
				SOAPReqBody.Save(stream);
			}
			//Geting response from request    
			using (WebResponse Serviceres = request.GetResponse())
			{
				using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
				{
					//reading stream    
					var ServiceResult = rd.ReadToEnd();
					XmlDocument doc = new XmlDocument();
					doc.LoadXml(ServiceResult);
					result = doc.InnerText;
				}
			}
			return result;
		}

	}
}
