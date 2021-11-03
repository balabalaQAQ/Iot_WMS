using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapidemo.Model
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public int OrderNumber { get; set; }
        public string AdmissionTime { get; set; }

        public int Integral { get; set; }
    }
}
