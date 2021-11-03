using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapidemo.Model
{
    public class Member
    {
        public Guid Id { get; set; }

        public int OrderNumber { get; set; }

        public string Name { get; set; }

        public DateTime AdmissionTime { get; set; }

        public int Integral { get; set; }
      
        public Member()
        {
            this.Id = Guid.NewGuid();
            this.AdmissionTime = DateTime.Now;
        }
    }
}
