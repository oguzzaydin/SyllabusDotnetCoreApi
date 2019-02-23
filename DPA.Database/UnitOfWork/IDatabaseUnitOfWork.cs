﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Database
{
    public interface IDatabaseUnitOfWork
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
