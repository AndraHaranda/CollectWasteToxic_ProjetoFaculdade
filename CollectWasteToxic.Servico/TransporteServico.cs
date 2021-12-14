using CollectToxicWaste.Comum.NotificationPattern;
using CollectToxicWaste.Dominio.Entidades;
using CollectToxicWaste.Infraestrutura.Repositórios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectToxicWaste.Servico
{
    public class TransporteServico
    {
        private readonly TransporteRepositorio _transporteRepositorio;
        public TransporteServico()
        {
            _transporteRepositorio = new TransporteRepositorio();
        }

        public NotificationResult Salvar(Transporte entidade)
        {
            var notificationResult = new NotificationResult();

            try
            {

                if (string.IsNullOrEmpty(entidade.Placa))
                    notificationResult.Add(new NotificationError("Telefone Inválido", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.CategoriaCNH))
                    notificationResult.Add(new NotificationError("Nome Inválido", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.Placa))
                    notificationResult.Add(new NotificationError("CPF Inválido", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.Empresa))
                    notificationResult.Add(new NotificationError("URL de Imagem Inválida!", NotificationErrorType.USER));


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
        public Transporte ListarUm(int IdTransporte) => _transporteRepositorio.ListarUm(IdTransporte);


        public NotificationResult Excluir(int IdTransporte)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (IdTransporte == 0)
                    return notificationResult.Add(new NotificationError("Código do Transporte Inválido!"));

                Transporte entidade = ListarUm(IdTransporte);

                if (entidade == null)
                    return notificationResult.Add(new NotificationError("Transporte cadastrado não encontrado!"));


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

        public IEnumerable<Transporte> ListarTransporte()
        {
            return _transporteRepositorio.ListarTransporte();
        }

        public NotificationResult Atualizar(Transporte entidade)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (entidade.IdTransporte <= 0)
                    return notificationResult.Add(new NotificationError("Código do Cliente Inválido!"));

                if (string.IsNullOrEmpty(entidade.Placa))
                    notificationResult.Add(new NotificationError("Telefone Inválido", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.CategoriaCNH))
                    notificationResult.Add(new NotificationError("Nome Inválido", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.Placa))
                    notificationResult.Add(new NotificationError("CPF Inválido", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.Empresa))
                    notificationResult.Add(new NotificationError("URL de Imagem Inválida!", NotificationErrorType.USER));

               

                if (notificationResult.IsValid)
                {
                    _transporteRepositorio.Atualizar(entidade);
                    notificationResult.Add("Transporte atualizado com sucesso.");
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