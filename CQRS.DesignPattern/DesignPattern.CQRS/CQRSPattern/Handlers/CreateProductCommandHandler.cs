using DesignPattern.CQRS.CQRSPattern.Commands;
using DesignPattern.CQRS.DAL;
using DesignPattern.CQRS.Models;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class CreateProductCommandHandler
    {
        private readonly CQRSContext _context;

        public CreateProductCommandHandler(CQRSContext context)
        {
            _context = context;
        }

        public void Handle(CreateProductCommand createProductCommand)
        {
            _context.Products.Add(new Product
            {
                Description = createProductCommand.Description,
                Name = createProductCommand.Name,
                Price = createProductCommand.Price,
                Status = true,
                Stock = createProductCommand.Stock,
            });
            _context.SaveChanges();

        }
    }
}
