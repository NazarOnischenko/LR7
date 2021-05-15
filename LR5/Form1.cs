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
    public partial class Form1 : Form
    {
        public string Name { get; set; }
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            using (Context DB = new Context())
            {
                var user = DB.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
                Name = user.Login;
                Form form;
                if (user == null)
                {
                    form = new Form8();
                    form.Show();
                }
                else if (user.Administrator == 1)
                {
                    form = new Form2();
                    form.Show();
                }
                else if (user.Administrator == 0)
                {
                    form = new Form10(Name);
                    form.Show();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            using (Context db = new Context())
            {
                var user = new User
                {
                    Login = textBox1.Text,
                    Password = textBox2.Text,
                    Administrator = 0
                };
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
