using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace CoachingManagementSystem
{
    class supportingClass
    {            
        
        Form1 f1;
        String phycheck="", chemcheck="", mathcheck="", cscheck="", phylabcheck="", chemlabcheck="", cslabcheck="", xicheck="", xiicheck="";
        String imgLoc = "";
        byte[] img = null;

                                                            // ******* Connection from SQL******\\
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-6MEQU96;Initial Catalog=COACHINGMANAGEMENTSYSTEM;Integrated Security=True");

        public supportingClass(Form1 ff) {
            f1 = ff;
        }


                                                            // ******* FORM SUBMISSION ******\\

            // ******* check values  ******\\


        public void checksValues() { 
        
            if (f1.bunifuCheckbox1.Checked )
                mathcheck = "yes";
            if (f1.bunifuCheckbox2.Checked)
                phycheck = "yes";
            if (f1.bunifuCheckbox3.Checked)
                chemcheck = "yes";
            if (f1.bunifuCheckbox4.Checked)
                cscheck = "yes";
            if (f1.bunifuCheckbox5.Checked)
                cslabcheck = "yes";
            if (f1.bunifuCheckbox6.Checked)
                chemlabcheck = "yes";
            if (f1.bunifuCheckbox7.Checked)
                phylabcheck = "yes";
            if (f1.bunifuCheckbox16.Checked)
                xicheck = "yes";
            if (f1.bunifuCheckbox15.Checked)
                xiicheck = "yes";       
        }

        public void browseImg() {
            try {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files(*.*)|*.*";
                dlg.Title = "Select Student Picture";
                if (dlg.ShowDialog() == DialogResult.OK) {
                    imgLoc = dlg.FileName.ToString();
                    f1.pictureBox2.ImageLocation = imgLoc;
                }
            }

            catch (Exception e){
                MessageBox.Show(e.ToString());
            }
        }


        public void imgToBinary() {
            try {
                FileStream fs = new FileStream(imgLoc,FileMode.Open,FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
            }
            catch(Exception e){
                MessageBox.Show(e.ToString());
            }
            
        }


        // ******* Insert Into Form ******\\

        public void insertIntoForm() {

            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into ADMSN(sname,fname,address,religion,mblNo,email,sex,DOB,phy,chem,math,CS,phylab,chemlab,CSlab,Xi,Xii,img) values(@sname,@fname,@address,@religion,@mblNo,@email,@sex,@DOB,@phy,@chem,@math,@CS,@phylab,@chemlab,@CSlab,@Xi,@Xii,@img)",conn);
            cmd.Parameters.AddWithValue("@sname",f1.bunifuMetroTextbox1.Text);
            cmd.Parameters.AddWithValue("@fname", f1.bunifuMetroTextbox2.Text);
            cmd.Parameters.AddWithValue("@address", f1.bunifuMetroTextbox3.Text);
            cmd.Parameters.AddWithValue("@religion", f1.bunifuMaterialTextbox4.Text);
            cmd.Parameters.AddWithValue("@mblNo", f1.bunifuMaterialTextbox5.Text);
            cmd.Parameters.AddWithValue("@email", f1.bunifuMaterialTextbox6.Text);
            cmd.Parameters.AddWithValue("@sex", f1.bunifuMaterialTextbox7.Text);
            cmd.Parameters.AddWithValue("@DOB", f1.bunifuDatepicker1.Value);
            cmd.Parameters.AddWithValue("@phy", phycheck);
            cmd.Parameters.AddWithValue("@chem", chemcheck);
            cmd.Parameters.AddWithValue("@math", mathcheck);
            cmd.Parameters.AddWithValue("@cs", cscheck);
            cmd.Parameters.AddWithValue("@phylab", phylabcheck);
            cmd.Parameters.AddWithValue("@chemlab", chemlabcheck);
            cmd.Parameters.AddWithValue("@cslab", cslabcheck);
            cmd.Parameters.AddWithValue("@xi", xicheck);
            cmd.Parameters.AddWithValue("@xii", xiicheck);
            cmd.Parameters.AddWithValue("@img", img);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("abc");
        }
        
    }
}
