﻿using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.InterfacesLogic
{
    public interface IPositionLogic
    {
        List<PositionVM> GetAllPositions();
        PositionVM GetPositionByID(int id);
    }
}
