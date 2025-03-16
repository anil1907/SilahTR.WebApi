using SilahTR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SilahTR.Application.Common.Contracts
{
    public interface IApplicationDbContext
    {
        DbSet<Category> Categories { get; }

        DatabaseFacade Database { get; }
    
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    } 
}
