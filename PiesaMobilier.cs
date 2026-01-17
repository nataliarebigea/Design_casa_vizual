namespace Desing_casa_vizual
{
    // MOSTENIRE
    public class PiesaMobilier : ElementDesign
    {
        private double taxaMontaj;

        public PiesaMobilier(string nume, double pretBaza, double taxaMontaj) 
            : base(nume, pretBaza) 
        {
            this.taxaMontaj = taxaMontaj;
        }

        // SUPRASCRIERE (Polimorfism)
        public override double CalculeazaPretFinal()
        {
            
            return base.CalculeazaPretFinal() + taxaMontaj;
        }

        public override void AfiseazaDetalii()
        {
            Console.WriteLine($"- {Nume}: {PretBaza} lei (+ {taxaMontaj} lei montaj/transport)");
        }
    }
}