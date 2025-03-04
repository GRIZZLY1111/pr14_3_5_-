using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace praktika14_3_5__Солихов
{
    public partial class Form1 : Form
    {
        Queue<int> Qu = new Queue<int>();
        Queue<string> sotrudniki = new Queue<string>();
        Queue<string> sotrudnikist40 = new Queue<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    listBox1.Items.Clear();
                    int n = Convert.ToInt32(textBox1.Text);
                    int p = 0;
                    while (n > p)
                    {
                        p = p + 1;
                        Qu.Enqueue(p);
                    }
                    listBox1.Items.Add("n = " + n);
                    listBox1.Items.Add("Размерность очереди = " + n);
                    listBox1.Items.Add("Верхний элеменнт очереди = " + n);
                    listBox1.Items.Add($"Содержимое очереди = ");
                    for (int i = Qu.Count; i > 0; i--)
                    {
                        listBox1.Items.Add(Qu.Dequeue());
                    }
                    Qu.Clear();
                    listBox1.Items.Add("Новая размерность очереди = " + Qu.Count);
                }
                else
                {
                    MessageBox.Show("Заполните поле ввода");
                }
            }
            catch
            {
                MessageBox.Show("Неверный ввод");
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists("t.txt"))
            {
                StreamReader si = File.OpenText("t.txt");
                {
                    while (true)
                    {
                        string st = si.ReadLine();
                        if (st == null)
                        {
                            break;
                        }
                        string[] chelovek = st.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        var age = chelovek.Skip(3).Take(1);
                        foreach (string i in age)
                        {
                            int vozr = Convert.ToInt32(i);
                            if (vozr < 40)
                            {
                                for (int j = 0; j < chelovek.Length; j++)
                                {
                                    sotrudniki.Enqueue(chelovek[j]);
                                }
                            }
                            else
                            {
                                for (int j = 0; j < chelovek.Length; j++)
                                {
                                    sotrudnikist40.Enqueue(chelovek[j]);
                                }
                            }
                        }
                    }
                    si.Close();
                    int k = 0, l = 0;
                    dataGridView1.ColumnCount = 5;
                    dataGridView1.RowCount = ((sotrudniki.Count/5)+(sotrudnikist40.Count/5));
                    while (sotrudniki.Count != 0)
                    {
                        dataGridView1.Rows[k].Cells[l].Value = sotrudniki.Dequeue();
                        l++;
                        if (l == 5)
                        {
                            l = 0;
                            k++;
                        }
                    }
                    while (sotrudnikist40.Count != 0)
                    {
                        dataGridView1.Rows[k].Cells[l].Value = sotrudnikist40.Dequeue();
                        l++;
                        if (l == 5)
                        {
                            l = 0;
                            k++;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Такой файл не существует");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists("t.txt"))
            {
                StreamReader si = File.OpenText("t.txt");
                {
                    while (true)
                    {
                        string st = si.ReadLine();
                        if (st == null)
                        {
                            break;
                        }
                        string[] chelovek = st.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        var age = chelovek.Skip(3).Take(1);
                        foreach (string i in age)
                        {
                            int vozr = Convert.ToInt32(i);
                            if (vozr < 40)
                            {
                                for (int j = 0; j < chelovek.Length; j++)
                                {
                                    sotrudniki.Enqueue(chelovek[j]);
                                }
                            }
                            else
                            {
                                for (int j = 0; j < chelovek.Length; j++)
                                {
                                    sotrudnikist40.Enqueue(chelovek[j]);
                                }
                            }
                        }
                    }
                    si.Close();
                    int k = 0, l = 0;
                    dataGridView1.ColumnCount = 5;
                    dataGridView1.RowCount = ((sotrudniki.Count / 5) + (sotrudnikist40.Count / 5));
                    while (sotrudniki.Count != 0)
                    {
                        dataGridView1.Rows[k].Cells[l].Value = sotrudniki.Dequeue();
                        l++;
                        if (l == 5)
                        {
                            l = 0;
                            k++;
                        }
                    }
                    while (sotrudnikist40.Count != 0)
                    {
                        dataGridView1.Rows[k].Cells[l].Value = sotrudnikist40.Dequeue();
                        l++;
                        if (l == 5)
                        {
                            l = 0;
                            k++;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Такой файл не существует");
            }
        }
    }
}
