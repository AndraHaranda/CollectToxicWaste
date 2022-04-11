using CollectToxicWaste.Infraestrutura.EnitityFramework;
using Microsoft.EntityFrameworkCore;

namespace CollectToxicWaste.Infraestrutura.Repositórios
{
    public class RepositorioBase<T> where T : class
    {
        protected Context Context { get; }
        private DbSet<T> Entidade { get; }
        public RepositorioBase()
        {
            Context = new Context();
            Entidade = Context.Set<T>();
        }

        public T ListarUm(params object[] keys)
        {
            return Entidade.Find(keys);
        }

        public List<T> ListarTodos()
        {
            return Context
                .Set<T>()
                .ToList();
        }

        public void Adicionar(T entidade, bool saveChanges = true)
        {
            Entidade.Add(entidade);

            if (saveChanges)
                SaveChanges();
        }

        public void Remover(T entidade, bool saveChanges = true)
        {
            Entidade.Remove(entidade);

            if (saveChanges)
                SaveChanges();
        }

        public void Atualizar(T entidade, bool saveChanges = true)
        {
            Entidade.Update(entidade);

            if (saveChanges)
                SaveChanges();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
