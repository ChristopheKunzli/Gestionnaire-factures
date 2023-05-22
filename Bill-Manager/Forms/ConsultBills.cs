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
    public partial class ConsultBills : Form
    {
        private List<Bill> bills;
        private User user;

        public ConsultBills(User user)
        {
            InitializeComponent();

            this.user = user;
        }

        /// <summary>
        /// Event handler for the form load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConsultBills_Load(object sender, EventArgs e)
        {
            //Get all bills
            bills = new ConnectionDB().GetAllBills(user);

            //Add providers to the listbox only if necessary
            foreach (Bill b in bills)
            {
                if (!lstBoxProviders.Items.Contains(b.Provider))
                {
                    lstBoxProviders.Items.Add(b.Provider);
                }
            }

            //Link bills to the data grid view
            updateDataGridView(bills);
        }

        /// <summary>
        /// Replaces the data grid view's source list
        /// </summary>
        /// <param name="list">The list to display</param>
        private void updateDataGridView(List<Bill> list)
        {
            dgvBills.DataSource = list;

            //Show only basic information columns
            HashSet<int> columnIndexToShow = new HashSet<int>(new int[] { 1, 2, 3, 5, 8 });
            for (int i = 0; i < dgvBills.ColumnCount; i++)
            {
                dgvBills.Columns[i].Visible = columnIndexToShow.Contains(i);
            }

            dgvBills.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        /// <summary>
        /// Event handler for the search button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSearch_Click(object sender, EventArgs e)
        {
            double minAmount = (double)numMin.Value;
            double maxAmount = (double)numMax.Value;

            if (minAmount < 0)
            {
                MessageBox.Show("le montant minimum ne peut pas être négatif");
                return;
            }

            //Determine which search criterias have been entered
            bool searchByAmount = minAmount >= 0 && maxAmount > minAmount;
            bool searchByProvider = lstBoxProviders.SelectedIndex >= 0;

            //Add bills if they fit the criterias
            List<Bill> newBills = new List<Bill>();

            foreach (Bill b in bills)
            {
                Provider selectedProvider = lstBoxProviders.SelectedItem as Provider;

                if (searchByAmount && searchByProvider)
                {
                    if (b.Provider.Equals(selectedProvider) && b.AmountTTC >= minAmount && b.AmountTTC <= maxAmount)
                    {
                        newBills.Add(b);
                    }
                }
                else if(searchByAmount)
                {
                    if(b.AmountTTC >= minAmount && b.AmountTTC <= maxAmount)
                    {
                        newBills.Add(b);
                    }
                }
                else if(searchByProvider)
                {
                    if(b.Provider.Equals(selectedProvider))
                    {
                        newBills.Add(b);
                    }
                }
            }

            updateDataGridView(newBills);
        }

        private bool areProvidersEqual(Provider p1, Provider p2)
        {
            foreach(var property in p1.GetType().GetProperties())
            {
                var value1 = property.GetValue(p1, null);
                var value2 = property.GetValue(p2, null);

                if(value1 != value2) {  return false; }
            }
            return true;
        }

        /// <summary>
        /// Event handler for the view button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdViewBill_Click(object sender, EventArgs e)
        {
            DataGridViewRow t = dgvBills.Rows[dgvBills.SelectedCells[0].RowIndex];

            Viewbill view = new Viewbill(t.DataBoundItem as Bill);

            view.FormClosing += delegate
            {
                this.Show();
            };

            view.Show();
            this.Hide();

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
