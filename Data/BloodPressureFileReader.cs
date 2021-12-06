using ST3PRJ3.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST3PRJ3.Data
{
    public class BloodPressureFileReader
    {
        public List<DTO_BloodPressure> ReadBloodPressureInFile(string path)
        {
            List<DTO_BloodPressure> bloodpressureList = new List<DTO_BloodPressure>();
            

            // open file
            string[] allLines = File.ReadAllLines(path);

            // for each line
            foreach (string line in allLines)
            {
                // split data in file
                string[] split = line.Split(new char[] { ' ' });
                double value = Convert.ToDouble(split[0]);
                string enhed = split[1];

                
                DTO_BloodPressure bp = new DTO_BloodPressure();
                bp.Value = Convert.ToInt32(value);
                //bp.Enhed = enhed;

                // add card to list
                bloodpressureList.Add(bp);
            }

            return bloodpressureList;
        }
    }
}
