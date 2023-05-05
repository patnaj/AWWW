using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3_test.Services
{
    public interface ITimeServie
    {
        int sec { get; }
        int hou { get; }

        int fun1(int a);
    }

    public class TimeServie : ITimeServie
    {
        public int sec { get => DateTime.Now.Second; }
        public int hou { get => DateTime.Now.Hour; }

        public int fun1(int a)
        {
            return a + 1;
        }
    }

    public interface ITimeServie2
    {
        int fun2(int a);
    }

    public class TimeServie2 : ITimeServie2
    {
        public TimeServie2(ITimeServie it)
        {
        }

        public int fun2(int a)
        {
            return a + 1;
        }
    }

    public class MyClass : ITimeServie
    {
        private int dd = 0;

        public int sec => 0;

        public int hou => 1;

        public int fun1(int a)
        {
            dd+=a;
            return dd;
        }
    }
}

