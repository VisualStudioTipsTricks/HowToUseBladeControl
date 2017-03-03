using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToUseBladeControl.ViewModels
{
    class Flight : ObservableObject
    {
        private string departure;
        public string Departure
        {
            get { return departure; }
            set { departure = value;
                base.RaisePropertyChanged();
            }
        }

        private string destination;
        public string Destination
        {
            get { return destination; }
            set { destination = value;
                base.RaisePropertyChanged();
            }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set { price = value;
                base.RaisePropertyChanged();
            }
        }

        public Flight()
        {

        }

        public Flight(string departure, string destination)
        {
            this.Departure = departure;
            this.Destination = destination;
        }
    }
}