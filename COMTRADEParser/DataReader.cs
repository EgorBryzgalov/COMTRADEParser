using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace COMTRADEParser
{
    class DataReader
    {
        private ConfigReader Config { get; set; }
        public List<AnalogChannel> AnalogChannels;
        public List<DigitalChannel> DigitalChannels;


        public DataReader()
        {

        }

        public DataReader(ConfigReader config) : this()
        {
            Config = config;
            AnalogChannels = Config.AnalogChannels;
            DigitalChannels = Config.DigitalChannels;
        }

        public void GetData(string dataPath)
        {
            try
            {


                using (BinaryReader reader = new BinaryReader(File.Open(dataPath, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        int num = reader.ReadInt32();
                        int timeBias = reader.ReadInt32();
                        foreach (AnalogChannel chan in AnalogChannels)
                        {
                            chan.AddFrame(num, timeBias, reader.ReadInt16());
                        }
                        foreach (DigitalChannel chan in DigitalChannels)
                        {
                            chan.AddFrame(num, timeBias, reader.ReadBoolean());
                        }
                        if (DigitalChannels.Count > 0)
                        {
                            int BitsToSkip = 16 - DigitalChannels.Count % 16;
                            for (int i = 0; i < BitsToSkip; i++)
                            {
                                reader.ReadBoolean();
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {

            }
        }


    }
}
