using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Notes_auto
{
    //[TestFixture(Platform.Android)]
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
        public void WelcomeTextIsDisplayed()
        {
            app.Repl();
        }

        [Test]
        public void HappyPAth()
        {
            //click button init
            app.Tap(x => x.Id("NoResourceEntry-5"));
            //click "+"
            app.Tap(x => x.Id("NoResourceEntry-0"));
            //enter fill title
            app.EnterText(x => x.Id("NoResourceEntry-12"), "aux-patito-one");
            //enter description
            app.EnterText(x => x.Id("NoResourceEntry-13"), "description");
            //click "save"
            app.Tap(x => x.Id("NoResourceEntry-14"));
            //close popup successe full
            app.Tap(x => x.Id("button2"));
            //validate
            var containsValue = app.Query(x => x.Text("aux-patito-one").All().Text("aux-patito-one")).Count();
            Assert.That(containsValue, Is.EqualTo(1));
        }
    }
}
