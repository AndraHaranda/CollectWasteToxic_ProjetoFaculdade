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
        public NotificationResult Atualizar(Transporte entidade)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (string.IsNullOrEmpty(entidade.Placa))
                    notificationResult.Add(new NotificationError("Placa invalida", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.CategoriaCNH))
                    notificationResult.Add(new NotificationError("CNH está inválido", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.Motorista))
                    notificationResult.Add(new NotificationError("Nome completo invalido", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.Empresa))
                    notificationResult.Add(new NotificationError("Empresa invalida", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.TipoVeiculo))
                    notificationResult.Add(new NotificationError("Veiculo invalida", NotificationErrorType.USER));


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

        public NotificationResult Adicionar(Transporte entidade)
        {
            var notificationResult = new NotificationResult();

            try
            {

                if (string.IsNullOrEmpty(entidade.Placa))
                    notificationResult.Add(new NotificationError("Placa invalida", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.CategoriaCNH))
                    notificationResult.Add(new NotificationError("CNH está inválido", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.Motorista))
                    notificationResult.Add(new NotificationError("Nome completo invalido", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.Empresa))
                    notificationResult.Add(new NotificationError("Empresa invalida", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.TipoVeiculo))
                    notificationResult.Add(new NotificationError("Veiculo invalida", NotificationErrorType.USER));


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

        public NotificationResult Remover(int IdTransporte)
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


    }


}