using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Clases
{
    internal class Sailboat:Ship
    {
		private int mast;

        public Sailboat()
        {

        }

        public Sailboat(string plate, int boatLength, int year, int mast) : base(plate, boatLength, year)
        {
            this.mast = mast;
        }

        public int Mast
		{
			get { return mast; }
			set { mast = value; }
		}

        public override string ToString()
        {
            return base.ToString();
        }

        public override int module(int price)
        {
            int total = (this.boatLength * price) + mast;
            return total;
        }



    }
}
