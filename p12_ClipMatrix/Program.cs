using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p12_ClipMatrix
{
    /// <summary>
    /// 12 裁剪矩阵（限制矩阵最大最小值）
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 创建图
            var g = new TFGraph();

            // 矩阵
            var matrix = g.Const(new int[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            });

            // 裁剪
            var a = g.ClipByValue(matrix, g.Const(4), g.Const(13));

            // 创建会话
            var sess = new TFSession(g);

            // 计算结果
            var result = sess.GetRunner().Run(a);

            // 输出结果
            Console.WriteLine("{0}", MatrixToString((int[,])result.GetValue()));
        }

        /// <summary>
        /// 矩阵转字符串
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        static string MatrixToString(int[,] matrix)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    sb.Append(matrix.GetValue(i, j));
                    sb.Append(",");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
}
