using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMTRADEParser
{
    class Channel
    {
        public int Number { get; set; }

        public string Id { get; set; }


    }
    class AnalogChannel : Channel
    {
        public AnalogChannel() : base()
        {

        }

        public string Phase { get; set; }

        public string Circuit { get; set; }

        public string Unit { get; set; }

        public float A { get; set; }

        public float B { get; set; }

        public float Skew { get; set; }

        public int Min { get; set; }

        public int Max { get; set; }

        public int Primary { get; set; }

        public int Secondary { get; set; }

        public string PS { get; set; }
    }
    class DigitalChannel : Channel
    {
       public int DefaultState { get; set; }
    }
}
