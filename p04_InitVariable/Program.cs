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

            // 创建操作和值，用于进行变量初始化，输出变量的值
            // 注意：操作和值都无法共用。否则，后面的操作和值会覆盖掉前面的操作和值
            TFOperation aInit, bInit;
            TFOutput aValue, bValue;

            // 创建状态，用于输出操作状态
            TFStatus status = new TFStatus();

            // 定义变量
            var a = g.Variable(g.Const(1.0), out aInit, out aValue);
            var b = g.Variable(g.Range(g.Const(1.0), g.Const(100.0)), out bInit, out bValue);

            // 创建会话
            var sess = new TFSession(g);

            // 初始化变量，并输出操作状态
            sess.GetRunner().AddTarget(aInit, bInit).Run(status);
            Console.WriteLine(status.StatusCode);

            // 并输出计算状态和计算结果
            var result = sess.GetRunner().Fetch(aValue, bValue).Run(status);
            Console.WriteLine(status.StatusCode);
            Console.WriteLine(result[0].GetValue());
            Console.WriteLine(result[1].GetValue());
        }
    }
}
