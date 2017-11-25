using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void codearea_TextChanged(object sender, EventArgs e)
        {
        }

        private void codearea_KeyDown(object sender, KeyEventArgs e)
        {
            int selectionStart = codearea.SelectionStart;

            if(e.KeyCode == Keys.OemCloseBrackets)
            {
                codearea.Text = codearea.Text.Insert(selectionStart, "]");
                codearea.SelectionStart = selectionStart;
                //codearea
            }

            if (e.Control)
            {
                if(e.KeyCode == Keys.Add)
                {
                    setFont(codearea, +2, true);
                }
                if (e.KeyCode == Keys.Subtract)
                {
                    setFont(codearea, -2, true);
                }
              
            }
            if (e.KeyCode == Keys.Tab)
            {
                int wordStartPosition = getPositionWordAt(codearea.Text, codearea.SelectionStart);

                String word = codearea.Text.Substring(wordStartPosition, selectionStart - wordStartPosition);

                if(word == "function")
                {
                    codearea.Text = codearea.Text.Remove(wordStartPosition, word.Length).Insert(wordStartPosition, "function() {" + Environment.NewLine + "    " + Environment.NewLine + "}");

                    codearea.SelectionStart = selectionStart + 10;
                }
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        public int getPositionWordAt(String text, int index, bool before = true)
        {
            if(index <= 0)
            {
                return index;
            }
            if(before)
            {
                int cont = index - 1;
                bool searching = true;

                while(searching)
                {
                    if(cont == 0 && text.Substring(cont, 1) != " ")
                    {
                        searching = false;
                        return cont;
                    }
                    if(text.Substring(cont, 1) == " ") {
                        searching = false;
                        cont++;
                        return cont;
                    }
                    else
                    {
                        cont --;
                    }
                }

                return cont;
            }

            return index;
        }

        public void setFont(TextBox textbox, int size, bool current_font)
        {
            if(current_font)
            {
                textbox.Font = new Font(textbox.Font.FontFamily, textbox.Font.Size + size);
            }
            else
            {
                textbox.Font = new Font(textbox.Font.FontFamily, size);
            }
           
        }
    }
}
