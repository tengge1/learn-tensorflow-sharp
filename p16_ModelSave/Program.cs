using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p16_ModelSave
{
    /// <summary>
    /// 16 模型保存和读取
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 创建图
            var g = new TFGraph();

            // 创建变量
            var a = g.VariableV2(TFShape.Scalar, TFDataType.Int32);

            // 变量赋值
            var initA = g.Assign(a, g.Const(0));
            var update = g.AssignAdd(a, g.Const(1));

            // 创建会话
            var sess = new TFSession(g);

            // 变量初始化
            sess.GetRunner().AddTarget(initA.Operation).Run();

            for (var i = 0; i < 10; i++)
            {
                // 更新值
                var result = sess.GetRunner().AddTarget(update.Operation).Fetch(a).Run();

                // 输出结果
                Console.WriteLine("a: {0}", result[0].GetValue());
            }
        }
    }
}
