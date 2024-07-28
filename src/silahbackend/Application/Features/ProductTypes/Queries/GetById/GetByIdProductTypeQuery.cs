using Application.Features.ProductTypes.Constants;
using Application.Features.ProductTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ProductTypes.Constants.ProductTypesOperationClaims;

namespace Application.Features.ProductTypes.Queries.GetById;

public class GetByIdProductTypeQuery : IRequest<GetByIdProductTypeResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdProductTypeQueryHandler : IRequestHandler<GetByIdProductTypeQuery, GetByIdProductTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly ProductTypeBusinessRules _productTypeBusinessRules;

        public GetByIdProductTypeQueryHandler(IMapper mapper, IProductTypeRepository productTypeRepository, ProductTypeBusinessRules productTypeBusinessRules)
        {
            _mapper = mapper;
            _productTypeRepository = productTypeRepository;
            _productTypeBusinessRules = productTypeBusinessRules;
        }

        public async Task<GetByIdProductTypeResponse> Handle(GetByIdProductTypeQuery request, CancellationToken cancellationToken)
        {
            ProductType? productType = await _productTypeRepository.GetAsync(predicate: pt => pt.Id == request.Id, cancellationToken: cancellationToken);
            await _productTypeBusinessRules.ProductTypeShouldExistWhenSelected(productType);

            GetByIdProductTypeResponse response = _mapper.Map<GetByIdProductTypeResponse>(productType);
            return response;
        }
    }
}