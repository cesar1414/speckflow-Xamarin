using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Notes_auto
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            //if (platform == Platform.Android)
            //{
            //    return ConfigureApp
            //        .Android
            //        .InstalledApp("com.companyname.Notes")
            //        .StartApp();
            //}

            return ConfigureApp
                //Xamarin.Calabash.Start();
                .iOS
                .InstalledApp("com.companyname.Notes")
                //.DeviceIp("172.21.7.241")
                .DeviceIdentifier("4D01434B-79D3-4C12-93A5-5D0D09D61ECD")
                .StartApp();
                //.Xamarin.Calabash.Start()
        }
    }
}