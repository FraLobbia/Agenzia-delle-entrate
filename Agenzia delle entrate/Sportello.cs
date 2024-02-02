using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenzia_delle_entrate
{
    internal static class Sportello
    {
        public static void Menu() 
        {
            Console.WriteLine("======================= AGENZIA DELLE ENTRATE =============================");
            Console.WriteLine("Benvenuto! Inserire i propri dati per un riepilogo di quanto dovuto:");
            Console.WriteLine("===========================================================================");

            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Cognome:");
            string cognome = Console.ReadLine();
            Console.Write("Inserisci la data di nascita (formato: dd/MM/yyyy): ");
            string dataNascita = Console.ReadLine();

            // Specifica il formato italiano per la data
            string formatoItaliano = "dd/MM/yyyy";

            // TryParseExact converte una stringa in un dato dateTime con il formato passato, restituisce true se la conversione è andata a buon fine
            // out DateTime dataDiNascita significa che il metodo mi converte la stringa "dataDiNascita" in un oggetto DateTime
            if (DateTime.TryParseExact(dataNascita, formatoItaliano, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataDiNascita))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Data di nascita valida: " + dataDiNascita.ToShortDateString());
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Formato data non valido. Assicurati di inserire la data nel formato corretto (dd/MM/yyyy).");
                Console.ResetColor();
            }

            Console.WriteLine("Codice Fiscale:");
            string codiceFiscale = Console.ReadLine();

            Console.WriteLine("Sesso (M/F):");
            char sesso = Convert.ToChar(Console.ReadLine().ToUpper());

            Console.WriteLine("Comune di residenza:");
            string comune = Console.ReadLine();

            Console.WriteLine("Reddito annuale:");
            double redditoAnnuale = Convert.ToDouble(Console.ReadLine());

            Contribuente newContribuente = new Contribuente(nome, cognome, dataDiNascita, codiceFiscale, sesso, comune, redditoAnnuale);
            


            newContribuente.getInfoContribuente();
            Console.ReadLine();
        }
    }
}
