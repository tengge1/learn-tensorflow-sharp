using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p04_UseMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var g = new TFGraph();

            var a = g.Placeholder(TFDataType.Int32);
            var b = g.Mul(a, g.Const(2));

            var matrix = new int[,]
            {
                { 0, 1 },
                { 2, 3 }
            };

            var sess = new TFSession(g);
            var result = (int[,])sess.GetRunner().AddInput(a, matrix).Fetch(b).Run()[0].GetValue();

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
