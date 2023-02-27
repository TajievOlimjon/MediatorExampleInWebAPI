using MediatR;

namespace WebMediatRExample.Models.Command
{
    public class AddCategoryCommand:IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
