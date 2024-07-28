using Application.Features.ProductTypes.Constants;
using Application.Features.ProductTypes.Constants;
using Application.Features.ProductTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ProductTypes.Constants.ProductTypesOperationClaims;

namespace Application.Features.ProductTypes.Commands.Delete;

public class DeleteProductTypeCommand : IRequest<DeletedProductTypeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, ProductTypesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetProductTypes"];

    public class DeleteProductTypeCommandHandler : IRequestHandler<DeleteProductTypeCommand, DeletedProductTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly ProductTypeBusinessRules _productTypeBusinessRules;

        public DeleteProductTypeCommandHandler(IMapper mapper, IProductTypeRepository productTypeRepository,
                                         ProductTypeBusinessRules productTypeBusinessRules)
        {
            _mapper = mapper;
            _productTypeRepository = productTypeRepository;
            _productTypeBusinessRules = productTypeBusinessRules;
        }

        public async Task<DeletedProductTypeResponse> Handle(DeleteProductTypeCommand request, CancellationToken cancellationToken)
        {
            ProductType? productType = await _productTypeRepository.GetAsync(predicate: pt => pt.Id == request.Id, cancellationToken: cancellationToken);
            await _productTypeBusinessRules.ProductTypeShouldExistWhenSelected(productType);

            await _productTypeRepository.DeleteAsync(productType!);

            DeletedProductTypeResponse response = _mapper.Map<DeletedProductTypeResponse>(productType);
            return response;
        }
    }
}