using NUnit.Framework;
using System;
using System.Linq;
using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace Notes_auto.Pages
{
    [TestFixture(Platform.Android)]
    class HomePage
    {
        public IApp app = StartApp2.Instance;

        public Query btnMyNote => x => x.Text("My notes");
        public Query btnMore => x => x.Text("+");

        public void ClickMoreBtn()
        {
            app.Tap(btnMyNote);
            app.Tap(btnMore);
        }

        public void VerifyIfNoteIsDisplayed(string title)
        {
            app.WaitForElement(x => x.Text(title));
            var containsValue = app.Query(x => x.Text(title).All()).Count();
            Assert.That(containsValue, Is.EqualTo(1));
            app.Back();
        }

        public void ClickOwerNote(string title)
        {
            app.Tap(btnMyNote);
            app.Tap(x => x.Text(title));
        }

        public void VerifyIfNoteIsNotDisplayed(string title)
        {
            app.WaitForNoElement(x => x.Text(title), "not displayed", TimeSpan.FromSeconds(4));
            app.Back();
        }
    }
}
