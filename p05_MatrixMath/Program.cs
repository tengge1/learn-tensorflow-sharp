using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p05_MatrixMath
{
    class Program
    {
        static void Main(string[] args)
        {
            var g = new TFGraph();

            var a = g.Const(new double[,] { { 1, 2 } });
            var b = g.Const(new double[,] { { 3 }, { 4 } });

            var mul = g.MatMul(a, b);

            var sess = new TFSession(g);

            var result = sess.GetRunner().Run(mul);

            Console.WriteLine(result.ToString());
            Console.WriteLine(((double[,])result.GetValue())[0, 0]);
        }
    }
}
