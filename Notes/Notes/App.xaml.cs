using Notes.Database;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Notes
{
    public partial class App : Application
    {
        //the advantage of exposing the database as a singleton is that a single database connection is created that's kept open while the application runs, 
        //    therefore avoiding the expense of opening and closing the database file each time a database operation is performed.
        public static NoteDbContext noteDbContext; //singleton
        public static string FolderPath { get; set; }
        public App()
        {
            InitializeComponent();
            noteDbContext = new NoteDbContext(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "coolNotes.db3"));
           // FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            MainPage = new NavigationPage(new Home())
            {
                BarBackgroundColor = Color.FromHex("#bf253c"),
                BarTextColor = Color.White
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
