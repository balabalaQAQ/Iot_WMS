
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapidemo.Model;
using weiapidemo.Provider;

namespace webapidemo.Provider
{
    public class MemberFake:MemberIO
    {
        private List<Member> _todoItems { get; set; }

        public List<Member> GetForecasts() 
        {
            return _todoItems;
        }

      
    }
}
