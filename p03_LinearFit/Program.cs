using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p03_LinearFit
{
    class Program
    {
        static void Main(string[] args)
        {
            var shape = new TFShape();

            var graph = new TFGraph();
            var xs = graph.Placeholder(TFDataType.Float, shape, "xs");
            var ys = graph.Placeholder(TFDataType.Float, shape, "ys");

            var w1 = graph.Variable(graph.RandomNormal(shape));
            var b1 = graph.Variable(graph.ZerosLike(w1));
            var wx_plus_b1 = graph.Add(graph.MatMul(xs, w1), b1);
            var output1 = graph.Relu(wx_plus_b1);

            var w2 = graph.Variable(graph.RandomNormal(shape));
            var b2 = graph.Variable(graph.ZerosLike(w2));
            var wx_plus_b2 = graph.Add(graph.MatMul(output1, w2), b2);
            var output2 = wx_plus_b2;

            var loss = graph.ReduceMean(graph.ReduceSum(graph.Square(graph.Sub(ys, output2))));

            var session = new TFSession(graph);
            for (var i = 0; i < 100; i++)
            {
                session.GetRunner().Run(loss);
            }
            session.CloseSession();
        }
    }
}
