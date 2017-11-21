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
            // 创建图
            var g = new TFGraph();

            // 创建占位符，以便在运行时赋值
            var x = g.Placeholder(TFDataType.Float); // 1
            var y = g.Placeholder(TFDataType.Float); // 2
            var z = g.Placeholder(TFDataType.Float); // 3

            // 进行各种数学运算
            var a = g.Add(x, y);
            var b = g.Mul(a, z);
            var c = g.Pow(b, g.Const(2.0f)); // 注意：一定要保证数据类型相同，否则报错
            var d = g.Div(c, x);
            var e = g.Sqrt(d);

            // 定义会话
            var sess = new TFSession(g);

            // 给占位符赋值并运行图
            var result = sess.GetRunner()
                .AddInput(x, 1.0f) // 注意：一定要保证数据类型相同，否则报错
                .AddInput(y, 2.0f)
                .AddInput(z, 3.0f)
                .Run(e).GetValue();

            // 输出结果
            // sqrt(((1+2)*3)^2/1) = 9
            Console.WriteLine("e={0}", result);
        }
    }
}
