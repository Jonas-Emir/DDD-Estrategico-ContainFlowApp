using ContainerFlow.Vendas.Locacoes;

namespace ContainerFlow.API.Data.Repositories;

public class LocacaoRepository(AppDbContext context) : BaseRepository<Locacao>(context)
{
}
