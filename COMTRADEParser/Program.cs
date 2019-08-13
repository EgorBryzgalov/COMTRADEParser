using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMTRADEParser
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigReader conf = new ConfigReader();
            conf.Parse();

            DataReader data = new DataReader(conf);
            data.GetData(@"D:\Comtrade\2\A1OBAMI4.DAT");
            Console.WriteLine(data.AnalogChannels[0].DataCollection[0].Num);
            Console.WriteLine(data.AnalogChannels[0].DataCollection[0].TimeBias);
            Console.WriteLine(data.AnalogChannels[0].DataCollection[0].Value);

            Console.ReadLine();
        }
    }
    
}
