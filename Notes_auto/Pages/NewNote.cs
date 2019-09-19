using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace Notes_auto.Pages
{
    class NewNote : BasePage
    {
        public IApp app = StartApp2.Instance;

        public Query BtnSuccess => x => x.Id("button2");


        public override void WaitForLoadPage()
        {
            app.WaitForElement(this.BtnSave);
        }

        public void FillData(Note note)
        {
            app.EnterText(this.TextTitle, note.title);
            app.EnterText(this.TextDescription, note.description);
        }

        public void ClickSaveBtn()
        {
            app.Tap(this.BtnSave);
            app.Tap(BtnSuccess);
        }
    }
}
