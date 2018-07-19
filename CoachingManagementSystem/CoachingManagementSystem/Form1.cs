using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CoachingManagementSystem
{
    public partial class Form1 : Form
    {

        public String textBoxtext;
        supportingClass c;
        batch b1;

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ES52MLE; AttachDbFilename=|DataDirectory|COACHINGMANAGEMENTSYSTEM.mdf;Initial Catalog=COACHINGMANAGEMENTSYSTEM;Integrated Security=True");


        //Constructor
        public Form1()
        {
            InitializeComponent();
           
        }

        //Load
        private void Form1_Load(object sender, EventArgs e)
        {
            c = new supportingClass(this,b1);
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
            c.clearItem();
            c.searchCombo();
        }


        //Register Button
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.pictureBox2.Image = null;
            this.bunifuGradientPanel4.Show();
            this.bunifuGradientPanel5.Hide();
            this.bunifuGradientPanel6.Hide();
            c.countRow(); //Form nnumber
        }

        
        //PAyment
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            c.paymentItemClear();
            c.searchCombo2();
            this.bunifuGradientPanel4.Show();
            this.bunifuGradientPanel5.Show();
            this.bunifuGradientPanel6.Show();
            this.bunifuGradientPanel7.Hide();

        }

       
        //Batch
        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            this.bunifuThinButton24.Show();
            this.bunifuThinButton216.Show();
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


            //Panels for Course
            this.bunifuGradientPanel4.Show();
            this.bunifuGradientPanel5.Show();
            this.bunifuGradientPanel6.Show();
            this.bunifuGradientPanel7.Show();
            this.bunifuGradientPanel8.Show();
            this.bunifuGradientPanel9.Hide();
            this.bunifuThinButton212.Show();
            this.bunifuThinButton213.Show();
            this.CoursePanel.Show();
            this.bunifuThinButton218.Show();
            this.bunifuThinButton219.Show();
            this.GirdView1.Hide();

            //hide control
            this.bunifuMetroTextbox4.Hide();
            this.bunifuMetroTextbox5.Hide();
            this.bunifuThinButton217.Hide();
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
            this.CoursePanel.Hide();
            this.bunifuGradientPanel9.Hide();
            this.bunifuThinButton212.Show();
            this.bunifuThinButton213.Show();

            this.Girdview.Hide();

            //TB2 and TB3 and B214 on add trainer's Button
            this.bunifuThinButton214.Hide();
            this.bunifuMetroTextbox2.Hide();
            this.bunifuMetroTextbox3.Hide();
        }


        //Student
        private void bunifuThinButton210_Click(object sender, EventArgs e)
        {
            this.bunifuGradientPanel4.Show();
            this.bunifuGradientPanel5.Show();
            this.bunifuGradientPanel6.Show();
            this.bunifuGradientPanel7.Show();
            this.bunifuGradientPanel8.Show();
            this.CoursePanel.Show();
            this.bunifuGradientPanel9.Show();
            this.GirdView2.Hide();
            this.bunifuThinButton221.Show();
            this.bunifuThinButton220.Show();
            this.button1.Hide();
            this.textBox14.Hide();
        }


            //************************* Start*************************\\


        /// <summary>
        /// here we use only enter and leave event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void bunifuMaterialTextbox1_Enter(object sender, EventArgs e)
        {
            textBoxtext = this.bunifuMaterialTextbox1.Text;
            this.bunifuMaterialTextbox1.Text = "";
        }

        private void bunifuMaterialTextbox1_Leave(object sender, EventArgs e)
        {
            if (this.bunifuMaterialTextbox1.Text == "")
            {
                this.bunifuMaterialTextbox1.Text = textBoxtext;
            }
        }

        private void bunifuMaterialTextbox2_Enter(object sender, EventArgs e)
        {
            textBoxtext = this.bunifuMaterialTextbox2.Text;
            this.bunifuMaterialTextbox2.Text = "";
        }

        private void bunifuMaterialTextbox2_Leave(object sender, EventArgs e)
        {
            if (this.bunifuMaterialTextbox2.Text == "")
            {
                this.bunifuMaterialTextbox2.Text = textBoxtext;
            }
        }

        private void bunifuMaterialTextbox3_Enter(object sender, EventArgs e)
        {
            textBoxtext = this.bunifuMaterialTextbox3.Text;
            this.bunifuMaterialTextbox3.Text = "";
        }

        private void bunifuMaterialTextbox3_Leave(object sender, EventArgs e)
        {
            if (this.bunifuMaterialTextbox3.Text == "")
            {
                this.bunifuMaterialTextbox3.Text = textBoxtext;
            }
        }

        private void bunifuMaterialTextbox4_Enter(object sender, EventArgs e)
        {
            textBoxtext = this.bunifuMaterialTextbox4.Text;
            this.bunifuMaterialTextbox4.Text = "";
        }

        private void bunifuMaterialTextbox4_Leave(object sender, EventArgs e)
        {
            if (this.bunifuMaterialTextbox4.Text == "")
            {
                this.bunifuMaterialTextbox4.Text = textBoxtext;
            }
        }

        private void bunifuMaterialTextbox5_Enter(object sender, EventArgs e)
        {
            textBoxtext = this.bunifuMaterialTextbox5.Text;
            this.bunifuMaterialTextbox5.Text = "";
        }

        private void bunifuMaterialTextbox5_Leave(object sender, EventArgs e)
        {
            if (this.bunifuMaterialTextbox5.Text == "")
            {
                this.bunifuMaterialTextbox5.Text = textBoxtext;
            }
        }

        private void bunifuMaterialTextbox6_Enter(object sender, EventArgs e)
        {
            textBoxtext = this.bunifuMaterialTextbox6.Text;
            this.bunifuMaterialTextbox6.Text = "";
        }

        private void bunifuMaterialTextbox6_Leave(object sender, EventArgs e)
        {
            if (this.bunifuMaterialTextbox6.Text == "")
            {
                this.bunifuMaterialTextbox6.Text = textBoxtext;
            }
        }

        private void bunifuMaterialTextbox7_Enter(object sender, EventArgs e)
        {
            textBoxtext = this.bunifuMaterialTextbox7.Text;
            this.bunifuMaterialTextbox7.Text = "";
        }

        private void bunifuMaterialTextbox7_Leave(object sender, EventArgs e)
        {
            if (this.bunifuMaterialTextbox7.Text == "")
            {
                this.bunifuMaterialTextbox7.Text = textBoxtext;
            }
        }

      


