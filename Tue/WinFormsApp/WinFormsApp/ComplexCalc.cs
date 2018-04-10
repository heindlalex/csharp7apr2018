using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp
{
    public class ComplexCalc
    {
        public async Task<int> AddAsync(int x, int y)
        {
            await Task.Delay(3000);
            return x + y;
        }
    }
}
