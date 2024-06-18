using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity() 
        {
            CreatedAt = DateTime.Now;
        }

        public long Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
