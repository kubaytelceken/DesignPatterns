using DesignPattern.CQRS.CQRSPattern.Commands;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class UpdateProductCommandHandler
    {
        private readonly CQRSContext _context;

        public UpdateProductCommandHandler(CQRSContext context)
        {
            _context = context;
        }

        public void Handle(UpdateProductCommand updateProductCommand)
        {
            var values = _context.Products.Find(updateProductCommand.Id);
            values.Name = updateProductCommand.Name;
            values.Description = updateProductCommand.Description;
            values.Price = updateProductCommand.Price;
            values.Stock = updateProductCommand.Stock;
            _context.SaveChanges();

        }
    }
}
