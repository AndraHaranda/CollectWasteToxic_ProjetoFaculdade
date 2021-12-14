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
    public class RotaServico
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
                    notificationResult.Add(new NotificationError("Nome da rota inválida", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.MaterialDescarte))
                    notificationResult.Add(new NotificationError("Material de descarte inválida", NotificationErrorType.USER));

                if (entidade.Horario < DateTime.Today)
                    notificationResult.Add(new NotificationError("Horario inválido", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.Responsavel))
                    notificationResult.Add(new NotificationError("Responsavel não encontrado", NotificationErrorType.USER));


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
            var notificationResult = new NotificationResult();

            try
            {
                if (entidade.IdRota <= 0)
                    return notificationResult.Add(new NotificationError("Código do Cliente Inválido!"));

                if (string.IsNullOrEmpty(entidade.NomeRota))
                    notificationResult.Add(new NotificationError("Nome da rota inválida", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.MaterialDescarte))
                    notificationResult.Add(new NotificationError("Material de descarte inválida", NotificationErrorType.USER));

                if (entidade.Horario < DateTime.Today)
                    notificationResult.Add(new NotificationError("Horario inválido", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.Responsavel))
                    notificationResult.Add(new NotificationError("Responsavel não encontrado", NotificationErrorType.USER));

                if (notificationResult.IsValid)
                {
                    _rotaRepositorio.Atualizar(entidade);
                    notificationResult.Add("Rota atualizada com sucesso.");
                }

                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public Rota ListarUm(int IdRota) => _rotaRepositorio.ListarUm(IdRota);

        public NotificationResult Remover(int IdRota)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (IdRota == 0)
                    return notificationResult.Add(new NotificationError("Código da Rota Inválida!"));

                Rota entidade = ListarUm(IdRota);

                if (entidade == null)
                    return notificationResult.Add(new NotificationError("Rota não Encontrada!"));

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
