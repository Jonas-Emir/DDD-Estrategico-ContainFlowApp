using ContainerFlow.Financeiro.Faturamento;

namespace ContainerFlow.API.Data.Repositories;

public class FaturaRepository : BaseRepository<Fatura>
{
    public FaturaRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
