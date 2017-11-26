using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
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
            var range = g.Range(g.Const(1), g.Const(10));

            // 创建平均数是1.0，标准差是0.5，长度是20的满足正态分布的随机数
            var randomNormal = g.RandomNormal(shape, 1.0, 0.5);

            // 返回随机位置
            var randomPosition = g.RandomPoisson(g.Range(g.Const(10), g.Const(10), operName: "pos"), g.Const(0.5));

            // 创建会话
            var sess = new TFSession(g);

            // 输出结果
            var result = sess.GetRunner().Fetch(range, randomNormal, randomPosition).Run();
            Console.WriteLine("Range: " + ArrayToString((int[])result[0].GetValue()));
            Console.WriteLine("Random Normal: " + ArrayToString((double[])(result[1].GetValue())));
            Console.WriteLine("Random Position: " + result[2].GetValue());
        }

        static string ArrayToString(Array array)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < array.Length; i++)
            {
                sb.Append(array.GetValue(i));
                sb.Append(",");
            }
            return sb.ToString();
        }
    }
}
