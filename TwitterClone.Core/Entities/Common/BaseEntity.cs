﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Core.Entities.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime CreateDate { get; set; }
    }
}
