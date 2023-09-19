using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Clases
{
    internal class SportBoat:Ship
    {

		private int power;

        public SportBoat(string plate, int boatLength, int year, int power) : base(plate, boatLength, year)
        {
            this.power = power;
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

        public override int module(int price)
        {
            int total = this.boatLength * price + power;
            return total;
        }


    }
}
