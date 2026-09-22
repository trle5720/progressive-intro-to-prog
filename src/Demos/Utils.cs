using System;
using System.Collections.Generic;
using System.Text;

namespace Demos.Tools;

public static class Utils
{
    extension(int num)
    {
        public  bool IsEven()
        {
            return (num % 2 == 0);
        }
        public DateTimeOffset DaysFromToday()
        {
            return DateTimeOffset.UtcNow.AddDays(num);
        }
    }

    extension(DateTimeOffset date)
    {
    
    }
}
