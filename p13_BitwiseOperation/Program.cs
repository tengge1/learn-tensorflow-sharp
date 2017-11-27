using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p13_BitwiseOperation
{
    /// <summary>
    /// 13 位运算
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 创建图
            var g = new TFGraph();

            // 创建变量
            var a = g.Const(Convert.ToInt32("110110", 2));
            var b = g.Const(Convert.ToInt32("101100", 2));

            // 进行位运算
            var bitwiseAnd = g.BitwiseAnd(a, b);
            var bitwiseOr = g.BitwiseOr(a, b);
            var bitwistXor = g.BitwiseXor(a, b);

            // 创建会话
            var sess = new TFSession(g);

            // 进行计算
            var result = sess.GetRunner().Fetch(bitwiseAnd, bitwiseOr, bitwistXor).Run();

            // 输出计算结果
            Console.WriteLine("BitwiseAnd: {0}", Convert.ToString((int)result[0].GetValue(), 2));
            Console.WriteLine("BitwiseOr: {0}", Convert.ToString((int)result[1].GetValue(), 2));
            Console.WriteLine("BitwistXor: {0}", Convert.ToString((int)result[2].GetValue(), 2));
        }
    }
}
