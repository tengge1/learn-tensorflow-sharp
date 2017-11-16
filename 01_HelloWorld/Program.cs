using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace _01_HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var session = new TFSession())
            {
                var graph = session.Graph;
                var a = graph.Const(2);
                var b = graph.Const(3);
                Console.WriteLine("a=2,b=3");

                var addResult = session.GetRunner().Run(graph.Add(a, b)).GetValue();
                Console.WriteLine("a+b={0}", addResult);

                var multiplyResult = session.GetRunner().Run(graph.Mul(a, b)).GetValue();
                Console.WriteLine("a*b={0}", multiplyResult);
            }
        }
    }
}
