using CollectToxicWaste.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectToxicWaste.Infraestrutura.Repositórios
{
    public class MotoristaRepositorio : RepositorioBase<Motorista>
    {
        public IEnumerable<Motorista> ListarMotorista()
        {
            return Context
                .Motoristas
                .Where(f => f.Id > 0);
        }
    }
}
