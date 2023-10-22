using Notepad.Core;
using System;
using System.Windows.Forms;

namespace Notepad
{
    public partial class mainWin : Form
    {
        public mainWin()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotepadCore.Exit();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotepadCore.NewFileCreate(richTextBox1,this);
        }
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotepadCore.Edit_Clear(richTextBox1);
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "Untitled";
            saveFileDialog1.Filter = "Txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.DefaultExt = "txt";
            NotepadCore.Save(richTextBox1,saveFileDialog1,this);
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotepadCore.Open(richTextBox1, openFileDialog1, this);
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotepadCore.Edit_Undo(richTextBox1);
        }
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotepadCore.Edit_Redo(richTextBox1);
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            NotepadCore.Preferences_zoom(richTextBox1, 5);
        }
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            NotepadCore.Preferences_zoom(richTextBox1, 10);
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            NotepadCore.Preferences_zoom(richTextBox1, 15);
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotepadCore.About(new Windows.aboutWin());
        }
    }
}
