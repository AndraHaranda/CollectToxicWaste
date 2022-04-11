using System.ComponentModel.DataAnnotations;

namespace CollectToxicWaste.Dominio.Entidades
{
    public class Coleta
    {
        [Key]
        public int Id { get; set; } 
        public string IdentificaoColeta { get; set; }
        public string MaterialColetado { get; set; }
        public string ResponsavelColeta { get; set;}


    }
}
