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

namespace Application.Features.ProductTypes.Commands.Create;

public class CreateProductTypeCommand : IRequest<CreatedProductTypeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Name { get; set; }

    public string[] Roles => [Admin, Write, ProductTypesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetProductTypes"];

    public class CreateProductTypeCommandHandler : IRequestHandler<CreateProductTypeCommand, CreatedProductTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly ProductTypeBusinessRules _productTypeBusinessRules;

        public CreateProductTypeCommandHandler(IMapper mapper, IProductTypeRepository productTypeRepository,
                                         ProductTypeBusinessRules productTypeBusinessRules)
        {
            _mapper = mapper;
            _productTypeRepository = productTypeRepository;
            _productTypeBusinessRules = productTypeBusinessRules;
        }

        public async Task<CreatedProductTypeResponse> Handle(CreateProductTypeCommand request, CancellationToken cancellationToken)
        {
            ProductType productType = _mapper.Map<ProductType>(request);

            await _productTypeRepository.AddAsync(productType);

            CreatedProductTypeResponse response = _mapper.Map<CreatedProductTypeResponse>(productType);
            return response;
        }
    }
}