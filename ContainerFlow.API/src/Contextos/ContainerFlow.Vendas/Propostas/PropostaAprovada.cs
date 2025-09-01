using ContainerFlow.DDD;

namespace ContainerFlow.Vendas.Propostas;

public class PropostaAprovada : IDomainEvent
{
    public PropostaAprovada(Guid idProposta, decimal valorProposta)
    {
        IdProposta = idProposta;
        ValorProposta = valorProposta;
    }

    public Guid IdProposta { get; }
    public decimal ValorProposta { get; }
}
