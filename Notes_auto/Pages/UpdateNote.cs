using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace Notes_auto.Pages
{
    [TestFixture(Platform.Android)]
    class UpdateNote :BasePage
    {
        public IApp app = StartApp2.Instance;

        public Query btnDelete => x => x.Text("Delete");
        public Query btnYes => x => x.Id("button1");

        public override void WaitForLoadPage()
        {
            app.WaitForElement(this.BtnSave);
        }

        public void FillNewValues(Note note)
        {
            app.ClearText(this.TextTitle);
            app.EnterText(this.TextTitle, note.title);
            app.ClearText(this.TextDescription);
            app.EnterText(this.TextDescription, note.description);
        }

        public void ClickSaveBtn()
        {
            app.Tap(this.BtnSave);
        }

        public void ClickDeleteBtn()
        {
            app.Tap(btnDelete);
            app.Tap(btnYes);
        }
    }
}
