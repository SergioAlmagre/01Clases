using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Clases
{
    internal class Ship
    {
        public Ship(string plate, string boatLength, int year)
        {
            this.plate = plate;
            this.boatLength = boatLength;
            this.year = year;
        }

        private string plate;

        public string Plate
        {
            get { return plate; }
            set { plate = value; }
        }

        private string boatLength;

        public string BoatLenght
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

        public static void Rent()
        {

        }



    }

}
