using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Access.Commands
{
    public class UpdateEmployeeNotesCommand
    {
        public UpdateEmployeeNotesCommand(int employeeId, string notes)
        {
            this.EmployeeId = employeeId;
            this.Notes = notes;
        }

        public int EmployeeId { get; }
        public string Notes { get; }
    }
}
