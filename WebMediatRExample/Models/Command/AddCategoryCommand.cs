using MediatR;

namespace WebMediatRExample.Models.Command
{
    public class AddCategoryCommand:IRequest
    {
        public string Name { get; set; }
    }
}
