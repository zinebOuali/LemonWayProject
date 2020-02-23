using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace WebServices.UnitTests
{
	[TestClass]
	public class FibonacciMethodTests
	{
		[TestMethod]
		public void Fibonacci_Returns_MinusOne_When_Input_Is_110()
		{
			//arrange
			WebServices services = new WebServices();
			int input = 110;
			//act
			int result = services.Fibonacci(input);
			//assert
			Assert.AreEqual(-1, result);
		}

		[TestMethod]
		public void Fibonacci_Returns_MinusOne_When_Input_Is_0()
		{

			//arrange
			WebServices services = new WebServices();
			int input = 0;
			//act
			int result = services.Fibonacci(input);
			//assert
			Assert.AreEqual(-1, result);
		}

		[TestMethod]
		public void Fibonacci_Returns_One_When_Input_Is_1()
		{
			//arrange
			WebServices services = new WebServices();
			int input = 1;
			//act
			int result = services.Fibonacci(input);
			//assert
			Assert.AreEqual(1, result);
		}

		[TestMethod]
		public void Fibonacci_Returns_One_When_Input_Is_2()
		{
			//arrange
			WebServices services = new WebServices();
			int input = 2;
			//act
			int result = services.Fibonacci(input);
			//assert
			Assert.AreEqual(1, result);
		}

		[TestMethod]
		public void Fibonacci_Returns_Number_When_Input_Is_InRange()
		{
			//arrange
			WebServices services = new WebServices();
			int input = 6;
			//act
			int result = services.Fibonacci(input);
			//assert
			Assert.AreEqual(8, result);
		}
	}
}
