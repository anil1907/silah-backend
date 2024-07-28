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

namespace Application.Features.ProductTypes.Commands.Update;

public class UpdateProductTypeCommand : IRequest<UpdatedProductTypeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public string[] Roles => [Admin, Write, ProductTypesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetProductTypes"];

    public class UpdateProductTypeCommandHandler : IRequestHandler<UpdateProductTypeCommand, UpdatedProductTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly ProductTypeBusinessRules _productTypeBusinessRules;

        public UpdateProductTypeCommandHandler(IMapper mapper, IProductTypeRepository productTypeRepository,
                                         ProductTypeBusinessRules productTypeBusinessRules)
        {
            _mapper = mapper;
            _productTypeRepository = productTypeRepository;
            _productTypeBusinessRules = productTypeBusinessRules;
        }

        public async Task<UpdatedProductTypeResponse> Handle(UpdateProductTypeCommand request, CancellationToken cancellationToken)
        {
            ProductType? productType = await _productTypeRepository.GetAsync(predicate: pt => pt.Id == request.Id, cancellationToken: cancellationToken);
            await _productTypeBusinessRules.ProductTypeShouldExistWhenSelected(productType);
            productType = _mapper.Map(request, productType);

            await _productTypeRepository.UpdateAsync(productType!);

            UpdatedProductTypeResponse response = _mapper.Map<UpdatedProductTypeResponse>(productType);
            return response;
        }
    }
}