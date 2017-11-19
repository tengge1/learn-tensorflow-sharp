using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p01_HelloWorld
{
    /// <summary>
    /// 01 HelloWorld
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new TFGraph();
            var a = graph.Const(2);
            var b = graph.Const(3);

            var add = graph.Add(a, b);
            var mul = graph.Mul(a, b);

            using (var session = new TFSession(graph))
            {
                var result1 = session.GetRunner().Run(add).GetValue();
                Console.WriteLine("a+b={0}", result1);

                var result2 = session.GetRunner().Run(mul).GetValue();
                Console.WriteLine("a*b={0}", result2);
            }
        }
    }
}
