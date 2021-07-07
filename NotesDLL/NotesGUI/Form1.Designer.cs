using System.Windows.Forms;
using System.Drawing;
using System;
using System.Globalization;
using System.Collections.Generic;

namespace NotesGUI
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>

        private void InitializeComponent()
        {
           
           

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.languageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.enUSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ukToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteALLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchButton = new System.Windows.Forms.Button();
            this.notexText = new System.Windows.Forms.TextBox();
            this.deleteNote = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchTextBox
            // 
            resources.ApplyResources(this.searchTextBox, "searchTextBox");
            this.searchTextBox.Name = "searchTextBox";
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem1,
            this.notesToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // languageToolStripMenuItem1
            // 
            resources.ApplyResources(this.languageToolStripMenuItem1, "languageToolStripMenuItem1");
            this.languageToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enUSToolStripMenuItem,
            this.ruToolStripMenuItem,
            this.ukToolStripMenuItem});
            this.languageToolStripMenuItem1.Name = "languageToolStripMenuItem1";
            // 
            // enUSToolStripMenuItem
            // 
            resources.ApplyResources(this.enUSToolStripMenuItem, "enUSToolStripMenuItem");
            this.enUSToolStripMenuItem.Name = "enUSToolStripMenuItem";
            this.enUSToolStripMenuItem.Click += new System.EventHandler(this.ChangeLanguage);
            // 
            // ruToolStripMenuItem
            // 
            resources.ApplyResources(this.ruToolStripMenuItem, "ruToolStripMenuItem");
            this.ruToolStripMenuItem.Name = "ruToolStripMenuItem";
            this.ruToolStripMenuItem.Click += new System.EventHandler(this.ChangeLanguage);
            // 
            // ukToolStripMenuItem
            // 
            resources.ApplyResources(this.ukToolStripMenuItem, "ukToolStripMenuItem");
            this.ukToolStripMenuItem.Name = "ukToolStripMenuItem";
            this.ukToolStripMenuItem.Click += new System.EventHandler(this.ChangeLanguage);
            // 
            // notesToolStripMenuItem
            // 
            resources.ApplyResources(this.notesToolStripMenuItem, "notesToolStripMenuItem");
            this.notesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.deleteALLToolStripMenuItem});
            this.notesToolStripMenuItem.Name = "notesToolStripMenuItem";
            // 
            // addToolStripMenuItem
            // 
            resources.ApplyResources(this.addToolStripMenuItem, "addToolStripMenuItem");
            this.addToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            resources.ApplyResources(this.deleteToolStripMenuItem, "deleteToolStripMenuItem");
            this.deleteToolStripMenuItem.BackColor = System.Drawing.Color.Red;
            this.deleteToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // deleteALLToolStripMenuItem
            // 
            resources.ApplyResources(this.deleteALLToolStripMenuItem, "deleteALLToolStripMenuItem");
            this.deleteALLToolStripMenuItem.BackColor = System.Drawing.Color.Maroon;
            this.deleteALLToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.deleteALLToolStripMenuItem.Name = "deleteALLToolStripMenuItem";
            this.deleteALLToolStripMenuItem.Click += new System.EventHandler(this.deleteALLToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backColorToolStripMenuItem,
            this.backImageToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            // 
            // backColorToolStripMenuItem
            // 
            resources.ApplyResources(this.backColorToolStripMenuItem, "backColorToolStripMenuItem");
            this.backColorToolStripMenuItem.Name = "backColorToolStripMenuItem";
            this.backColorToolStripMenuItem.Click += new System.EventHandler(this.backColorToolStripMenuItem_Click);
            // 
            // backImageToolStripMenuItem
            // 
            resources.ApplyResources(this.backImageToolStripMenuItem, "backImageToolStripMenuItem");
            this.backImageToolStripMenuItem.Name = "backImageToolStripMenuItem";
            this.backImageToolStripMenuItem.Click += new System.EventHandler(this.backImageToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // searchButton
            // 
            resources.ApplyResources(this.searchButton, "searchButton");
            this.searchButton.Name = "searchButton";
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // notexText
            // 
            resources.ApplyResources(this.notexText, "notexText");
            this.notexText.Name = "notexText";
            this.notexText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.notexText_KeyDown);
            // 
            // deleteNote
            // 
            resources.ApplyResources(this.deleteNote, "deleteNote");
            this.deleteNote.Name = "deleteNote";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.deleteNote);
            this.Controls.Add(this.notexText);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      

        private void LanguageToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            CultureInfo ci = new CultureInfo((sender as ToolStripMenuItem).Text);
            foreach (Control c in this.Controls)
                resources.ApplyResources(c, c.Name, ci);
            foreach (ToolStripItem c in menuStrip1.Items)
            {
                foreach (ToolStripItem item in languageToolStripMenuItem1.DropDownItems)
                    resources.ApplyResources(item, item.Name, ci);
                resources.ApplyResources(c, c.Name, ci);
            }
        }
        private TextBox searchTextBox;
        public List<Button> Notes { get; private set; }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem languageToolStripMenuItem1;
        private ToolStripMenuItem notesToolStripMenuItem;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private Button searchButton;
        private TextBox notexText;
        private TextBox deleteNote;
        private ToolStripMenuItem backColorToolStripMenuItem;
        private ToolStripMenuItem backImageToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem deleteALLToolStripMenuItem;
        private ToolStripMenuItem enUSToolStripMenuItem;
        private ToolStripMenuItem ruToolStripMenuItem;
        private ToolStripMenuItem ukToolStripMenuItem;
    }
}

