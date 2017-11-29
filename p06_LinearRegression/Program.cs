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
            // 创建所需数据
            var xList = new List<double>();
            var yList = new List<double>();
            var ran = new Random();
            for (var i = 0; i < 10; i++)
            {
                var num = ran.NextDouble();
                var noise = ran.NextDouble();
                xList.Add(num);
                yList.Add(num * 3 + 4 + noise); // y = 3 * x + 4
            }
            var xData = xList.ToArray();
            var yData = yList.ToArray();
            var learning_rate = 0.01;

            // 创建图
            var g = new TFGraph();

            // 创建占位符
            var x = g.Placeholder(TFDataType.Double, new TFShape(xData.Length));
            var y = g.Placeholder(TFDataType.Double, new TFShape(yData.Length));

            // 权重和偏置
            var W = g.VariableV2(TFShape.Scalar, TFDataType.Double, operName: "weight");
            var b = g.VariableV2(TFShape.Scalar, TFDataType.Double, operName: "bias");

            var initW = g.Assign(W, g.Const(ran.NextDouble()));
            var initb = g.Assign(b, g.Const(ran.NextDouble()));

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

            // 变量初始化
            sess.GetRunner().AddTarget(initW.Operation, initb.Operation).Run();

            // 进行训练拟合
            for (var i = 0; i < 1000; i++)
            {
                var result = sess.GetRunner()
                    .AddInput(x, xData)
                    .AddInput(y, yData)
                    .AddTarget(optimize)
                    .Fetch(loss, W, b).Run();

                Console.WriteLine("loss: {0} W:{1} b:{2}", result[0].GetValue(), result[1].GetValue(), result[2].GetValue());
            }
        }
    }
}
