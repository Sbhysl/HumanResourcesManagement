using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Data
{
    interface IUnitOfWork
    {
        // IAdminRepository Admins { get; }
        Task<int> CommitAsync();
    }
}
