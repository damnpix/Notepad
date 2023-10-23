using Notepad.Windows;
using System.IO;
using System.Windows.Forms;

namespace Notepad.Core
{
    internal class NotepadCore
    {
        private static string _savedFileLocation;
        private static bool _saved = false;

        public static void NewFileCreate(RichTextBox richTextBox, mainWin mainWin)
        {
            if (_saved)
            {
                mainWin.Text = "Untitled - Notepad";
                richTextBox.Clear();
                _saved = false;
            }
            else richTextBox.Clear();
        }
        public static void Exit()
        {
            Application.Exit();
        }
        public static void Edit_Clear(RichTextBox richTextBox)
        {
            richTextBox.Clear();
        }
        public static void Edit_Undo(RichTextBox richTextBox)
        {
            richTextBox.Undo();
        }
        public static void Edit_Redo(RichTextBox richTextBox)
        {
            richTextBox.Redo();
        }
        public static void Save(RichTextBox richTextBox,SaveFileDialog saveFileDialog,mainWin mainWin)
        {
            if (_saved == false)
            {
                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    
                    using (StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName))
                    {
                        _savedFileLocation = saveFileDialog.FileName;
                        streamWriter.Write(richTextBox.Text);
                    }
                    _saved = true;
                    mainWin.Text = Path.GetFileNameWithoutExtension(saveFileDialog.FileName);
                }
            }
            else if(_saved == true) {
                using (StreamWriter streamWriter = new StreamWriter(_savedFileLocation))
                {
                    streamWriter.Write(richTextBox.Text);
                }
            }
        }
        public static void Open(RichTextBox richTextBox,OpenFileDialog openFileDialog,mainWin mainWin)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader streamReader = new StreamReader(openFileDialog.FileName))
                {
                    mainWin.Text = Path.GetFileNameWithoutExtension(openFileDialog.FileName) + " - Notepad";
                    richTextBox.Text = streamReader.ReadToEnd();
                }
            }
        }
        public static void Preferences_zoom(RichTextBox richTextBox,int value)
        {
            richTextBox.ZoomFactor = value;
        }
        public static void About(aboutWin aboutWin)
        {
            aboutWin.ShowDialog();
        }
        public static void Font(RichTextBox richTextBox, string fontName)
        {
            richTextBox.Font = new System.Drawing.Font(fontName, 12);
        }
    }
}
