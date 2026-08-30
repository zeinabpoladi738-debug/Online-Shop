using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.BaseEntities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatDate { get; set; }
        public DateTime UpdateDate { get; set; }    
    }
}
