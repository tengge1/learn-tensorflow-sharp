using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p99_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var g = new TFGraph();

            var greater = g.Greater(g.Const(1), g.Const(0));
            var greaterEqual = g.GreaterEqual(g.Const(1), g.Const(0));
            var less = g.Less(g.Const(1), g.Const(2));
            var lessEqual = g.LessEqual(g.Const(1), g.Const(1));

            var sess = new TFSession(g);

            var result = sess.GetRunner().Fetch(greater, greaterEqual, less, lessEqual).Run();

            Console.WriteLine("{0} {1} {2} {3}", result[0].GetValue(), result[1].GetValue(), result[2].GetValue(), result[3].GetValue());
        }
    }
}
