using CollectToxicWaste.Comum.NotificationPattern;
using CollectToxicWaste.Comum.Validações;
using CollectToxicWaste.Dominio.Entidades;
using CollectToxicWaste.Infraestrutura.Repositórios;

namespace CollectToxicWaste.Servico.Serviços
{
    public class TransporteServico : TransporteRepositorio

    {
        private readonly TransporteRepositorio _transporteRepositorio;
        public TransporteServico()
        {
            _transporteRepositorio = new TransporteRepositorio();
        }

        public NotificationResult Adicionar(Transporte entidade)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (string.IsNullOrEmpty(entidade.Motorista))
                    notificationResult.Add(new NotificationError("adicionado com sucesso", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.Placa))
                    notificationResult.Add(new NotificationError("adicionado com sucesso", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.Empresa))
                    notificationResult.Add(new NotificationError("adicionado com sucesso", NotificationErrorType.USER));

                if (ValidacaoCNPJ.ValidaCNPJ(entidade.CNPJ))
                    notificationResult.Add(new NotificationError("CNPJ adicionado com sucesso", NotificationErrorType.USER));

                //if (TransporteType.(entidade.TipoTransporte))
                //    notificationResult.Add(new NotificationError("Informe a placa do veiculo", NotificationErrorType.USER));

                if (notificationResult.IsValid)
                {
                    _transporteRepositorio.Adicionar(entidade);

                    notificationResult.Add("Transporte cadastrado com sucesso.");
                }

                notificationResult.Result = entidade;
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public NotificationResult Atualizar(Transporte entidade)
        {
            throw new NotImplementedException();
        }

        public Transporte ListarUm(int Id) => _transporteRepositorio.ListarUm(Id);


        public NotificationResult Remover(int Id)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (Id == 0)
                    return notificationResult.Add(new NotificationError("Código inválido!"));

                Transporte entidade = ListarUm(Id);

                if (entidade == null)
                    return notificationResult.Add(new NotificationError("Transporte não encontrado!"));

                if (notificationResult.IsValid)
                {
                    _transporteRepositorio.Remover(entidade);
                    notificationResult.Add("Transporte removido com sucesso.");
                }

                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public IEnumerable<Transporte> ListarTransportes()
        {
            return _transporteRepositorio.ListarTransportes();
        }


    }

}
