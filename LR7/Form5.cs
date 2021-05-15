using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR7
{
    public partial class Form5 : Form
    {
        
        public Form5()
        {
            InitializeComponent();
            ShowConcerts();
            
        }
        
        
        private void ShowConcerts()
        {
            using (Context context = new Context())
            {
                
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.DataSource = context.Concerts.ToList();
                
            }
            
        }
        private void Update()
        {
            using (Context context = new Context())
            {
                var newRow = new Concert { 
                    NameConcert = textBoxConcert.Text, 
                    Actors = textBoxActor.Text
                };
                context.Concerts.Add(newRow);
                context.SaveChanges();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
