using CrmBl.Model;
using System;
using System.Windows.Forms;

namespace CrmUi
{
    class CashDaskView
    {
        CashDesk cashDesk;
        public Label CashDaskName { get; set; }
        public NumericUpDown Price { get; set; }
        public ProgressBar QueueLenght { get; set; }
        public Label LeaveCustomerCount { get; set; }
        public CashDaskView(CashDesk cashDesk, int number, int x, int y)
        {
            CashDaskName = new Label();
            Price = new NumericUpDown();
            QueueLenght = new ProgressBar();
            LeaveCustomerCount = new Label();
            this.cashDesk = cashDesk;
            CashDaskName.AutoSize = true;
            CashDaskName.Location = new System.Drawing.Point(x, y);
            CashDaskName.Name = "label" + number;
            CashDaskName.Size = new System.Drawing.Size(35, 13);
            CashDaskName.TabIndex = number;
            CashDaskName.Text = cashDesk.ToString();
            
            Price.Location = new System.Drawing.Point(x + 70, y);
            Price.Name = "numericUpDown" + number;
            Price.Size = new System.Drawing.Size(120, 20);
            Price.TabIndex = number;
            Price.Maximum = 100000000000000;

            QueueLenght.Location = new System.Drawing.Point(x + 250, y);
            QueueLenght.Maximum = cashDesk.MaxQueueLenght;
            QueueLenght.Name = "progressBar" + number;
            QueueLenght.Size = new System.Drawing.Size(100, 23);
            QueueLenght.TabIndex = number;
            QueueLenght.Value = 0;

            LeaveCustomerCount.AutoSize = true;
            LeaveCustomerCount.Location = new System.Drawing.Point(x + 400, y);
            LeaveCustomerCount.Name = "label2" + number;
            LeaveCustomerCount.Size = new System.Drawing.Size(35, 13);
            LeaveCustomerCount.TabIndex = number;
            LeaveCustomerCount.Text = "";

            cashDesk.CheckClosed += CashDesk_CheckClosed;
        }

        private void CashDesk_CheckClosed(object sender, Check e)
        {
            Price.Invoke((Action)delegate 
            { 
                Price.Value = e.Price;
                QueueLenght.Value = cashDesk.Count;
                LeaveCustomerCount.Text = cashDesk.ExitCustomer.ToString();
            });
        }
    }
}
