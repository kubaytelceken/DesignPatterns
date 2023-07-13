using DesignPattern.CQRS.CQRSPattern.Queries;
using DesignPattern.CQRS.CQRSPattern.Results;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class GetProductUpdateQueryHandler
    {
        private readonly CQRSContext _context;

        public GetProductUpdateQueryHandler(CQRSContext context)
        {
            _context = context;
        }

        public GetProductUpdateQueryResult Handle(GetProductUpdateQuery getProductUpdateQuery)
        {
            var values = _context.Products.Find(getProductUpdateQuery.Id);

            return new GetProductUpdateQueryResult
            {
                Id = values.Id,
                Name = values.Name,
                Description = values.Description,
                Stock = values.Stock,
                Price = values.Price,
            };
        }
    }
}
