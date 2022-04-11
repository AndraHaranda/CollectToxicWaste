using System.ComponentModel.DataAnnotations;

namespace CollectToxicWaste.Dominio.Entidades
{
    public class Transporte
    {
        [Key]
        public int Id { get; set; }
        public string Motorista { get; set; }
        TransporteType TipoTransporte { get; set; }
        public string Placa { get; set; } 
        public string? Empresa { get; set; }
    }

    enum TransporteType
    {
        CARRO = 1,
        MOTO = 2,
        ONIBUS = 3,
        VAN = 4
    }
}
