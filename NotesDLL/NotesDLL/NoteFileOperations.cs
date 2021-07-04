using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NotesDLL
{
    public static class NoteFileOperations
    {
        public static bool SaveNote(Note note, string path)
        {
            bool res = false;
            if (note != null)
            {
                File.WriteAllText(path, $"{note.NoteName}\n\n{note.Text}\n{note.CreationData.Date}");
            }
            return res;
        }
        public static bool SaveNotes(string path, params Note[] notes)
        {
            bool res = false;
            if (notes.Where(x => x != null).Count() == notes.Length)
            {
                notes.ToList().ForEach(x => File.WriteAllText(path, $"{x.NoteName}\n\n>{x.Text}\n<{x.CreationData.Date}\n*\n\n"));
            }
            return res;
        }

        public static List<Note> ReadFromFile(string path)
        {
            List<Note> notesFromFile = new List<Note>();
            string data = File.ReadAllText(path);
            try
            {
                data.Split('*').ToList().ForEach(x => notesFromFile.Add(new Note(new string(x.TakeWhile(y => y != '>').ToArray()), x.Substring(x.IndexOf('>'), x.IndexOf('<') - x.IndexOf('>')), DateTime.Parse(x.Substring(x.IndexOf('<'), x.LastIndexOf('*') - x.LastIndexOf('<'))))));
            }
            catch { }
            return notesFromFile;
        }
    }
}
