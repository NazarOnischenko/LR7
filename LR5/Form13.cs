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
    public partial class Form13 : Form
    {
        private string Table { get; set; }
        public Form13(string table)
        {
            Table = table;
            InitializeComponent();
            if (table == "Спектаклі") { ShowConcerts(); }
            else if (table == "Білети") { ShowTickets(); }
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
        private void ShowTickets()
        {
            using (Context context = new Context())
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dataGridView1.DataSource = context.Tickets.ToList();
                dataGridView1.ReadOnly = true;
            }
        }
        private void DeleteConcert() {
            using (Context context = new Context())
            {
                var concert = context.Concerts.Find(int.Parse(textBoxId.Text));
                context.Concerts.Remove(concert);
                context.SaveChanges();
            }
        }
        private void DeleteTicket()
        {
            using (Context context = new Context())
            {
                var ticket = context.Tickets.Find(int.Parse(textBoxId.Text));
                context.Tickets.Remove(ticket);
                context.SaveChanges();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Table == "Спектаклі")
            {
                DeleteConcert();
            }
            else if (Table == "Білети") 
            {
                DeleteTicket();
            }
        }
    }
}
