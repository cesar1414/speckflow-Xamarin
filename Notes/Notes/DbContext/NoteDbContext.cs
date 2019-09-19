using Notes.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Database
{
    public class NoteDbContext
    {
        readonly SQLiteAsyncConnection context;

        public NoteDbContext(string path)
        {
            context = new SQLiteAsyncConnection(path);
            context.CreateTableAsync<Note>();
        }

        public Task<int> SaveData(Note note)
        {
            if (note.Id != 0)
            {
                return context.UpdateAsync(note); //cuando ya existen datos en la table
            }
            else
            {
                return context.InsertAsync(note); //primer dato
            }
        }

        public Task<List<Note>> GetAllNotes()
        {
            return context.Table<Note>().ToListAsync();
        }

        public Task<Note> GetANote(int id)
        {
            return context.Table<Note>().Where(note => note.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> DeleteNote(Note note)
        {
            return context.DeleteAsync(note);
        }
    }
}
