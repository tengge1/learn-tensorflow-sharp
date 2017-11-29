using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p03_LinearFit
{
    /// <summary>
    /// 06 线性回归（没实现）
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 所需数据
            var xData = new double[] {
                3.3, 4.4, 5.5, 6.71, 6.93, 4.168, 9.779, 6.182, 7.59, 2.167,
                7.042, 10.791, 5.313, 7.997, 5.654, 9.27, 3.1
            };
            var yData = new double[] {
                1.7,2.76,2.09,3.19,1.694,1.573,3.366,2.596,2.53,1.221,
                 2.827,3.465,1.65,2.904,2.42,2.94,1.3
            };
            var learning_rate = 0.001;

            // 创建图
            var g = new TFGraph();

            // 创建占位符
            var x = g.Placeholder(TFDataType.Double);
            var y = g.Placeholder(TFDataType.Double);

            // 权重和偏置
            var W = g.VariableV2(TFShape.Scalar, TFDataType.Double, operName: "weight");
            var b = g.VariableV2(TFShape.Scalar, TFDataType.Double, operName: "bias");

            var initW = g.Assign(W, g.Const(100.0));
            var initb = g.Assign(b, g.Const(0.01));

            var output = g.Add(g.Mul(x, W), b);

            // 损失
            var loss = g.ReduceSum(g.Abs(g.Sub(output, y)));
            var grad = g.AddGradients(new TFOutput[] { loss }, new TFOutput[] { W, b });
            var optimize = new[]
            {
                g.AssignSub(W, g.Mul(grad[0], g.Const(learning_rate))).Operation,
                g.AssignSub(b, g.Mul(grad[1], g.Const(learning_rate))).Operation
            };

            // 创建会话
            var sess = new TFSession(g);
            var runner = sess.GetRunner();
            runner.AddInput(x, xData).AddInput(y, yData);

            // 变量初始化
            runner.AddTarget(initW.Operation, initb.Operation).Run();

            // 进行训练拟合
            for (var i = 0; i < 10; i++)
            {
                var result = runner.AddTarget(optimize).Fetch(loss, W, b).Run();

                Console.WriteLine("loss: {0} W:{1} b:{2}", result[0].GetValue(), result[1].GetValue(), result[2].GetValue());
            }
        }
    }
}
