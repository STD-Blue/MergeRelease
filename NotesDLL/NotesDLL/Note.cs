using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesDLL
{
    public class Note
    {
        public string NoteName;
        public string Text;
        public DateTime CreationData;
        public Note()
        {
            NoteName = string.Empty;
            Text = string.Empty;
            CreationData = new DateTime();
        }
        public Note(string noteName, string text, DateTime creationData)
        {
            Text = text;
            NoteName = noteName;
            CreationData = creationData;
        }
    }
}
