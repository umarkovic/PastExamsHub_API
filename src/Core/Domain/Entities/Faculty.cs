﻿using PastExamsHub.Base.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Domain.Entities
{
    public class Faculty : DomainEntity
    {
        public string Name { get; set; }
    }
}