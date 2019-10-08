using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Book_Information_Keeper
{
    public partial class Form1 : Form
    {
        Dictionary<long, string> bookKeepingList = new Dictionary<long, string>();
        List<long> isbnLIST = new List<long>();
        List<string> nameLIST = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
          
                string isbnNumber = isbnTextBox.Text;
                long isbn = long.Parse(isbnNumber);
                if (isbnNumber.Length != 13)
                {
                    MessageBox.Show("Insert valid isbn");
                    isbnTextBox.Clear();
                    nameTextBox.Clear();
                }
                else if (isbnNumber.Length == 13 && nameTextBox.Text.Length!=0)
                {
                    try
                    {
                        bookKeepingList.Add(isbn, nameTextBox.Text);

                        addListBox.Items.Add(isbnTextBox.Text);
                        addListBox.Items.Add(nameTextBox.Text);
                    }
                    catch (ArgumentException p)
                    {
                        MessageBox.Show("isbn ID alreday exist");
                        isbnTextBox.Clear();
                        nameTextBox.Clear();
                    }
                    isbnTextBox.Clear();
                    nameTextBox.Clear();

                }
        }
            
        
        

        private void addListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchListBox.Items.Clear();
            if (isbnRadioButton.Checked== true)
            {

             isbnLIST = bookKeepingList.Keys.ToList();
             long i = long.Parse(searchTextBox.Text);
                    if (isbnLIST.Contains(i))
                    {
                       searchListBox.Items.Add(bookKeepingList[i]);
                       searchTextBox.Clear();
                    }
                    else 
                    {
                        MessageBox.Show("isbn number invalid");
                        searchTextBox.Clear();
                    }

            }

           else if (nameRadioButton.Checked == true)
            {
                nameLIST = bookKeepingList.Values.ToList();
                string i = Convert.ToString(searchTextBox.Text);
                if (nameLIST.Contains(i))
                {
                    searchListBox.Items.Add(searchTextBox.Text);
                    searchTextBox.Clear();
                }
                else
                {
                    MessageBox.Show("name invalid");
                    searchTextBox.Clear();
                }

            }
        }
    }
}
