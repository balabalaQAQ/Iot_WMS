
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapidemo.Model;

namespace weiapidemo.Provider
{
    public interface MemberIO
    {
        List<Member> GetForecasts();
    }
}
