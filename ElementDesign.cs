namespace  Desing_casa_vizual
{
    public class ElementDesign
    {
        // INCAPSULARE: 
        private string nume;
        private double pretBaza;

        public string Nume 
        { 
            get => nume; 
            set => nume = value; 
        }

        public double PretBaza 
        { 
            get => pretBaza; 
            set => pretBaza = value < 0 ? 0 : value; 
        }

        public ElementDesign(string nume, double pretBaza)
        {
            this.nume = nume;
            this.pretBaza = pretBaza;
        }

        // SUPRASCRIERE:
        public virtual double CalculeazaPretFinal()
        {
            return pretBaza;
        }

        public virtual void AfiseazaDetalii()
        {
            Console.WriteLine($"- {Nume}: {CalculeazaPretFinal()} lei");
        }
    }
}