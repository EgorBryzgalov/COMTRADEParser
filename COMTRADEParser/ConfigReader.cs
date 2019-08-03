using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace COMTRADEParser
{
    class ConfigReader
    {
        public int NumberOfChannels { get; set; }

        public int NumberOfAnalogs { get; set; }

        public ConfigReader()
        {

        }

        public void Parse()
        {
            //Заменить на чтение пути из диалогового окна
            string FilePath = @"D:\Comtrade\2\A1OBAMI4.CFG";

            StreamReader reader = new StreamReader(FilePath);
            List<string> lines = new List<string>();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }

            //Кол-во каналов, кол-во аналоговых каналов, кол-во цифровых каналов
            string[] second = lines[1].Split(',');
            NumberOfChannels = int.Parse(second[0]);
            StringBuilder Analog = new StringBuilder();
            foreach (char c in second[1])
            {
                if (c != 'A')
                    Analog.Append(c);
            }
            NumberOfAnalogs = int.Parse(Analog.ToString());
            

        }
    }
}
