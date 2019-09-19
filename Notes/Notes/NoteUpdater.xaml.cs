using Notes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteUpdater : ContentPage
    {
        public NoteUpdater()
        {
            InitializeComponent();
        }
        
        public async void SavePressed(object sender, EventArgs e)
        {
            var note = BindingContext as Note;
            note.Date = DateTime.Now;
            await App.noteDbContext.SaveData(note);
            await Navigation.PopAsync();
        }

        public async void DeletePressed(object sender, EventArgs e)
        {
            var note = BindingContext as Note;
            if (await DisplayAlert("Delete Note", "Are you shure you want to delete this note?", "Yes", "No"))
            {
                await App.noteDbContext.DeleteNote(note);
            }
            
            await Navigation.PopAsync();
        }
	}
}