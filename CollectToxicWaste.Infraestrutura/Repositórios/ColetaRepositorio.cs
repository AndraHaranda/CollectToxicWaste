using CollectToxicWaste.Dominio.Entidades;
using CollectToxicWaste.Infraestrutura.EnitityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectToxicWaste.Infraestrutura.Repositórios
{
    public class ColetaRepositorio : RepositorioBase<Coleta>
    {
        public IEnumerable<Coleta> ListarColetas()
        {
            return Context
                .Coletas
                .Where(f => f.Id > 0);
        }
    }
}
