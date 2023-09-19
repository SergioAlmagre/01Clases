using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Clases
{
    internal class yacht:Ship
    {
		private int power;
		private int nCabin;

        public yacht(string plate, string boatLength, int year, int power, int nCabin) : base(plate, boatLength, year)
        {
			this.power = power;
			this.nCabin = nCabin;
        }

        public int NCabin
		{
			get { return nCabin; }
			set { nCabin = value; }
		}

		public int Power
		{
			get { return power; }
			set { power = value; }
		}

        public override string ToString()
        {
            return base.ToString();
        }



    }
}
