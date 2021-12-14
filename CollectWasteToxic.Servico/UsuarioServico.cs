using CollectToxicWaste.Comum;
using CollectToxicWaste.Comum.NotificationPattern;
using CollectToxicWaste.Dados;
using CollectToxicWaste.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectToxicWaste.Servico
{
    public class UsuarioServico
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;
        public UsuarioServico()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
        }

        public NotificationResult Salvar(Usuario entidade)
        {
            var notificationResult = new NotificationResult();

            try
            {

                if (string.IsNullOrEmpty(entidade.Nome))
                    notificationResult.Add(new NotificationError("Nome Inválido", NotificationErrorType.USER));

                if (ValidarCPF.ValidaCPF(entidade.CPF) == false)
                    notificationResult.Add(new NotificationError("CPF Inválido", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.CNPJ))
                    notificationResult.Add(new NotificationError("URL de Imagem Inválida!", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.RG))
                    notificationResult.Add(new NotificationError("RG Inválido", NotificationErrorType.USER));

                if (ValidarEmail.ValidaEmail(entidade.Email) == false)
                    notificationResult.Add(new NotificationError("E-mail Inválido!", NotificationErrorType.USER));

                if (entidade.DataNascimento < DateTime.Today)
                    notificationResult.Add(new NotificationError("Data Inválida!", NotificationErrorType.USER));

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
        public Usuario ListarUm(int IdUsuario) => _usuarioRepositorio.ListarUm(IdUsuario);


        public NotificationResult Excluir(int IdUsuario)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (IdUsuario == 0)
                    return notificationResult.Add(new NotificationError("Código do Cliente Inválido!"));

                Usuario entidade = ListarUm(IdUsuario);

                if (entidade == null)
                    return notificationResult.Add(new NotificationError("Cliente não Encontrado!"));

                if (notificationResult.IsValid)
                {
                    _usuarioRepositorio.Remover(entidade);
                    notificationResult.Add("Cliente Removido com sucesso.");
                }

                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public IEnumerable<Usuario> ListarUsuarios()
        {
            return _usuarioRepositorio.ListarUsuarios();
        }

        public NotificationResult Atualizar(Usuario entidade)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (entidade.IdUsuario <= 0)
                    return notificationResult.Add(new NotificationError("Código do Usuario Inválido!"));

                if (string.IsNullOrEmpty(entidade.Nome))
                    notificationResult.Add(new NotificationError("Nome Inválido", NotificationErrorType.USER));

                if (ValidarCPF.ValidaCPF(entidade.CPF) == false)
                    notificationResult.Add(new NotificationError("CPF Inválido", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.CNPJ))
                    notificationResult.Add(new NotificationError("URL de Imagem Inválida!", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.RG))
                    notificationResult.Add(new NotificationError("RG Inválido", NotificationErrorType.USER));

                if (ValidarEmail.ValidaEmail(entidade.Email) == false)
                    notificationResult.Add(new NotificationError("E-mail Inválido!", NotificationErrorType.USER));

                if (entidade.DataNascimento < DateTime.Today)
                    notificationResult.Add(new NotificationError("Data Inválida!", NotificationErrorType.USER));

                if (notificationResult.IsValid)
                {
                    _usuarioRepositorio.Atualizar(entidade);
                    notificationResult.Add("Cliente Atualizado com sucesso.");
                }

                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }
    }
}