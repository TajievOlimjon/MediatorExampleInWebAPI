using MediatR;
using WebMediatRExample.Models.Command.ResponseCommand;

namespace WebMediatRExample.Models.Command
{
    public class AddProductCommand: IRequest<ProductCommandResponse>
    {
        public string Name { get; set; }
    }
}

