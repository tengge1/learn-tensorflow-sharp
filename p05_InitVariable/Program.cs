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
            TFOperation init;
            TFOutput value;

            var g = new TFGraph();

            var a = g.Variable(g.Const(1), out init, out value);

            var sess = new TFSession(g);

            sess.GetRunner().AddTarget(init).Run();

            var result = sess.GetRunner().Run(value);

            Console.WriteLine(result);
        }
    }
}
