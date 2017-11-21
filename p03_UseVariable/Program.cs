using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p03_UseVariable
{
    /// <summary>
    /// 03 使用变量
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 创建图
            var g = new TFGraph();

            // 定义操作，用于初始化变量
            TFOperation init;

            // 定义值，用于保存变量的值
            TFOutput value;

            // 定义一个变量，初始值为1.5
            var a = g.Variable(g.Const(1.5), out init, out value);

            // 定义一个常量，表示每次循环变量增加值
            var inc = g.Const(0.5);

            // 定义一个操作，将变量a的值value加上inc，然后赋值给a
            var update = g.AssignVariableOp(a, g.Add(value, inc));

            // 会话
            var sess = new TFSession(g);

            // 变量使用前一定要初始化
            sess.GetRunner().AddTarget(init).Run();

            for (var i = 0; i < 5; i++)
            {
                // 每次执行更新操作，都取出value的值存放到result中
                // Fetch可以一次取出多个值
                var result = sess.GetRunner().Fetch(value).AddTarget(update).Run();

                // 输出每次循环变量的值
                Console.WriteLine("result {0}:{1}", i, result[0].GetValue());
            }
        }
    }
}
