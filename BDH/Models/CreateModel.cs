using System;
using System.Collections.Generic;
using System.Text;

namespace BDH.Models
{
    public class CreateModel<TEntity> where TEntity: class
    {
        public TEntity Entity { get; set; }
    }
}
