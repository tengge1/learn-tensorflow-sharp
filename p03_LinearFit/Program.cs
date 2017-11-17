using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p03_LinearFit
{
    class Program
    {
        static void Main(string[] args)
        {
            var shape = new TFShape();

            var graph = new TFGraph();
            var xs = graph.Placeholder(TFDataType.Float, shape, "xs");
            var ys = graph.Placeholder(TFDataType.Float, shape, "ys");
        }
    }
}
