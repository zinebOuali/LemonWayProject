using System;
using System.Web.Services;
using System.Xml;

namespace WebServices
{
	/// <summary>
	/// Summary description for HelloWorld
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class WebServices : System.Web.Services.WebService
	{

		/// <summary>
		/// returns the nth element of Fibonacci sequence
		/// </summary>
		/// <param name="n"></param>
		/// <returns>int</returns>
		[WebMethod]
		public int Fibonacci(int n)
		{

			if (n < 1 || n > 100)
			{
				return -1;
			}

			if (n == 1 || n == 2)
			{
				return 1;
			}
			else
			{
				return Fibonacci(n - 1) + Fibonacci(n - 2);
			}

		}
		/// <summary>
		/// returns json from xml input
		/// </summary>
		/// <param name="xml"></param>
		/// <returns>string</returns>
		[WebMethod]
		public string XmlToJson(string xml)
		{

			try
			{
				XmlDocument doc = new XmlDocument();
				doc.LoadXml(xml);
				RemoveAttributes(doc.ChildNodes);
				return Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);
			}
			catch (Exception)
			{

				return "Bad Xml format";
			}

		}


		private void RemoveAttributes(XmlNodeList doc)
		{
			foreach (XmlNode element in doc)
			{
				element.Attributes?.RemoveAll();
				if (element.ChildNodes.Count != 0)
				{
					RemoveAttributes(element.ChildNodes);
				}
			}
		}
	}
}
