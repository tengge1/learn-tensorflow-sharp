using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p02_UsePlaceholder
{
    /// <summary>
    /// 02 UsePlaceholder
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new TFGraph();

            var a = graph.Placeholder(TFDataType.Float, operName: "a");
            var b = graph.Placeholder(TFDataType.Float, operName: "b");
            var c = graph.Placeholder(TFDataType.Float, operName: "c");

            var d = graph.Add(a, b);
            var e = graph.Mul(d, c);
            var f = graph.Pow(e, graph.Const(2.0f));
            var g = graph.Div(f, a);
            var h = graph.Sqrt(g);

            var session = new TFSession(graph);

            // sqrt(((1+2)*3)^2/a) = 9
            var result = session.GetRunner()
                .AddInput("a", 1.0f)
                .AddInput("b", 2.0f)
                .AddInput("c", 3.0f)
                .Run(h).GetValue();

            Console.WriteLine("h={0}", result);

            session.CloseSession();
        }
    }
}
