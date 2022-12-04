using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract5
{
    internal class Triangle
    {
        public uint Length1 { get; set; }
        public uint Length2 { get; set; }
        public uint Length3 { get; set; }

        public Triangle(uint length1, uint length2, uint length3)
        {
            Length1 = length1;
            Length2 = length2;
            Length3 = length3;
        }

        public uint PerimeterTriangle()
        {
            return Length1 + Length2 + Length3;
        }

        public void IncreaseLength()
        {
            Length1 *= 2;
            Length2 *= 2;
            Length3 *= 2;
        }

        public void SetParams(uint length1, uint length2, uint length3)
        {
            Length1 = length1;
            Length2 = length2;
            Length3 = length3;
        }
        public void SetParams(uint length1)
        {
            Length1 = length1;
        }
        public void SetParams(uint length1, uint length2)
        {
            Length1 = length1;
            Length2 = length2;
        }
        public void SetParams(int length1, int length2, int length3)
        {
            if (!(length1 > 0 && length2 > 0 && length3 > 0))
            {
                throw new ArgumentOutOfRangeException(null, "Данные должны быть больше 0");
            }
            Length1 = (uint)length1;
            Length2 = (uint)length2;
            Length3 = (uint)length3;
        }
        public void ClearTriangle()
        {
            Length1 = 0;
            Length2 = 0;
            Length3 = 0;
        }
    }
}
