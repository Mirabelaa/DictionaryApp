using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace tema1
{
    public partial class Dictionar
    {
        private readonly string _path = $"D:\\facultate\\an2\\sem2\\mvp\\tema1\\tema1\\resurse\\fisier\\date.json";
        private List<Cuvant> dictionar;
        private List<string> categorii = new List<string>();
        private List<Cuvant> indicii = new List<Cuvant>();
        private string read;
        public Dictionar()
        {
            read = System.IO.File.ReadAllText(_path);
            dictionar = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Cuvant>>(read);
            foreach (Cuvant cuv in dictionar)
                categorii.Add(cuv.Categorie);
            indicii = GenerareIndicii();
        }
        public List<Cuvant> GetCuvinte()
        {
            return dictionar;
        }
        public Cuvant GetCuvant(string nume, string descriere, string categorie, string imag)
        {
            var cuvant = new Cuvant { Denumire = nume, Descriere = descriere, Categorie = categorie, Imagine = imag };
            return cuvant;
        }
        private void Serializare(List<Cuvant> _data)
        {
            String json = Newtonsoft.Json.JsonConvert.SerializeObject(_data.ToArray());
            System.IO.File.WriteAllText(_path, json);
        }

        public void AdaugareCuvant(Cuvant cuvant)
        {
            if (dictionar == null)
            {
                List<Cuvant> _data = new List<Cuvant>();
                _data.Add(cuvant);
                Serializare(_data);
            }
            else
            {
                dictionar.Add(cuvant);
                Serializare(dictionar);
            }
        }

        public void CautareCuvant(TextBox nume, TextBox descriere, TextBox categorie, TextBox imag)
        {
            foreach (Cuvant cuvant in dictionar)
            {
                if (cuvant.Denumire.Equals(nume.Text) || cuvant.Descriere.Equals(descriere.Text))
                {
                    cuvant.Denumire = nume.Text;
                    cuvant.Descriere = descriere.Text;
                    cuvant.Categorie = categorie.Text;
                    cuvant.Imagine = imag.Text;
                    Serializare(dictionar);
                }
            }
        }

        public void Stergere(TextBox nume)
        {
            var itemToRemove = dictionar.Find(r => r.Denumire == nume.Text);
            if (itemToRemove != null)
                dictionar.Remove(itemToRemove);
            Serializare(dictionar);
        }

        public void AfisareDetalii(TextBox nume, TextBox descriere, TextBox categorie, TextBox imag)
        {
            foreach (Cuvant cuvant in dictionar)
            {
                if (cuvant.Denumire.Equals(nume.Text))
                {
                    descriere.Text = cuvant.Descriere;
                    categorie.Text = cuvant.Categorie;
                    imag.Text = cuvant.Imagine;
                }
            }
        }
        public List<string> GetNumeCuvinte()
        {
            List<string> denumiri = new List<string>();
            foreach (Cuvant cuvant in dictionar)
                denumiri.Add(cuvant.Denumire);
            return denumiri;
            
        }
        public SortedSet<string> GetCategorii()
        {
            SortedSet<string> categorii = new SortedSet<string>();
            foreach (Cuvant cuvant in dictionar)
                categorii.Add(cuvant.Categorie);
            return categorii;

        }
        public List<string> GetCuvinteCategorie(string categorie)
        {
            List<string> sugestii = new List<string>();
            foreach (Cuvant cuvant in dictionar)
            {
                if (cuvant.Categorie == categorie)
                    sugestii.Add(cuvant.Denumire);
            }
            return sugestii;
        }
        public int GenerareIndexRandom()
        {
            Random random = new Random();
            int index = random.Next(0, dictionar.Count);
            return index;
        }
        public int ImagineSauDescriere()
        {
            Random random = new Random();
            int optiune = random.Next(0, 2);
            return optiune;
        }
        public List<Cuvant> GenerareIndicii()
        {
            SortedSet<int> indecsi = GenerareIndexCuvinteJoc();
            foreach (int index in indecsi)
                indicii.Add(dictionar[index]);
            return indicii;
        }
        public bool VerificareRaspuns(string raspunsDat, string raspunsCorect)
        {
            if (raspunsDat.Equals(raspunsCorect))
                return true;
            return false;
        }
        public bool VerificareImagine(Cuvant cuv)
        {
            if (cuv.Imagine == "D:\\facultate\\an2\\sem2\\mvp\\tema1\\tema1\\imagini\\noi.png")
                return false;
            return true;
        }
        public SortedSet<int> GenerareIndexCuvinteJoc()
        {
            SortedSet<int> cuvinte = new SortedSet<int>();
            Console.WriteLine(cuvinte.Count);
            while(cuvinte.Count < 5)
                cuvinte.Add(GenerareIndexRandom());
            return cuvinte;
        }
        public List<Cuvant> GetIndicii()
        {
            return indicii;
        }
    }
}
