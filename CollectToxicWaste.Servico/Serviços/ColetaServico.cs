using CollectToxicWaste.Comum.NotificationPattern;
using CollectToxicWaste.Dominio.Entidades;
using CollectToxicWaste.Infraestrutura.Repositórios;

namespace CollectToxicWaste.Servico.Serviços
{
    public class ColetaServico : ColetaRepositorio
    {
        private readonly ColetaRepositorio _coletaRepositorio;
        public ColetaServico()
        {
            _coletaRepositorio = new ColetaRepositorio();
        }

        public NotificationResult Adicionar(Coleta entidade)
        {
            var notificationResult = new NotificationResult();

            try
            {

                if (string.IsNullOrEmpty(entidade.IdentificaoColeta))
                    notificationResult.Add(new NotificationError("Identificação incorreta", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.MaterialColetado))
                    notificationResult.Add(new NotificationError("É necessario informar o material de descarte", NotificationErrorType.USER));

                if (notificationResult.IsValid)
                {
                    _coletaRepositorio.Adicionar(entidade);

                    notificationResult.Add("Ponto de coleta cadastrado com sucesso.");
                }

                notificationResult.Result = entidade;
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public NotificationResult Atualizar(Coleta entidade)
        {
            throw new NotImplementedException();
        }

        public Coleta ListarUm(int IdColeta) => _coletaRepositorio.ListarUm(IdColeta);


        public NotificationResult Remover(int IdColeta)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (IdColeta == 0)
                    return notificationResult.Add(new NotificationError("Código de coleta inválido!"));

                Coleta entidade = ListarUm(IdColeta);

                if (entidade == null)
                    return notificationResult.Add(new NotificationError("Ponto de coleta não encontrado!"));

                if (notificationResult.IsValid)
                {
                    _coletaRepositorio.Remover(entidade);
                    notificationResult.Add("Ponto de coleta removido com sucesso.");
                }

                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public IEnumerable<Coleta> ListarColeta()
        {
            return _coletaRepositorio.ListarColetas();
        }


    }

}