using NUnit.Framework;
using System;

namespace NotesDLL.Test
{

    public class FileNoteTests
    {

        [Test]
        public void TestIsTrueStandartConstruct()
        {
            Assert.True(NoteFileOperations.SaveNote("text.txt", new Note()));
        }
        [Test]
        public void TestIsTrueParametrized()
        {
            Assert.True(NoteFileOperations.SaveNote("text.txt", new Note("123", "123", DateTime.Now)));
        }

        [Test]
        public void TestIsFalseNullNote()
        {
            Assert.False(NoteFileOperations.SaveNote("text.txt", null));
        }
        [Test]
        public void TestIsFalseNullString()
        {
            Assert.False(NoteFileOperations.SaveNote(null, new Note("123", "123", DateTime.Now)));
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