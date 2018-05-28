using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoachingManagementSystem
{
    public partial class Form1 : Form
    {
        //Constructor
        public Form1()
        {
            InitializeComponent();
        }

        //Load
        private void Form1_Load(object sender, EventArgs e)
        {
            this.bunifuGradientPanel4.Hide();
        }

        // Exit Button
        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //Search Button
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.bunifuGradientPanel4.Show();
            this.bunifuGradientPanel5.Show();
            this.bunifuGradientPanel6.Hide();
        }


        //Register Button
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.bunifuGradientPanel4.Show();
            this.bunifuGradientPanel5.Hide();
        }

        
        //PAyment
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {

            this.bunifuGradientPanel4.Show();
            this.bunifuGradientPanel5.Show();
            this.bunifuGradientPanel6.Show();
            this.bunifuGradientPanel7.Hide();

        }

       
        //Batch
        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            this.bunifuGradientPanel4.Show();
            this.bunifuGradientPanel5.Show();
            this.bunifuGradientPanel6.Show();
            this.bunifuGradientPanel7.Show();
            //TextBox and Submit Button
            this.bunifuMetroTextbox1.Hide();
            this.bunifuFlatButton1.Hide();
        }


        //Courses
        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {

        }


        //Trainer
        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {

        }


        //Student
        private void bunifuThinButton210_Click(object sender, EventArgs e)
        {

        }


        //Create Batch Button in Batch tab
        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            //Hide Create batch Button
            this.bunifuThinButton24.Hide();

            //TextBox and Submit Button
            this.bunifuMetroTextbox1.Show();
            this.bunifuFlatButton1.Show();
        }

        //to add labels on click submit
        static byte batchCount = 0;
        public Label[] batchNames = new Label[100];
        public int labelX = 10, labelY = 0;
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
                
                batchNames[batchCount] = new Label();
                batchNames[batchCount].Name = "batchName" + batchCount;
                batchNames[batchCount].Location = new Point(labelX, labelY);
                batchNames[batchCount].Font = new Font("Century Gothic", 9.75F);
                batchNames[batchCount].Text = bunifuMetroTextbox1.Text;
                this.batchPanel.Controls.Add(batchNames[batchCount]);
                batchNames[batchCount].Click += (object s, EventArgs ev) =>
                {
                    bunifuMetroTextbox1.Text = ((Label)s).Name + " has been clicked!";
                };
            labelY += 20;
            batchCount++;
        }

       


       

       

        
        /*
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.bunifuGradientPanel4.Show();
        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                if (dlg.ShowDialog() == DialogResult.OK) {
                    pictureBox1.ImageLocation = dlg.FileName;
                }
            }
            catch (Exception ) {
                MessageBox.Show("Wrong selection"+e);
            }
        }
         
         */
    }
}
