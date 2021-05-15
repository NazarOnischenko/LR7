using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR7
{
    public partial class Form6 : Form
    { 
        
        
        public Form6()
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
                dataGridView1.ReadOnly = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (Context db = new Context())
            {
                Concert con; 
                if (textBox1.Text != string.Empty)
                {
                    con = db.Concerts.Find(int.Parse(textBox1.Text));
                    if (textBoxActor.Text != string.Empty)
                    {
                        con.Actors = textBoxActor.Text;
                    }
                    if (textBoxConcert.Text != string.Empty)
                    {
                        con.NameConcert = textBoxConcert.Text;
                    }
                    db.SaveChanges();
                }
                else
                {
                    var form = new Form8();
                    form.Show();
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
