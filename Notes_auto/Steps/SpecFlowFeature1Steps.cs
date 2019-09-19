using Notes_auto.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Notes_auto
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        private Note note;
        private HomePage home = new HomePage();
        private NewNote newNote = new NewNote();
        private UpdateNote updateNote = new UpdateNote();

        [Given(@"I create a new item by following values")]
        public void GivenICreateANewItemByFollowingValues(Table table)
        {
            note = table.CreateInstance<Note>();
            home.ClickMoreBtn();
            newNote.FillData(note);
        }

        [When(@"I press Save button")]
        public void WhenIPressAddButton()
        {
            newNote.ClickSaveBtn();
        }

        [Then(@"the item should be displayed on Home page")]
        public void ThenTheItemShouldBeDisplayed()
        {
            home.VerifyIfNoteIsDisplayed(note.title);
        }

        [Given(@"I Edit ""(.*)"" a Note by following values")]
        public void GivenIEditANewItemByFollowingValues(string title, Table table)
        {
            note = table.CreateInstance<Note>();
            home.ClickOwerNote(title);
            updateNote.FillNewValues(note);
        }

        [When(@"I press Save button on Update page")]
        public void WhenIPressAddButtonOnUpdatePage()
        {
            updateNote.ClickSaveBtn();
        }

        [Given(@"I Edit ""(.*)"" a Note")]
        public void GivenIEditANote(string title)
        {
            note = new Note();
            note.title = title;
            home.ClickOwerNote(title);
        }

        [When(@"I press Dlete button on Update page")]
        public void WhenIPressDleteButtonOnUpdatePage()
        {
            updateNote.ClickDeleteBtn();
        }

        [Then(@"the Note not displayed in Home page")]
        public void ThenTheNoteNotDisplayedInHomePage()
        {
            home.VerifyIfNoteIsNotDisplayed(note.title);
            ScenarioContext.Current.Set<Note>(new Note());
        }
    }
}
