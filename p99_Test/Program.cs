using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p99_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var tensor = new TFTensor(1);
            Console.WriteLine(tensor.GetValue());
        }
    }
}
