using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITestiOS
{
    //[TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class StructuralTests
    {
        IApp app;
        Platform platform;

        public StructuralTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void EntryResultAndEntryInitializeWithZero()
        {
            var result = app.WaitForElement("EntryInput");
            Assert.AreEqual(1, result.Length);
            result = app.WaitForElement("EntryResult");
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(app.Query("EntryResult").First().Text, "0");
            Assert.AreEqual(app.Query("EntryInput").First().Text, "0");
            Assert.IsFalse(app.Query("EntryResult").First().Enabled);
            Assert.IsTrue(app.Query("EntryInput").First().Enabled);
        }
        [Test]
        public void OperationButtonsArePresent()
        {
            var result = app.WaitForElement("ButtonPlus");
            Assert.AreEqual(1, result.Length);
            Assert.True(result.First().Enabled);
            result = app.WaitForElement("ButtonMinus");
            Assert.AreEqual(1, result.Length);
            Assert.True(result.First().Enabled);
            result = app.WaitForElement("ButtonMultiply");
            Assert.AreEqual(1, result.Length);
            Assert.True(result.First().Enabled);
            result = app.WaitForElement("ButtonDivide");
            Assert.AreEqual(1, result.Length);
            Assert.True(result.First().Enabled);
            result = app.WaitForElement("ButtonSqrt");
            Assert.AreEqual(1, result.Length);
            Assert.True(result.First().Enabled);
            result = app.WaitForElement("ButtonModulo");
            Assert.AreEqual(1, result.Length);
            Assert.True(result.First().Enabled);
            result = app.WaitForElement("ButtonEqual");
            Assert.AreEqual(1, result.Length);
            Assert.True(result.First().Enabled);
        }

        [Test]
        [TestCase("Apple","0")]
        [TestCase(".,,.,,.4,5354", "45354")]
        [TestCase("sdsa$8", "8")]
        [TestCase("ssadhas6", "6")]
        [TestCase("6", "6")]
        public void EntryInputAcceptsOnlyNumber(string input, string output)
        {
            app.EnterText("EntryInput", input);
            Assert.AreEqual(output, app.Query("EntryInput").First().Text);
        }
        [Test]
        [TestCase("532", "532")]
        [TestCase("45354", "45354")]
        [TestCase("986865", "98686")]
        [TestCase("7895245665456", "78952")]
        [TestCase("6", "6")]
        public void EntryInputAcceptsOnlyFiveDigitNumber(string input, string output)
        {
            app.EnterText("EntryInput", input);
            Assert.AreEqual(output, app.Query("EntryInput").First().Text);
        }
        [Test]
        public void ClearButtonClearsData()
        {
            app.EnterText("EntryInput", "654");
            app.Tap("ButtonMultiply");
            app.EnterText("EntryInput", "65656");
            app.Tap("ButtonClear");
            Assert.AreEqual("0", app.Query("EntryInput").First().Text);
            Assert.AreEqual("0", app.Query("EntryResult").First().Text);
            app.EnterText("EntryInput", "66");
            app.Tap("ButtonEqual");
            Assert.AreEqual("66", app.Query("EntryResult").First().Text);
        }
    }
}