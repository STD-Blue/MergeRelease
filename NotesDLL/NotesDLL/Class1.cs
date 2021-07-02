using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesDLL
{
    public class Note { }
    public static class NoteFileOperations
    {
        public static bool SaveNote(Note note)
        {
            bool res = false;
            if (note != null)
            {

            }
            return res;
        }
        public static bool SaveNotes(params Note[] notes)
        {
            bool res = false;
            if (notes.Where(x => x != null).Count() == notes.Length)
            {

            }
            return res;
        }
    }
}
