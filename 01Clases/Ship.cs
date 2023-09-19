using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _01Clases
{
    internal class Ship
    {
        public Ship(string plate, int boatLength, int year)
        {
            this.plate = plate;
            this.boatLength = boatLength;
            this.year = year;
        }

        public Ship()
        {

        }

        private string plate;

        public string Plate
        {
            get { return plate; }
            set { plate = value; }
        }

        public int boatLength;

        public int BoatLenght
        {
            get { return boatLength; }
            set { boatLength = value; }
        }

        private int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public override string ToString()
        {
            return $"Plate: {plate}, Boat Length: {boatLength}, Year: {year}";
        }

        virtual public int module(int price)
        {
            int total = this.boatLength * price;
            return total;
        }


    }
 


}
