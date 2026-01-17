using System.Collections.Generic;

namespace  Desing_casa_vizual
{
    public class Camera
    {
        public string NumeCamera { get; set; }
        
        private List<ElementDesign> obiecte = new List<ElementDesign>();

        public Camera(string nume) 
        { 
            NumeCamera = nume; 
        }

        public void AdaugaObiect(ElementDesign obj) 
        { 
            obiecte.Add(obj); 
        }

        public double TotalCamera()
        {
            double total = 0;
            foreach (var obj in obiecte) 
            {
                total += obj.CalculeazaPretFinal();
            }
            return total;
        }

        public void AfiseazaInventar()
        {
            Console.WriteLine($"\n--- INVENTAR: {NumeCamera.ToUpper()} ---");
            foreach (var obj in obiecte) 
            {
                obj.AfiseazaDetalii();
            }
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"TOTAL COST CAMERA: {TotalCamera()} lei");
        }
    }
}