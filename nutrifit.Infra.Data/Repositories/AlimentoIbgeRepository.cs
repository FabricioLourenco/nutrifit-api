using Nutrifit.Domain.Entities;
using Nutrifit.Domain.Interfaces.Infra.Data.Repositories;
using Nutrifit.Domain.Interfaces.Infra.Data;
using Nutrifit.Infra.CrossCutting.Handlers.Notifications;
using nutrifit.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Nutrifit.Domain.DTos.Base;

namespace Nutrifit.Infra.Data.Repositories
{
    public class AlimentoIbgeRepository : IAlimentoIbgeRepository
    {
        private readonly NutrifitContext _context;
        private readonly IUnitOfWork _uow;
        private readonly INotificationHandler _notificationHandler;

        public AlimentoIbgeRepository(NutrifitContext context,
                                      IUnitOfWork uow,
                                      INotificationHandler notificationHandler)
        {
            _context = context;
            _uow = uow;
            _notificationHandler = notificationHandler;
        }

        #region Public Methods

        public async Task<AlimentoIbge?> BuscarAlimentoIbgePorNumero(int numeroDoAlimento)
        {
            return await _context.AlimentoIbge.FirstOrDefaultAsync(a => a.NumeroDoAlimento == numeroDoAlimento);
        }

        public async Task<IEnumerable<AlimentoIbge>> BuscarTodosAlimentosIbge()
        {
            return await _context.AlimentoIbge.ToListAsync();
        }
        public async Task<PagedResultDTo<AlimentoIbge>> BuscarAlimentosIbgePaginado(PaginationDTo pagination)
        {
            var query = _context.AlimentoIbge.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.SearchTerm))
            {
                query = query.Where(a => a.DescricaoDosAlimentos.Contains(pagination.SearchTerm) ||
                                         a.CategoriaDoAlimento.Contains(pagination.SearchTerm));
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
            .ToListAsync();

            return new PagedResultDTo<AlimentoIbge>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }


        #endregion
    }
}
