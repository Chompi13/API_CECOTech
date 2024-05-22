namespace API.Models{
    public class RegistroTienda{
        
        public int id {get;set;}   
        public List<int> cantidad {get;set;}
        public List<int> productoID {get;set;}
        public int coste {get;set;}
        public int presoId {get;set;}
        public DateTime fecha {get;set;} = DateTime.UtcNow;
        public int tiendaId {get;set;}
    }
}