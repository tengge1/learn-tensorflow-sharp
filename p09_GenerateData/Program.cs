using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p09_GenerateData
{
    /// <summary>
    /// 09 产生数据
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 创建图
            var g = new TFGraph();

            // 创建向量
            var shape = new TFShape(20);

            // 创建1到100的序列
            var range = g.Range(g.Const(1), g.Const(100));

            // 创建平均数是1.0，标准差是0.5，长度是20的满足正态分布的随机数
            var randomNormal = g.RandomNormal(shape, 1.0, 0.5);

            // 创建alpha为0.5的伽马随机分布
            var randomGamma = g.RandomGamma(g.Range(g.Const(1), g.Const(10), operName: "gamma"), g.Const(0.5));

            // 创建会话
            var sess = new TFSession(g);

            // 输出序列
            var result = sess.GetRunner().Run(range);
            Console.WriteLine("Range: " + string.Join(",", (int[])result.GetValue()));

            // 输出正态分布随机数
            result = sess.GetRunner().Run(randomNormal);
            Console.WriteLine("Random Normal: " + string.Join(",", (double[])result.GetValue()));

            // 输出伽马随机分布
            result = sess.GetRunner().Run(randomGamma);
            Console.WriteLine("Random Gamma: " + string.Join(",", (double[])result.GetValue()));

            sess.CloseSession();
        }
    }
}
