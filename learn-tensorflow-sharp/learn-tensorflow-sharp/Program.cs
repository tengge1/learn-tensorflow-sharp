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
            using (var sess = new TFSession())
            {
                var graph = sess.Graph;
                var a = graph.Const(3);
                var b = graph.Const(4);

                var result = sess.GetRunner().Run(graph.Add(a, b));
                Console.WriteLine(result.GetValue());
            }
        }
    }
}
