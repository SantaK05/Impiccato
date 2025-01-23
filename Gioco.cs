using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impiccato
{
    internal class Gioco
    {
        private string[] rows = File.ReadAllLines(@"c:\temp\impiccato.txt");
        private string[] omino = { "_", "|", "O", "|", "/", @"\", "|", "//", @"\\" };

        private int errori = 0;
        private List<string> erroriList = new List<string>();

        private string parolaScelta;
        private List<string> parolaNascosta;
        public Gioco()
        {
            int casuale = new Random().Next(0, rows.Length);
            this.parolaScelta = rows[casuale];
            parolaNascosta = new List<string>();

            foreach (var lettera in parolaScelta)
            {
                parolaNascosta.Add("_");
            }
        }

        public string getParolaScelta()
        {
            return this.parolaScelta;
        }

        public List<string> getParolaNascosta()
        {
            return this.parolaNascosta;
        }

        public Boolean Check(char lettera)
        {
            Console.WriteLine();
            if (!parolaScelta.Contains(lettera))
            {
                printErrori(omino[errori]);

                foreach (var e in erroriList)
                {
                    Console.Write(e);
                }

                if (errori == 8)
                {
                    Console.WriteLine("Hai perso! \n" +
                        $"La parola era: {parolaScelta}");
                    return false;
                }
                errori += 1;
            }
            else
            {
                for (int i = 0; i < parolaScelta.Length; i++)
                {
                    if (parolaScelta[i] == lettera)
                    {
                        parolaNascosta[i] = lettera.ToString();
                    }
                }

                if (!parolaNascosta.Contains("_"))
                {
                    Console.WriteLine("Hai vinto!");
                    return false;
                }
            }
            Console.WriteLine();
            Console.WriteLine(string.Join("", parolaNascosta));
            return true;
        }

        public void printErrori(string e)
        {
            switch (e)
            {
                case "_":
                    erroriList.AddRange(new string[] { "_", "\n" });
                    break;
                case "|":
                    erroriList.AddRange(new string[] { " |", "\n" });
                    break;
                case "O":
                    erroriList.AddRange(new string[] { " O", "\n" });
                    break;
                case "/":
                    erroriList.AddRange(new string[] { "/", " " });
                    break;
                case @"\":
                    erroriList.AddRange(new string[] { @"\", "\n" });
                    break;
                case "//":
                    erroriList.AddRange(new string[] { "/", " " });
                    break;
                case @"\\":
                    erroriList.AddRange(new string[] { @"\", "\n" });
                    break;
            }
        }
    }
}
