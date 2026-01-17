using System;
using System.Collections.Generic;
using System.Linq;

namespace Desing_casa_vizual
{
    class Program
    {
        static List<Camera> toateCamerele = new List<Camera>();

        static void Main(string[] args)
        {
            Console.Title = "Software Gestiune Design Case v2.3";
            bool aplicatieRulanduSe = true;

            while (aplicatieRulanduSe)
            {
                Console.Clear();
                Console.WriteLine("=== CONFIGURATOR CASA COMPLETA ===");
                Console.WriteLine("1. Adauga o Camera Noua");
                Console.WriteLine("2. Sterge o Camera existenta");
                Console.WriteLine("3. Adauga Mobilier intr-o camera");
                Console.WriteLine("4. Vezi Inventarul unei camere");
                Console.WriteLine("5. Vezi Costul Total Casa");
                Console.WriteLine("0. Iesire");
                Console.Write("\nAlege: ");

                string optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        AdaugaCameraNoua();
                        break;
                    case "2":
                        StergeCamera();
                        break;
                    case "3":
                        GestionareAdaugareMobilier();
                        break;
                    case "4":
                        GestionareAfisareInventar();
                        break;
                    case "5":
                        AfiseazaTotalGeneral();
                        break;
                    case "0":
                        aplicatieRulanduSe = false;
                        break;
                }
            }
        }

        static void AdaugaCameraNoua()
        {
            try
            {
                Console.Write("Introdu numele noii camere: ");
                string numeCam = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(numeCam))
                {
                    throw new Exception("Numele camerei nu poate fi gol!");
                }

                bool existaDeja = false;

                foreach (var c in toateCamerele)
                {
                    if (c.NumeCamera.ToLower() == numeCam.ToLower())
                    {
                        existaDeja = true;
                        break; 
                    }
                }

                if (existaDeja)
                {
                    Console.WriteLine($"\n[EROARE] Camera '{numeCam}' exista deja!");
                }
                else
                {
                    toateCamerele.Add(new Camera(numeCam));
                    Console.WriteLine("Camera adaugata!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[EROARE] A aparut o problema: {ex.Message}");
            }
            Console.WriteLine("Apasa orice tasta...");
            Console.ReadKey();
        }

        static void GestionareAdaugareMobilier()
        {
            Camera sel = AlegeCamera();
            if (sel != null)
            {
                try
                {
                    Console.Write("Nume obiect: "); 
                    string n = Console.ReadLine();

                    Console.Write("Pret magazin (lei): "); 
                    double p = double.Parse(Console.ReadLine());

                    Console.Write("Taxa montaj (lei): "); 
                    double t = double.Parse(Console.ReadLine());
                    
                    sel.AdaugaObiect(new PiesaMobilier(n, p, t));
                    Console.WriteLine("\nObiect adaugat cu succes!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n[EROARE] Te rog sa introduci doar cifre pentru pret si taxa (foloseste virgula pentru zecimale).");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n[EROARE] A aparut o eroare neprevazuta: {ex.Message}");
                }
                
                Console.WriteLine("Apasa o tasta...");
                Console.ReadKey();
            }
        }

        static void StergeCamera()
        {
            Camera deSters = AlegeCamera();
            if (deSters != null)
            {
                toateCamerele.Remove(deSters);
                Console.WriteLine("Camera a fost stearsa.");
            }
            Console.WriteLine("Apasa o tasta...");
            Console.ReadKey();
        }

        static void AfiseazaTotalGeneral()
        {
            Console.Clear();
            double total = toateCamerele.Sum(c => c.TotalCamera());
            Console.WriteLine("=== REZUMAT COSTURI CASA ===");
            foreach (var cam in toateCamerele)
            {
                Console.WriteLine($"- {cam.NumeCamera}: {cam.TotalCamera()} lei");
            }
            Console.WriteLine($"\nTOTAL GENERAL PROIECT: {total} lei");
            Console.WriteLine("\nApasa orice tasta...");
            Console.ReadKey();
        }

        static void GestionareAfisareInventar()
        {
            Camera sel = AlegeCamera();
            if (sel != null)
            {
                sel.AfiseazaInventar();
                Console.WriteLine("\nApasa orice tasta...");
                Console.ReadKey();
            }
        }

        static Camera AlegeCamera()
        {
            Console.Clear();
            if (toateCamerele.Count == 0) 
            { 
                Console.WriteLine("Nu exista camere in proiect."); 
                return null; 
            }

            for (int i = 0; i < toateCamerele.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {toateCamerele[i].NumeCamera}");
            }
            
            Console.Write("\nSelecteaza numarul camerei: ");
            try
            {
                int idx = int.Parse(Console.ReadLine());
                if (idx > 0 && idx <= toateCamerele.Count)
                {
                    return toateCamerele[idx - 1];
                }
                Console.WriteLine("Numarul introdus nu este in lista.");
            }
            catch
            {
                Console.WriteLine("Introdu un numar valid.");
            }
            
            return null;
        }
    }
}