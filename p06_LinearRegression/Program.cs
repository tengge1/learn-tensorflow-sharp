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
            var xData = new double[] {
                3.3, 4.4, 5.5, 6.71, 6.93, 4.168, 9.779, 6.182, 7.59, 2.167,
                7.042, 10.791, 5.313, 7.997, 5.654, 9.27, 3.1
            };
            var yData = new double[] {
                1.7,2.76,2.09,3.19,1.694,1.573,3.366,2.596,2.53,1.221,
                 2.827,3.465,1.65,2.904,2.42,2.94,1.3
            };

            var g = new TFGraph();

            var x = g.Placeholder(TFDataType.Float);
            var y = g.Placeholder(TFDataType.Float);

            var ran = new Random();
            var w = g.Variable(g.Const((float)ran.Next()), operName: "weight");
            var b = g.Variable(g.Const((float)ran.Next()), operName: "bias");
            var output = g.Add(g.Mul(x, w.Read), b.Read);

            var loss = g.ReduceSum(g.Pow(g.Sub(output, y), g.Const(2.0)));

            var sess = new TFSession(g);

            for (var i = 0; i < 100; i++)
            {

            }
        }
    }
}
