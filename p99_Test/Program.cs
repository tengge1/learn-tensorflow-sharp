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

            var hello = g.Const(TFTensor.CreateString(Encoding.UTF8.GetBytes("Hello,world!")));

            var sess = new TFSession(g);

            var result = sess.GetRunner().Run(hello);

            Console.WriteLine(result.GetValue());
        }
    }
}
