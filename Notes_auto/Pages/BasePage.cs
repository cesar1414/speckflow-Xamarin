using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace Notes_auto.Pages
{
    abstract class BasePage
    {
        public Query TextTitle => x => x.Marked("Enter a title");
        public Query TextDescription => x => x.Marked("Enter a description");
        public Query BtnSave => x => x.Text("Save");


        public abstract void WaitForLoadPage();
    }
}
