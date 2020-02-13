
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using System.Threading;
using System;

namespace CalculatorTest
{
    [TestClass]
    public class ScenarioScientific : CalculatorSession
    {
        private static WindowsElement header;
        private static WindowsElement calculatorResult;

        [TestMethod]
        public void ScientificPi()
        {
            session.FindElementByName("Pi").Click();
            
            Assert.AreEqual("3.1415", GetCalculatorResultText().Substring(0,6));
        }
        [TestMethod]
        public void ScientificEulersNum()
        {
            session.FindElementByName("Euler's number").Click();

            Assert.AreEqual("2.7182", GetCalculatorResultText().Substring(0, 6));
        }
        [TestMethod]

        public void ScientificReciprocal()
        {
            session.FindElementByName("Eight").Click();
            session.FindElementByName("Reciprocal").Click();

            Assert.AreEqual("0.125", GetCalculatorResultText());
        }
        [TestMethod]
        
        public void ScientificAbsoluteValue()
        {
            session.FindElementByName("Eight").Click();
            session.FindElementByName("Positive Negative").Click();
            session.FindElementByName("Absolute Value").Click();

            Assert.AreEqual("8", GetCalculatorResultText());
        }
        [TestMethod]
        [DataRow("Eight", "64")]
        [DataRow("Two", "4")]
        [DataRow("Zero", "0")]
        
        public void ScientificSquare(string input,string expectedResult)
        {
            session.FindElementByName(input).Click();
            session.FindElementByName("Square").Click();
            

            Assert.AreEqual(expectedResult, GetCalculatorResultText());
        }
        [TestMethod]
        [DataRow("Eight", "Nine","8")]
        [DataRow("Two", "One","0")]
        [DataRow("Seven", "Three","1")]

        public void ScientificModulo(string input,string secondInput, string expectedResult)
        {
            session.FindElementByName(input).Click();
            session.FindElementByName("Modulo").Click();
            session.FindElementByName(secondInput).Click();
            session.FindElementByName("Equals").Click();
            Assert.AreEqual(expectedResult, GetCalculatorResultText());
        }
        [TestMethod]
        

        public void ScientificExponential()
        {
            session.FindElementByName("Five").Click();
            session.FindElementByName("Exponential").Click();
            session.FindElementByName("Three").Click();
            session.FindElementByName("Plus").Click();
            session.FindElementByName("Five").Click();
            session.FindElementByName("Zero").Click();
            session.FindElementByName("Zero").Click();
            session.FindElementByName("Zero").Click();
            session.FindElementByName("Equals").Click();
            Assert.AreEqual("10,000", GetCalculatorResultText());
        }
        [TestMethod]
        [DataRow( "Five", "125")]
        [DataRow("Four", "64")]
        [DataRow("Nine","729")]

        public void ScientificCube(string input, string expectedResult)
        {
            session.FindElementByName(input).Click();
            session.FindElementByName("Cube").Click();
            
            Assert.AreEqual(expectedResult, GetCalculatorResultText());
        }
        [TestMethod]

        public void ScientificParentheses()
        {
            session.FindElementByName("Seven").Click();
            session.FindElementByName("Multiply by").Click();
            session.FindElementByName("Left parenthesis").Click();
            session.FindElementByName("Three").Click();
            session.FindElementByName("Plus").Click();
            session.FindElementByName("Four").Click();
            session.FindElementByName("Right parenthesis").Click();
            session.FindElementByName("Equals").Click();


            Assert.AreEqual("49", GetCalculatorResultText());
        }
        [TestMethod]
        [DataRow("Three", "6")]
        [DataRow("Four", "24")]
        [DataRow("Nine", "362,880")]

        public void ScientificFactorial(string input,string expectedResult)
        {
            session.FindElementByName(input).Click();
            session.FindElementByName("Factorial").Click();

            Assert.AreEqual(expectedResult, GetCalculatorResultText());
        }
        [TestMethod]
        [DataRow("Eight", "Nine", "134,217,728")]
        [DataRow("Two", "One", "2")]
        [DataRow("Seven", "Three", "343")]

        public void ScientificExponent(string input, string secondInput, string expectedResult)
        {
            session.FindElementByName(input).Click();
            session.FindElementByName("'X' to the exponent").Click();
            session.FindElementByName(secondInput).Click();
            session.FindElementByName("Equals").Click();
            Assert.AreEqual(expectedResult, GetCalculatorResultText());
        }
        [TestMethod]
        [DataRow("Eight", "100,000,000")]
        [DataRow("Two", "100")]
        [DataRow("Zero", "1")]

        public void ScientificTentotheexponent(string input, string expectedResult)
        {
            session.FindElementByName(input).Click();
            session.FindElementByName("Ten to the exponent").Click();


            Assert.AreEqual(expectedResult, GetCalculatorResultText());
        }
        [TestMethod]
        

        public void ScientificLog()
        {
            session.FindElementByName("One").Click();
            session.FindElementByName("Zero").Click();
            session.FindElementByName("Zero").Click();
            session.FindElementByName("Zero").Click();
            session.FindElementByName("Log").Click();


            Assert.AreEqual("3", GetCalculatorResultText());
        }
        [TestMethod]


        public void ScientificNaturalLog()
        {
            session.FindElementByName("One").Click();
            session.FindElementByName("Natural log").Click();


            Assert.AreEqual("0", GetCalculatorResultText());
        }
        [TestMethod]

        public void ScientificFunctionFloor()
        {
            session.FindElementByName("Six").Click();
            session.FindElementByName("Decimal Separator").Click();
            session.FindElementByName("Six").Click();
            session.FindElementByName("Function").Click();
            session.FindElementByName("Floor").Click();


            Assert.AreEqual("6", GetCalculatorResultText());
        }
        [TestMethod]

        public void ScientificFunctionCeiling()
        {
            session.FindElementByName("Six").Click();
            session.FindElementByName("Decimal Separator").Click();
            session.FindElementByName("Six").Click();
            session.FindElementByName("Function").Click();
            session.FindElementByName("Ceiling").Click();


            Assert.AreEqual("7", GetCalculatorResultText());
        }
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            // Create session to launch a Calculator window
            Setup(context);

            // Identify calculator mode by locating the header
            try
            {
                header = session.FindElementByAccessibilityId("Header");
            }
            catch
            {
                
                header = session.FindElementByAccessibilityId("ContentPresenter");
            }

            // Ensure that calculator is in scientific mode
            if (!header.Text.Equals("Scientific", StringComparison.OrdinalIgnoreCase))
            {
                session.FindElementByAccessibilityId("TogglePaneButton").Click();
                Thread.Sleep(TimeSpan.FromSeconds(1));
                var splitViewPane = session.FindElementByClassName("SplitViewPane");
                splitViewPane.FindElementByName("Scientific Calculator").Click();
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Assert.IsTrue(header.Text.Equals("Scientific", StringComparison.OrdinalIgnoreCase));
            }

            // Locate the calculatorResult element
            calculatorResult = session.FindElementByAccessibilityId("CalculatorResults");
            Assert.IsNotNull(calculatorResult);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TearDown();
        }

        [TestInitialize]
        public void Clear()
        {
            session.FindElementByName("One").Click();
            session.FindElementByName("Clear entry").Click();
            Assert.AreEqual("0", GetCalculatorResultText());
        }

        private string GetCalculatorResultText()
        {
            return calculatorResult.Text.Replace("Display is", string.Empty).Trim();
        }
    }
}
