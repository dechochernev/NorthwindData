using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Usecases.Interfaces
{
    public interface IUpdateEmployeeNotes
    {
        Task UpdateEmployeeNotesAsync(int employeeId, string notes);
    }
}
