using VideoClub_API.Domain.Entities;
namespace VideoClub_API.Business.Persistence;

public interface ICategoriaRepository
{
    // EF Core (Comandos)
    Task<int> AddAsync(Categoria categoria);
    Task UpdateAsync(Categoria categoria);
    Task DeleteAsync(int id);
    
    // Dapper (Consultas)
    Task<Categoria?> GetByIdAsync(int id);
    Task<IEnumerable<Categoria>> GetAllAsync();
}