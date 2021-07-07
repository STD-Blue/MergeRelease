using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NotesDLL;
using System.Globalization;

namespace NotesGUI
{
    public partial class SelectedNote : Form
    {
        public SelectedNote()
        {
            InitializeComponent();
            textBox1.Text = Manager.TakeTextNote(File.ReadAllText("FindBtn.txt"));
            this.Focus();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectedNote));

            CultureInfo ci = new CultureInfo(File.ReadAllText("LastLanguage.txt"));
            foreach (ToolStripItem c in menuStrip1.Items)
            {
                foreach (ToolStripItem item in fontToolStripMenuItem.DropDownItems)
                {
                    resources.ApplyResources(item, item.Name, ci);
                }
                foreach (ToolStripItem item in exitToolStripMenuItem.DropDownItems)
                {
                    resources.ApplyResources(item, item.Name, ci);
                }
                resources.ApplyResources(c, c.Name, ci);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Manager.notes.Find(item => item.NoteName == File.ReadAllText("FindBtn.txt")).Text = textBox1.Text;
            File.WriteAllText("FindBtnText.txt", textBox1.Text);
        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
            using (FontDialog font = new FontDialog())
            {
                if(font.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Font = font.Font;
                }
            }
        }

        private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog color = new ColorDialog())
            {
                if(color.ShowDialog() == DialogResult.OK)
                {
                    textBox1.ForeColor = color.Color;
                }
            }
        }

        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog color = new ColorDialog())
            {
                if (color.ShowDialog() == DialogResult.OK)
                {
                    textBox1.BackColor = color.Color;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog save = new SaveFileDialog())
            {
                save.Filter = "Txt(.txt)|*.txt";
                if(save.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText($"{save.FileName}.txt", textBox1.Text);
                }
            }
        }

        private void backToNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Manager.SaveAllNotes("SaveNotes.txt");
            Environment.Exit(0);
        }
    }
}
