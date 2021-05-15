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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        public Form11(Ticket ticket)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id",typeof(int));
            table.Columns.Add("Спектакль", typeof(string));
            table.Columns.Add("Ряд", typeof(int));
            table.Columns.Add("Місце", typeof(int));
            table.Columns.Add("Ціна", typeof(int));
            table.Columns.Add("Дата",typeof(DateTime));
            table.Rows.Add(ticket.Id, ticket.NameConcert, ticket.Row, ticket.Place, ticket.Price, ticket.Date);
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DataSource = table;
            dataGridView1.ReadOnly = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
