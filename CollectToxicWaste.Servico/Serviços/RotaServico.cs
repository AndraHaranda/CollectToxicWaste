using CollectToxicWaste.Comum.NotificationPattern;
using CollectToxicWaste.Comum.Validações;
using CollectToxicWaste.Dominio.Entidades;
using CollectToxicWaste.Infraestrutura.Repositórios;

namespace CollectToxicWaste.Servico.Serviços
{
    public class RotaServico : RotaRepositorio
    {
        private readonly RotaRepositorio _rotaRepositorio;
        public RotaServico()
        {
            _rotaRepositorio = new RotaRepositorio();
        }

        public NotificationResult Adicionar(Rota entidade)
        {
            var notificationResult = new NotificationResult();

            try
            {

                if (string.IsNullOrEmpty(entidade.NomeRota))
                    notificationResult.Add(new NotificationError("Nome da rota está inválido", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.Trajeto))
                    notificationResult.Add(new NotificationError("É obrigatorio informar o trajeto", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.Cidade))
                    notificationResult.Add(new NotificationError("Cidade inválida", NotificationErrorType.USER));

                if (ValidacaoCEP.ValidaCep(entidade.CEP))
                    notificationResult.Add(new NotificationError("CEP inválido", NotificationErrorType.USER));

                if (ValidacaoEmail.ValidaEmail(entidade.Turno))
                    notificationResult.Add(new NotificationError("É obrigatorio informar o turno da rota", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.Horario))
                    notificationResult.Add(new NotificationError("É obrigatorio informar o horario", NotificationErrorType.USER));

                if (notificationResult.IsValid)
                {
                    _rotaRepositorio.Adicionar(entidade);

                    notificationResult.Add("Rota cadastrada com sucesso.");
                }

                notificationResult.Result = entidade;
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public NotificationResult Atualizar(Rota entidade)
        {
            throw new NotImplementedException();
        }

        public Rota ListarUm(int Id) => _rotaRepositorio.ListarUm(Id);


        public NotificationResult Remover(int Id)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (Id == 0)
                    return notificationResult.Add(new NotificationError("Código inválido!"));

                Rota entidade = ListarUm(Id);

                if (entidade == null)
                    return notificationResult.Add(new NotificationError("Rota não encontrada!"));

                if (notificationResult.IsValid)
                {
                    _rotaRepositorio.Remover(entidade);
                    notificationResult.Add("Rota removida com sucesso.");
                }

                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public IEnumerable<Rota> ListarRota()
        {
            return _rotaRepositorio.ListarRota();
        }


    }
}
