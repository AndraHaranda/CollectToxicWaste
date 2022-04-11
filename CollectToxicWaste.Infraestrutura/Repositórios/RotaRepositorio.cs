using CollectToxicWaste.Dominio.Entidades;

namespace CollectToxicWaste.Infraestrutura.Repositórios
{
    public class RotaRepositorio : RepositorioBase<Rota>
    {
        public IEnumerable<Rota> ListarRota()
        {
            return Context
                .Rotas
                .Where(f => f.Id > 0);
        }
    }
}
