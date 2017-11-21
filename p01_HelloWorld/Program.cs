using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p01_HelloWorld
{
    /// <summary>
    /// 01 HelloWorld
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 创建图
            var g = new TFGraph();

            // 定义常量
            var a = g.Const(2);
            var b = g.Const(3);

            // 加法和乘法运算
            var add = g.Add(a, b);
            var mul = g.Mul(a, b);

            // 创建会话
            var sess = new TFSession(g);

            // 计算加法
            var result1 = sess.GetRunner().Run(add).GetValue();
            Console.WriteLine("a+b={0}", result1);

            // 计算乘法
            var result2 = sess.GetRunner().Run(mul).GetValue();
            Console.WriteLine("a*b={0}", result2);

            // 关闭会话
            sess.CloseSession();
        }
    }
}
