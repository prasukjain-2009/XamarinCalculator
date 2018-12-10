using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UiTest2
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }
        [Test]
        public void EntryResultAndEntryInitializeWithZero()
        {
            //Assert.AreNotEqual(0,app.Query("EntryInput").Length);\
            //var result = app.WaitForElement("EntryInput");
            //Assert.AreEqual(1, result.Length);
            //Assert.NotZero(app.Query("EntryResult").Length);
            Assert.AreEqual(app.Query("EntryResult").First().Text, "0");
            Assert.AreEqual(app.Query("EntryInput").First().Text, "0");
            Assert.IsFalse(app.Query("EntryResult").First().Enabled);
            Assert.IsTrue(app.Query("EntryInput").First().Enabled);
        }
        [Test]
        public void OperationButtonsArePresentAndEnabled()
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
            result = app.WaitForElement("ButtonEqual");
            Assert.AreEqual(1, result.Length);
            Assert.True(result.First().Enabled);
        }
        [Test]
        public void ReplTest()
        {
            app.Repl();
        }
    }
}
