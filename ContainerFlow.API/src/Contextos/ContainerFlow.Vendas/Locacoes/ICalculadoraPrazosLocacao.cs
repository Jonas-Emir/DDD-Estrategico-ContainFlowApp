using ContainerFlow.Vendas.Propostas;

namespace ContainerFlow.Vendas.Locacoes;

public interface ICalculadoraPrazosLocacao
{
    DateTime CalculaDataPrevistaParaEntrega(Proposta proposta);
    DateTime CalculaDataPrevistaParaTermino(Proposta proposta);
}

public class CalculadoraPadraoPrazosLocacao : ICalculadoraPrazosLocacao
{
    public DateTime CalculaDataPrevistaParaEntrega(Proposta proposta)
    {
        return proposta.Solicitacao
            .DataInicioOperacao
            .AddDays(-proposta.Solicitacao.DisponibilidadePrevia);
    }

    public DateTime CalculaDataPrevistaParaTermino(Proposta proposta)
    {
        return proposta.Solicitacao
            .DataInicioOperacao
            .AddDays(proposta.Solicitacao.DuracaoPrevistaLocacao);
    }
}