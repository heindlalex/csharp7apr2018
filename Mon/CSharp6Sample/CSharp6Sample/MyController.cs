using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp6Sample
{
    public interface IMyService
    {

    }
    public class MyController
    {
        private readonly IMyService _myService;
        public MyController(IMyService myService)
        {
            //if (_myService == null) throw new ArgumentNullException(nameof(myService));

            //_myService = myService;

            _myService = myService ?? throw new ArgumentNullException(nameof(myService));
        }
    }
}
