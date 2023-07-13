namespace DesignPattern.CQRS.CQRSPattern.Commands
{
    public class DeleteProductCommand
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
