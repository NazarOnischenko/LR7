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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            var concert = new Concert
            {
                NameConcert = "Кайдашева Сім'я",
                Actors = "Віктор Жданов, Ірина Мак, Тарас Цимбалюк, Григорій Бакланов",
            };
            using (Context db = new Context())
            {
                db.Concerts.Add(concert);
            }
                Form form;
            var tableName = comboBox1.SelectedItem.ToString();
            var action = comboBox2.SelectedItem.ToString();
            if (tableName == "Спектаклі")
            {
                
                switch (action)
                {
                    case "Переглянути дані":
                        form = new Form4("Спектаклі");
                        form.Show();
                        break;
                    case "Додати дані":
                        form = new Form5();
                        form.Show();
                        break;
                    case "Редагувати дані":
                        form = new Form6();
                        form.Show();
                        break;
                    case "Видалити дані":
                        form = new Form13("Спектаклі");
                        form.Show();
                        break;
                    default:
                        return;
                        break;
                }
            }
            if (tableName == "Білети")
            {
                switch (action)
                {
                    case "Переглянути дані":
                        form = new Form4("Білети");
                        form.Show();
                        break;
                    case "Додати дані":
                        form = new Form3();
                        form.Show();
                        break;
                    case "Редагувати дані":
                        form = new Form9();
                        form.Show();
                        break;
                    case "Видалити дані":
                        form = new Form13("Білети");
                        form.Show();
                        break;
                    default:
                        return;
                        break;
                }

            }
            
            
                   
                    //form.table.RowCount = table.Count();
                    //form.table.ColumnCount = 4;
                    //var text = new TextBox();
                    //text.Text = "Id";
                    //form.table.Controls.Add(text, 0, 0);
                    //text.Text = "Концерт";
                    //form.table.Controls.Add(text, 0, 1);
                    //text.Text = "Актори";
                    //form.table.Controls.Add(text, 0, 2);
                    //text.Text = "Білети";
                    //form.table.Controls.Add(text, 0, 3);
                    //int i = 1;
                    //foreach (var item in table)
                    //{
                    //    text.Text = item.Id.ToString();
                    //    form.table.Controls.Add(text, i, 0);
                    //    text.Text = item.NameConcert.ToString();
                    //    form.table.Controls.Add(text, i, 1);
                    //    text.Text = item.Actors.ToString();
                    //    form.table.Controls.Add(text, i, 2);
                    //    text.Text = item.Tickets.ToString();
                    //    form.table.Controls.Add(text, i, 3);
                    //    i++;
                    //}
                    
        }
                
            
            

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
