using MediatR;
using WebMediatRExample.Models.Command.ResponseCommand;

namespace WebMediatRExample.Models.Command
{
    public class UpdateProductCommand: IRequest<ProductCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
