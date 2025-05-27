using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osrs_toolbox
{
    public class ShopBuyoutViewModel : ShopBuyoutModel
    {
        public ShopBuyoutViewModel()
        {
            InitializeVariables();
            InitializeCommands();
        }

        private void InitializeVariables()
        {
            QuantityAvailable = 1000;
            BaseValue = 100;
            BaseMultiplier = 11.5;
            ChangePerUnit = 0.01;
        }

        private void InitializeCommands()
        {

        }
    }
}
