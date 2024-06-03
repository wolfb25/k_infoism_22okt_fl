using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BukkMaraton2019 {

	internal class Program {

		static void Main(string[] args) {

			List<Futo> futok = new List<Futo>();
			foreach (string sor in File.ReadAllLines("bukkm2019.txt", Encoding.UTF8).Skip(1)) {
				futok.Add(new Futo(sor));
			}
            Console.WriteLine($"4. feladat: Versenytávot nem teljesítők: {(double)(691-futok.Count)/691*100}%");
			Console.WriteLine($"5. feladat: Női versenyzők száma a rövid távú versenyen: {futok.Where(f => f.Tav == "Rövid").Where(f => f.Kategoria.Last() == 'n').Count()}fő");
			Console.WriteLine($"6. feladat: {(futok.Where(f => Convert.ToInt32(f.Ido.First()) >= 6).Count() > 0 ? "Volt ilyen versenyző" : "Nem volt ilyen versenyző")}");
			Futo ffnyertes = futok.Where(f => f.Kategoria == "ff" && f.Tav == "Rövid").OrderBy(f => f.Ido).First();
			Console.WriteLine("7. feladat: A felnőtt férfi (ff) kategória győztese rövid távon" +
				$"\n\tRajtszám: {ffnyertes.Rajtszam}" +
				$"\n\tNév: {ffnyertes.Nev}" +
				$"\n\tEgyesület: {ffnyertes.Egyesulet}" +
				$"\n\tIdő: {ffnyertes.Ido}");
			Console.WriteLine("8. feladat: Statisztika");
			var kategoriak = futok.Select(f => f.Kategoria).Distinct().OrderBy(f => f);
            foreach (var kategoria in kategoriak) {
                Console.WriteLine($"\t{kategoria} - {futok.Where(f => f.Kategoria == kategoria).Count()}fő");
            }

        }

	}

	class Futo {

		public string Rajtszam { get; private set; }
		public string Kategoria { get; private set; }
		public string Nev { get; private set; }
		public string Egyesulet { get; private set; }
		public string Ido { get; private set; }
		public string Tav { get; private set; }

		public Futo(string sor) {
			string[] adatok = sor.Split(';');
			Rajtszam = adatok[0];
			Kategoria = adatok[1];
			Nev = adatok[2];
			Egyesulet = adatok[3];
			Ido = adatok[4];
			Tav = new Versenytav(Rajtszam).Tav;
		}
	}

	class Versenytav {

		private string Rajtszam;

		public string Tav {
			get {
				switch (Rajtszam[0])
				{
					case 'M': return "Mini";
					case 'R': return "Rövid";
					case 'K': return "Közép";
					case 'H': return "Hosszú";
					case 'E': return "Pedelec";
				}
				return "Hibás rajtszám";
			}
		}

		public Versenytav(string rajtszam) {
			Rajtszam = rajtszam;
		}
	}
}
