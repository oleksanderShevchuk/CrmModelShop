using CrmBl.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUi
{
    public partial class ModelForm : Form
    {
        ShopComputerModel model = new ShopComputerModel();
        public ModelForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cashDasks = new List<CashDaskView>();
            for (int i = 0; i < model.CashDesks.Count; i++)
            {
                var dask = new CashDaskView(model.CashDesks[i], i, 10, 20 * i);
                cashDasks.Add(dask);
                Controls.Add(dask.CashDaskName);
                Controls.Add(dask.Price);
                Controls.Add(dask.QueueLenght);
                Controls.Add(dask.LeaveCustomerCount);
            }
            model.Start();
        }

        private void ModelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            model.Stop();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            model.CashDaskSpeed = (int)numericUpDown1.Value;
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            model.CashDaskSpeed = (int)numericUpDown2.Value;
        }
    }
}
