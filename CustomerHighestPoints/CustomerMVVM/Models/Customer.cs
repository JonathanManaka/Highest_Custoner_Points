using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CustomerMVVM.Models
{
    public class Customer
    {
        private int _id;
        private List<string> fromlines = new List<string>();
        private List<string> tolines = new List<string>();
        private string _fileName = "Customer.txt";
        public int ID
        {
            get
            {
                return _id;
            }

            private set
            {
                _id = value;
            }
        }
        public void getID(int providedID)
        {
            string[] charec = { "," };
            string[] list;
            string line = "";
            _id = -1;

            using(StreamReader sr = new StreamReader(_fileName))
            {
                if(File.Exists(_fileName))
                {
                    while(!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                       
                        list = line.Split(charec, StringSplitOptions.RemoveEmptyEntries);
                        if(Convert.ToInt32(list[0]) == providedID)
                        {
                            _id = Convert.ToInt32(list[0]);
                        }
                        fromlines.Add(line);
                    }
                }
               sr.Close();
            }

        }

        public void storePoints(int points)
        {
            string[] charec = { "," };
            string[] list;
            string line = "";
            int incrPoints = 0;

            
            for (int i = 0;i < fromlines.Count;i++)
            {
                line = fromlines[i];

                list = line.Split(charec, StringSplitOptions.RemoveEmptyEntries);
                if(Convert.ToInt32(list[0]) == _id)
                {
                    incrPoints = Convert.ToInt32(list[2]);

                  incrPoints += points;
                  list[2] = incrPoints.ToString();
                  line = list[0] + "," + list[1] + "," + list[2];
                }
                tolines.Add(line);
            }
            storeDataToFile(tolines);
            fromlines.Clear();
            tolines.Clear();  
        }

        public void storeDataToFile(List<string> toLines)
        {
            
            using (StreamWriter sw = new StreamWriter(_fileName,false))
            {
                if(File.Exists(_fileName))
                {
                    for(int i = 0; i<tolines.Count;i++)
                    {
                        sw.WriteLine(tolines[i]);   
                    }
               }
                sw.Close();

            }
        }
        public List<string> fileData()
        {
            List<string> dataLines = new List<string>();
            using(StreamReader sr = new StreamReader(_fileName))
            {
                if(File.Exists(_fileName))
                {
                    while(!sr.EndOfStream)
                    {
                        dataLines.Add(sr.ReadLine());
                    }
                   
                }
                sr.Close();
            }
            return dataLines;
        }

        
       

    }
}
