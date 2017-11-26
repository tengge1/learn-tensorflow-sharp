using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p10_CalculateGradient
{
    /// <summary>
    /// 10 计算倾斜度（偏导数）
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 创建图
            var g = new TFGraph();

            // 创建一些变量
            var x = g.Const(3.0); // x=3

            var y1 = g.Square(x); // x^2=9
            var y2 = g.Square(y1); // x^4=81
            var y3 = g.Square(y2); // x^8=6561

            // 计算倾斜度d(y1+y3)=d(x^2 + x^8)=2*x+8*x^7=17502
            var a = g.AddGradients(new[] { y1, y3 }, new[] { x });

            // 创建会话
            var sess = new TFSession(g);

            // 计算结果
            var result = sess.Run(new TFOutput[] { }, new TFTensor[] { }, a);

            // 输出计算结果
            Console.WriteLine((double)result[0].GetValue()); // 17502
        }
    }
}
