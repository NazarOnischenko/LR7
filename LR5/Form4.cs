using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
//using System.Data.SqlClient;

namespace LR7
{
    public partial class Form4 : Form
    {
       
        
        
        public Form4()
        {
            InitializeComponent();
            
        }
        public Form4(string table)
        {
            InitializeComponent();
            if (table == "Спектаклі")
            {
                ShowConcerts();
            }
            else if(table == "Білети")
            {
                ShowTickets();
            }
        }
        
        private void ShowConcerts()
        {
            using (Context context = new Context()) {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.DataSource = context.Concerts.ToList();
                dataGridView1.ReadOnly = true; 
            }
        }
        private void ShowTickets()
        {
            using (Context context = new Context())
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                
                dataGridView1.DataSource = context.Tickets.ToList();
                dataGridView1.ReadOnly = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
