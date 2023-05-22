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
            ConnectionDB connection = new ConnectionDB();

            //Get list of providers for the provider listbox
            lstBoxProviders.Items.AddRange(connection.GetAllProviders().ToArray());

            //Get all bills
            bills = connection.GetAllBills(user);

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
            HashSet<int> columnIndexToShow = new HashSet<int>(new int[] { 1, 2, 3, 5, 12});
            for(int i = 0; i < dgvBills.ColumnCount; i++)
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

        }

        /// <summary>
        /// Event handler for the view button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdViewBill_Click(object sender, EventArgs e)
        {
            DataGridViewRow t = dgvBills.Rows[dgvBills.SelectedCells[0].RowIndex];
            MessageBox.Show(t.Cells[0].Value.ToString());
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
