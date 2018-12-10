using NUnit.Framework;
using System;
using System.Linq;
using Xamarin.UITest;

namespace UITestiOS
{
    [TestFixture(Platform.iOS)]
    public class FunctionalTests
    {

        IApp app;
        Platform platform;

        public FunctionalTests(Platform platform)
        {
            this.platform = platform;
        }
        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        [TestCase("ButtonPlus")]
        [TestCase("ButtonDivide")]
        [TestCase("ButtonMultiply")]
        [TestCase("ButtonMinus")]
        [TestCase("ButtonEqual")]
        public void ClickingOpertationalButtonPassesValue(string button)
        {
            app.EnterText("EntryInput", "5");
            app.Tap(button);
            Assert.AreEqual(app.Query("EntryResult").First().Text, "5");
            Assert.AreEqual(app.Query("EntryInput").First().Text, "0");
        }
        [Test]
        [TestCase("5", "6", "11")]
        [TestCase("2", "0", "2")]
        [TestCase("55", "22", "77")]
        [TestCase("55", "", "55")]
        public void AddingTwoNumber(string num1, string num2, string outnum)
        {
            app.EnterText("EntryInput", num1);
            app.Tap("ButtonPlus");
            app.EnterText("EntryInput", num2);
            app.Tap("ButtonEqual");
            Assert.AreEqual(outnum, app.Query("EntryResult").First().Text);
        }

        [Test]
        [TestCase("11", "6", "5")]
        [TestCase("7", "0", "7")]
        [TestCase("77", "22", "55")]
        [TestCase("", "55", "-55")]
        public void SubtractingTwoNumber(string num1, string num2, string outnum)
        {
            app.EnterText("EntryInput", num1);
            app.Tap("ButtonMinus");
            app.EnterText("EntryInput", num2);
            app.Tap("ButtonEqual");
            Assert.AreEqual(outnum, app.Query("EntryResult").First().Text);
        }

        [Test]
        [TestCase("11", "6", "66.00")]
        [TestCase("", "33", "0.00")]
        [TestCase("77", "22", "1694.00")]
        [TestCase("12", "0", "0.00")]

        public void MultiplyingTwoNumber(string num1, string num2, string outnum)
        {
            app.EnterText("EntryInput", num1);
            app.Tap("ButtonMultiply");
            app.EnterText("EntryInput", num2);
            app.Tap("ButtonEqual");
            Assert.AreEqual(outnum, app.Query("EntryResult").First().Text);
        }

        [Test]
        [TestCase("66", "6", "11.00")]
        [TestCase("99", "32", "3.09")]
        [TestCase("77", "0", "77")]
        [TestCase("", "77", "0.00")]

        public void DividingTwoNumber(string num1, string num2, string outnum)
        {
            app.EnterText("EntryInput", num1);
            app.Tap("ButtonDivide");
            app.EnterText("EntryInput", num2);
            app.Tap("ButtonEqual");
            Assert.AreEqual(outnum, app.Query("EntryResult").First().Text);
        }

        [Test]
        [TestCase("66", "6", "0")]
        [TestCase("99", "32", "3")]
        [TestCase("77", "0", "77")]
        [TestCase("", "77", "0")]

        public void ModuloOfTwoNumber(string num1, string num2, string outnum)
        {
            app.EnterText("EntryInput", num1);
            app.Tap("ButtonModulo");
            app.EnterText("EntryInput", num2);
            app.Tap("ButtonEqual");
            Assert.AreEqual(outnum, app.Query("EntryResult").First().Text);
        }

        [Test]
        [TestCase("66", "8.12")]
        [TestCase("144", "12.00")]
        [TestCase("0", "0.00")]
        [TestCase("","0.00")]

        public void SquareRootaNumber(string num1, string outnum)
        {
            app.EnterText("EntryInput", num1);
            app.Tap("ButtonSqrt");
            Assert.AreEqual(outnum, app.Query("EntryResult").First().Text);
        }

        [Test]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        public void AddingMultipleNumber()
        {
            string[] num = GenerateArray();
            int l = num.Length;
            if (l > 2)
                for (int i = 0; i < l - 2; i++)
                {
                    string numi = num[i];
                    app.EnterText("EntryInput", numi);
                    app.Tap("ButtonPlus");
                }
            app.EnterText("EntryInput", num[num.Length - 2]);
            app.Tap("ButtonEqual");
            Assert.AreEqual(num[l - 1], app.Query("EntryResult").First().Text);
        }



        private string[] GenerateArray()
        {
            Random random = new Random();
            int n = random.Next(2, 10);
            string[] output = new string[n + 1];
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                int val = random.Next(0, 99999);
                sum += val;
                output[i] = val.ToString();
            }
            output[n] = sum.ToString();
            return output;
        }
    }



}
