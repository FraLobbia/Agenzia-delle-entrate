using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenzia_delle_entrate
{
    internal class Contribuente
    {
        private string Nome {  get; set; }
        private string Cognome { get; set; }
        private DateTime DataNascita { get; set; }
        private string CodiceFiscale { get; set; }
        private char Sesso {  get; set; }
        private string ComuneResidenza { get; set; }
        private double RedditoAnnuale { get; set; }
        private int Aliquota { get; set; }
        private double ImpostaDovuta { get; set; }

        public Contribuente(string nome, string cognome, DateTime dataNascita, string codiceFiscale, char sesso, string comuneResidenza, double redditoAnnuale)
        {
            this.Nome = nome;
            this.Cognome = cognome;
            this.DataNascita = dataNascita;
            this.CodiceFiscale = codiceFiscale;
            this.Sesso = sesso;
            this.ComuneResidenza = comuneResidenza;
            this.RedditoAnnuale = redditoAnnuale;
            this.SetScaglione();
        }

        // in base al reddito annuale calcola l'imposta dovuta in base ai vari scaglioni
        private void SetScaglione()
        {
            if (this.RedditoAnnuale <= 15000)
            {
                this.Aliquota = 23;
                this.ImpostaDovuta = this.RedditoAnnuale * (this.Aliquota / 100);
            }
            else if (this.RedditoAnnuale <= 28000)
            {
                this.Aliquota = 27;
                double eccedenza = this.RedditoAnnuale - 15000;
                this.ImpostaDovuta = 3450 + eccedenza * (this.Aliquota / 100);
            }
            else if (this.RedditoAnnuale <= 55000)
            {
                this.Aliquota = 38;
                double eccedenza = this.RedditoAnnuale - 28000;
                this.ImpostaDovuta = 6960 + eccedenza * (this.Aliquota / 100);
            }
            else if (this.RedditoAnnuale <= 75000)
            {
                this.Aliquota = 41;
                double eccedenza = this.RedditoAnnuale - 55000;
                this.ImpostaDovuta = 17220 + eccedenza * (this.Aliquota / 100);
            }
            else
            {
                this.Aliquota = 43;
                double eccedenza = this.RedditoAnnuale - 75000;
                this.ImpostaDovuta = 25420 + eccedenza * (this.Aliquota / 100);
            }
        }

        public void getInfoContribuente()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("==========================================");
            Console.WriteLine($"CALCOLO DELL'IMPOSTA DA VERSARE:" +
                $"\nContribuente: {this.Nome} {this.Cognome}," +
                $"\nnato il {this.DataNascita} ({this.Sesso})," +
                $"\nresidente in {this.ComuneResidenza}," +
                $"\ncodice fiscale: {this.CodiceFiscale}" +
                $"\nReddito dichiarato: € {this.RedditoAnnuale.ToString("N2")}" +
                $"\nIMPOSTA DA VERSARE: \u20AC {this.ImpostaDovuta.ToString("N2")}");
        } 

    }
}
