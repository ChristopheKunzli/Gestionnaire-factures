﻿using Bill_Manager.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

        private OpenFileDialog ofd = new OpenFileDialog()
        {
            InitialDirectory = @"D:\",
            Title = "Parcourir les fichiers",

            CheckFileExists = true,
            CheckPathExists = true,

            Filter = "Pdf Files|*.pdf",
            RestoreDirectory = true,

            ReadOnlyChecked = true,
            ShowReadOnly = true
        };

        public ImportBill()
        {
            InitializeComponent();
        }

        private void ImportBill_Load(object sender, EventArgs e)
        {
            ConnectionDB connection = new ConnectionDB();

            //Insert list of currencies in combobox
            foreach (Currencies currency in Enum.GetValues(typeof(Currencies)))
            {
                cmbCurrency.Items.Add(currency);
            }
            cmbCurrency.SelectedIndex = -1;

            //Insert list of users in combobox
            cmbUser.DataSource = connection.GetAllUsers();
            cmbUser.SelectedIndex = -1;

            //Insert list of providers in combobox
            cmbProvider.DataSource = connection.GetAllProviders();
            cmbProvider.SelectedIndex = -1;

            //Insert list of types in combobox
            cmbType.DataSource = connection.GetAllTypes();
            cmbType.SelectedIndex = -1;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            //Verify that all mandatory controls contain a value
            bool billNumberIsEmpty = txtBillNumber.Text == string.Empty;
            bool currencyIsEmpty = cmbCurrency.SelectedIndex == -1;
            bool amountHTIsEmpty = txtAmountHT.Text == string.Empty;
            bool amountTTCIsEmpty = txtAmountTTC.Text == string.Empty;

            bool userIsEmpty = cmbUser.SelectedIndex == -1;
            bool providerIsEmpty = cmbProvider.SelectedIndex == -1;
            bool typeIsEmpty = cmbType.SelectedIndex == -1;

            bool fileIsEmpty = ofd.FileName == string.Empty;

            //If any was empty, show error message
            if (billNumberIsEmpty || currencyIsEmpty || amountHTIsEmpty || amountTTCIsEmpty || userIsEmpty || providerIsEmpty || typeIsEmpty || fileIsEmpty)
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires (*)");
                return;
            }

            ConnectionDB connection = new ConnectionDB();

            //Extract the data
            string num = txtBillNumber.Text;
            DateTime date = dateDate.Value;
            string currency = cmbCurrency.SelectedItem.ToString();

            double amountHT = Convert.ToDouble(txtAmountHT.Text);
            double amountTTC = Convert.ToDouble(txtAmountTTC.Text);

            string storage = rtxtStorage.Text;
            string filePath = copyFile(ofd.FileName); //Copy the file to server storage location

            User user = cmbUser.SelectedItem as User;
            Provider provider = cmbProvider.SelectedItem as Provider;
            Type type = cmbType.SelectedItem as Type;

            //Send it to the connction class
            connection.AddBill(new Bill(num, date, currency, amountHT, amountTTC, storage, filePath, provider, type, user));

            Close();
        }

        /// <summary>
        /// Copies a file into a specified direcory
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="destination"></param>
        /// <returns>the full destination path</returns>
        private string copyFile(string filePath, string destination = "C:\\bills")
        {
            string selectedFilePath = filePath;
            string selectedFileName = Path.GetFileName(selectedFilePath);

            string destinationFilePath = Path.Combine(destination, selectedFileName);

            File.Copy(selectedFilePath, destinationFilePath);

            return destinationFilePath;
        }

        private void cmdFile_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(ofd.FileName).ToLower() != ".pdf")
                {
                    MessageBox.Show("Veuillez sélectionner un ficher de type PDF");
                    ofd.FileName = "";
                    return;
                }

                lblFile.Text = ofd.FileName;
            }
            else
            {
                ofd.FileName = "";
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}
