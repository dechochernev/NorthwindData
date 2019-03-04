using System.Threading.Tasks;

namespace BusinessLayer.Access.Commands
{
    public interface IUpdateEmployeeNotesCommand
    {
        Task HandleAsync(UpdateEmployeeNotesCommand query);
    }
}
