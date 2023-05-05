using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3.Services
{
    public interface IDataService
    {
        string getTime { get; }
    }

    public class DataService : IDataService
    {
        public string getTime { get => DateTime.Now.ToShortTimeString(); }
    }
}