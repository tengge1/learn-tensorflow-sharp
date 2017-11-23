using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p08_UseTensor
{
    /// <summary>
    /// 08 张量的使用
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 整数张量
            var tensor = new TFTensor(1);
            Console.WriteLine("Value:" + tensor.GetValue());

            // 矩阵张量
            tensor = new TFTensor(new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
            });
            Console.WriteLine("TensorType: {0}", tensor.TensorType.ToString());
            Console.WriteLine("NumDims: " + tensor.NumDims);
            Console.WriteLine("Shape", string.Join(",", tensor.Shape));
            for (var i = 0; i < tensor.NumDims; i++)
            {
                var dim = tensor.GetTensorDimension(i);
                Console.WriteLine("DimIndex: {0}, Dim: {1}", i, dim);
            }

            // 创建图
            var g = new TFGraph();

            // 创建字符串张量
            tensor = new TFTensor("Hello, world!".Select(o => (sbyte)o).ToArray());
            var hello = g.Const(tensor);

            // 创建会话
            var sess = new TFSession(g);

            // 进行计算
            var result = sess.GetRunner().Run(hello).GetValue();

            // 输出计算结果
            Console.WriteLine(string.Join("", ((sbyte[])result).Select(o => (char)o)));
        }
    }
}
