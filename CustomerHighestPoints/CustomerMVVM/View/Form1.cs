using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomerMVVM.ViewModel;

namespace CustomerMVVM
{
    public partial class Form1 : Form
    {
        customerViewModel customView;
        int id;
        double amount;
        public Form1()
        {
            InitializeComponent();
            customView = new customerViewModel();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(textBox1.Text);
            amount = Convert.ToDouble(textBox2.Text);
            if(customView.checkID(id,amount) == true)
            {
                button1.Enabled = false;

                //SHow highest chustomer points
                customView.highestCustomer();
                label5.Text = "Customer: " + customView.Name + "Has the highest points with: " + customView.Points + " pts";
            }
            else
            {
                MessageBox.Show("Incorrect ID");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled=true;
        }
    }
}
