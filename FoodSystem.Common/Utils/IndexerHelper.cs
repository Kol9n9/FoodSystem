using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSystem.Common.Utils
{
    public static class IndexerHelper
    {
        public static Tuple<int,int> FlatIndexToTwoDimensional(int index, int cols)
        {
            int row = index / cols;
            int col = index % cols;
            return Tuple.Create(row, col);
        }
        public static int TwoDimensionalToFlatIndex(int row, int col, int cols)
        {
            return row * cols + col;
        }
    }
}
