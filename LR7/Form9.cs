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
    public partial class Form9 : Form
    {
        public Form9()
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
                dataGridView1.ReadOnly = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Context db = new Context())
            {
                Ticket ticket;
                if (textBox1.Text != string.Empty)
                {
                    ticket = db.Tickets.Find(int.Parse(textBox1.Text));
                    if (textBoxConcert.Text != string.Empty)
                    {
                        ticket.NameConcert = textBoxConcert.Text;
                    }
                    if (textBoxRow.Text != string.Empty)
                    {
                        ticket.Row = int.Parse(textBoxRow.Text);
                    }
                    if (textBoxPlace.Text != string.Empty)
                    {
                        ticket.Place = int.Parse(textBoxPlace.Text);
                    }
                    if (textBoxPrice.Text!=string.Empty)
                    {
                        ticket.Price = int.Parse(textBoxPrice.Text);
                    }
                    if (textBoxDate.Text != string.Empty)
                    {
                        ticket.Date = DateTime.Parse(textBoxDate.Text);
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

