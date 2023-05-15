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
    public partial class ImportBill : Form
    {
        public enum Currencies
        {
            CHF,
            EUR,
            USD
        }

        public ImportBill()
        {
            InitializeComponent();
        }

        private void ImportBill_Load(object sender, EventArgs e)
        {
            foreach(Currencies currency in Enum.GetValues(typeof(Currencies)))
            {
                cmbCurrency.Items.Add(currency);
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}
