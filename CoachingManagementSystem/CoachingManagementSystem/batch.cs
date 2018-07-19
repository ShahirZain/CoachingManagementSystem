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
    public partial class batch : Form
    {
        supportingClass c1;
        supportingClass obj;
        Form1 f1;
        public batch()
        {
            InitializeComponent();
        }

        private void batch_Load(object sender, EventArgs e)
        {
            this.dataGridView1.Hide();
             obj = new supportingClass(f1,this);
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.button2.Hide();
            this.bunifuThinButton22.Hide();
            this.bunifuThinButton21.Hide();
            this.dataGridView1.Show();
            obj.batchShow();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            batch b = new batch();
            this.Hide();
            b.Show();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.button2.Show();
            obj.addbatch();
            DataGridViewCheckBoxColumn ch = new DataGridViewCheckBoxColumn();
            this.dataGridView1.Show();
            dataGridView1.Columns.Add(ch);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            obj.addBatchStudent();
        }

    }
}
