using System;
using System.Collections.Generic;
using System.Linq;

namespace NotesDLL
{
    public static class Manager
    {
        public static List<Note> notes { get; private set; } = new List<Note>();
        public void CreateNote(string noteName, string text, DateTime creationData)
        {
            this.notes.Add(new Note(noteName, text, creationData));
        }
        public static string TakeTextNote(string notename)
        {
            return notes.Find(x => x.NoteName == notename).Text;
        }
        public void DeleteNote(string noteName)
        {
            this.notes.RemoveAt(notes.FindIndex(item => item.NoteName == noteName));
        }
        public void SaveAllNotes(string path)
        {
            if (path.EndsWith(".txt"))
            {
                NoteFileOperations.SaveNotes(path, notes.ToArray());
            }
            else
            {
                path += ".txt";
                NoteFileOperations.SaveNotes(path, notes.ToArray());
            }
        }
        public void SaveNote(string noteName, string path)
        {
            NoteFileOperations.SaveNote(this.notes.Find(item => item.NoteName == noteName), path);
        }
        public static void ReadNotesFromFile(string path)
        {
            notes = NoteFileOperations.ReadFromFile(path);
        }
    }
}
