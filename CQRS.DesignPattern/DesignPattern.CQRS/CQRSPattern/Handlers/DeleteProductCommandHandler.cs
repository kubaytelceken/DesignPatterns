using DesignPattern.CQRS.CQRSPattern.Commands;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class DeleteProductCommandHandler
    {
        private readonly CQRSContext _context;

        public DeleteProductCommandHandler(CQRSContext context)
        {
            _context = context;
        }

        public void Handle(DeleteProductCommand deleteProductCommand)
        {
            var values = _context.Products.Find(deleteProductCommand.Id);
            _context.Products.Remove(values);
            _context.SaveChanges();
        }
    }
}
