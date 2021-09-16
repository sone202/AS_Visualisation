using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortsVisualisation.Models
{
    public struct RenderObject
    {
        public int value;

        public static int PivotIndex;
        public static int ComparableIndex;

        public static int FirstSwapIndex;
        public static int SecondSwapIndex;

        public static void ResetIndexes()
        {
            PivotIndex = -1;
            ComparableIndex = -1;
            FirstSwapIndex = -1;
            SecondSwapIndex = -1;
        }
    }
}
