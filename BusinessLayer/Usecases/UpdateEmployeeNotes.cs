using BusinessLayer.Access.Commands;
using BusinessLayer.Usecases.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Usecases
{
    public class UpdateEmployeeNotes : IUpdateEmployeeNotes
    {
        private readonly IUpdateEmployeeNotesCommand handlers;

        public UpdateEmployeeNotes(IUpdateEmployeeNotesCommand handlers)
        {
            this.handlers = handlers;
        }

        public async Task UpdateEmployeeNotesAsync(int employeeId, string notes)
        {
            await handlers.HandleAsync(new UpdateEmployeeNotesCommand(employeeId,notes));
        }
    }
}
