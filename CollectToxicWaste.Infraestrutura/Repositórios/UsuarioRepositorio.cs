using CollectToxicWaste.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectToxicWaste.Infraestrutura.Repositórios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>
    {
        public IEnumerable<Usuario> ListarUsuarios()
        {
            return Context
                .Usuarios
                .Where(f => f.Id > 0);
        }
    }
}
