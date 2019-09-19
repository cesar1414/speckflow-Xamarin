using Notes_auto.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xamarin.UITest;

namespace Notes_auto.Hooks
{
    [Binding]
    public sealed class CreateDeleteNote
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private Note note = new Note();
        private HomePage home = new HomePage();
        private NewNote newNote = new NewNote();
        private UpdateNote UpdateNote = new UpdateNote();
        public IApp app = StartApp2.Instance;


        [BeforeScenario("CreateNote")]
        public void CreateNote()
        {
            note.title = "patito hook";
            note.description = "patito description Hook";
            home.ClickMoreBtn();
            newNote.FillData(note);
            newNote.ClickSaveBtn();
            home.VerifyIfNoteIsDisplayed(note.title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
        }
    }
}
