using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ed_roadtoriches.database
{
    public class Body
    {
        public uint ID{get;set ;}
        public string body { get; set; }
        public string system { get; set; }
        public uint dta { get; set; }
        public uint orbitalPeriod { get; set; }
        public byte type { get; set; }

        public Body(uint _id,string _system,string _body,uint _dta, uint _orbitalPeriod, byte _type)
        {
            ID = _id;
            system = _system;
            body = _body;
            dta = _dta;
            orbitalPeriod = _orbitalPeriod;
            type = _type;
        }
    }
}
