using DotNetCore.Repositories;
using DPA.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPA.Database
{
    public interface IUserLogRepository : IRelationalRepository<UserLogEntity> { }

}
