using Microsoft.EntityFrameworkCore;
using RealEstateBackend.Application.Contracts.Persistence;
using RealEstateBackend.Domain;
using RealEstateBackend.Persistence.DatabaseContext;

namespace RealEstateBackend.Persistence.Repositories
{
    public class PropertyRepository : IPropertyRepository, IGenericRepository<Property>
    {
        private readonly DataContext _context;
        public PropertyRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Property> CreateAsync(Property entity)
        {
            await _context.Properties.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Property> DeleteAsync(Property entity)
        {
            _context.Properties.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IReadOnlyList<Property>> GetAllAsync()
        {
            return await _context.Properties.ToListAsync();
        }

        public async Task<Property> GetByIdAsync(int id)
        {
            return await _context.Properties.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Property> UpdateAsync(Property entity)
        {
            _context.Properties.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
