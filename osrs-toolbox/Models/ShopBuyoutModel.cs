using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osrs_toolbox
{
    public abstract class ShopBuyoutModel : ModelBase
    {
        private int _quantityAvailable;
        private int _baseValue;
        private double _baseMultiplier;
        private double _changePerUnit;

        public int QuantityAvailable
        {
            get { return _quantityAvailable; }
            set 
            { 
                SetProperty(ref _quantityAvailable, value, nameof(QuantityAvailable));
                OnPropertyChanged(nameof(MaxMultiplier));
                OnPropertyChanged(nameof(MaxPrice));
                OnPropertyChanged(nameof(BuyoutPrice));
            }
        }
        public int BaseValue
        {
            get { return _baseValue; }
            set 
            { 
                SetProperty(ref _baseValue, value, nameof(BaseValue)); 
                OnPropertyChanged(nameof(BasePrice));
                OnPropertyChanged(nameof(MaxPrice));
                OnPropertyChanged(nameof(BuyoutPrice));
            }
        }
        public double BaseMultiplier
        {
            get { return _baseMultiplier; }
            set 
            { 
                SetProperty(ref _baseMultiplier, value, nameof(BaseMultiplier)); 
                OnPropertyChanged(nameof(BasePrice));
                OnPropertyChanged(nameof(MaxMultiplier));
                OnPropertyChanged(nameof(MaxPrice));
                OnPropertyChanged(nameof(BuyoutPrice));
            }
        }
        public double ChangePerUnit
        {
            get { return _changePerUnit; }
            set 
            { 
                SetProperty(ref _changePerUnit, value, nameof(ChangePerUnit));
                OnPropertyChanged(nameof(MaxMultiplier));
                OnPropertyChanged(nameof(MaxPrice));
                OnPropertyChanged(nameof(BuyoutPrice));
            }
        }

        public double MaxMultiplier => (QuantityAvailable * ChangePerUnit) + BaseMultiplier;
        public double BasePrice => Math.Round(BaseValue * BaseMultiplier, 0);
        public double MaxPrice => Math.Round(BaseValue * MaxMultiplier, 0);
        public double BuyoutPrice
        {
            get
            {
                double PriceSum = 0d;
                for(int i = 0; i < QuantityAvailable; i++)
                {
                    double CurrentMultiplier = ((ChangePerUnit * i) + BaseMultiplier);
                    PriceSum += Math.Round(BaseValue * Math.Min(CurrentMultiplier, MaxMultiplier));
                }
                return PriceSum;
            }
        }
    }
}
