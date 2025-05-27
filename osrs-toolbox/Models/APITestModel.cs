using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace osrs_toolbox
{
    public abstract class APITestModel : ModelBase
    {
        private string _testOutput;
        private ICommand _testCall;
        
        public string TestOutput
        {
            get { return _testOutput; }
            set { SetProperty(ref _testOutput, value, nameof(TestOutput)); }
        }
        public ICommand TestCall
        { 
            get { return _testCall; }
            set { SetProperty(ref _testCall, value, nameof(TestCall)); }
        }
    }
}
