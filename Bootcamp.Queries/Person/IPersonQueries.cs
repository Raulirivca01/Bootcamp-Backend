﻿using Bootcamp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Queries.Person
{
    public interface IPersonQueries
    {
        Task<IEnumerable<PersonViewModel>> ReadAll();
        Task<IEnumerable<PersonViewModel>> ReadById(int id);

    }
}
