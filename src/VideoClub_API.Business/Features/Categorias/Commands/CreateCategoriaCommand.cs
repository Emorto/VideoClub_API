using MediatR;
using VideoClub_API.Business.Persistence;
using VideoClub_API.Domain.Entities;
namespace VideoClub_API.Business.Features.Categorias.Commands;

public record CreateCategoriaCommand(string Nombre, string? Descripcion) : IRequest<int>;

public class CreateCategoriaCommandHandler(ICategoriaRepository repository)
    : IRequestHandler<CreateCategoriaCommand, int>
{
    public async Task<int> Handle(CreateCategoriaCommand request, CancellationToken cancellationToken)
    {
        var entity = new Categoria
        {
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            Activo = true
        };

        return await repository.AddAsync(entity);
    }
}