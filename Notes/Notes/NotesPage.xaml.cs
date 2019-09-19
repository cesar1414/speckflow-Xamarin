using Notes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NotesPage : ContentPage
	{
		public NotesPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing() // When the page appears, the OnAppearing method is executed,
        {
            //---------archivs------//
            //base.OnAppearing();//cuando se sobreescribe , se puede customizar su comportamiento ni bien sea visible la pagina

            //var notes = new List<Note>();
            //var files = Directory.EnumerateFiles(App.FolderPath, "*.notes.txt");//retorna todos los files existentes en ese path
            //foreach (var filename in files)
            //{
            //    var lines = File.ReadAllLines(filename);
            //    notes.Add(new Note
            //    {
            //        Title = lines[0],
            //        Description = lines[1],
            //        Filename = filename,
            //        Date = File.GetCreationTime(filename)
            //    });
            //}

            //listNotes.ItemsSource = notes.OrderBy(note => note.Date).ToList();

            //----------db--------//
            base.OnAppearing();
            listNotes.ItemsSource = await App.noteDbContext.GetAllNotes();
        }

        public async void NoteAddClicked(object sender, EventArgs e) //boton + del toolbar
        {
            await this.Navigation.PushAsync(new NoteEntryPage()
            {
                BindingContext = new Note() //el binding context de la pagina sera un nuevo objecto nota, entonces se jalara a la UI las props de este objecto
            });
        }

        public async void ListItemSelected(object sender, SelectedItemChangedEventArgs e) // cuando se seleccione una nota
        {
            await this.Navigation.PushAsync(new NoteUpdater()
            {
                BindingContext = e.SelectedItem as Note //jalara a la ui los props de una nota existente osea un update
            });
        }

    }
}