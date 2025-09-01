using ContainerFlow.Vendas.Propostas;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ContainerFlow.API.Data.Repositories;

public class SolicitacaoRepository(AppDbContext dbContext) 
    : BaseRepository<PedidoLocacao>(dbContext)
{
    public override Task<PedidoLocacao?> GetFirstAsync<TProperty>(Expression<Func<PedidoLocacao, bool>> filtro, Expression<Func<PedidoLocacao, TProperty>> orderBy, CancellationToken cancellationToken = default)
    {
        return dbContext.Pedidos
            .Include(s => s.Propostas)
            .AsNoTracking()
            .OrderBy(orderBy)
            .FirstOrDefaultAsync(filtro, cancellationToken);
    }
}
