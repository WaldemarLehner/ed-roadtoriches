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
        public string Planet { get; set; }
        public string System { get; set; }
        public uint DTA { get; set; }
        public uint OrbitalPeriod { get; set; }
        public byte Type { get; set; }

        public Body(uint _id,string _system,string _body,uint _dta, uint _orbitalPeriod, byte _type)
        {
            ID = _id;
            System = _system;
            Planet = _body;
            DTA = _dta;
            OrbitalPeriod = _orbitalPeriod;
            Type = _type;
        }
    }
}
