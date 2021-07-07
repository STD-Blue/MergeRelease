using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NotesDLL;
using System.IO;
using Logging2;
using System.Globalization;

namespace NotesGUI
{
    public partial class Form1 : Form
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        public string noteName { get; private set; }
        public int EmptyNote { get; private set; }
        
        public Form1()
        {
            Log.CreateFile("Logging.txt");
            Log.SetLog($"Init {this.Name}", LogType.MESSAGE);
            InitializeComponent();
            Notes = new List<Button>();
            int x = -130, y = 100;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Notes.Add(new Button()
                    {
                        Width = 130,
                        Height = 100,
                        Location = new Point(x += 130, y),
                        Visible = false
                    });
                    Notes.Last().Click += Form1_Click;
                }
                x = -130;
                y += 100;
            }

            Controls.AddRange(Notes.ToArray());
            Log.SetLog($"Init {this.Name} end", LogType.MESSAGE);
        }
        public string test { get; set; }
        private void Form1_Click(object sender, EventArgs e)
        {
            Log.SetLog($"Start Form1_Click", LogType.MESSAGE);
            File.WriteAllText("FindBtn.txt", $"{(sender as Button).Text}");
            Form note = new SelectedNote();
            this.Visible = false;
            note.ShowDialog();
            this.Visible = true;
            Log.SetLog($"Start Form1_Click end", LogType.MESSAGE);
        }

        private void notexText_KeyDown(object sender, KeyEventArgs e)
        {
            Log.SetLog($"Start notexText_KeyDown", LogType.MESSAGE);
            if (e.KeyCode == Keys.Enter)
            {
                if (notexText.Text.Length < 3)
                {
                    MessageBox.Show("Название не может быть меньше 3 символов!");
                    notexText.Focus();
                    Log.SetLog($"Check on length triger {notexText.Text.Length}", LogType.MESSAGE);
                }
                else
                {
                    if (notexText.Text.Equals("Enter note's name"))
                    {
                        MessageBox.Show("Не по правилам!");
                        notexText.Focus();
                        Log.SetLog($"Check on Equals({notexText.Text}) triger", LogType.MESSAGE);
                    }
                    else
                    {
                        if (Notes.Find(x => x.Text == notexText.Text) == null)
                        {
                            noteName = $"{notexText.Text}";
                            notexText.Text = "Enter note's name";
                            notexText.Visible = false;
                            if (MessageBox.Show("Создать пустую заметку?", "INFO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                Log.SetLog($"Choose empty note", LogType.MESSAGE);
                                Manager.CreateNote(noteName, "Welcome!", System.DateTime.UtcNow);
                                Notes.Find(x => x.Text == string.Empty).Visible = true;
                                Notes.Find(x => x.Text == string.Empty).Text = noteName;

                            }
                            else
                            {
                                Log.SetLog($"Choose not empty note", LogType.MESSAGE);
                                MessageBox.Show("Выберите .txt файл который будет загружен в заметку");
                                OpenFileDialog openFile = new OpenFileDialog();
                                openFile.Filter = "Txt(.txt)|*.txt";
                                if (openFile.ShowDialog() == DialogResult.OK)
                                {
                                    Log.SetLog($"OpeDialogFile end OK", LogType.MESSAGE);
                                    Manager.CreateNote(noteName, File.ReadAllText(openFile.FileName), System.DateTime.Now);
                                    Notes.Find(x => x.Text == string.Empty).Visible = true;
                                    Notes.Find(x => x.Text == string.Empty).Text = noteName;
                                }
                                else
                                {
                                    Log.SetLog($"OpeDialogFile end NO", LogType.MESSAGE);
                                    Manager.CreateNote(noteName, "Welcome!", System.DateTime.UtcNow);
                                    Notes.Find(x => x.Text == string.Empty).Visible = true;
                                    Notes.Find(x => x.Text == string.Empty).Text = noteName;
                                }
                            }
                        }
                        else
                        {
                            Log.SetLog($"Check the same name trigger", LogType.MESSAGE);
                            MessageBox.Show("Такая заметка уже есть");
                        }
                    }

               
                }
            }
            if(e.KeyCode == Keys.Escape)
            {
                Log.SetLog($"Check Escape key - cancel action", LogType.MESSAGE);
                notexText.Text = "Enter note's name";
                notexText.Visible = false;
            }
            Log.SetLog($"notexText_KeyDown end", LogType.MESSAGE);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.SetLog($"Start addToolStripMenuItem_Click", LogType.MESSAGE);
            if (Manager.notes.Count == 20)
            {
                MessageBox.Show("Больше 20 заметок нельзя.Удалите 1 заметку");
            }
            else
            {
                notexText.Visible = true;
                notexText.Focus();
            }
            Log.SetLog($"End addToolStripMenuItem_Click", LogType.MESSAGE);
        }

      
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.SetLog($"Start Form1_FormClosing", LogType.MESSAGE);
            Manager.SaveAllNotes("SaveNotes.txt");
            Log.SetLog($"SaveAllNotes", LogType.MESSAGE);
            Log.SetLog($"Form1_FormClosing end", LogType.MESSAGE);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Log.SetLog($"Start Form1_Load", LogType.MESSAGE);
            if (File.Exists("SaveNotes.txt"))
            {
                Log.SetLog($"SaveNotes.txt - Exists", LogType.MESSAGE);
                if (File.ReadAllText("SaveNotes.txt").Length != 0)
                {
                    Log.SetLog($"SaveNotes.txt - not Empty", LogType.MESSAGE);
                    Manager.ReadNotesFromFile("SaveNotes.txt");

                    for (int i = 0; i < Manager.notes.Count; i++)
                    {
                        Notes.Find(x => x.Text == string.Empty).Visible = true;
                        Notes.Find(x => x.Text == string.Empty).Text = Manager.notes[i].NoteName;
                    }
                    Log.SetLog($"Triger ReadNotesFromFile", LogType.MESSAGE);
                }
            }


            Log.SetLog($"Localazible start", LogType.MESSAGE);
            CultureInfo ci = new CultureInfo(File.ReadAllText("LastLanguage.txt"));
            foreach (ToolStripItem c in menuStrip1.Items)
            {
                foreach (ToolStripItem item in addToolStripMenuItem.DropDownItems)
                {
                    Log.SetLog($"Localazible {item}", LogType.MESSAGE);
                    resources.ApplyResources(item, item.Name, ci);
                }
                foreach (ToolStripItem item in notesToolStripMenuItem.DropDownItems)
                {
                    Log.SetLog($"Localazible {item}", LogType.MESSAGE);
                    resources.ApplyResources(item, item.Name, ci);
                }
                foreach (ToolStripItem item in settingsToolStripMenuItem.DropDownItems)
                {
                    Log.SetLog($"Localazible {item}", LogType.MESSAGE);
                    resources.ApplyResources(item, item.Name, ci);
                }
                Log.SetLog($"Localazible {c}", LogType.MESSAGE);
                resources.ApplyResources(c, c.Name, ci);
            }
            Log.SetLog($"Localazible end", LogType.MESSAGE);
            Log.SetLog($"Form1_Load end", LogType.MESSAGE);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Log.SetLog($"Start searchButton_Click", LogType.MESSAGE);
            if (Notes.Find(x => x.Text.Equals(searchTextBox.Text)) == null)
            {
                Log.SetLog($"Trigger check failed search -> {searchTextBox.Text}", LogType.MESSAGE);
                MessageBox.Show("Ничего не найдено");
            }
            else
            {
                Log.SetLog($"Find note -> {searchTextBox.Text}", LogType.MESSAGE);
                Notes.Find(x => x.Text.Equals(searchTextBox.Text)).Focus();
            }
            Log.SetLog($"searchButton_Click end", LogType.MESSAGE);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.SetLog($"Start deleteToolStripMenuItem_Click", LogType.MESSAGE);
            if (Manager.notes.Count == 0)
            {
                Log.SetLog($"Trigger check on empty notes", LogType.MESSAGE);
                MessageBox.Show("Нечего удалть!");
            }
            else
            {
                Log.SetLog($"Trigger act ->deleteNote.KeyDown += DeleteNote_KeyDown", LogType.MESSAGE);
                deleteNote.Visible = true;
                deleteNote.Focus();
                deleteNote.KeyDown += DeleteNote_KeyDown;
            }
            Log.SetLog($"deleteToolStripMenuItem_Click end", LogType.MESSAGE);
        }

        private void DeleteNote_KeyDown(object sender, KeyEventArgs e)
        {
            Log.SetLog($"Start DeleteNote_KeyDown", LogType.MESSAGE);
            if (e.KeyCode == Keys.Enter)
            {
                Log.SetLog($"Trigger chekc on key -> press -> enter", LogType.MESSAGE);
                if (Notes.Find(x=>x.Text == deleteNote.Text) == null)
                {
                   
                }
                else
                {
                    Log.SetLog($"Success delete note", LogType.MESSAGE);
                    Manager.DeleteNote($"{deleteNote.Text}");
                    Notes.Find(x => x.Text == $"{deleteNote.Text}").Visible = false;
                    Notes.Find(x => x.Text == $"{deleteNote.Text}").Text = string.Empty;

                    deleteNote.Text = "Enter note's name";
                    deleteNote.Visible = false;
                }
              
            }
            if(e.KeyCode == Keys.Escape)
            {
                Log.SetLog($"Trigger chekc on key -> press -> Escape", LogType.MESSAGE);
                deleteNote.Text = "Enter note's name";
                deleteNote.Visible = false;
            }
            Log.SetLog($"DeleteNote_KeyDown end", LogType.MESSAGE);
        }

        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.SetLog($"Start backColorToolStripMenuItem_Click", LogType.MESSAGE);
            using (ColorDialog color = new ColorDialog())
            {
                if(color.ShowDialog() == DialogResult.OK)
                {
                    Log.SetLog($"Trigger Dialog res = OK", LogType.MESSAGE);
                    this.BackColor = color.Color;
                }
            }
            Log.SetLog($"backColorToolStripMenuItem_Click end", LogType.MESSAGE);
        }

        private void backImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.SetLog($"Start backImageToolStripMenuItem_Click", LogType.MESSAGE);
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "Png(.png)|*.png|Jpg(.jpg)|*.jpg";
                if(openFile.ShowDialog() == DialogResult.OK)
                {
                    Log.SetLog($"Trigger Dialog res = OK", LogType.MESSAGE);
                    this.BackgroundImage = Image.FromFile(openFile.FileName);
                }
            }
            Log.SetLog($"backImageToolStripMenuItem_Click end", LogType.MESSAGE);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.SetLog($"Start exitToolStripMenuItem_Click", LogType.MESSAGE);
            Manager.SaveAllNotes("SaveNotes.txt");
            Log.SetLog($"Trigger SaveAllNotes", LogType.MESSAGE);
            Log.SetLog($"exitToolStripMenuItem_Click end", LogType.MESSAGE);
            Log.SetLog($"CLOSE APP", LogType.MESSAGE);
            Environment.Exit(0);
           
        }

        private void deleteALLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.SetLog($"Start deleteALLToolStripMenuItem_Click", LogType.MESSAGE);
            if (Manager.notes.Count == 0)
            {
                Log.SetLog($"Trigger chekc on notes empty", LogType.MESSAGE);
                MessageBox.Show("Удалять нечего!");
            }
            else
            {
                if (MessageBox.Show("Удалить все заметки?", "WARNING", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Log.SetLog($"Trigger chekc dialog res = YES", LogType.MESSAGE);
                    for (int i = 0; i < Manager.notes.Count; i++)
                    {
                        Notes.Find(x => x.Text == $"{Manager.notes[i].NoteName}").Visible = false;
                        Notes.Find(x => x.Text == $"{Manager.notes[i].NoteName}").Text = string.Empty;
                        Manager.DeleteNote($"{Manager.notes[i].NoteName}");
                        Log.SetLog($"Delete - > {Manager.notes[i]}", LogType.MESSAGE);

                    }
                }
            }
            Log.SetLog($"deleteALLToolStripMenuItem_Click end", LogType.MESSAGE);
        }
        

        private void ChangeLanguage(object sender, EventArgs e)
        {
            Log.SetLog($"Start ChangeLanguage", LogType.MESSAGE);
            CultureInfo ci = new CultureInfo((sender as ToolStripMenuItem).Text);
            Log.SetLog($"Save language to txt -> {ci.ToString()}", LogType.MESSAGE);
            File.WriteAllText("LastLanguage.txt", ci.ToString());

            foreach (ToolStripItem c in menuStrip1.Items)
            {
                foreach (ToolStripItem item in addToolStripMenuItem.DropDownItems)
                {
                    Log.SetLog($"Local - {item}", LogType.MESSAGE);
                    resources.ApplyResources(item, item.Name, ci);
                }
                foreach (ToolStripItem item in notesToolStripMenuItem.DropDownItems)
                {
                    Log.SetLog($"Local - {item}", LogType.MESSAGE);
                    resources.ApplyResources(item, item.Name, ci);
                }
                foreach (ToolStripItem item in settingsToolStripMenuItem.DropDownItems)
                {
                    Log.SetLog($"Local - {item}", LogType.MESSAGE);
                    resources.ApplyResources(item, item.Name, ci);
                }
                Log.SetLog($"Local - {c}", LogType.MESSAGE);
                resources.ApplyResources(c, c.Name, ci);
            }
        }
    }
}
