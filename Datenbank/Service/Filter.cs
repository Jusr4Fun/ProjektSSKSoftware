using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datenbank.Service
{
    public class Filter
    {
        public List<string> FilterArguments { get; set; } = new List<string>();

        public void ChangeFilterArguments(string suche)
        {
            FilterArguments.Clear();
            var argumente = suche.Split(' ');

            foreach (var arg in argumente)
            {
                FilterArguments.Add(arg);
            }
        }

        public string[] returnFilterArgsArray()
        {
            return FilterArguments.ToArray();
        }
    }
}
