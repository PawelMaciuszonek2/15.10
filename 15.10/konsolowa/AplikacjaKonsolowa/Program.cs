// Aplikacja konsolowa - Program notatek użytkownika

class Notatka
{
    // Ogólnodostępne pola klasy
    public string Tytul;
    public string Tresc;
    public bool Priorytet;
    public DateTime DataDodania;

    /*
     * nazwa: Notatka (konstruktor trójargumentowy)
     * opis: Tworzy notatkę z podanym tytułem, treścią i priorytetem; przypisuje aktualną datę
     * parametry: tytul - tytuł notatki (string),
     *            tresc - treść notatki (string),
     *            priorytet - czy notatka jest ważna (bool)
     * zwracany typ: brak
     * autor: <numer zdającego>
     */
    public Notatka(string tytul, string tresc, bool priorytet)
    {
        Tytul = tytul;
        Tresc = tresc;
        Priorytet = priorytet;
        DataDodania = DateTime.Now;
    }

    // Konstruktor jednoargumentowy – tylko tytuł, treść pusta, priorytet nieważny
    public Notatka(string tytul)
    {
        Tytul = tytul;
        Tresc = "";
        Priorytet = false;
        DataDodania = DateTime.Now;
    }

    /*
     * nazwa: WypiszNotatke
     * opis: Wyświetla dane notatki na ekranie: linię poziomą, tytuł (z oznaczeniem ważności),
     *       treść oraz datę dodania, a następnie kolejną linię poziomą
     * parametry: brak
     * zwracany typ: brak
     * autor: <numer zdającego>
     */
    public void WypiszNotatke()
    {
        Console.WriteLine("__________________");
        if (Priorytet)
            Console.WriteLine("Notatka WAŻNA! " + Tytul);
        else
            Console.WriteLine("Notatka " + Tytul);
        Console.WriteLine(Tresc);
        Console.WriteLine(DataDodania.ToString("dd.MM.yyyy"));
        Console.WriteLine("__________________");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Pierwsza notatka – konstruktor trójargumentowy, notatka ważna
        Notatka notatka1 = new Notatka("Zakupy", "Mleko, chleb, masło", true);

        // Druga notatka – konstruktor jednoargumentowy, tytuł z klawiatury
        Console.Write("Podaj tytuł notatki: ");
        string tytul = Console.ReadLine() ?? "";
        Notatka notatka2 = new Notatka(tytul);

        // Wyświetlenie obu notatek
        notatka1.WypiszNotatke();
        notatka2.WypiszNotatke();
    }
}
