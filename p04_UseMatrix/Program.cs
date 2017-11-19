using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p04_UseMatrix
{
    /// <summary>
    /// 04 UseMatrix
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var g = new TFGraph();

            var x = g.Placeholder(TFDataType.Int32);

            var a = g.Const(2);
            var b = g.Const(new int[,]
            {
                { 1, 1 },
                { 1, 1 }
            });
            var c = g.Const(new int[,]
            {
                { 1, 0 },
                { 0, 1 }
            });

            var d = g.Mul(x, a);
            var e = g.Add(d, b);
            var f = g.MatMul(e, c);

            var matrix = new int[,]
            {
                { 0, 1 },
                { 2, 3 }
            };

            var session = new TFSession(g);
            var result = (int[,])session.GetRunner().AddInput(x, matrix).Fetch(f).Run()[0].GetValue();

            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0}\t", result[i, j].ToString());
                }
                Console.Write("\r\n");
            }
        }
    }
}
