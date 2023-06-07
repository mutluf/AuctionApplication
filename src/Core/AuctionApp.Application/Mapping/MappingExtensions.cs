using AuctionApp.Application.DTOs.Responses.ProductResponses;
using AuctionApp.Domain.Entities;
using AutoMapper;

namespace AuctionApp.Application.Mapping
{
	public static class MappingExtensions
	{
		public static T ConvertToDto<T>(this IEnumerable<Product> products, IMapper mapper)
		{
			return mapper.Map<T>(products);
		}
		public static IEnumerable<GetAllProductsResponse> ConvertToResponses(this IEnumerable<Product> products, IMapper mapper)
		{
			return mapper.Map<IEnumerable<GetAllProductsResponse>>(products);
		}

		//public static IEnumerable<CategoryDisplayResponse> ConvertToDto(this IEnumerable<Category> categories, IMapper mapper)
		//{
		//	return mapper.Map<IEnumerable<CategoryDisplayResponse>>(categories);
		//}
	}
}
