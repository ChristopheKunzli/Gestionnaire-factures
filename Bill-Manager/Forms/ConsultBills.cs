using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Bill_Manager
{
    public partial class ConsultBills : Form
    {
        private List<Bill> allBills;
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
            allBills = new ConnectionDB().GetAllBills(user);

            //Add providers to the listbox only if necessary
            foreach (Bill b in allBills)
            {
                if (!lstBoxProviders.Items.Contains(b.Provider))
                {
                    lstBoxProviders.Items.Add(b.Provider);
                    cmbProviders.Items.Add(b.Provider);
                }
            }

            //Link bills to the data grid view
            updateDataGridView(allBills);

            //Initialize the chart with every bill
            reloadChart(allBills);
        }

        /// <summary>
        /// Used to load bills in a chart separated by year
        /// </summary>
        private class BillGroup
        {
            private List<Bill> bills = new List<Bill>();
            private int year;
            private double sum = 0;
            private double average = 0;
            public List<Bill> Bills { get { return bills; } }
            public double Sum { get { return sum; } }
            public double Average { get { return average; } }
            public int Year { get { return year; } }

            public BillGroup(int year)
            {
                this.year = year;
            }

            public BillGroup(int year, List<Bill> bills)
            {
                this.year = year;
                InsertBillList(bills);
            }

            public void InsertBillList(List<Bill> bills)
            {
                foreach (Bill b in bills)
                {
                    InsertBill(b);
                }
            }

            public void InsertBill(Bill bill)
            {
                //Add the bill to the list
                bills.Add(bill);

                //Update sum and average
                sum += bill.AmountTTC;
                average = sum / bills.Count;
            }
        }

        /// <summary>
        /// Reloads the chart with a list of bills
        /// </summary>
        private void reloadChart(List<Bill> bills, string title = "Tous les fournisseurs")
        {
            //Reset the chart 
            chartAverage.Titles.Clear();
            chartAverage.Series.Clear();

            //Create the groups of bills
            int year = DateTime.Now.Year;

            List<BillGroup> groups = new List<BillGroup>();
            for (int i = 0; i < 5; i++)
            {
                BillGroup group = new BillGroup(year - i, searchBills(bills, year - i));

                groups.Add(group);
            }

            chartAverage.DataSource = groups;
            chartAverage.Titles.Add(title);

            //Add a series showing averages per year
            Series averages = new Series();
            averages.Name = "Moyennes";

            averages.XValueMember = "Year";
            averages.YValueMembers = "Average";

            chartAverage.Series.Add(averages);

            //Add a series showing sums per year
            Series sums = new Series();
            sums.Name = "Sommes";

            sums.XValueMember = "Year";
            sums.YValueMembers = "Sum";

            chartAverage.Series.Add(sums);
        }

        /// <summary>
        /// Reloads the chart using only bills from a certain provider
        /// </summary>
        /// <param name="provider"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void reloadChart(List<Bill> bills, Provider provider)
        {
            reloadChart(searchBills(bills, provider), provider.Name);
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

            dgvBills.Columns[1].HeaderText = "Numéro de facture";
            dgvBills.Columns[2].HeaderText = "Date";
            dgvBills.Columns[3].HeaderText = "Devise";
            dgvBills.Columns[5].HeaderText = "Montant TTC";
            dgvBills.Columns[8].HeaderText = "Fournisseur";

            dgvBills.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvBills.Rows[0].Selected = false;
        }

        /// <summary>
        /// Find every bill from a specific year
        /// </summary>
        /// <param name="fullList"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        private List<Bill> searchBills(List<Bill> fullList, int year)
        {
            List<Bill> list = new List<Bill>();

            foreach (Bill b in fullList)
            {
                if (b.Date.Year == year)
                {
                    list.Add(b);
                }
            }

            return list;
        }

        /// <summary>
        /// Find bills that have amountTTC between min and max
        /// </summary>
        /// <param name="fullList"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private List<Bill> searchBills(List<Bill> fullList, double min, double max)
        {
            List<Bill> list = new List<Bill>();

            foreach (Bill b in fullList)
            {
                if (b.AmountTTC >= min && b.AmountTTC <= max)
                {
                    list.Add(b);
                }
            }

            return list;
        }

        /// <summary>
        /// Find bills from a specific provider
        /// </summary>
        /// <param name="fullList"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        private List<Bill> searchBills(List<Bill> fullList, Provider provider)
        {
            List<Bill> list = new List<Bill>();

            foreach (Bill b in fullList)
            {
                if (b.Provider == provider)
                {
                    list.Add(b);
                }
            }

            return list;
        }

        /// <summary>
        /// Find bills from a specific that have amountTTC between min and max
        /// </summary>
        /// <param name="fullList"></param>
        /// <param name="provider"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private List<Bill> searchBills(List<Bill> fullList, Provider provider, double min, double max)
        {
            List<Bill> list = new List<Bill>();

            foreach (Bill b in fullList)
            {
                if (b.Provider.Equals(provider) && b.AmountTTC >= min && b.AmountTTC <= max)
                {
                    list.Add(b);
                }
            }

            return list;
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

            //Errors
            if (minAmount < 0)
            {
                MessageBox.Show("le montant minimum ne peut pas être négatif");
                return;
            }

            //Determine which search criterias have been entered
            bool searchByAmount = minAmount >= 0 && maxAmount > minAmount;
            bool searchByProvider = lstBoxProviders.SelectedIndex >= 0;

            //Add bills if they fit the criterias
            List<Bill> newBills;

            Provider selectedProvider = lstBoxProviders.SelectedItem as Provider;

            if (searchByAmount && searchByProvider)
            {
                newBills = searchBills(allBills, selectedProvider, minAmount, maxAmount);
            }
            else if (searchByAmount)
            {
                newBills = searchBills(allBills, minAmount, maxAmount);
            }
            else if (searchByProvider)
            {
                newBills = searchBills(allBills, selectedProvider);
            }
            else
            {
                newBills = new List<Bill>(allBills);
            }

            //Reset search controls
            lstBoxProviders.ClearSelected();
            numMin.Value = 0;
            numMax.Value = 0;

            updateDataGridView(newBills);
        }

        /// <summary>
        /// Event handler for the view button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdViewBill_Click(object sender, EventArgs e)
        {
            if (dgvBills.Rows.Count == 0 || dgvBills.SelectedRows.Count == 0) return;

            //Find which row is selected
            int index = dgvBills.SelectedCells[0].RowIndex;
            DataGridViewRow t = dgvBills.Rows[index];

            //Send the item in the selected row to new form
            Viewbill view = new Viewbill(t.DataBoundItem as Bill);

            //Reopen current form when new form closes
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

        /// <summary>
        /// Reload chart data when selected provider changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProviders_SelectedIndexChanged(object sender, EventArgs e)
        {
            Provider selectedProvider = cmbProviders.SelectedItem as Provider;
            reloadChart(allBills, selectedProvider);
        }
    }
}
