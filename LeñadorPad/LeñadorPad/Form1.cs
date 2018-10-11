using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LeñadorPad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleasepCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMesagger(System.IntPtr hwnd, int wmsg, int wparam, int lpam);


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleasepCapture();
            SendMesagger(this.Handle,0x112,0xf012,0);
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName);
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Todos los Archivos |*.*| Documentos (.txt .rtf) |*.txt; *.rtf";

            if(openFileDialog1  .ShowDialog() == DialogResult.OK)
                this.richTextBox1.LoadFile(openFileDialog1.FileName);
            
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Todos los Archivos |*.*| Documentos (.txt .rtf) |*.txt; *.rtf";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                this.richTextBox1.LoadFile(openFileDialog1.FileName);

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void btnSubrayado_Click(object sender, EventArgs e)
        {
            Font f = richTextBox1.SelectionFont;
            FontStyle style = richTextBox1.SelectionFont.Style;

            if(richTextBox1.SelectionFont.Underline)
            {
                style &= ~FontStyle.Underline;
                this.btnSubrayado.BackColor = Color.FromName("Tomato");
            }
            else
            {
                style |= FontStyle.Underline;
                this.btnSubrayado.BackColor = Color.FromName("Firebrick");
            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
        }
               

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //Pone en negrita el texto seleccioando.
            Font f = richTextBox1.SelectionFont;
            FontStyle style = richTextBox1.SelectionFont.Style;
            //Ajustando segun lo requerido.

            if (richTextBox1.SelectionFont.Bold)
            {
                style &= ~FontStyle.Bold;
                this.btnNegrita.BackColor = Color.FromName("Tomato");
            }
            else
            {
                style |= FontStyle.Bold;
                this.btnNegrita.BackColor = Color.FromName("Firebrick");
            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
        }

        //Poner en Italic la letra.
        private void btnItalic_Click(object sender, EventArgs e)
        {
            Font f = richTextBox1.SelectionFont;
            FontStyle style = richTextBox1.SelectionFont.Style;

            if (richTextBox1.SelectionFont.Italic)
            {
                style &= ~FontStyle.Italic;
                this.btnItalic.BackColor = Color.FromName("Tomato");
            }
            else
            {
                style |= FontStyle.Italic;
                this.btnItalic.BackColor = Color.FromName("Firebrick");
            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);

        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            //Verifica si el cursor esta arriba de alguna letra.
            if (richTextBox1.SelectionFont.Bold)
            {
                this.btnNegrita.BackColor = Color.FromName("Firebrick");
            }
            else
            {
                this.btnNegrita.BackColor = Color.FromName("Tomato");
            }

            //Para las Subrayadas.
            if (richTextBox1.SelectionFont.Underline)
            {
                this.btnSubrayado.BackColor = Color.FromName("Firebrick");
            }
            else
            {
                this.btnSubrayado.BackColor = Color.FromName("Tomato");
            }


            if (richTextBox1.SelectionFont.Italic)
            {
                this.btnItalic.BackColor = Color.FromName("Firebrick");
            }
            else
            {
                this.btnItalic.BackColor = Color.FromName("Tomato");
            }
        }
    }
}
