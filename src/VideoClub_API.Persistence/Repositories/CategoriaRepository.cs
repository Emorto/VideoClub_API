using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VideoClub_API.Business.Persistence;
using VideoClub_API.Domain.Entities;
using VideoClub_API.Persistence.Contexts;

namespace VideoClub_API.Persistence.Repositories;

public class CategoriaRepository(
    VideoClubDbContext dbContext,
    IConfiguration configuration) : ICategoriaRepository
{
    private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection")!;

    // === EF CORE (ESCRITURAS) ===
    public async Task<int> AddAsync(Categoria categoria)
    {
        await dbContext.Categorias.AddAsync(categoria);
        await dbContext.SaveChangesAsync();
        return categoria.Id;
    }

    public async Task UpdateAsync(Categoria categoria)
    {
        dbContext.Categorias.Update(categoria);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await dbContext.Categorias.FindAsync(id);
        if (entity != null)
        {
            dbContext.Categorias.Remove(entity);
            await dbContext.SaveChangesAsync();
        }
    }

    // === DAPPER (LECTURAS) ===
    public async Task<Categoria?> GetByIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        const string sql = "SELECT Id, Nombre, Descripcion, Activo FROM Categorias WHERE Id = @Id";
        return await connection.QueryFirstOrDefaultAsync<Categoria>(sql, new { Id = id });
    }

    public async Task<IEnumerable<Categoria>> GetAllAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        const string sql = "SELECT Id, Nombre, Descripcion, Activo FROM Categorias WHERE Activo = 1";
        return await connection.QueryAsync<Categoria>(sql);
    }
}