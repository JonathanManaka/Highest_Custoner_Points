using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerMVVM.Models;

namespace CustomerMVVM.ViewModel
{
    internal class customerViewModel
    {
        double _amount;
        string _name;
        string _points;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Points
        {
            get { return _points; } 
            set { _points = value; }
        }
        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        Customer cust;
        public customerViewModel()
        {
            cust = new Customer();
        }

        public bool checkID(int id, double amount)
        {
            cust.getID(id);
            int points = 0;
            if(cust.ID>=0)
            {
                points = calcPoints(amount);
                cust.storePoints(points);
                return true;
            }
            else
            {
                return false;
            }

        }

        public int calcPoints(double amount)
        {
            int points = 0;
            if(amount >= 1000 && amount <= 1500)
            {
                points = 50;
            }
            else if(amount >1500 && amount <= 5000)
            {
                points = 75;
            }
            else if(amount > 5000 && amount <= 10000)
            {
                points = 150;
            }
            else if(amount > 10000)
            {
                points = 200;
            }
            else
            {
                points = 5;
            }
            return points;
        }
        public void highestCustomer()
        {
            List<string> dataF = new List<string>();
            dataF = cust.fileData();
            int highestValue = 0;
            string highestName = "";

            string[] splitOpt = {","};
            string[] lines;

            for (int i =0; i<dataF.Count;i++)
            {
                lines = dataF[i].Split(splitOpt, StringSplitOptions.RemoveEmptyEntries);
                if(Convert.ToInt32(lines[2]) > highestValue)
                {
                    highestValue = Convert.ToInt32(lines[2]);
                    highestName = lines[1];
                }
            }
            _name = highestName;
            _points = highestValue.ToString();
        }
    }
}
