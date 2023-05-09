using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace CinemaC
{
    public partial class BookOfTicket : Form
    {
        public BookOfTicket()
        {
            InitializeComponent();
            RefreshData();
        }

        private void RefreshData()
        {
            dataGridView1.Rows.Clear();

            int count = Data.Tickets.Count();

            for (int i = 0; i < count; i++)
            {
                dataGridView1.Rows.Add(Data.GetTicketID(Data.Tickets[i]), Data.Tickets[i].Date.ToLongDateString(), Data.Tickets[i].Time.ToString().Remove(3, 3), Data.Halls[Data.Tickets[i].Hall - 1].NameHall, Data.Tickets[i].Row, Data.Tickets[i].Place, Data.Tickets[i].Sold, Data.money[Data.Tickets[i].Hall - 1]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty)
            {
                bool NotData = true;
                int count = Data.Tickets.Count();
                for (int i = 0; i < count; i++)
                {
                    if (textBox1.Text == Convert.ToString(Data.GetTicketID(Data.Tickets[i])))
                    {
                        NotData = false;
                        if (Data.Tickets[i].Sold == true)
                        {
                            MessageBox.Show("Увы, место уже забронировано кем-то другим!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox1.Text = "";
                        }
                        else
                        {
                            textBox1.Text = "";

                            string connectionString = "Data Source=(local);Initial Catalog=CinemaSystem;Integrated Security=true";

                            string sqlExpression = $"UPDATE Tickets SET Sold = 1 WHERE IDticket = '{Data.GetTicketID(Data.Tickets[i])}'";

                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(sqlExpression, connection);
                                int number = command.ExecuteNonQuery();
                                connection.Close();
                            }

                            //Обновление данных в классе
                            Data.Initialization();

                            // Обновление DataGridView
                            RefreshData();


                        }
                    }
                }
                
                if(NotData)
                {
                    MessageBox.Show("Такого № не существует", "Уведомление");
                    textBox1.Text = "";
                }
            }
            else
                MessageBox.Show("Вы не ввели номер", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
