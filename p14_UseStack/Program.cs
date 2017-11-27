using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p14_UseStack
{
    /// <summary>
    /// 14 使用堆栈
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 创建图
            var g = new TFGraph();

            // 创建两个堆栈
            var a = g.Const(new int[,]
            {
                { 1, 2 },
                { 3, 4 }
            });
            var b = g.Const(new int[,]
            {
                { 5, 6 },
                { 7, 8 }
            });

            // 进行计算
            var stack0 = g.Stack(new[] { a, b }, axis: 0, operName: "stack0");
            var stack1 = g.Stack(new[] { a, b }, axis: 1, operName: "stack1");

            // 创建会话
            var sess = new TFSession(g);

            // 计算结果
            var stack0Value = sess.GetRunner().Run(stack0);
            var stack1Value = sess.GetRunner().Run(stack1);

            // 输出结果
            // axis=0: [a, b],
            // axis=1: [[a0, b0], [a1, b1]]
            PrintMatrix("Stack(axis=0)", (int[,,])stack0Value.GetValue());
            PrintMatrix("Stack(axis=1)", (int[,,])stack1Value.GetValue());
        }

        /// <summary>
        /// 输出矩阵
        /// </summary>
        /// <param name="name"></param>
        /// <param name="matrix"></param>
        static void PrintMatrix(string name, int[,,] matrix)
        {
            Console.WriteLine("{0}: [{1}, {2}, {3}]", name, matrix.GetLength(0), matrix.GetLength(1), matrix.GetLength(2));
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    for (var k = 0; k < matrix.GetLength(2); k++)
                    {
                        Console.Write("{0},", matrix.GetValue(i, j, k));
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
