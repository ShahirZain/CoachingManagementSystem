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
     public   int Studentflag0;
        SqlCommand cmd;
        int flag = 1;
        Form1 f1;
        String phycheck="", chemcheck="", mathcheck="", cscheck="", phylabcheck="", chemlabcheck="", cslabcheck="", xicheck="", xiicheck="";
        String imgLoc = "";
        byte[] img = null;

                                                            // ******* Connection from SQL******\\
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ES52MLE;Initial Catalog=COACHINGMANAGEMENTSYSTEM;Integrated Security=True");

        public supportingClass(Form1 ff) {
            f1 = ff;
        }

                                     //<><><><><><><><><><><><><><><><Register Work START><><><><><><><><><><><><><><><><><><>\\

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


        //<<><><><><IMAGE BROWSE FROM FILE><<><<><>>\\

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

        //<<><><><>< IMAGE TO BINARY NUMBER ><<><<><>>\\

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


        //<<><><><><FORM NUMBER><<><<><>>\\
        public void countRow()
        {

            int c = 0;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(formNO) FROM ADMSN", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    c = Convert.ToInt32(dr[0]);
                    c++;
                }
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            f1.label11.Text = c.ToString();

        }



        // ******* Insert Into Form ******\\

        public void insertIntoForm() {

            conn.Open();
            try
            {
                cmd  = new SqlCommand("insert into ADMSN(sname,fname,address,religion,mblNo,email,sex,DOB,phy,chem,math,CS,phylab,chemlab,CSlab,Xi,Xii,img,formNo) values(@sname,@fname,@address,@religion,@mblNo,@email,@sex,@DOB,@phy,@chem,@math,@CS,@phylab,@chemlab,@CSlab,@Xi,@Xii,@img,@formNo)", conn);
                SqlCommand cmd1 = new SqlCommand("insert into fee(formNo) values(@formNo)", conn);
                cmd.Parameters.AddWithValue("@sname", f1.bunifuMaterialTextbox1.Text);
                cmd.Parameters.AddWithValue("@fname", f1.bunifuMaterialTextbox2.Text);
                cmd.Parameters.AddWithValue("@address", f1.bunifuMaterialTextbox3.Text);
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
                cmd.Parameters.AddWithValue("@formNo", Convert.ToInt32(f1.label11.Text));
                cmd1.Parameters.AddWithValue("@formNo", Convert.ToInt32(f1.label11.Text));
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
            }
            catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
            conn.Close();
            MessageBox.Show("Form submitted");
        }

                              //<><><><><><><><><><><><><><><><Register Work END><><><><><><><><><><><><><><><><><><>\\

                             //<><><><><><><><><><><><><><><><><Search Work START><><><><><><><><><><><><><><><><><><>\\

        // ******* Populate Combo 1  ******\\

        public void searchCombo() {
            f1.comboBox1.Items.Clear();
            conn.Open();
            try{
                cmd = new SqlCommand("Select * from ADMSN",conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    f1.comboBox1.Items.Add(dr["formNo"].ToString());
                }

            }
            catch(Exception e){
            MessageBox.Show(e.ToString());
            }
            conn.Close();
        }

        // ******* selectedIndex Combo ******\\

        public void selectedCombo()
        {
            
            conn.Open();

            
                cmd = new SqlCommand("Select * from ADMSN where formNo='"+f1.comboBox1.SelectedItem+"'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                
                if (dr.Read())
                {
                    f1.bunifuMaterialTextbox16.Text = dr["sname"].ToString();
                    f1.bunifuMaterialTextbox15.Text = dr["fname"].ToString();
                    f1.bunifuMaterialTextbox14.Text = dr["address"].ToString();
                    f1.bunifuMaterialTextbox13.Text = dr["religion"].ToString();
                    f1.bunifuMaterialTextbox12.Text = dr["mblNo"].ToString();
                    f1.bunifuMaterialTextbox11.Text = dr["email"].ToString();
                    f1.bunifuMaterialTextbox10.Text = dr["sex"].ToString();
                    if (dr["math"].ToString() == "yes       ")
                        f1.bunifuCheckbox14.Checked = true;
                    if (dr["phy"].ToString() == "yes       ")
                        f1.bunifuCheckbox13.Checked = true;
                    if (dr["chem"].ToString() == "yes       ")
                        f1.bunifuCheckbox12.Checked = true;
                    if (dr["cs"].ToString() == "yes       ")
                        f1.bunifuCheckbox11.Checked = true;
                    if (dr["phylab"].ToString() == "yes       ")
                        f1.bunifuCheckbox10.Checked = true;
                    if (dr["chemlab"].ToString() == "yes       ")
                        f1.bunifuCheckbox9.Checked = true;
                    if (dr["cslab"].ToString() == "yes       ")
                        f1.bunifuCheckbox8.Checked = true;
                    if (dr["xi"].ToString() == "yes       ")
                        f1.bunifuCheckbox18.Checked = true;
                    if (dr["xii"].ToString() == "yes       ")
                        f1.bunifuCheckbox17.Checked = true;
                    }
                byte []img = ((byte[])dr["img"]);
                MemoryStream ms = new MemoryStream(img);
                f1.pictureBox3.Image = Image.FromStream(ms);
                
            conn.Close();
        }

                             //<><><><><><><><><><><><><><><><><Search Work END><><><><><><><><><><><><><><><><><><>\\

                            //<><><><><><><><><><><><><><><><><Payment Work START><><><><><><><><><><><><><><><><><><>\\

        public void searchCombo2()
        {
            f1.comboBox2.Items.Clear();
            conn.Open();
            try
            {
                cmd = new SqlCommand("Select * from fee", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    f1.comboBox2.Items.Add(dr["formNo"].ToString());
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            conn.Close();
        }

        public void searchcomboselected() {

            conn.Open();
            try
            {
                cmd = new SqlCommand("Select * from fee where formNo ='"+f1.comboBox2.SelectedItem+"'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    f1.textBox1.Text = dr["Admission"].ToString();
                    f1.textBox2.Text = dr["jan"].ToString();
                    f1.textBox3.Text = dr["feb"].ToString();
                    f1.textBox4.Text = dr["march"].ToString();
                    f1.textBox5.Text = dr["april"].ToString();
                    f1.textBox6.Text = dr["may"].ToString();
                    f1.textBox7.Text = dr["jun"].ToString();
                    f1.textBox8.Text = dr["july"].ToString();
                    f1.textBox9.Text = dr["aug"].ToString();
                    f1.textBox10.Text = dr["september"].ToString();
                    f1.textBox11.Text = dr["oct"].ToString();
                    f1.textBox12.Text = dr["nov"].ToString();
                    f1.textBox13.Text = dr["dec"].ToString();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            conn.Close();
        }

        // this submit function is called when submit button is clicked on payment table
        public void submit()
        {
            conn.Open();
            try
            {
                
                    cmd = new SqlCommand("update  fee SET Admission=@Admission,jan=@jan,feb=@feb,march=@march,april=@april,may=@may,jun=@jun,july=@july,aug=@aug,september=@september,oct=@oct,nov=@nov,dec=@dec where formNo='" + f1.comboBox2.SelectedItem + "'", conn);
                    cmd.Parameters.AddWithValue("@Admission", f1.textBox1.Text);
                    cmd.Parameters.AddWithValue("@jan", f1.textBox2.Text);
                    cmd.Parameters.AddWithValue("@feb", f1.textBox3.Text);
                    cmd.Parameters.AddWithValue("@march", f1.textBox4.Text);
                    cmd.Parameters.AddWithValue("@april", f1.textBox5.Text);
                    cmd.Parameters.AddWithValue("@may", f1.textBox6.Text);
                    cmd.Parameters.AddWithValue("@jun", f1.textBox7.Text);
                    cmd.Parameters.AddWithValue("@july", f1.textBox8.Text);
                    cmd.Parameters.AddWithValue("@aug", f1.textBox9.Text);
                    cmd.Parameters.AddWithValue("@september", f1.textBox10.Text);
                    cmd.Parameters.AddWithValue("@oct", f1.textBox11.Text);
                    cmd.Parameters.AddWithValue("@nov", f1.textBox12.Text);
                    cmd.Parameters.AddWithValue("@dec", f1.textBox13.Text);
                    cmd.ExecuteNonQuery();
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            conn.Close();
        }

                           //<><><><><><><><><><><><><><><><><Payment Work END><><><><><><><><><><><><><><><><><><>\\

                          //<><><><><><><><><><><><><><><><><><BATCH Work START><><><><><><><><><><><><><><><><><><>\\
        public void creatTable() {
            
            conn.Open();
            try
            {
                cmd = new SqlCommand("CREATE TABLE "+f1.bunifuMetroTextbox1.Text.ToString()+"   (fname varchar(30), year varchar(30)) ", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            conn.Close();
        }
                         //<><><><><><><><><><><><><><><><><><BATCH Work END><><><><><><><><><><><><><><><><><><>\\

                       //<><><><><><><><><><><><><><><><><><Trainer Work START><><><><><><><><><><><><><><><><><><>\\
        public void addTeacher() {
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into trainer(subject,tname) values(@subject,@tname)", conn);
                cmd.Parameters.AddWithValue("@subject", f1.bunifuMetroTextbox3.Text);
                cmd.Parameters.AddWithValue("@tname", f1.bunifuMetroTextbox2.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            conn.Close();
            MessageBox.Show("Data submitted");
        }
        public void dataview() {
            try {
                conn.Open();
                cmd = new SqlCommand("select * from trainer",conn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                f1.Girdview.DataSource = dt;
                
                

                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }
                  //<><><><><><><><><><><><><><><><><><Trainer Work END><><><><><><><><><><><><><><><><><><>\\

                 //<><><><><><><><><><><><><><><><><><COURSE Work START><><><><><><><><><><><><><><><><><><>\\



        public void addCourse()
        {
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into course(subject,COURSE_LEVEL) values(@subject,@COURSE_LEVEL)", conn);
                cmd.Parameters.AddWithValue("@SUBJECT", f1.bunifuMetroTextbox5.Text);
                cmd.Parameters.AddWithValue("@COURSE_LEVEL", f1.bunifuMetroTextbox4.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            conn.Close();
            MessageBox.Show("Data submitted");
        }

        //COurse view
        public void courseDataView()
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand("select * from course", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                f1.GirdView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }
                        //<><><><><><><><><><><><><><><><><><COURSE Work END><><><><><><><><><><><><><><><><><><>\\

                       //<><><><><><><><><><><><><><><><><><STUDENT Work START><><><><><><><><><><><><><><><><><><>\\

        public void xi() {
            try
            {
                conn.Open();
                cmd = new SqlCommand("select sname,fname,mblNo from ADMSN where xi='yes'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                f1.GirdView2.DataSource = dt;
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


        public void xii()
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand("select formNo as 'FORM NO.',sname as'STUDENT NAME',fname as 'FATHER NAME',mblNo as 'MOBILE NO.' from ADMSN where xii='yes'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                f1.GirdView2.DataSource = dt;
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void search() { 
        if(Studentflag0==1){
            try
            {
                conn.Open();
                cmd = new SqlCommand("select formNo as 'FORM NO.',sname as'STUDENT NAME',fname as 'FATHER NAME',mblNo as 'MOBILE NO.' from ADMSN where xi='yes' and sname like '%" + f1.textBox14.Text + "%' ", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                f1.GirdView2.DataSource = dt;
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        if (Studentflag0 == 2)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand("select formNo as 'FORM NO.',sname as'STUDENT NAME',fname as 'FATHER NAME',mblNo as 'MOBILE NO.' from ADMSN where xii='yes' and sname like '%"+f1.textBox14.Text+"%' ", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                f1.GirdView2.DataSource = dt;
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        }
            

                     //<><><><><><><><><><><><><><><><><><STUDENT Work END><><><><><><><><><><><><><><><><><><>\\
    }
}
