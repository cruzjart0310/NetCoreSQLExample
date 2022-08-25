using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.NetCore.DataAccess.Entities
{
    public class Survey
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        //public IEnumerable<Question> Questions { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
