﻿using Leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_management.Contracts
{
    interface ILeaveHistoryRepository:IRepositoryBase<LeaveHistory>
    {
    }
}
