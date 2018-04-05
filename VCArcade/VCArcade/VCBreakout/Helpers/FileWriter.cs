using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCArcade.VCBreakout.Helpers
{
    class FileWriter
    {
        private static string FILENAME = @"Z:\acsv13-imagine\Breakout\scores.txt";

        private int[] stats = new int[2];

        public FileWriter(int[] args)
        {
            this.stats = args;

            WriteFile();

            ReadFile();

            //Console.Read();
        }

        private void WriteFile()
        {
            FileStream fs = new FileStream(FILENAME, FileMode.Append, FileAccess.Write);

            if (fs.CanWrite)
            {
                string statLine = makeBuffer();

                byte[] buffer = Encoding.ASCII.GetBytes(statLine);

                fs.Write(buffer, 0, buffer.Length);
            }

            fs.Flush();

            fs.Close();
        }

        private static void ReadFile()
        {
            FileStream fs = new FileStream(FILENAME, FileMode.Open, FileAccess.Read);

            if (fs.CanRead)
            {
                byte[] buffer = new byte[fs.Length];

                int bytesRead = fs.Read(buffer, 0, buffer.Length);

                Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, bytesRead));
            }

            fs.Close();
        }

        private string makeBuffer()
        {
            string stat = "";

            for (int i = 0; i < this.stats.Length; i++)
            {
                stat = parseInt(i);
            }

            return stat;
        }

        private string parseInt(int idx)
        {
            return this.stats[idx].ToString();
        }
    }
}