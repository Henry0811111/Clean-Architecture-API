using CleanArchAPI.Domain.Entities;
using CleanArchAPI.Domain.Interfaces;
using CleanArchAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchAPI.Infrastructure.Repositories;

public class ProductRepository(AppDbContext context)
    : Repository<Product>(context), IProductRepository
{
    // Include() laddar Category i samma query — undviker N+1-problem
    public async Task<IEnumerable<Product>> GetAllWithCategoryAsync()
        => await _dbSet.Include(p => p.Category).AsNoTracking().ToListAsync();

    public async Task<Product?> GetByIdWithCategoryAsync(int id)
        => await _dbSet.Include(p => p.Category).AsNoTracking()
                       .FirstOrDefaultAsync(p => p.Id == id);
}
