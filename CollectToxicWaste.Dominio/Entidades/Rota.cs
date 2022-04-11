using System.ComponentModel.DataAnnotations;

namespace CollectToxicWaste.Dominio.Entidades
{
    public class Rota
    {
        [Key]
        public int Id { get; set; }
        public string NomeRota { get; set; }
        public string Trajeto { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string Turno { get; set; }
        public string Horario { get; set; }
    }
}
