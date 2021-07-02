using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesDLL
{
    public class Manager
    {
        public Note note { get; private set; }
        public Manager()
        {
            note = new Note();
        }
        public Manager(string noteName, string text, DateTime creationData)
        {
            this.note = new Note(noteName, text, creationData);
        }
    }
}
