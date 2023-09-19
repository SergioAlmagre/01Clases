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

        public string Namecustomer
        {
            get { return nameCustomer; }
            set { nameCustomer = value; }
        }

        private string dniCustomer;

        public string dnicustomer
        {
            get { return dniCustomer; }
            set { dniCustomer = value; }
        }

        private DateTime dateInit;

        public DateTime DateInit
        {
            get { return dateInit; }
            set { dateInit = value; }
        }

        private DateTime dateEnd;

        public DateTime DateEnd
        {
            get { return dateEnd; }
            set { dateEnd = value; }
        }

        private string position;

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        private Ship shipN;

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



    }
}
