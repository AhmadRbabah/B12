namespace B12.Application.Command.Tag.Create;

using AutoMapper;

using B12.Application.Response;
using B12.Domain.AggregateModels.TagAggregate;
using B12.Domain.Interfaces;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, TagResponse>
{
    private readonly IMapper _mapper;
    private readonly ITagRepository _tagRepository;

    public CreateTagCommandHandler(IMapper mapper, ITagRepository tagRepository)
    {
        _mapper = mapper;
        _tagRepository = tagRepository;
    }

    public async Task<TagResponse> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        var isTagUnique = await _tagRepository.IsUnique(request.Name);
        if (!isTagUnique)
        {
            throw new ArgumentException($"Tag name {request.Name} must be unique.");
        }

        var tag = Tag.New(request);

        await _tagRepository.AddAsync(tag);
        await _tagRepository.SaveChangesAsync();

        var tagResponse = _mapper.Map<TagResponse>(tag);

        return tagResponse;
    }
}