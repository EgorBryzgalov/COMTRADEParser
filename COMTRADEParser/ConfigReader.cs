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

        public int NumberOfDigitals { get; set; }

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
            #region парсинг второй строки
            string[] second = lines[1].Split(',');
            NumberOfChannels = int.Parse(second[0]);
            StringBuilder StrBuilder = new StringBuilder();
            foreach (char c in second[1])
            {
                if (c != 'A')
                    StrBuilder.Append(c);
            }
            NumberOfAnalogs = int.Parse(StrBuilder.ToString());
            StrBuilder.Clear();
            foreach (char c in second[2])
            {
                if (c != 'D')
                    StrBuilder.Append(c);
            }
            NumberOfDigitals = int.Parse(StrBuilder.ToString());
            #endregion


        }
    }
}
