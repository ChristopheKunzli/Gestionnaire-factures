using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bill_Manager
{
    public partial class Viewbill : Form
    {
        private Bill bill;

        public Viewbill(Bill bill)
        {
            InitializeComponent();
            this.bill = bill;

            this.Text += "numéro : " + bill.BillNumber;
        }

        /// <summary>
        /// Form load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Viewbill_Load(object sender, EventArgs e)
        {
            txtNum.Text = bill.BillNumber;
            txtDate.Text = bill.Date.ToString();
            txtHT.Text = bill.AmountHT.ToString() + " " + bill.Currency;
            txtTTC.Text = bill.AmountTTC.ToString() + " " + bill.Currency;
            rtxtStorage.Text = bill.StorageLocation;
        }

        /// <summary>
        /// Event handler for the open/print file button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOpenFile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(bill.ImageLink);
        }

        /// <summary>
        /// Event handler for the quit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
