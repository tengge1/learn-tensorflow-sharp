using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace LearnTensorflowSharp
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
                var result = session.GetRunner().Run(graph.Add(a, b)).GetValue();
                Console.WriteLine(result);
            }
        }
    }
}
