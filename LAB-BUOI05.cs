using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_03_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int size = 14;
        string font = "Tamoha";

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            font.ShowColor = true;
            font.ShowApply = true;
            font.ShowEffects = true;
            font.ShowHelp = true;

            if (font.ShowDialog() != DialogResult.Cancel)
            {
                txt_type.ForeColor = font.Color;
                txt_type.Font = font.Font;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddFont();
            AddSize();
            lamMoiRich();

            toolStripStatusLabel1.Text = "Số ký tự: 0";

        }


        private void AddFont()
        {
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                cmb_font.Items.Add(font.Name);
            }
        }
        
        
        private void AddSize()
        {
            int[] sizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (int size in sizes)
            {
                cmb_size.Items.Add(size);
            }
        }

        private void lamMoiRich()
        {
            txt_type.Clear();
            txt_type.Font = new Font("Tamoha", 14, FontStyle.Regular);
            cmb_font.SelectedItem = "Tahoma";
            cmb_size.SelectedItem = 14;
            
        }

        private void cmb_size_SelectedIndexChanged(object sender, EventArgs e)
        {
            size = Int32.Parse(cmb_size.Text);
            txt_type.Font = new Font(font, size, FontStyle.Regular);
        }

        private void cmb_font_SelectedIndexChanged(object sender, EventArgs e)
        {
            font = cmb_font.Text;
            txt_type.Font = new Font(font, size);
        }

        private void cmb_font_TextChanged(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tạoVănBảnMớiCTRLNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lamMoiRich();
        }

        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Text file| *.txt| RFT File | *.rft";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = open.FileName;
                txt_type.LoadFile(selectedFileName,RichTextBoxStreamType.UnicodePlainText);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                lamMoiRich();
                e.Handled = true;
                return;
            }
            if (e.Control && e.KeyCode == Keys.O)
            {
               mởTậpTinToolStripMenuItem_Click(this, e);
                e.Handled = true;
                return;
            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                toolStripButton2_Click(this, e);
                e.Handled = true;
                return;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog(); 
            saveFile.CheckFileExists = true;
            saveFile.Title = "Lưu tập tin văn bản";
            saveFile.DefaultExt = "rft";
            saveFile.Filter = "RichText files |*.rft";
            saveFile.RestoreDirectory = true;
            saveFile.AddExtension = true;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = saveFile.FileName;
                try
                {
                    txt_type.SaveFile(selectedFile, RichTextBoxStreamType.UnicodePlainText);
                    MessageBox.Show("Tập tin đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình lưu tập tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                }
            }    
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if(txt_type.SelectionFont.Bold)
            {
                txt_type.SelectionFont = new Font (txt_type.SelectionFont, txt_type.SelectionFont.Style & ~FontStyle.Bold);
            } else
            {
                txt_type.SelectionFont = new Font(txt_type.SelectionFont, txt_type.SelectionFont.Style & FontStyle.Bold);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (txt_type.SelectionFont.Italic)
            {
                txt_type.SelectionFont = new Font(txt_type.SelectionFont, txt_type.SelectionFont.Style & ~FontStyle.Italic);
            }
            else
            {
                txt_type.SelectionFont = new Font(txt_type.SelectionFont, txt_type.SelectionFont.Style & FontStyle.Italic);
            }
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (txt_type.SelectionFont.Underline)
            {
                txt_type.SelectionFont = new Font(txt_type.SelectionFont, txt_type.SelectionFont.Style & ~FontStyle.Underline);
            }
            else
            {
                txt_type.SelectionFont = new Font(txt_type.SelectionFont, txt_type.SelectionFont.Style & FontStyle.Underline);
            }
        }

        private void cmb_font_Click(object sender, EventArgs e)
        {

        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txt_type_TextChanged(object sender, EventArgs e)
        {           
                int dem = txt_type.Text.Length;
                this.toolStripStatusLabel1.Text = $"Số ký tự: {dem}";

        }  
    }
}
