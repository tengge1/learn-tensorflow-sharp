using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p11_ReduceMethod
{
    /// <summary>
    /// 11 Reduce方法的使用
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

            // 创建ReduceMean、ReduceSum变量
            var reduceMean0 = g.ReduceMean(x, axis: g.Const(0));
            var reduceMean1 = g.ReduceMean(x, axis: g.Const(1));

            var reduceSum0 = g.ReduceSum(x, axis: g.Const(0));
            var reduceSum1 = g.ReduceSum(x, axis: g.Const(1));

            // 创建会话
            var sess = new TFSession(g);

            // 计算ReduceMean、ReduceSum
            var reduceMean0Value = sess.GetRunner().Run(reduceMean0);
            var reduceMean1Value = sess.GetRunner().Run(reduceMean1);

            var reduceSum0Value = sess.GetRunner().Run(reduceSum0);
            var reduceSum1Value = sess.GetRunner().Run(reduceSum1);

            // 输出结果：ReduceMean
            // axis=0，第一维求平均值：2,3
            // axis=1，第二维求平均值：1.5,3.5
            Console.WriteLine("ReduceMean(axis=0): {0}", ArrayToString((double[])reduceMean0Value.GetValue()));
            Console.WriteLine("ReduceMean(axis=1): {0}", ArrayToString((double[])reduceMean1Value.GetValue()));

            // 输出结果：ReduceSum
            // axis=0，第一维求和：4,6
            // axis=1，第二维求和：3,7
            Console.WriteLine("ReduceSum(axis=0): {0}", ArrayToString((double[])reduceSum0Value.GetValue()));
            Console.WriteLine("ReduceSum(axis=1): {0}", ArrayToString((double[])reduceSum1Value.GetValue()));
        }

        /// <summary>
        /// 数组转字符串
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
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
