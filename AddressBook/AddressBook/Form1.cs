using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForBirthdays();
            UpdateDisplayMember();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(new Person());

            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }


        private void UpdateDisplayMember()
        {
            listBox1.DisplayMember = "";
            listBox1.DisplayMember = "Name";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                return;
            }

            int savedIndex = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);

            if (savedIndex - 1 > 0)
            {
                listBox1.SelectedIndex = savedIndex - 1;
            }
            else if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                return;
            }

            Person person = (Person)listBox1.SelectedItem;

            TextName.Text = person.Name;
            TextEmail.Text = person.Email;
            TextAddress.Text = person.Address;
            PickerBirthday.Value = person.Birthday;
            TextNotes.Text = person.Notes;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                return;
            }

            Person person = (Person)listBox1.SelectedItem;

            person.Name = TextName.Text;
            person.Email = TextEmail.Text;
            person.Address = TextAddress.Text;
            person.Birthday = PickerBirthday.Value;
            person.Notes = TextNotes.Text;

            UpdateDisplayMember();
        }

        private void CheckForBirthdays()
        {
            Person person;
            string birthday = "";

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                person = listBox1.Items[i] as Person;

                if (person != null && person.Birthday.Day == DateTime.Today.Day && person.Birthday.Month == DateTime.Today.Month)
                {
                    birthday += person.Name + " is " + (DateTime.Today.Year - person.Birthday.Year).ToString() + "today! \n";
                }
            }
            if (birthday != "")
            {
                MessageBox.Show(birthday, "Birthdays!");
            }
        }
    }
}
