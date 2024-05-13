namespace API.Models{
    public class Sancion{
        
        public int id {get;set;}
        public double cantidad {get;set;}
        public string razon {get;set;}
        public Preso preso {get;set;}
        public int nplaca_guardia {get;set;}

    }
}