using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p04_UseMatrix
{
    /// <summary>
    /// 04 使用矩阵
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 创建图
            var g = new TFGraph();

            // 创建占位符，占位符将由xValue矩阵填充
            var x = g.Placeholder(TFDataType.Int32);
            var xValue = new int[,]
            {
                { 0, 1 },
                { 2, 3 }
            };

            // 创建常量
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

            // 矩阵乘以常数
            var d = g.Mul(x, a);

            // 两个矩阵相加
            var e = g.Add(d, b);

            // 矩阵乘以矩阵
            var f = g.MatMul(e, c);

            // 创建会话
            var sess = new TFSession(g);

            // 计算矩阵f的值，并把结果保存到result中
            var result = (int[,])sess.GetRunner()
                .AddInput(x, xValue)
                .Fetch(f).Run()[0].GetValue();

            // 输出矩阵f
            for (var i = 0; i < xValue.GetLength(0); i++)
            {
                for (var j = 0; j < xValue.GetLength(1); j++)
                {
                    Console.Write("{0}\t", result[i, j].ToString());
                }
                Console.Write("\r\n");
            }
        }
    }
}
