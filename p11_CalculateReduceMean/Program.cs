using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p11_CalculateReduceMean
{
    /// <summary>
    /// 11 计算矩阵维度平均值
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 创建图
            var g = new TFGraph();

            // 输入矩阵
            var x = g.Const(new double[,]
            {
                { 1, 2 },
                { 3, 4 }
            });

            // 计算ReduceMean
            var y = g.ReduceMean(x, axis: g.Const(1));

            // 创建会话
            var sess = new TFSession(g);

            // 计算结果
            var result = sess.GetRunner().Run(y);

            // 输出结果
            // axis为 0，第一维求平均值：2,3
            // axis为 1，第二维求平均值：1.5,3.5
            PrintDoubleArray((double[])result.GetValue());
        }

        /// <summary>
        /// 输出数组
        /// </summary>
        /// <param name="array"></param>
        static void PrintDoubleArray(double[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + ",");
            }
            Console.WriteLine();
        }
    }
}
