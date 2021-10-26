using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public class BadDependency
    {
        public BadDependency()
        {
            System.Threading.Thread.Sleep(4000);
            Id = Guid.NewGuid().ToString();
        }

        public bool True() => true;
        public string Id { get; set; }
    }
}
