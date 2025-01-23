using Impiccato;
class Program
{
    static void Main(string[] args)
    {
        Gioco impiccato = new Gioco();

        Console.WriteLine("Benvenuto al gioco dell'impiccato!");
        
        string parolaNascosta = string.Join(" ", impiccato.getParolaNascosta());
        Console.WriteLine($"La parola da trovare è: {parolaNascosta}");

        while (true)
        {
            Console.WriteLine("Inserisci una lettera: ");
            char lettera = Console.ReadKey().KeyChar;
            Boolean res = impiccato.Check(lettera);

            if (!res)
            {
                break;
            }
        }
    }
}