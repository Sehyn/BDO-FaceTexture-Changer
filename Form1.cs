using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BDO_Facetexture_Patcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Hey! I'm ArthurB a simple hobbyist developer, I've made that tool to make things easier on Black Desert.\nI've noticed that when you have alot of characters it's not very handy to do things manually.\nTherefore here we are! That tool is free to use and completely safe have fun!\nPS: I've also made a Font Patcher to make it easier aswell check it out on my GitHub it's open source :)\nGitHub.com/Sehyn \n\nI forgot sorry, If you need to import your custom art just put your .bmp files in the Face Texture folder in the same location as the executable!", "Hi!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Get content of the DESTINATION files on a specific folder and put it into a dataGridView1

            string[] files = Directory.GetFiles(@Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Black Desert\\FaceTexture", "*", SearchOption.TopDirectoryOnly);
            DataTable table = new DataTable();
            table.Columns.Add("File Name");
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo file = new FileInfo(files[i]);
                table.Rows.Add(file.Name);

            }
            dataGridView1.DataSource = table;



            //Get content of the SOURCE files on a specific folder and put it into a dataGridView2

            string[] files2 = Directory.GetFiles(@"Face Texture", "*");
            DataTable table2 = new DataTable();
            table2.Columns.Add("File Name");
            for (int i = 0; i < files2.Length; i++)
            {
                FileInfo file = new FileInfo(files2[i]);
                table2.Rows.Add(file.Name);

            }
            dataGridView2.DataSource = table2;




        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {




                string[] sizes = { "B", "KB", "MB", "GB", "TB" };
                double len = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Black Desert\\FaceTexture\\" + dataGridView1.SelectedCells[0].Value.ToString()).Length;
                int order = 0;
                while (len >= 1024 && order < sizes.Length - 1)
                {
                    order++;
                    len = len / 1024;
                }

                string result = String.Format("{0:0.##} {1}", len, sizes[order]);


                //We get the picturebox to show which file we selected in the cell (datagridview1)
                pictureBox1.Image = Image.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Black Desert\\FaceTexture\\" + dataGridView1.SelectedCells[0].Value.ToString());
                LblFileName1.Text = dataGridView1.SelectedCells[0].Value.ToString();
                //We have the full path here
                LblFilePath1.Text = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Black Desert\\FaceTexture\\" + dataGridView1.SelectedCells[0].Value.ToString());
                LblFileSize1.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                button1.Enabled = true;


                string[] sizes = { "B", "KB", "MB", "GB", "TB" };
                double len = new FileInfo("Face Texture\\" + dataGridView2.SelectedCells[0].Value.ToString()).Length;
                int order = 0;
                while (len >= 1024 && order < sizes.Length - 1)
                {
                    order++;
                    len = len / 1024;
                }


                string result = String.Format("{0:0.##} {1}", len, sizes[order]);

                //We get the picturebox to show which file we selected in the cell (datagridview2)
                pictureBox2.Image = Image.FromFile("Face Texture\\" + dataGridView2.SelectedCells[0].Value.ToString());
                LblFileName2.Text = dataGridView2.SelectedCells[0].Value.ToString();
                //We have the full path here
                LblFilePath2.Text = @"Face Texture\\" + dataGridView2.SelectedCells[0].Value.ToString();
                LblFileSize2.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Get store into a string both paths before disposing them
                string Destination = LblFilePath1.Text;
                string Source = LblFilePath2.Text;

                pictureBox1.Image.Dispose();
                pictureBox2.Image.Dispose();
                
         

                File.Copy(Source, Destination, true);
                pictureBox1.Image = Image.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Black Desert\\FaceTexture\\" + dataGridView1.SelectedCells[0].Value.ToString());

                MessageBox.Show("Source file: "+Source + "\n->\nDestination file:"+Destination,"Success!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
    }
}


