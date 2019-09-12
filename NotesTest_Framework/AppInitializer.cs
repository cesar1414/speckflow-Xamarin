using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace NotesTest_Framework
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .Debug()
                    .InstalledApp("com.companyname.Notes")
                    .StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}