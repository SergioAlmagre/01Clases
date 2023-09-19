using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Clases
{
    internal class Rent
    {
        private string nameCustomer ;
        private string dniCustomer;
        private DateTime dateInit;
        private DateTime dateEnd;
        private string position;
        private Ship shipN;

        public string Namecustomer
        {
            get { return nameCustomer; }
            set { nameCustomer = value; }
        }

        
        public string dnicustomer
        {
            get { return dniCustomer; }
            set { dniCustomer = value; }
        }

        
        public DateTime DateInit
        {
            get { return dateInit; }
            set { dateInit = value; }
        }

        
        public DateTime DateEnd
        {
            get { return dateEnd; }
            set { dateEnd = value; }
        }

        
        public string Position
        {
            get { return position; }
            set { position = value; }
        }
                

        public Ship ShipN
        {
            get { return shipN; }
            set { shipN = value; }
        }


        public Rent(string nameCustomer, string dniCustomer, DateTime dateInit, DateTime dateEnd, string position, Ship shipN)
        {
            this.nameCustomer = nameCustomer;
            this.dniCustomer = dniCustomer;
            this.dateInit = dateInit;
            this.dateEnd = dateEnd;
            this.position = position;
            this.shipN = shipN;
        }


        public override string ToString()
        {
            return base.ToString();
        }

        public int calculateTotalRent(int modulo)
        {
            TimeSpan daysRent = this.dateEnd - this.dateInit;
            int difference = (int)daysRent.TotalDays;
            int total = difference * modulo;
            return total;
        }



    }
}
