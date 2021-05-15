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
    public partial class Form10 : Form
    {
        private string Name { get; set; }
        public Form10()
        {
            InitializeComponent();
        }
        public Form10(string name)
        {
            Name = name;
            InitializeComponent();
            ShowConcerts();
        }
        private void ShowConcerts()
        {
            button3.Hide();
            label1.Text = "Назва спектакля";
            
            using (Context context = new Context())
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.DataSource = context.Concerts.ToList();
                dataGridView1.ReadOnly = true;
            }
            textBox1.Text = "";
        }
        private void CheckTickets()
        {
            button3.Show();
            label1.Text = "Id білета";
            
            using (Context context = new Context())
            {
                
                var concert = textBox1.Text;
                var tickets = context.Tickets.Where(x => x.NameConcert == concert);
                dataGridView1.DataSource = tickets.ToList();
                dataGridView1.ReadOnly = true;
            }
            textBox1.Text = "";
        }
        private void SelectTicket() {
            using (Context context = new Context())
            {
                if (int.TryParse(textBox1.Text, out int id))
                {


                    var ticket = context.Tickets.Find(id);
                    if (ticket == null)
                    {
                        var form12 = new Form12();
                        form12.Show();
                    }
                    else
                    {
                        var order = new Order { NameCustomer = Name, IdTicket = ticket.Id };
                        context.Orders.Add(order);
                        var form = new Form11(ticket);
                        form.Show();
                        context.Tickets.Remove(ticket);
                        context.SaveChanges();
                    }
                }
                else
                {
                    var form = new Form8();
                    form.Show();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (label1.Text == "Id білета") { SelectTicket(); } 
            else { CheckTickets(); }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowConcerts();
        }
    }
}
