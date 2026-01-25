using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineCraft_Story_Mod
{
    class Person<T>
    {
        public string Name { get; set; }
        public T Id { get; set; }
    }
}
