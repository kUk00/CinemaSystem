using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaC
{
    public partial class Control : Form
    {
        public Control()
        {
            InitializeComponent();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;

            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            checkBox1.Visible = false;

            RefreshData();
        }

        private void Control_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //Метод перезаполнения datagGridView
        public void RefreshData()
        {
            if (radioButton1.Checked)
            {
                dataGridView1.Rows.Clear();
                int count = Data.Movies.Count;
                for (int i = 0; i < count; i++)
                {
                    dataGridView1.Rows.Add(Data.Movies[i].NameMovie, Data.Movies[i].Country, Data.Movies[i].YearOfIssue, Data.Movies[i].Genre, Data.Movies[i].Duration);
                }
            }
            else if (radioButton2.Checked)
            {
                dataGridView1.Rows.Clear();
                int count = Data.Tickets.Count;
                for (int i = 0; i < count; i++)
                {
                    dataGridView1.Rows.Add(Data.Tickets[i].Date.ToLongDateString(), Data.Tickets[i].Time.ToString().Remove(5, 3), Data.Halls[Data.Tickets[i].Hall - 1].NameHall, Data.Tickets[i].Row, Data.Tickets[i].Place, Data.Tickets[i].Sold);
                }
            }
            else if (radioButton3.Checked)
            {
                dataGridView1.Rows.Clear();
                int count = Data.Sessions.Count;
                for (int i = 0; i < count; i++)
                {
                    dataGridView1.Rows.Add(Data.Sessions[i].Date.ToLongDateString(), Data.Sessions[i].Time.ToString().Remove(5, 3), Data.Halls[Data.Sessions[i].Hall - 1].NameHall, Data.Movies[Data.Sessions[i].Movie - 1].NameMovie);
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                switch (radioButton.Text)
                {
                    case "Фильмы":
                        {
                            for (int i = 1; i <= Data.Halls.Count; i++)
                            {
                                comboBox1.Items.Add(Data.Halls[i - 1].NameHall);
                            }

                            comboBox1.Visible = false;
                            comboBox2.Visible = false;
                            comboBox3.Visible = false;
                            checkBox1.Visible = false;
                            dateTimePicker1.Visible = false;

                            textBox1.Visible = true;
                            textBox3.Visible = true;
                            textBox4.Visible = true;
                            textBox5.Visible = true;
                            textBox6.Visible = true;

                            label1.Text = "";
                            textBox1.Visible = false;

                            label2.Text = "Название фильма:";
                            label3.Text = "Производство:";
                            label4.Text = "Год выпуска:";
                            label5.Visible = true;
                            label6.Visible = true;
                            label5.Text = "Жанр:";
                            label6.Text = "Длительность:";

                            dataGridView1.Columns[0].HeaderText = "Название фильма";
                            dataGridView1.Columns[1].HeaderText = "Производство";
                            dataGridView1.Columns[2].HeaderText = "Дата выпуска";
                            dataGridView1.Columns[3].HeaderText = "Жанр";
                            if (dataGridView1.Columns.Count < 5)
                            {
                                dataGridView1.Columns.Add("", "");
                                dataGridView1.Columns[4].HeaderText = "Длительность";
                            }

                            if (dataGridView1.Columns.Count == 6)
                                dataGridView1.Columns.RemoveAt(5);

                            RefreshData();
                            break;
                        }
                    case "Билеты":
                        {
                            dataGridView1.Columns[0].HeaderText = "Дата";
                            dataGridView1.Columns[1].HeaderText = "Время";
                            dataGridView1.Columns[2].HeaderText = "Зал";
                            dataGridView1.Columns[3].HeaderText = "Ряд";

                            comboBox2.Items.Clear();
                            comboBox1.Items.Clear();

                            for (int i = 1; i <= Data.Halls.Count; i++)
                            {
                                comboBox1.Items.Add(Data.Halls[i - 1].NameHall);
                            }

                            for (int i = 1; i <= 15; i++)
                                comboBox3.Items.Add($"{i}");

                            for (int i = 1; i <= 13; i++)
                                comboBox2.Items.Add($"{i}");

                            if (dataGridView1.Columns.Count < 5)
                            {
                                dataGridView1.Columns.Add("", "");
                                dataGridView1.Columns[4].HeaderText = "Место";
                            }

                            dataGridView1.Columns[4].HeaderText = "Место";

                            dataGridView1.Columns.Add("", "");
                            dataGridView1.Columns[5].HeaderText = "Занят/Не занят";

                            textBox1.Visible = true;
                            textBox2.Text = "";
                            label5.Visible = true;
                            label6.Visible = true;
                            label1.Text = "Дата:";
                            label2.Text = "Время:";
                            label3.Text = "Зал:";
                            label4.Text = "Ряд:";
                            label5.Text = "Место:";
                            label6.Text = "Занят/Не занят:";

                            dateTimePicker1.Visible = true;
                            comboBox1.Visible = true;
                            comboBox2.Visible = true;
                            comboBox3.Visible = true;
                            checkBox1.Visible = true;

                            textBox1.Visible = false;
                            textBox3.Visible = false;
                            textBox4.Visible = false;
                            textBox5.Visible = false;
                            textBox6.Visible = false;

                            RefreshData();
                            break;
                        }
                    case "Сеансы":
                        {
                            textBox1.Visible = true;
                            textBox2.Text = "";
                            dateTimePicker1.Visible = true;
                            comboBox1.Visible = true;
                            comboBox1.Items.Clear();
                            for (int i = 1; i <= Data.Halls.Count; i++)
                            {
                                comboBox1.Items.Add(Data.Halls[i - 1].NameHall);
                            }

                            label1.Text = "Дата:";
                            label2.Text = "Время:";
                            label3.Text = "Зал:";
                            label4.Text = "Фильм";
                            label5.Visible = false;
                            label6.Visible = false;

                            comboBox2.Visible = true;
                            comboBox3.Visible = false;
                            checkBox1.Visible = false;

                            textBox1.Visible = false;
                            textBox3.Visible = false;
                            textBox4.Visible = false;
                            textBox5.Visible = false;
                            textBox6.Visible = false;

                            dataGridView1.Columns[0].HeaderText = "Дата";
                            dataGridView1.Columns[1].HeaderText = "Время";
                            dataGridView1.Columns[2].HeaderText = "Зал";
                            dataGridView1.Columns[3].HeaderText = "Фильм";

                            if (dataGridView1.Columns.Count == 6)
                                dataGridView1.Columns.RemoveAt(5);

                            if (dataGridView1.Columns.Count == 5)
                                dataGridView1.Columns.RemoveAt(4);

                            comboBox2.Items.Clear();
                            //Добавление фильмов в комбобокс
                            for (int i = 0; i < Data.Movies.Count; i++)
                            {
                                comboBox2.Items.Add(Data.Movies[i].NameMovie);
                            }

                            RefreshData();
                            break;
                        }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Добавление
            if (radioButton1.Checked)
            {//Фильмы
                if (textBox2.Text != String.Empty && textBox3.Text != String.Empty && textBox4.Text != String.Empty && textBox5.Text != String.Empty && textBox6.Text != String.Empty)
                {
                    Movie mv = new Movie(textBox2.Text, textBox3.Text, Convert.ToInt32(textBox4.Text), textBox5.Text, Convert.ToInt32(textBox6.Text));
                    // Команда на добавлине в БД
                    Data.AddMovie(mv);
                    // Обновление DataGridView
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("Какое-то из полей не заполнено!", "Уведомление");
                }

            }
            else if (radioButton2.Checked)
            {//Билеты
                if (textBox2.Text != String.Empty && comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1 && comboBox3.SelectedIndex != -1)
                {
                    Ticket tk = new Ticket(dateTimePicker1.Value, TimeSpan.Parse(textBox2.Text), comboBox1.SelectedIndex + 1, comboBox2.SelectedIndex + 1, comboBox3.SelectedIndex + 1, checkBox1.Checked);
                    // Команда на добавлине в БД
                    Data.AddTicket(tk);
                    // Автоматическое добавление цены билета
                    Price p = new Price(dateTimePicker1.Value, TimeSpan.Parse(textBox2.Text), comboBox1.SelectedIndex + 1, (decimal)Data.money[comboBox1.SelectedIndex]);

                    // Команда на добавление цены в БД
                    Data.AddMoney(p);
                    // Обновление DataGridView
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("Какое-то из полей не заполнено!", "Уведомление");
                }
            }
            else if (radioButton3.Checked)
            {
                if (textBox2.Text != String.Empty && comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
                {
                    Session ss = new Session(dateTimePicker1.Value, TimeSpan.Parse(textBox2.Text), comboBox1.SelectedIndex + 1, comboBox2.SelectedIndex + 1);
                    // Команда на добавлине в БД
                    Data.AddSession(ss);
                    // Обновление DataGridView
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("Какое-то из полей не заполнено!", "Уведомление");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Удаление
            if (radioButton1.Checked)
            {
                if (textBox2.Text != String.Empty && textBox3.Text != String.Empty && textBox4.Text != String.Empty && textBox5.Text != String.Empty && textBox6.Text != String.Empty)
                {
                    Movie mv = new Movie(textBox2.Text, textBox3.Text, Convert.ToInt32(textBox4.Text), textBox5.Text, Convert.ToInt32(textBox6.Text));
                    Data.DelMovie(mv);
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("Какое-то из полей не заполнено!", "Уведомление");
                }
            }
            else if (radioButton2.Checked)
            {//удаление билета
                if (textBox2.Text != String.Empty && comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1 && comboBox3.SelectedIndex != -1)
                {
                    Ticket tk = new Ticket(Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString()), TimeSpan.ParseExact(textBox2.Text, "c", null), comboBox1.SelectedIndex + 1, comboBox2.SelectedIndex, comboBox3.SelectedIndex, checkBox1.Checked);
                    // Команда на удаление из БД
                    Data.DelTicket(tk);

                    // Автоматическое удаление цены билета
                    Price p = new Price(dateTimePicker1.Value, TimeSpan.Parse(textBox2.Text), comboBox1.SelectedIndex + 1, (decimal)Data.money[comboBox1.SelectedIndex]);

                    // Команда на удаление цены в БД
                    Data.DelPrice(p);

                    // Обновление DataGridView
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("Какое-то из полей не заполнено!", "Уведомление");
                }
            }
            else if (radioButton3.Checked)
            {
                if (textBox2.Text != String.Empty && comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
                {
                    Session ss = new Session(dateTimePicker1.Value, TimeSpan.Parse(textBox2.Text), comboBox1.SelectedIndex + 1, comboBox2.SelectedIndex + 1);
                    // Команда на удаление из БД
                    Data.DelSession(ss);
                    // Обновление DataGridView
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("Какое-то из полей не заполнено!", "Уведомление");
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ИЗМЕНИТЬ
            if (radioButton1.Checked)
            {
                Movie newmv = new Movie(textBox2.Text, textBox3.Text, Convert.ToInt32(textBox4.Text), textBox5.Text, Convert.ToInt32(textBox6.Text));

                Movie oldmv = Data.Movies[dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected) - 1];

                // Команда на изменение в БД
                Data.EditMovie(oldmv, newmv);
                // Обновление DataGridView
                RefreshData();
            }
            else if (radioButton2.Checked)
            {
                Ticket newtk = new Ticket(dateTimePicker1.Value, TimeSpan.Parse(textBox2.Text), comboBox1.SelectedIndex + 1, comboBox2.SelectedIndex + 1, comboBox3.SelectedIndex + 1, checkBox1.Checked);

                Ticket oldtk = Data.Tickets[dataGridView1.CurrentCell.RowIndex];

                // Команда на изменение в БД
                Data.EditTicket(oldtk, newtk);
                // Обновление DataGridView
                RefreshData();
            }
            else if (radioButton3.Checked)
            {
                Session newss = new Session(dateTimePicker1.Value, TimeSpan.Parse(textBox2.Text), comboBox1.SelectedIndex + 1, comboBox2.SelectedIndex + 1);

                Session oldss = Data.Sessions[dataGridView1.CurrentCell.RowIndex];

                // Команда на изменение в БД
                Data.EditSession(oldss, newss);
                // Обновление DataGridView
                RefreshData();
            }
        }
    }
}
