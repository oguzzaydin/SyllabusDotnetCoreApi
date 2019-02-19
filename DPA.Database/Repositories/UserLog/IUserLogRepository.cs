using DotNetCore.Repositories;
using DPA.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPA.Database.Repositories.UserLog
{
    public interface IUserLogRepository : IRelationalRepository<UserLogEntity> { }

}
