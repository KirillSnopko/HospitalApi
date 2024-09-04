using MediatR;

namespace Application.ApiCommandHandlers.Doctors.Queries.GetData;

public sealed record GetAvailableDataQuery : IRequest<GetAvailableDataQueryResponse>
{
}
