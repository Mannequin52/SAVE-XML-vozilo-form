using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.IO;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;

namespace WinFormsXML
{
    public partial class Form1 : Form
    {
        List<Vozilo> brm = new List<Vozilo>(); 
        public Form1()
        {
            InitializeComponent();
        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtBrojKotaca.Text) % 2 == 1)
                {
                    MessageBox.Show("Nije paran broj.", "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                Vozilo brum = new Vozilo(txtModel.Text, Convert.ToInt32(txtGodinaProizvodnje.Text), Convert.ToInt32(txtBrojKotaca.Text), ToString(Vozilo.vrsta));

                txtModel.Clear();
                txtGodinaProizvodnje.Clear();
                txtBrojKotaca.Clear();

                brm.Add(brum);


            }
            catch (Exception greska)
            {
                MessageBox.Show(greska.Message, "Pogresan unos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnObradi_Click(object sender, EventArgs e)
        {
            
            
        }

        private void btnIspis_Click(object sender, EventArgs e)
        {
            txtIspis.Clear();

            txtIspis.Text = "Model:" + "\nGod Proizvodnje" + "\nBroj kotaca" + "\nVozilo je:" + "\n";

            foreach (Vozilo brum in brm)
            {
                txtIspis.AppendText("\n\n" + brum.ToString());
            }
        }


        private void xmlbtn_Click(object sender, EventArgs e)
        {
            string vrsta;
            if (Convert.ToInt32(txtBrojKotaca.Text) == 2)
            {
                vrsta = "Motor";
            }
            if (Convert.ToInt32(txtBrojKotaca.Text) == 4)
            {
                vrsta = "Automobil";
            }
            if (Convert.ToInt32(txtBrojKotaca.Text) > 4)
            {
                vrsta = "Kamion";
            } 

            var dokumentXmlVozilo = new XDocument();
            var rootElem = new XElement("Vozila");
            dokumentXmlVozilo.Add(rootElem);
            foreach (Vozilo vozilo in brm)
            {
                
                var voziloElem = new XElement("Vozilo",
                    new XAttribute("Model", vozilo.model),
                    new XAttribute("Godina-proizvodnje", vozilo.god),
                    new XAttribute("Broj-kotaca", vozilo.brkt),
                    new XElement("Vrsta", vozilo.Vrsta));
                rootElem.Add(voziloElem);

            }
            foreach (Vozilo vozilo in brm)
            {
                xmlispis.AppendText(dokumentXmlVozilo.ToString());
            }

            XmlSerializer serialiser = new XmlSerializer(typeof(List<Vozilo>));

            TextWriter filestream = new StreamWriter(@"C:\output.xml");

            serialiser.Serialize(filestream, xmlispis);

            filestream.Close();


        }
    }
    }