//************************   END ENTER AND LEAVE   ***************************\\


//************************   FORM SUBMISSION   ***************************\\



        //Browse Image
        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            c.browseImg();
        }

        //Form submit button

        private void bunifuThinButton215_Click(object sender, EventArgs e)
        {
            c.checksValues();
            c.imgToBinary();
            c.insertIntoForm();
        }



//************************   END FORM SUBMISSION   ***************************\\


        //Search
      private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
               c.selectedCombo();
        }

        //payment 

        //selected Index
     private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
          c.searchcomboselected();
      }
       
        //payment submit
        private void bunifuThinButton211_Click(object sender, EventArgs e)
        {
            c.submit();
            MessageBox.Show("Data submitted");

        }

//************************   BATCH WORK START   ***************************\\


        //Create Batch Button in Batch tab
        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            //Hide Create batch Button
            this.bunifuThinButton24.Hide();
            this.bunifuThinButton216.Hide();


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


        //to add labels on click submit
        public  byte batchCount = 0;
        public Label[] batchNames = new Label[100];
        public int labelX = 100, labelY = 200;
        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            batchNames[batchCount] = new Label();
            batchNames[batchCount].Name = "batchName" + batchCount;
            batchNames[batchCount].Location = new Point(labelX, labelY);
            batchNames[batchCount].Font = new Font("Century Gothic", 9.75F);
            batchNames[batchCount].Text = bunifuMetroTextbox1.Text;
            this.bunifuGradientPanel7.Controls.Add(batchNames[batchCount]);
            batchNames[batchCount].Click += (object s, EventArgs ev) =>
            {
                bunifuMetroTextbox1.Text = ((Label)s).Name + " has been clicked!";
            };
            labelY += 20;
            batchCount++;
            c.creatTable();

        }

        //View Batch
        private void bunifuThinButton216_Click(object sender, EventArgs e)
        {
            this.bunifuThinButton216.Hide();
            this.bunifuThinButton24.Hide();
            c.viewbatch();
        }
        //************************   BATCH WORK END   ***************************\\
        private void bunifuThinButton214_Click(object sender, EventArgs e)
        {
            c.addTeacher();
        }

        private void bunifuThinButton213_Click(object sender, EventArgs e)
        {
            this.Girdview.Show();
            c.dataview();
        }

        private void bunifuThinButton219_Click(object sender, EventArgs e)
        {
            this.bunifuMetroTextbox4.Show();
            this.bunifuMetroTextbox5.Show();
            this.bunifuThinButton217.Show();
            this.bunifuThinButton218.Hide();
            this.bunifuThinButton219.Hide();
        }

        private void bunifuThinButton218_Click(object sender, EventArgs e)
        {
            this.bunifuMetroTextbox4.Hide();
            this.bunifuMetroTextbox5.Hide();
            this.bunifuThinButton217.Hide();
            this.bunifuThinButton219.Hide();
            this.bunifuThinButton218.Hide();
            this.GirdView1.Show();
            c.courseDataView();
        }

        private void bunifuThinButton217_Click(object sender, EventArgs e)
        {
            c.addCourse();
        }

        private void bunifuThinButton221_Click(object sender, EventArgs e)
        {
            this.bunifuThinButton220.Hide();
            this.bunifuThinButton221.Hide();
            this.GirdView2.Show();
            c.xii();
            c.Studentflag0 = 2;
            this.button1.Show();
            this.textBox14.Show();
        }

        private void bunifuThinButton220_Click(object sender, EventArgs e)
        {
            this.bunifuThinButton221.Hide();
            this.bunifuThinButton220.Hide();
            this.GirdView2.Show();
            c.xi();
            c.Studentflag0 = 1;
            this.button1.Show();
            this.textBox14.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.search();
        }

       

        


        

        }

        



     


       

       

        
     
    }
