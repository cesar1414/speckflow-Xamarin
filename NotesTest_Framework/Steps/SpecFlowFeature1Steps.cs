using NUnit.Framework;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace NotesTest_Framework.Steps
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        private IApp app;

        [Given(@"I create a new item by following values")]
        public void GivenICreateANewItemByFollowingValues(Table table)
        {
            app = ConfigureApp
                   .Android
                   .Debug()
                   .InstalledApp("com.companyname.EAXamarinApp")
                   //.ApkFile(@"C:\ionictest\eanew\platforms\android\build\outputs\apk\android-debug.apk")
                   .StartApp();

            app.Tap(x => x.Marked("More options"));
            app.Tap(x => x.Text("Add"));
            app.EnterText(x => x.Id("txtTitle"), "EA");
            app.DismissKeyboard();
            app.EnterText(x => x.Id("txtDesc"), "Description");
            app.DismissKeyboard();
        }
        
        [When(@"I press add button")]
        public void WhenIPressAddButton()
        {
            app.Tap(x => x.Id("save_button"));
        }
        
        [Then(@"the item should be displayed")]
        public void ThenTheItemShouldBeDisplayed()
        {
            var elementCount = app.Query(x => x.Id("recyclerView").All().Text("EA")).Count();
            Assert.That(elementCount, Is.EqualTo(1), "There is no such element being added in app list");
        }
    }
}
