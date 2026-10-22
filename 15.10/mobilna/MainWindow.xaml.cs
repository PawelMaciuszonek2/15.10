using System.Collections.ObjectModel;
using System.Windows;

namespace AplikacjaMobilna
{
    // Klasa Notatka reprezentująca notatkę użytkownika
    public class Notatka
    {
        public string Tytul { get; set; }
        public string Tresc { get; set; }
        public bool Priorytet { get; set; }
        public DateTime DataDodania { get; set; }

        // Konstruktor trójargumentowy
        public Notatka(string tytul, string tresc, bool priorytet)
        {
            Tytul = tytul;
            Tresc = tresc;
            Priorytet = priorytet;
            DataDodania = DateTime.Now;
        }

        // Konstruktor jednoargumentowy
        public Notatka(string tytul)
        {
            Tytul = tytul;
            Tresc = "";
            Priorytet = false;
            DataDodania = DateTime.Now;
        }

        // Nadpisanie ToString dla widoku listy
        public override string ToString()
        {
            string wazna = Priorytet ? "WAŻNA! " : "";
            return $"[{DataDodania:dd.MM.yyyy}] Notatka {wazna}{Tytul}: {Tresc}";
        }
    }

    public partial class MainWindow : Window
    {
        // Kolekcja obserwowalna – zmiany widoczne automatycznie w ListView
        private ObservableCollection<Notatka> kolekcjaNotatek = new ObservableCollection<Notatka>();

        public MainWindow()
        {
            InitializeComponent();

            // Stan początkowy – jedna przykładowa notatka
            kolekcjaNotatek.Add(new Notatka("Zakupy", "Mleko, chleb, masło", false));

            // Przypisanie kolekcji do widoku listy
            listaNotatek.ItemsSource = kolekcjaNotatek;
        }

        /*
         * nazwa: PrzyciskDodaj_Click
         * opis: Obsługuje zdarzenie kliknięcia przycisku DODAJ; tworzy nową notatkę
         *       z wartościami pobranymi z pól tekstowych i dodaje ją do kolekcji
         * parametry: sender - obiekt wywołujący zdarzenie,
         *            e - argumenty zdarzenia
         * zwracany typ: brak
         * autor: <numer zdającego>
         */
        private void PrzyciskDodaj_Click(object sender, RoutedEventArgs e)
        {
            string tytul = poleTytul.Text;
            string tresc = poleTresc.Text;

            // Tworzy nową notatkę (nieważną) z danych z pól edycyjnych
            Notatka nowaNotatka = new Notatka(tytul, tresc, false);

            // Dodanie do kolekcji – ListView odświeży się automatycznie
            kolekcjaNotatek.Add(nowaNotatka);

            // Wyczyszczenie pól po dodaniu
            poleTytul.Clear();
            poleTresc.Clear();
        }
    }
}