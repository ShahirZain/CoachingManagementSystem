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
            this.bunifuGradientPanel8.Hide();
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
            //Panels for trainer
            this.bunifuGradientPanel4.Show();
            this.bunifuGradientPanel5.Show();
            this.bunifuGradientPanel6.Show();
            this.bunifuGradientPanel7.Show();
            this.bunifuGradientPanel8.Show();

            //TB2 and TB3 and B214 on add trainer's Button
            this.bunifuThinButton214.Hide();
            this.bunifuMetroTextbox2.Hide();
            this.bunifuMetroTextbox3.Hide();
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


        //Add Button of Trainer
        private void bunifuThinButton212_Click(object sender, EventArgs e)
        {
            //TB2 and TB3 and B214 on add trainer's Button
            this.bunifuThinButton214.Show();
            this.bunifuMetroTextbox2.Show();
            this.bunifuMetroTextbox3.Show();
            //ADD button and view button
            this.bunifuThinButton212.Hide();
            this.bunifuThinButton213.Hide();
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
