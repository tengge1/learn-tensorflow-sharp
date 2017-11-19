using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;
using Learn.Mnist;

namespace p07_MNIST
{
    class Program
    {
        static void Main(string[] args)
        {
            var mnist = Mnist.Load();

            var trainCount = 5000;
            var testCount = 200;

            float[,] trainingImages, trainingLabels, testImages, testLabels;
            mnist.GetTrainReader().NextBatch(trainCount, out trainingImages, out trainingLabels);
            mnist.GetTestReader().NextBatch(testCount, out testImages, out testLabels);

            var g = new TFGraph();

            var trainingInput = g.Placeholder(TFDataType.Float, new TFShape(-1, 784));
            var xte = g.Placeholder(TFDataType.Float, new TFShape(784));

            var distance = g.ReduceSum(g.Abs(g.Add(trainingInput, g.Neg(xte))), axis: g.Const(1));

            var pred = g.ArgMin(distance, g.Const(0));

            var sess = new TFSession(g);

            float accuracy = 0.0f;

            for (int i = 0; i < testCount; i++)
            {
                var runner = sess.GetRunner();

                var result = runner.
                    Fetch(pred).
                    Fetch(distance).
                    AddInput(trainingInput, trainingImages).
                    AddInput(xte, Extract(testImages, i)).Run();
                var r = result[0].GetValue();
                var tr = result[1].GetValue();
                var nn_index = (int)(long)result[0].GetValue();

                Console.WriteLine($"Test {i}: Prediction: { ArgMax(trainingLabels, nn_index) } True class: { ArgMax(testLabels, i)} (nn_index= { nn_index })");
                if (ArgMax(trainingLabels, nn_index) == ArgMax(testLabels, i))
                    accuracy += 1f / testImages.Length;
            }

            Console.WriteLine("Accuracy: " + accuracy);
        }

        static int ArgMax(float[,] array, int idx)
        {
            float max = -1;
            int maxIdx = -1;
            var l = array.GetLength(1);
            for (int i = 0; i < l; i++)
                if (array[idx, i] > max)
                {
                    maxIdx = i;
                    max = array[idx, i];
                }
            return maxIdx;
        }

        static public float[] Extract(float[,] array, int index)
        {
            var n = array.GetLength(1);
            var ret = new float[n];

            for (int i = 0; i < n; i++)
                ret[i] = array[index, i];
            return ret;
        }
    }
}
