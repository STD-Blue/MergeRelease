using NUnit.Framework;
using System;

namespace NotesDLL.Test
{
    public partial class Note
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


    
    public class FileNoteTests
    {

        [Test]
        public void TestIsTrueStandartConstruct()
        {
            Assert.True(NoteFileOperations.SaveNote(new Note(), "text.txt"));
        }
        [Test]
        public void TestIsTrueParametrized()
        {
            Assert.True(NoteFileOperations.SaveNote(new Note("123", "123", DateTime.Now), "text.txt"));
        }

        [Test]
        public void TestIsFalseNullNote()
        {
            Assert.False(NoteFileOperations.SaveNote(null, "text.txt"));
        }
        [Test]
        public void TestIsFalseNullString()
        {
            Assert.False(NoteFileOperations.SaveNote(new Note("123", "123", DateTime.Now), null));
        }

        [Test]
        public void TestReadFromFileIsNullWrongFile()
        {
            Assert.Null(NoteFileOperations.ReadFromFile(null));
        }

        [Test]
        public void TestReadFromFileCorrect()
        {
            Assert.NotNull(NoteFileOperations.ReadFromFile("text.txt"));
        }
    }
}