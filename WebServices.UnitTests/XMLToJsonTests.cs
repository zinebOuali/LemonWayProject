using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebServices.UnitTests
{
	[TestClass]
	public class XMLToJsonTests
	{
		[TestMethod]
		public void XML_To_Json_Resturns_Json_When_XML_Is_Well_Formed()
		{
			//arrange
			WebServices services = new WebServices();
			string input = "<foo>bar</foo>";
			//act
			string output = services.XmlToJson(input);
			//assert
			Assert.AreEqual("{\"foo\":\"bar\"}", output);
		}

		[TestMethod]
		public void XML_To_Json_Resturns_Json_And_Ignore_Attributes_When_XML_Is_Well_Formed()
		{
			//arrange
			WebServices services = new WebServices();
			string input = "<foo attr=\"value\">bar</foo>";
			//act
			string output = services.XmlToJson(input);
			//assert
			Assert.AreEqual("{\"foo\":\"bar\"}", output);
		}

		[TestMethod]
		public void XML_To_Json_Resturns_BadFormat_When_XML_Is_Not_Well_Formed()
		{
			//arrange
			WebServices services = new WebServices();
			string input = "<foo>hello</bar>";
			//act
			string output = services.XmlToJson(input);
			Assert.AreEqual("Bad Xml format", output);
		}
	}
}
