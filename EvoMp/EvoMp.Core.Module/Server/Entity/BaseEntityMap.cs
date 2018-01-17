using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoMp.Core.Module.Server.Entity
{
    public class BaseEntityMap
    {
        [Key, Column(Order = 0)]
        public virtual int Id { get; set; }
    }
}
