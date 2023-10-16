using System;
using System.Windows.Forms;

namespace WinFormsXML
{
    public class Vozilo
    {
        public string model;
        public int god, brkt;
        public string vrsta;

        public Vozilo(string model, int god, int brkt, string vrsta)
        {
            this.Model = model;
            this.God = god;
            this.Brkt = brkt;
            this.Vrsta = vrsta;
        }

        #region getteri i setteri
        public string Model { get => model; set => model = value; }
        public int God { get => god; set => god = value; }
        public int Brkt { get => brkt; set => brkt = (char)value; }
        public string Vrsta { get => vrsta; set => vrsta = value; }

        #endregion


        public override string ToString()
        {
            string ispis = null;
            string vrstav;

            if (brkt == 2)
            {
                this.vrsta = "Motor";
                ispis = this.Model + "\n" + this.God + "\n" + this.Brkt + "\n" + this.vrsta;
            }
            if (brkt == 4)
            {
                this.vrsta = "Automobil";
                ispis = this.Model + "\n" + this.God + "\n" + this.Brkt + "\n" + this.vrsta;
            }
            if(brkt > 4)
            {
                this.vrsta = "Kamion";
                ispis = this.Model + "\n" + this.God + "\n" + this.Brkt + "\n" + this.vrsta;
            }
           return ispis;
        }
    }
}