using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToUseBladeControl.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private string[] airports = new string[]
        {
            "LIML", "LIRF", "LIBR", "LIMC", "LIPZ", "LIMF", "LIPE"
        };

        public event EventHandler FlightSelectionChanged;
        public event EventHandler PriceConfirmed;

        public ObservableCollection<Flight> Flights { get; set; }

        private Flight selectedFlight;
        public Flight SelectedFlight
        {
            get { return selectedFlight; }
            set
            {
                selectedFlight = value;
                base.RaisePropertyChanged();
                this.IsFlightSelected = (selectedFlight != null);
            }
        }

        private bool isFlightSelected;
        public bool IsFlightSelected
        {
            get { return isFlightSelected; }
            set
            {
                isFlightSelected = value;
                base.RaisePropertyChanged();
            }
        }

        private double editPrice;
        public double EditPrice
        {
            get { return editPrice; }
            set { editPrice = value;
                base.RaisePropertyChanged();
            }
        }

        public RelayCommand<Flight> ShowDetailCommand { get; set; }
        public RelayCommand ConfirmPriceCommand { get; set; }

        public MainViewModel()
        {
            this.ShowDetailCommand = new RelayCommand<Flight>(showDetailCommandExecute);
            this.ConfirmPriceCommand = new RelayCommand(confirmPriceCommandExecute);

            load();
        }

        private void confirmPriceCommandExecute()
        {
            this.SelectedFlight.Price = this.EditPrice;
            this.PriceConfirmed?.Invoke(this, EventArgs.Empty);
        }

        private void showDetailCommandExecute(Flight selected)
        {
            this.SelectedFlight = selected;
            this.EditPrice = this.SelectedFlight.Price;
            this.FlightSelectionChanged?.Invoke(this, EventArgs.Empty);
        }

        private void load()
        {
            this.Flights = new ObservableCollection<Flight>();

            int index1;
            int index2;

            Random rnd = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < 50; i++)
            {
                var cloned = (airports.Clone() as string[]).ToList();

                index1 = rnd.Next(0, cloned.Count - 1);
                cloned.RemoveAt(index1);
                index2 = rnd.Next(0, cloned.Count - 1);

                var f = new Flight(cloned[index1], cloned[index2]);
                f.Price = rnd.Next(1, 12) * 100;
                this.Flights.Add(f);
            }
        }
    }
}