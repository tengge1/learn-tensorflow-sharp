using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p18_TFBufferTest
{
    /// <summary>
    /// 18 TFBuffer测试
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var hello = Encoding.UTF8.GetBytes("Hello, world!");

            var buffer = new TFBuffer(hello);

            var bytes = buffer.ToArray();

            Console.WriteLine(Encoding.UTF8.GetString(bytes));
        }
    }
}
