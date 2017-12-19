using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p22_ConditionalOperators
{
    /// <summary>
    /// 22 Conditional Operators
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var g = new TFGraph();

            var pred = g.Greater(g.Const(1.0), g.Const(0.0));

            var value = g.Switch(g.Const(0), pred);

            var sess = new TFSession();

            var result = sess.GetRunner().Fetch(value.Item1, value.Item2).Run();

            Console.WriteLine("{0}", result[0].GetValue());
            Console.WriteLine("{1}", result[1].GetValue());
        }
    }
}
