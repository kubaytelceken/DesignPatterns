using DesignPattern.CQRS.CQRSPattern.Commands;
using DesignPattern.CQRS.CQRSPattern.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.CQRS.Controllers
{
    public class DefaultController : Controller
    {
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler;
        private readonly DeleteProductCommandHandler _deleteProductCommandHandler;
        private readonly GetProductUpdateQueryHandler _getProductUpdateQueryHandler;
        private readonly UpdateProductCommandHandler _updateProductCommandHandler;

        public DefaultController(GetProductQueryHandler getProductQueryHandler, CreateProductCommandHandler createProductCommandHandler, GetProductByIdQueryHandler getProductByIdQueryHandler, DeleteProductCommandHandler deleteProductCommandHandler, GetProductUpdateQueryHandler getProductUpdateQueryHandler, UpdateProductCommandHandler updateProductCommandHandler)
        {
            _getProductQueryHandler = getProductQueryHandler;
            _createProductCommandHandler = createProductCommandHandler;
            _getProductByIdQueryHandler = getProductByIdQueryHandler;
            _deleteProductCommandHandler = deleteProductCommandHandler;
            _getProductUpdateQueryHandler = getProductUpdateQueryHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
        }

        public IActionResult Index()
        {
            var values = _getProductQueryHandler.Handle();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
         
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(CreateProductCommand createProductCommand)
        {
           _createProductCommandHandler.Handle(createProductCommand);
            return RedirectToAction("Index");
        }

        public IActionResult GetProduct(int id)
        {
            var values =_getProductByIdQueryHandler.Handle(new CQRSPattern.Queries.GetProductByIdQuery(id));
            return View(values);
        }

        public IActionResult DeleteProduct(int id)
        {
            _deleteProductCommandHandler.Handle(new DeleteProductCommand(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var values = _getProductUpdateQueryHandler.Handle(new CQRSPattern.Queries.GetProductUpdateQuery(id));
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductCommand updateProductCommand)
        {
            _updateProductCommandHandler.Handle(updateProductCommand);
            return RedirectToAction("Index");
        }
    }
}
