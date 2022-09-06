using CollectToxicWaste.Comum.NotificationPattern;
using CollectToxicWaste.Comum.Validações;
using CollectToxicWaste.Dominio.Entidades;
using CollectToxicWaste.Infraestrutura.Repositórios;

namespace CollectToxicWaste.Servico.Serviços
{
    public class MotoristaServico
    {
        private readonly MotoristaRepositorio _motoristaRepositorio;
        public MotoristaServico()
        {
            _motoristaRepositorio = new MotoristaRepositorio();
        }

        public NotificationResult Adicionar(Motorista entidade)
        {
            var notificationResult = new NotificationResult();

            try
            {

                if (string.IsNullOrEmpty(entidade.NomeMotorista))
                    notificationResult.Add(new NotificationError("Identificação inválida", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.Idade))
                    notificationResult.Add(new NotificationError("É necessario informar a idade", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.Telefone))
                    notificationResult.Add(new NotificationError("Número de telefone está inválida", NotificationErrorType.USER));

                //if (DateTime(entidade.DataNascimento))
                //    notificationResult.Add(new NotificationError("Data de nascimento informado, está inválida", NotificationErrorType.USER));

                if (ValidacaoCPF.ValidaCPF(entidade.CPF))
                    notificationResult.Add(new NotificationError("CPF está inválido", NotificationErrorType.USER));
                
                if (ValidacaoEmail.ValidaEmail(entidade.Email))
                    notificationResult.Add(new NotificationError("E-mail informado está inválido", NotificationErrorType.USER));
                
                //if (CategoriaCNH.IsNullOrEmpty(entidade.))
                //    notificationResult.Add(new NotificationError("Categoria de CNH está inválida", NotificationErrorType.USER));

                if (notificationResult.IsValid)
                {
                    _motoristaRepositorio.Adicionar(entidade);

                    notificationResult.Add("Motorista cadastrado com sucesso.");
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

        public Motorista ListarUm(int Id) => _motoristaRepositorio.ListarUm(Id);


        public NotificationResult Remover(int Id)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (Id == 0)
                    return notificationResult.Add(new NotificationError("Código inválido!"));

                Motorista entidade = ListarUm(Id);

                if (entidade == null)
                    return notificationResult.Add(new NotificationError("Motorista não encontrado!"));

                if (notificationResult.IsValid)
                {
                    _motoristaRepositorio.Remover(entidade);
                    notificationResult.Add("Motorista removido com sucesso.");
                }

                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public IEnumerable<Motorista> ListarMotorista()
        {
            return _motoristaRepositorio.ListarMotorista();
        }


    }
}

