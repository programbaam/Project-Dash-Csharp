using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ColorPointComparer : IComparer<(int index, string color)>
{
    public int Compare((int index, string color) lvalue, (int index, string color) rvalue)
    {
        return lvalue.index.CompareTo(rvalue.index);
    }
}

