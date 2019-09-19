using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Models
{
    public class Note
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        public string Filename { get; set; }
        public string Title { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
