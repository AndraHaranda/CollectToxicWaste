using CollectToxicWaste.Comum.NotificationPattern;
using CollectToxicWaste.Comum.Validações;
using CollectToxicWaste.Dominio.Entidades;
using CollectToxicWaste.Infraestrutura.Repositórios;

namespace CollectToxicWaste.Servico.Serviços
{
    public class UsuarioServico : UsuarioRepositorio
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;
        public UsuarioServico()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
        }

        public NotificationResult Adicionar(Usuario entidade)
        {
            var notificationResult = new NotificationResult();

            try
            {

                if (string.IsNullOrEmpty(entidade.NomeLogin))
                    notificationResult.Add(new NotificationError("Identificação incorreta", NotificationErrorType.USER));

                if (ValidacaoCPF.ValidaCPF(entidade.CPF))
                    notificationResult.Add(new NotificationError("CPF inválido", NotificationErrorType.USER));

                if (ValidacaoEmail.ValidaEmail(entidade.Email))
                    notificationResult.Add(new NotificationError("E-mail inválido", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.Profissao))
                    notificationResult.Add(new NotificationError("É obrigatorio informar a profissão", NotificationErrorType.USER));
                
                if (string.IsNullOrEmpty(entidade.Telefone))
                    notificationResult.Add(new NotificationError("Número de telefone inválido", NotificationErrorType.USER));

                if (notificationResult.IsValid)
                {
                    _usuarioRepositorio.Adicionar(entidade);

                    notificationResult.Add("Usuario cadastrado com sucesso.");
                }

                notificationResult.Result = entidade;
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public NotificationResult Atualizar(Usuario entidade)
        {
            throw new NotImplementedException();
        }

        public Usuario ListarUm(int Id) => _usuarioRepositorio.ListarUm(Id);


        public NotificationResult Remover(int Id)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (Id == 0)
                    return notificationResult.Add(new NotificationError("Código inválido!"));

                Usuario entidade = ListarUm(Id);

                if (entidade == null)
                    return notificationResult.Add(new NotificationError("Usuario não encontrado!"));

                if (notificationResult.IsValid)
                {
                    _usuarioRepositorio.Remover(entidade);
                    notificationResult.Add("Usuario removido com sucesso.");
                }

                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public IEnumerable<Usuario> ListarUsuario()
        {
            return _usuarioRepositorio.ListarUsuarios();
        }


    }

}