using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osrs_toolbox
{
    public class DropChanceViewModel : DropChanceModel
    {
        public DropChanceViewModel() 
        {
            InitializeVariables();
            InitializeCommands();
        }

        private void InitializeVariables()
        {
            DropRate = 1;
            CurrentKC = 1;
            ChanceCheck = 1;
        }

        private void InitializeCommands()
        {

        }
    }
}
