using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osrs_toolbox
{
    public class APITestViewModel : APITestModel
    {
        public APITestViewModel() 
        {
            TestOutput = string.Empty;
            TestCall = new RelayCommand(DoTest);
        }

        private void DoTest(object obj)
        {

        }
    }
}
