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

        private async void DoTest(object obj)
        {
            int[] test = await Random.GetRandomIntegersAsync(0, 36, 8, false);
            string TestString = string.Empty;
            foreach(int i in test)
            {
                TestString += string.Format("{0}\n", i);
            }
            TestOutput = TestString;
        }
    }
}
