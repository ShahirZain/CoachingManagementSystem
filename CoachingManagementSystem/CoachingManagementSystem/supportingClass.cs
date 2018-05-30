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
    class supportingClass
    {
        Form1 f1;

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-6MEQU96;Initial Catalog=COACHINGMANAGEMENTSYSTEM;Integrated Security=True");

        public supportingClass(Form1 ff) {
            f1 = ff;
        }


        // ******* FORM SUBMISSION ******\\

        public void insertIntoForm() {

            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into ADMSN(sname,fname,address,religion,mblNo,email,sex,DOB,phy,chem,math,CS,phylab,chemlab,CSlab,Xi,Xii,img) values(@sname,@fname,@address,@religion,@mblNo,@email,@sex,@DOB,@phy,@chem,@math,@CS,@phylab,@chemlab,@CSlab,@Xi,@Xii,@img)",conn);
        }
        
    }
}
