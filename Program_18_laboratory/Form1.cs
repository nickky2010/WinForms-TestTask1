using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_18_laboratory
{
    public partial class Form1 : Form
    {
        List<Person> people = new List<Person>();
        BindingSource source = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            people.Add(new Person ("Donald", "Duck", 10, "Donald.jpg"));
            people.Add(new Person("Child", "Ivanov", 2, "Child.jpg"));
            people.Add(new Person("Petya", "Sidorov", 5, "Petya.jpg"));
            people.Add(new Person("Iog", "Petrov", 30, "Iog.jpg"));
            people.Add(new Person("Ded", "Moroz", 60, "Ded.jpg"));
            source.DataSource = people;
            listBox1.DataSource = source;
            listView1.Columns.Add("Name");
            listView1.Columns.Add("Surname");
            listView1.Columns.Add("Age");
            listView1.Columns[0].Width = 100;
            listView1.Columns[1].Width = 100;
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Effect == DragDropEffects.Move)
            {
                Person person = (Person)e.Data.GetData(typeof(Person));
                if (person != null)
                {
                    listView1.Items.Add(person.Name, person.Foto);
                    listView1.Items[listView1.Items.Count-1].Checked = true;
                    listView1.Items[listView1.Items.Count - 1].Name = person.Name;
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(person.Name);
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(person.Surname);
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(person.Age.ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems[0].Text = person.Name;
                    listView1.Items[listView1.Items.Count - 1].SubItems[1].Text = person.Surname;
                    listView1.Items[listView1.Items.Count - 1].SubItems[2].Text = person.Age.ToString();
                    source.Remove(person);
                }
            }
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                try
                {
                    if (listBox1.SelectedItems != null)
                        listBox1.DoDragDrop(listBox1.SelectedItem, DragDropEffects.Move);
                }
                catch { }
            }
        }

        private void largeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void littleIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.Tile;
        }

        private void detalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected)
                {
                    panel1.BackgroundImage = imageList3.Images[listView1.Items[i].ImageKey];
                    break;
                }
            }
        }
    }
}
