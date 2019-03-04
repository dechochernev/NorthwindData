using Access.EntityFramework.Models;
using BusinessLayer.Access.Commands;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Access.EntityFramework.CommandHandlers
{
    public class UpdateEmployeeNotesCommandHandler : IUpdateEmployeeNotesCommand
    {
        private readonly NorthwindContext northwindContext;

        public UpdateEmployeeNotesCommandHandler(NorthwindContext northwindContext)
        {
            this.northwindContext = northwindContext;
        }

        public async Task HandleAsync(UpdateEmployeeNotesCommand query)
        {
            using (var context = northwindContext)
            {
                var employee = await context.Employees.FindAsync(query.EmployeeId);
                employee.Notes = query.Notes;
                await context.SaveChangesAsync();
            }
        }
    }
}
