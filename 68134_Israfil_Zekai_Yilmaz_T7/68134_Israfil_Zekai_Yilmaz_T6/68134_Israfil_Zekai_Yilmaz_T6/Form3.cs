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
using static System.Windows.Forms.LinkLabel;
using System.Drawing.Text;

namespace _68134_Israfil_Zekai_Yilmaz_T6
{
    public partial class Form3 : Form
    {
        private Library library = new Library();
        private List<string> lines = new List<string>();
        private int currentLine = 0;
        private bool click = true;
        public Form3()
        {
            InitializeComponent();
            LoadFileData();
            CurrentLine();

        }

        private void LoadFileData()
        {
            using (var sr = new StreamReader(Library.FileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            button4.Enabled = lines.Count > 0;
            button5.Enabled = false;

        }


        private void CurrentLine()
        {
            if (currentLine >= 0 && currentLine < lines.Count)
            {
                var parts = lines[currentLine].Split('\t');
                txtType2.Text = parts.Length > 0 ? parts[0] : "";
                txtTitle2.Text = parts.Length > 1 ? parts[1] : "";
                txtAuthor2.Text = parts.Length > 2 ? parts[2] : "";
                txtCategory2.Text = parts.Length > 3 ? parts[3] : "";
                txtVar.Text = parts.Length > 4 ? parts[4] : "";
                txtVar2.Text = parts.Length > 5 ? parts[5] : "";
                label8.Text = (currentLine + 1).ToString();
            }
            button4.Enabled = currentLine < lines.Count - 1;
            button5.Enabled = currentLine > 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LabelNum();
            LoadData();
            Falsetxt();
            
        }
        private void Falsetxt()
        {
            txtTitle2.Enabled = false;
            txtAuthor2.Enabled= false;
            txtVar2.Enabled= false;
            txtCategory2.Enabled= false;
            txtVar.Enabled= false;
            txtType2.Enabled= false;
        }
        private void LoadData()
        {
            FileStream fs = new FileStream("Library.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            var s = sr.ReadLine();
            if (!string.IsNullOrEmpty(s))
            {
                DataLine(s);
                LabelChanging();
            }
            else
            {
                Clearing();
            }

            sr.Close();
            fs.Close();
        }
        private void DataLine(string line)
        {
            string[] part = line.Split('\t');
            if (part != null)
            {
              
                txtType2.Text = part[0];
                txtTitle2.Text = part[1];
                txtAuthor2.Text = part[2];
                txtCategory2.Text = part[3];
                txtVar.Text = part[4];
                txtVar2.Text = part[5];
            }
            else
            {
                Clearing();
            }

        }
        private void LabelChanging()
        {
            switch (txtType2.Text)
            {
                case "Paper Book":
                    label4.Text = "ISBN";
                    label7.Text = "Pages";
                    break;
                case "E-Book":
                    label4.Text = "Format";
                    label7.Text = "File Size";
                    break;
                case "Audio Book":
                    label4.Text = "Narrator";
                    label7.Text = "Duration";
                    break;
                default:
                    label4.Text = "";
                    label7.Text = "";
                    break;

            }
        }
        public void LabelNum()
        {
            var s = Convert.ToString(library.CountLines(Library.FileName));
            label9.Text = s.ToString();
        }
       

        private void button4_Click(object sender, EventArgs e)
        {
            ReadNextLine();
            LabelChanging();

        }

        private void ReadNextLine()
        {
            if (currentLine < lines.Count - 1)
            {
                currentLine++;
                CurrentLine();
            }
            else
            {
                button4.Enabled = false;
            }
        }
        private void ReadPreviousLine()
        {
            if (currentLine > 0)
            {
                currentLine--;
                CurrentLine();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ReadPreviousLine();
            LabelChanging();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Delete();
            LabelNum();
            Form3 form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
            this.Close();


        }
        private void Delete()
        {
            FileStream fs = new FileStream(Library.FileName, FileMode.Open, FileAccess.Read);
            FileStream fs2 = new FileStream("Temp.txt", FileMode.Create, FileAccess.Write);
            StreamReader sr = new StreamReader(fs);
            using (StreamWriter sw = new StreamWriter(fs2))
            {
                string line;
                int lineIndex = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    if (lineIndex != currentLine)
                    {
                        sw.WriteLine(line);
                    }
                    lineIndex++;
                }
            }

            sr.Close();
            fs.Close();
            fs2.Close();

            FileStream fs3 = new FileStream(Library.FileName, FileMode.Create, FileAccess.Write);
            FileStream fs4 = new FileStream("Temp.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr2 = new StreamReader(fs4);
            StreamWriter sw2 = new StreamWriter(fs3);

            while (!sr2.EndOfStream)
            {
                string s = sr2.ReadLine();
                sw2.WriteLine(s);


            }

            sr2.Close();
            sw2.Close();
            fs3.Close();
            fs4.Close();
            MessageBox.Show("Current Line is deleted");
        }
        private void Clearing()
        {
            txtType2.Text = "";
            txtTitle2.Text = "";
            txtAuthor2.Text = "";
            txtCategory2.Text = "";
            txtVar.Text = "";
            txtVar2.Text = "";

        }
        

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (click== true)
            {
                Truetxt();
                btnEdit.Text = "Apply";
            }
            else
            {
               Editing();
               Falsetxt();
               btnEdit.Text = "Edit";
            }
            click = !click;
            
                    
        }

        private void Truetxt()
        {
            txtTitle2.Enabled = true;
            txtAuthor2.Enabled = true;
            txtVar2.Enabled = true;
            txtCategory2.Enabled = true;
            txtVar.Enabled = true;
        }

        private void Editing()
        {
            if (currentLine>=0 && currentLine < lines.Count)
            {
                string[] part = lines[currentLine].Split('\t');
                if ((txtType2.Text != part[0]) || (txtTitle2.Text!= part[1]) || (txtAuthor2.Text != part[2]) || (txtCategory2.Text != part[3]) || (txtVar.Text != part[4]) || (txtVar2.Text != part[5]))
                {
                    part[0] = txtType2.Text;
                    part[1] = txtTitle2.Text;
                    part[2] = txtAuthor2.Text;
                    part[3]= txtCategory2.Text;
                    part[4]= txtVar.Text;
                    part[5]= txtVar2.Text;
                    
                }
                lines[currentLine] = string.Join("\t", part);
                EditedData();
            }
        }
        private void EditedData()
        {
            FileStream fs = new FileStream(Library.FileName, FileMode.Open, FileAccess.Read);
            FileStream fs2 = new FileStream("Temp.txt", FileMode.Create, FileAccess.Write);
            StreamReader sr = new StreamReader(fs);
            using (StreamWriter sw = new StreamWriter(fs2))
            {
                foreach (var line in lines)
                {
                    sw.WriteLine(line);
                }
            }
                sr.Close();
                fs.Close();
                fs2.Close();

                FileStream fs3 = new FileStream("library.txt", FileMode.Create, FileAccess.Write);
                FileStream fs4 = new FileStream("Temp.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr2 = new StreamReader(fs4);
                StreamWriter sw2 = new StreamWriter(fs3);

                while (!sr2.EndOfStream)
                {
                    string s = sr2.ReadLine();
                    sw2.WriteLine(s);


                }

                sr2.Close();
                sw2.Close();
                fs3.Close();
                fs4.Close();
            
            
        }
        
    }

}
