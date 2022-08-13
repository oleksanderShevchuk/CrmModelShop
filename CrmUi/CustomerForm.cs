using CrmBl.Model;
using System;
using System.Windows.Forms;

namespace CrmUi
{
    public partial class CustomerForm : Form
    {
        public Customer Customer { get; set; }
        public CustomerForm()
        {
            InitializeComponent();
        }
        public CustomerForm(Customer customer) : this()
        {
            Customer = customer;
            textBox1.Text = customer.Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var c = Customer ?? new Customer();
            c.Name = textBox1.Text;
            Close();
        }
    }
}
