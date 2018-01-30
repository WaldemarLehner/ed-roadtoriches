using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ed_roadtoriches.database
{
    public interface IBody
    {
        uint ID { get; set; }
        string Planet { get; set; }
        string System { get; set; }
        uint DTA { get; set; }
        uint OrbitalPeriod { get; set; }
        byte Type { get; set; }
        int X { get; set; }
        int Y { get; set; }
        int Z { get; set; }

    }
    public class Body : IBody
    {
        public uint ID{get;set ;}
        public string Planet { get; set; }
        public string System { get; set; }
        public uint DTA { get; set; }
        public uint OrbitalPeriod { get; set; }
        public byte Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Body(uint _id,string _system,string _body,uint _dta, uint _orbitalPeriod, byte _type, int _x, int _y, int _z)
        {
            ID = _id;
            System = _system;
            Planet = _body;
            DTA = _dta;
            OrbitalPeriod = _orbitalPeriod;
            Type = _type;
            X = _x;
            Y = _y;
            Z = _z;
        }
        public Body()
        {

        }
    }
}
