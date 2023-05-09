namespace CinemaC
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Data.Initialization();
            DataStart();
            label1.Visible = false;
            textBox1.Visible = false;
        }

        int labelID = 0;

        public void DataStart()
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < Data.Sessions.Count(); i++)
            {
                //âûáîð íàçâàíèÿ ôèëüìà ïî èä âîçìîæíî íå î÷ òî÷åí
                dataGridView1.Rows.Add(Data.Sessions[i].Date.ToLongDateString(), Data.Sessions[i].Time.ToString().Remove(5,3), Data.Halls[Data.Sessions[i].Hall - 1].NameHall, Data.Movies[Data.Sessions[i].Movie - 1].NameMovie);
            }
        }

        private void AccountChanged()
        {
            if (ïîëüçîâàòåëüToolStripMenuItem.Checked == true)
            {
                //this.Hide();
                new MainForm().Show();
            }
            else
            {
                //this.Hide();
                Form adm = new Adm();
                adm.ShowDialog();
                if (adm.DialogResult == DialogResult.OK)
                {
                    MessageBox.Show("Âû àâòîðèçîâàëèñü îò èìåíè àäìèíèñòðàòîðà", "Óâåäîìëåíèå");
                    àäìèíèñòðàòîðToolStripMenuItem.Checked = true;
                    ïîëüçîâàòåëüToolStripMenuItem.Checked = false;
                    this.Hide();
                    new Control().Show();
                }
                else
                {
                    MessageBox.Show("Ïàðîëü íå âåðíûé. Âû îñòàëèñü ïîëüçîâàòåëåì", "Óâåäîìëåíèå");
                    àäìèíèñòðàòîðToolStripMenuItem.Checked = false;
                    ïîëüçîâàòåëüToolStripMenuItem.Checked = true;
                }
            }
        }

        private void àäìèíèñòðàòîðToolStripMenuItem_Click(object sender, EventArgs e)
        {
            àäìèíèñòðàòîðToolStripMenuItem.Checked = true;
            ïîëüçîâàòåëüToolStripMenuItem.Checked = false;
            AccountChanged();
        }

        private void ïîëüçîâàòåëüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            àäìèíèñòðàòîðToolStripMenuItem.Checked = false;
            ïîëüçîâàòåëüToolStripMenuItem.Checked = true;
            AccountChanged();
        }

        private void âûõîäToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                switch(radioButton.Text)
                {
                    case "Ïî ôèëüìó":
                        {
                            label1.Text = "Íàçâàíèå ôèëüìà:";
                            label1.Visible = true;
                            textBox1.Text = "";
                            textBox1.Visible = true;
                            labelID = 1;
                            CancelSearch.Visible = true;
                            break;
                        }
                    case "Ïî äàòå":
                        {
                            label1.Text = "Äàòà ïðåäñòàâëåíèÿ:";
                            label1.Visible = true;
                            textBox1.Text = "";
                            textBox1.Visible = true;
                            labelID = 2;
                            CancelSearch.Visible = true;
                            break;
                        }
                    case "Ïî âðåìåíè":
                        {
                            label1.Text = "Âðåìÿ ôèëüìà:";
                            label1.Visible = true;
                            textBox1.Text = "";
                            textBox1.Visible = true;
                            labelID = 3;
                            CancelSearch.Visible = true;
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            dataGridView1.Rows.Clear();
            int count = Data.Sessions.Count;
            for(int i = 0; i < count; i++)
            {
                if (labelID == 1)
                {
                    if (Data.Movies[Data.Sessions[i].Movie - 1].NameMovie == str)
                    {
                        dataGridView1.Rows.Add(Data.Sessions[i].Date.ToLongDateString(), Data.Sessions[i].Time.ToString().Remove(3, 3), Data.Sessions[i].Hall, Data.Movies[Data.Sessions[i].Movie - 1].NameMovie);
                    }
                }
                else if (labelID == 2)
                {
                    if (Data.Sessions[i].Date.ToLongDateString() == str)
                    {
                        dataGridView1.Rows.Add(Data.Sessions[i].Date.ToLongDateString(), Data.Sessions[i].Time.ToString().Remove(3, 3), Data.Sessions[i].Hall, Data.Movies[Data.Sessions[i].Movie - 1].NameMovie);
                    }
                }
                else if (labelID == 3)
                {
                    if (Data.Sessions[i].Time.ToString().Remove(3, 3) == str)
                    {
                        dataGridView1.Rows.Add(Data.Sessions[i].Date.ToLongDateString(), Data.Sessions[i].Time.ToString().Remove(3,3), Data.Sessions[i].Hall, Data.Movies[Data.Sessions[i].Movie - 1].NameMovie);
                    }
                }

            }
        }

        private void CancelSearch_Click(object sender, EventArgs e)
        {
            CancelSearch.Visible = false;
            textBox1.Text = "";
            textBox1.Visible = false;
            label1.Visible = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            DataStart();
        }

        private void ïîìîùüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ñ ïîìîùüþ ýòîé ïðîãðàììû âû ìîæåòå ïîñìîòðåòü ñïèñîê ôèëüìîâ, äàòó è âðåìÿ, à òàê æå çàáðîíèðîâàòü ñåáå ìåñòî\n\n\n- Äëÿ ïîèñêà ïî îïðåäåë¸ííûì êðèòåðèÿì èñïîëüçóéòå îáëàñòü \"Ïîèñê\"\n- Äëÿ áðîíèðîâàíèÿ íàæìèòå íà êíîïêó \"Çàáðîíèðîâàòü\"", "Ïîìîùü", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void BookOfTicket_Click(object sender, EventArgs e)
        {
            new BookOfTicket().ShowDialog();
        }
    }
}