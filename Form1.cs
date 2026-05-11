using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace projekt2algorytmy
{
    public partial class Form1 : Form
    {
        public class Wierzcholek
        {
            public string Nazwa;
            public Point Pozycja;
            public int Promien = 20;

            public Wierzcholek(string nazwa, Point pozycja)
            {
                Nazwa = nazwa;
                Pozycja = pozycja;
            }
        }

        public class Krawedz
        {
            public Wierzcholek Start;
            public Wierzcholek Koniec;
            public int Waga;
            public bool CzyWDrzewie = false;

            public Krawedz(Wierzcholek start, Wierzcholek koniec, int waga)
            {
                Start = start;
                Koniec = koniec;
                Waga = waga;
            }
        }

        List<Wierzcholek> listaWierzcholkow = new List<Wierzcholek>();
        List<Krawedz> listaKrawedzi = new List<Krawedz>();
        Wierzcholek wybranyWierzcholek = null;

        public Form1()
        {
            InitializeComponent();
            var doubleBufferProperty = typeof(Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            doubleBufferProperty.SetValue(panel1, true, null);
        }

        private List<Krawedz> MergeSortKrawedzi(List<Krawedz> lista)
        {
            if (lista.Count <= 1)
                return lista;

            int middle = lista.Count / 2;
            List<Krawedz> left = lista.Take(middle).ToList();
            List<Krawedz> right = lista.Skip(middle).ToList();

            left = MergeSortKrawedzi(left);
            right = MergeSortKrawedzi(right);

            return MergeKrawedzi(left, right);
        }

        private List<Krawedz> MergeKrawedzi(List<Krawedz> left, List<Krawedz> right)
        {
            List<Krawedz> result = new List<Krawedz>();
            int i = 0, j = 0;

            while (i < left.Count && j < right.Count)
            {
                if (left[i].Waga <= right[j].Waga)
                {
                    result.Add(left[i]);
                    i++;
                }
                else
                {
                    result.Add(right[j]);
                    j++;
                }
            }

            while (i < left.Count)
            {
                result.Add(left[i]);
                i++;
            }

            while (j < right.Count)
            {
                result.Add(right[j]);
                j++;
            }

            return result;
        }

        private void ResetujWynikAlgorytmu()
        {
            foreach (var k in listaKrawedzi)
            {
                k.CzyWDrzewie = false;
            }
            textBox1.Clear();
            panel1.Invalidate();
        }

        private void Dodaj_wierzcholek_btn_Click(object sender, EventArgs e)
        {
            string nazwa = Microsoft.VisualBasic.Interaction.InputBox("Podaj nazwê wierzcho³ka:", "Nowy Wierzcho³ek", "V" + (listaWierzcholkow.Count + 1));

            if (!string.IsNullOrWhiteSpace(nazwa))
            {
                if (listaWierzcholkow.Any(w => w.Nazwa == nazwa))
                {
                    MessageBox.Show("Wierzcho³ek o tej nazwie ju¿ istnieje!");
                    return;
                }

                listaWierzcholkow.Add(new Wierzcholek(nazwa, new Point(50, 50)));
                listBox1.Items.Add(nazwa);
                panel1.Invalidate();
            }
            ResetujWynikAlgorytmu();
        }

        private void Polacz_wierzcholki_btn_Click(object sender, EventArgs e)
        {
            if (listaWierzcholkow.Count < 2)
            {
                MessageBox.Show("Dodaj przynajmniej dwa wierzcho³ki!");
                return;
            }

            var nazwy = listaWierzcholkow.Select(w => w.Nazwa).ToList();

            using (var popup = new FormPolacz(nazwy))
            {
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    var v1 = listaWierzcholkow.FirstOrDefault(w => w.Nazwa == popup.StartowaNazwa);
                    var v2 = listaWierzcholkow.FirstOrDefault(w => w.Nazwa == popup.DocelowaNazwa);

                    if (v1 != null && v2 != null && v1 != v2)
                    {
                        var istniejacaKrawedz = listaKrawedzi.FirstOrDefault(k =>
                            (k.Start == v1 && k.Koniec == v2) || (k.Start == v2 && k.Koniec == v1));

                        if (istniejacaKrawedz != null)
                        {
                            istniejacaKrawedz.Waga = popup.Waga;
                        }
                        else
                        {
                            listaKrawedzi.Add(new Krawedz(v1, v2, popup.Waga));
                        }

                        panel1.Invalidate();
                    }
                    else
                    {
                        MessageBox.Show("Nie mo¿na po³¹czyæ wierzcho³ka z samym sob¹.");
                    }
                }
            }
            ResetujWynikAlgorytmu();
        }

        private void oblicz_droge_btn_Click(object sender, EventArgs e)
        {
            if (listaKrawedzi.Count == 0) return;

            foreach (var k in listaKrawedzi) k.CzyWDrzewie = false;

            var posortowaneKrawedzie = MergeSortKrawedzi(listaKrawedzi);

            Dictionary<string, string> rodzic = new Dictionary<string, string>();
            foreach (var w in listaWierzcholkow) rodzic[w.Nazwa] = w.Nazwa;

            string Find(string i)
            {
                if (rodzic[i] == i) return i;
                return rodzic[i] = Find(rodzic[i]);
            }

            void Union(string x, string y)
            {
                string rootX = Find(x);
                string rootY = Find(y);
                if (rootX != rootY) rodzic[rootX] = rootY;
            }

            int sumaWag = 0;
            textBox1.Clear();
            textBox1.AppendText("Wybrane krawêdzie MST:" + Environment.NewLine);

            foreach (var k in posortowaneKrawedzie)
            {
                if (Find(k.Start.Nazwa) != Find(k.Koniec.Nazwa))
                {
                    k.CzyWDrzewie = true;
                    Union(k.Start.Nazwa, k.Koniec.Nazwa);
                    sumaWag += k.Waga;
                    textBox1.AppendText($"{k.Start.Nazwa} - {k.Koniec.Nazwa} (waga: {k.Waga}){Environment.NewLine}");
                }
            }
            textBox1.AppendText("--------------------------" + Environment.NewLine);
            textBox1.AppendText("Suma wag ca³kowita: " + sumaWag);
            panel1.Invalidate();
        }

        private void clear_all_btn_Click(object sender, EventArgs e)
        {
            listaWierzcholkow.Clear();
            listaKrawedzi.Clear();
            listBox1.Items.Clear();
            textBox1.Clear();
            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            foreach (var k in listaKrawedzi)
            {
                Pen p = k.CzyWDrzewie ? new Pen(Color.Red, 4) : new Pen(Color.Gray, 1);
                e.Graphics.DrawLine(p, k.Start.Pozycja, k.Koniec.Pozycja);

                string wagaText = k.Waga.ToString();
                var size = e.Graphics.MeasureString(wagaText, this.Font);
                int midX = (k.Start.Pozycja.X + k.Koniec.Pozycja.X) / 2;
                int midY = (k.Start.Pozycja.Y + k.Koniec.Pozycja.Y) / 2;
                e.Graphics.FillRectangle(Brushes.White, midX, midY, size.Width, size.Height);
                e.Graphics.DrawString(wagaText, this.Font, Brushes.Blue, midX, midY);
            }

            foreach (var w in listaWierzcholkow)
            {
                Rectangle rect = new Rectangle(w.Pozycja.X - w.Promien, w.Pozycja.Y - w.Promien, w.Promien * 2, w.Promien * 2);
                e.Graphics.FillEllipse(Brushes.White, rect);
                e.Graphics.DrawEllipse(Pens.Black, rect);
                StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                e.Graphics.DrawString(w.Nazwa, this.Font, Brushes.Black, w.Pozycja, sf);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (var w in listaWierzcholkow)
            {
                float dx = e.X - w.Pozycja.X;
                float dy = e.Y - w.Pozycja.Y;
                if (Math.Sqrt(dx * dx + dy * dy) <= w.Promien)
                {
                    wybranyWierzcholek = w;
                    break;
                }
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (wybranyWierzcholek != null)
            {
                wybranyWierzcholek.Pozycja = e.Location;
                panel1.Invalidate();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            wybranyWierzcholek = null;
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string nazwaDoUsuniecia = listBox1.SelectedItem.ToString();
                var wierzcholek = listaWierzcholkow.FirstOrDefault(w => w.Nazwa == nazwaDoUsuniecia);

                if (wierzcholek != null)
                {
                    listaKrawedzi.RemoveAll(k => k.Start == wierzcholek || k.Koniec == wierzcholek);
                    listaWierzcholkow.Remove(wierzcholek);
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    panel1.Invalidate();

                    textBox1.Clear();
                    textBox1.Text = "Usuniêto wierzcho³ek: " + nazwaDoUsuniecia;
                }
            }
            else
            {
                MessageBox.Show("Najpierw zaznacz wierzcho³ek na liœcie lewym przyciskiem myszy.");
            }
        }

        private void Dodaj_wiele_wierzcholkow_btn_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "Wpisz nazwy wierzcho³ków oddzielone spacj¹ (np. V1 V2 V3):",
                "Masowe dodawanie");

            if (string.IsNullOrWhiteSpace(input)) return;

            string[] nazwy = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Random rnd = new Random();
            int dodano = 0;

            foreach (string n in nazwy)
            {
                if (!listaWierzcholkow.Any(w => w.Nazwa == n))
                {
                    int x = rnd.Next(50, panel1.Width - 50);
                    int y = rnd.Next(50, panel1.Height - 50);

                    listaWierzcholkow.Add(new Wierzcholek(n, new Point(x, y)));
                    listBox1.Items.Add(n);
                    dodano++;
                }
            }

            panel1.Invalidate();
            ResetujWynikAlgorytmu();
            if (dodano > 0) MessageBox.Show($"Dodano {dodano} nowych wierzcho³ków.");
        }

        private void Polacz_wiele_btn_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "Wpisz po³¹czenia w formacie Start,Koniec,Waga oddzielone spacj¹\n(np. V1,V2,5 V2,V3,10):",
                "Masowe ³¹czenie");

            if (string.IsNullOrWhiteSpace(input)) return;

            string[] krawedzieString = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int licznik = 0;

            foreach (string ks in krawedzieString)
            {
                string[] dane = ks.Split(',');

                if (dane.Length == 3)
                {
                    string n1 = dane[0];
                    string n2 = dane[1];

                    if (int.TryParse(dane[2], out int waga))
                    {
                        var v1 = listaWierzcholkow.FirstOrDefault(w => w.Nazwa == n1);
                        var v2 = listaWierzcholkow.FirstOrDefault(w => w.Nazwa == n2);

                        if (v1 != null && v2 != null && v1 != v2)
                        {
                            var istniejaca = listaKrawedzi.FirstOrDefault(k =>
                                (k.Start == v1 && k.Koniec == v2) || (k.Start == v2 && k.Koniec == v1));

                            if (istniejaca != null)
                                istniejaca.Waga = waga;
                            else
                                listaKrawedzi.Add(new Krawedz(v1, v2, waga));

                            licznik++;
                        }
                    }
                }
            }

            panel1.Invalidate();
            ResetujWynikAlgorytmu();
            MessageBox.Show($"Przetworzono {licznik} po³¹czeñ.");
        }
    }
}