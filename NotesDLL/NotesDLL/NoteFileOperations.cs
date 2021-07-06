using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NotesDLL
{
    public static class NoteFileOperations
    {
        public static bool SaveNote(string path, Note note)
        {
            bool res = false;
            if (note != null)
            {
                try
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    File.WriteAllText(path, $"{note.NoteName}\n>{note.Text}\n<{note.CreationData.Date}|\n\n*");
                    res = true;
                }
                catch { }
            }
            return res;
        }

        public static bool SaveNotes(string path, params Note[] notes)
        {
            bool res = false;
            if (notes.Where(x => x != null).Count() == notes.Length)
            {
                try
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    notes.ToList().ForEach(x => File.AppendAllText(path, $"{x.NoteName}>{x.Text}\n<{x.CreationData.Date}|\n\n*"));
                    res = true;
                }
                catch { }
            }
            return res;
        }

        public static List<Note> ReadFromFile(string path)
        {
            List<Note> notesFromFile = new List<Note>();
            if (path != null && File.Exists(path))
            {
                string data = File.ReadAllText(path);
                data.Split('*').ToList().ForEach(x => { if (x.Count() > 5) { notesFromFile.Add(new Note(new string(x.TakeWhile(y => y != '>').ToArray()), x.Substring(x.LastIndexOf('>') + 1, x.LastIndexOf('<') - x.LastIndexOf('>') - 1), DateTime.Parse(x.Substring(x.IndexOf('<') + 1, x.LastIndexOf('|') - x.LastIndexOf('<') - 1)))); } });

            }
            else
            {
                notesFromFile = null;
            }
            return notesFromFile;
        }
    }
}
