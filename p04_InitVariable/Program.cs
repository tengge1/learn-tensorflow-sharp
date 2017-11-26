using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p04_InitVariable
{
    /// <summary>
    /// 04 变量初始化
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 创建图
            var g = new TFGraph();

            // 创建状态，用于输出操作状态
            TFStatus status = new TFStatus();

            // 定义变量
            var a = g.VariableV2(TFShape.Scalar, TFDataType.Double);
            var initA = g.Assign(a, g.Const(1.0));

            var b = g.VariableV2(new TFShape(99), TFDataType.Int32);
            var initB = g.Assign(b, g.Range(g.Const(1), g.Const(100)));

            // 创建会话
            var sess = new TFSession(g);
            var runner = sess.GetRunner();

            // 初始化变量，并输出操作状态
            runner.AddTarget(initA.Operation, initB.Operation).Run(status);
            Console.WriteLine(status.StatusCode);

            // 并输出计算状态和计算结果
            var result = runner.Fetch(a, b).Run();
            Console.WriteLine(result[0].GetValue());
            Console.WriteLine(string.Join(",", (int[])result[1].GetValue()));
        }
    }
}
