using System;
using System.Collections.Generic;
using System.Linq;

namespace NotesDLL
{
    public class Manager
    {
        public List<Note> notes { get; private set; }
        public Manager()
        {
            notes = new List<Note>();
        }
        public void CreateNote(string noteName, string text, DateTime creationData)
        {
            this.notes.Add(new Note(noteName, text, creationData));
        }
        public void DeleteNote(string noteName)
        {
            this.notes.RemoveAt(notes.FindIndex(item => item.NoteName == noteName));
        }
    }
}
