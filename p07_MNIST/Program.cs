using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;
using Learn.Mnist;

namespace p07_MNIST
{
    /// <summary>
    /// 07 手写数字识别
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 加载手写数字资源
            var mnist = Mnist.Load();

            // 训练次数和测试次数
            var trainCount = 5000;
            var testCount = 200;

            // 获取训练图片、训练图片标签、测试图片、测试图片标签
            float[,] trainingImages, trainingLabels, testImages, testLabels;
            mnist.GetTrainReader().NextBatch(trainCount, out trainingImages, out trainingLabels);
            mnist.GetTestReader().NextBatch(testCount, out testImages, out testLabels);

            // 创建图
            var g = new TFGraph();

            // 训练图片占位符和训练标签占位符
            var trainingInput = g.Placeholder(TFDataType.Float, new TFShape(-1, 784)); // 不定数量的像素为24*24的图片
            var xte = g.Placeholder(TFDataType.Float, new TFShape(784));

            // 创建计算误差和预测的图
            var distance = g.ReduceSum(g.Abs(g.Add(trainingInput, g.Neg(xte))), axis: g.Const(1));
            var pred = g.ArgMin(distance, g.Const(0));

            // 创建会话
            var sess = new TFSession(g);

            // 精度
            var accuracy = 0.0f;

            // 进行迭代训练，并且每次都输出预测值
            for (int i = 0; i < testCount; i++)
            {
                var runner = sess.GetRunner();

                // 计算并且获取误差和预测值
                var result = runner.
                    Fetch(pred).
                    Fetch(distance).
                    AddInput(trainingInput, trainingImages).
                    AddInput(xte, Extract(testImages, i)).Run();
                var r = result[0].GetValue();
                var tr = result[1].GetValue();

                var nn_index = (int)(long)result[0].GetValue();

                Console.WriteLine($"训练次数 {i}： 预测： { ArgMax(trainingLabels, nn_index) } 真实值： { ArgMax(testLabels, i)} (nn_index= { nn_index })");
                if (ArgMax(trainingLabels, nn_index) == ArgMax(testLabels, i))
                    accuracy += 1f / testImages.Length;
            }

            // 精确度
            Console.WriteLine("精度：" + accuracy);
        }

        /// <summary>
        /// 获取矩阵array中idx行的最大值
        /// </summary>
        /// <param name="array"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        static int ArgMax(float[,] array, int idx)
        {
            float max = -1;
            int maxIdx = -1;
            var len = array.GetLength(1);
            for (int i = 0; i < len; i++)
                if (array[idx, i] > max)
                {
                    maxIdx = i;
                    max = array[idx, i];
                }
            return maxIdx;
        }

        /// <summary>
        /// 获取矩阵array中的index行（即获取n*n图片数组中的第n张）
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <returns></returns>
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
