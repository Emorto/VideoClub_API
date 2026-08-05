using MediatR;
using VideoClub_API.Business.Persistence;
using VideoClub_API.Domain.Entities;

namespace VideoClub_API.Business.Features.Categorias.Queries;

public record GetCategoriasQuery() : IRequest<IEnumerable<Categoria>>;

public class GetCategoriasQueryHandler(ICategoriaRepository repository) 
    : IRequestHandler<GetCategoriasQuery, IEnumerable<Categoria>>
{
    public async Task<IEnumerable<Categoria>> Handle(GetCategoriasQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAllAsync();
    }
}