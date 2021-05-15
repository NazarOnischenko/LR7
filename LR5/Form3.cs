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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            ShowTickets();
        }
        private void ShowTickets()
        {
            using (Context context = new Context())
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.DataSource = context.Tickets.ToList();
                //dataGridView1.ReadOnly = true;
            }
        }
        private void Update()
        {
            using (Context context = new Context())
            {
                var newRow = new Ticket
                {
                    NameConcert = textBoxConcert.Text,
                    Row = int.Parse(textBoxRow.Text),
                    Place = int.Parse(textBoxPlace.Text),
                    Price = int.Parse(textBoxPrice.Text),
                    Date = DateTime.Parse(textBoxDate.Text)
                };
                context.Tickets.Add(newRow);
                context.SaveChanges();
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
