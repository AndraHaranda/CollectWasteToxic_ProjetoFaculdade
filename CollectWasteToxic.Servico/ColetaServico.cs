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
    public class ColetaServico
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

                if (string.IsNullOrEmpty(entidade.Localizacao))
                    notificationResult.Add(new NotificationError("Não é possivel encontrar localização ", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.Endereco))
                    notificationResult.Add(new NotificationError("CEP está incorreto", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.Referencia))
                    notificationResult.Add(new NotificationError("É necessario informar a referencia", NotificationErrorType.USER));

                if (string.IsNullOrEmpty(entidade.Imagem))
                    notificationResult.Add(new NotificationError("URL de Imagem Inválida", NotificationErrorType.USER));

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
                    return notificationResult.Add(new NotificationError("Código do Ponto de coleta inválido!"));

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
            return _coletaRepositorio.ListarColeta();
        }


    }

}

