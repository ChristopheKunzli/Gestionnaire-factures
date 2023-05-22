using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bill_Manager
{
    public class Bill
    {
        private int id;
        private string billNumber;
        private DateTime date;
        private string currency;
        private double amountHT;
        private double amountTTC;
        private string storageLocation;
        private string imgLink;
        private Provider provider;
        private Type type;
        private User user;

        public int Id { get { return id; } }
        public string BillNumber { get {  return billNumber; } }
        public DateTime Date { get { return date; } }
        public string Currency { get { return currency; } }
        public double AmountHT { get {  return amountHT; } }
        public double AmountTTC { get {  return amountTTC; } }
        public string StorageLocation { get {  return storageLocation; } }
        public string ImageLink { get {  return imgLink; } }
        public Provider Provider { get { return provider; } }
        public Type Type { get { return type; } }
        public User User { get { return user; } }

        public Bill (int id, string billNumber, DateTime date, string currency, double amountHC, double amountTTC, string storageLocation, string imgLink, Provider provider, Type type, User user)
        {
            this.id = id;
            this.billNumber = billNumber;
            this.date = date;
            this.currency = currency;
            this.amountHT = amountHC;
            this.amountTTC = amountTTC;
            this.storageLocation = storageLocation;
            this.imgLink = imgLink;
            this.provider = provider;
            this.type = type;
            this.user = user;
        }

        public Bill(string billNumber, DateTime date, string currency, double amountHC, double amountTTC, string storageLocation, string imgLink, Provider provider, Type type, User user)
        {
            this.id = -1;
            this.billNumber = billNumber;
            this.date = date;
            this.currency = currency;
            this.amountHT = amountHC;
            this.amountTTC = amountTTC;
            this.storageLocation = storageLocation;
            this.imgLink = imgLink;
            this.provider = provider;
            this.type = type;
            this.user = user;
        }

        public override string ToString()
        {
            return $"Numéro:{billNumber}, date:{date.Day}:{date.Month}:{date.Year}, fournisseur:{provider}, montant TTC:{amountTTC} {currency}";
        }
    }
}
