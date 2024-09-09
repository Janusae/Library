using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                LibraryEntities Context = new LibraryEntities();
                Book newObject = new Book();
                newObject.BookName = textBox2.Text;
                newObject.BookSerial = Convert.ToInt32(textBox1.Text);
                newObject.DateOfBuy = DateTime.Parse(textBox3.Text);
                Context.Books.Add(newObject);
                Context.SaveChanges();
                dataGridView1.DataSource = Context.Books.ToList();
            }
            catch(FormatException)
            {
                MessageBox.Show("You can not enter string for number!");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException) 
            {
                MessageBox.Show("Your Information is Wrong!");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LibraryEntities Context = new LibraryEntities();
            dataGridView1.DataSource = Context.Books.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Convert.ToInt32(textBox1.Text);
                LibraryEntities Context = new LibraryEntities();
                var query = from row in Context.Books
                            where row.BookSerial == id
                            select row;
                if (query.Count() == 0) MessageBox.Show("We could not find anything!");
                else
                {
                    dataGridView1.DataSource = query.ToList();
                }
                
            }
            catch(FormatException)
            {
                MessageBox.Show("You can not enter string for number!");
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var SerrialId = Convert.ToInt32(textBox1.Text);
                LibraryEntities Context = new LibraryEntities();
                var query = from row in Context.Books
                            where row.BookSerial == SerrialId
                            select row;
                if (query.Count() == 0) MessageBox.Show("We could not find anything!");
                else
                {
                    Context.Books.Remove(query.First());
                    Context.SaveChanges();
                    dataGridView1.DataSource = Context.Books.ToList();
                }
            }
            catch(FormatException)
            {
                MessageBox.Show("You can not enter string for number!");
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
