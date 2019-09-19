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
    public partial class NoteEntryPage : ContentPage //esta vista es para modificar una nota o crear una nueva
    {
        public NoteEntryPage()
        {
            InitializeComponent();
        }

        public async void SavePressed(object sender, EventArgs e)
        {
            var note = BindingContext as Note;
            
            //---------archivos------------//
            //if (string.IsNullOrEmpty(note.Filename))
            //{
            //    var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
            //    File.WriteAllText(filename, note.Title);
            //    File.WriteAllText(filename, note.Description);
            //}
            //else
            //{
            //    File.WriteAllText(note.Filename, note.Title);
            //    File.WriteAllText(note.Filename, note.Description);
            //}

            // database //
            note.Date = DateTime.Now;

            if (await App.noteDbContext.SaveData(note) > 0)
            {
                await DisplayAlert("Success", "The note was saved successfully", "Ok");
            }
            await this.Navigation.PopAsync(); //volvemos a la pagina anterior

        }

        public async void DeletePressed(object sender, EventArgs e)
        {
            var note = BindingContext as Note;

            // archivos //
            //if (File.Exists(note.Filename))
            //{
            //    File.Delete(note.Filename);
            //}

            //db ////
            if (await DisplayAlert("Delete note", "Are you shure that you want to delete this note?", "Yes", "No"))
            {
                await App.noteDbContext.DeleteNote(note);
            }

            await this.Navigation.PopAsync(); //volvemos a la pagina anterior
        }
	}
}