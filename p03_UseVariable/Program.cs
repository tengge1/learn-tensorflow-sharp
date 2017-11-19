using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p03_UseVariable
{
    /// <summary>
    /// 03 UseVariable
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            TFOperation init;
            TFOutput value;

            var g = new TFGraph();

            var a = g.Variable(g.Const(1.5), out init, out value);
            var inc = g.Const(0.5);

            // value+inc=>a
            var update = g.AssignVariableOp(a, g.Add(value, inc));

            var session = new TFSession(g);

            session.GetRunner().AddTarget(init).Run();

            for (var i = 0; i < 5; i++)
            {
                var result = session.GetRunner().Fetch(value).AddTarget(update).Run();

                Console.WriteLine("result {0}:{1}", i, result[0].GetValue());
            }
        }
    }
}
