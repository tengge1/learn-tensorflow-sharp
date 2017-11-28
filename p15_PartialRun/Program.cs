using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p15_PartialRun
{
    /// <summary>
    /// 15 部分运行
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 创建图
            var g = new TFGraph();

            var xValue = 1.0f;
            var yValue = 2.0f;

            // 创建占位符
            var x = g.Placeholder(TFDataType.Float);
            var y = g.Placeholder(TFDataType.Float);
            var z = g.Placeholder(TFDataType.Float);

            // 创建运算
            var a = g.Add(x, y); // x+y
            var b = g.Mul(a, z); // a*z

            // 创建会话
            var sess = new TFSession(g);

            // 运行设置：a = x + y, b = (x + y) * z
            var setup = sess.PartialRunSetup(
                new[] { x, y, z },
                new[] { a, b },
                new[] { a.Operation, b.Operation });

            // 部分运行
            var result1 = sess.PartialRun(setup,
                new[] { x, y },
                new TFTensor[] { xValue, yValue },
                new TFOutput[] { a },
                new[] { a.Operation }); // a = x + y = 1 + 2 = 3

            // 计算结果
            var aValue = (float)result1[0].GetValue(); // 3
            Console.WriteLine("a = {0}", aValue);

            // 部分运行
            var result2 = sess.PartialRun(setup,
                new[] { z },
                new TFTensor[] { aValue * 17 }, // 3 * 17 = 51
                new[] { b },
                new[] { b.Operation }); // 51 * 3=153

            // 计算结果
            var bValue = (float)result2[0].GetValue();
            Console.WriteLine("b = {0}", bValue);
        }
    }
}
