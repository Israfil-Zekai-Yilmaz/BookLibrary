using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _68134_Israfil_Zekai_Yilmaz_T6
{
    public partial class Form2 : Form
    {
        private Library library = new Library();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fr1 = new Form1();
            this.Hide();
            fr1.ShowDialog();
            this.Close();
        }

   

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString()=="Paper Book")
            {
                gpPaper.Enabled = true;
                gpEbook.Enabled = false;
                gpAudio.Enabled = false;
            }
            else if (comboBox1.SelectedItem.ToString() == "E-Book")
            {
                gpPaper.Enabled = false;
                gpEbook.Enabled = true;
                gpAudio.Enabled = false; 
            }
            else
            {
                gpPaper.Enabled = false;
                gpEbook.Enabled = false;
                gpAudio.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var book = new PaperBook
            {
                Title = txtTitle.Text,
                Author = txtAuthor.Text,
                Category = txtCategory.Text,
                Type = comboBox1.SelectedItem.ToString(),
                ISBN = txtIsbn.Text,
                Pages = int.Parse(txtPages.Text)
            };
            library.AddBook(book);

            MessageBox.Show("Paper book added succesfully.");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var book = new E_Book
            {
                Title = txtTitle.Text,
                Author = txtAuthor.Text,
                Category = txtCategory.Text,
                Type = comboBox1.SelectedItem.ToString(),
                Format = txtFormat.Text,
                Size=int.Parse(txtSize.Text)
            };
            library.AddBook(book);

            MessageBox.Show("E-Book added succesfully.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var book = new AudioBook
            {
                Title = txtTitle.Text,
                Author = txtAuthor.Text,
                Category = txtCategory.Text,
                Type = comboBox1.SelectedItem.ToString(),
                Narrator = txtNarrator.Text,
                Duration = int.Parse(txtDuration.Text)
            };
            library.AddBook(book);

            MessageBox.Show("Audio Book added succesfully.");
        }


    }
}
