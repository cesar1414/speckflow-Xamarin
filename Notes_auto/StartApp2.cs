using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace Notes_auto
{
    [TestFixture(Platform.iOS)]
    class StartApp2
    {
        private static IApp app = null;

        private StartApp2() { }

        public static IApp Instance
        {
            get
            {
                if (app == null)
                {
                    app = ConfigureApp
                    .iOS
                    .Debug()
                    .InstalledApp("com.companyname.Notes")
                    .StartApp();
                }
                return app;
            }
        }
    }
}
