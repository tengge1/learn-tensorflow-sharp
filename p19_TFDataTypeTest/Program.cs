using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p19_TFDataTypeTest
{
    /// <summary>
    /// 19 TFDataType测试
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TFDataType.BFloat16.ToString());
            Console.WriteLine(TFDataType.Bool.ToString());
            Console.WriteLine(TFDataType.Complex.ToString());
            Console.WriteLine(TFDataType.Complex128.ToString());
            Console.WriteLine(TFDataType.Complex64.ToString());
            Console.WriteLine(TFDataType.Double.ToString());
            Console.WriteLine(TFDataType.Float.ToString());
            Console.WriteLine(TFDataType.Half.ToString());
            Console.WriteLine(TFDataType.Int16.ToString());
            Console.WriteLine(TFDataType.Int32.ToString());
            Console.WriteLine(TFDataType.Int64.ToString());
            Console.WriteLine(TFDataType.Int8.ToString());
            Console.WriteLine(TFDataType.QInt16.ToString());
            Console.WriteLine(TFDataType.QInt32.ToString());
            Console.WriteLine(TFDataType.QInt8.ToString());
            Console.WriteLine(TFDataType.QUInt16.ToString());
            Console.WriteLine(TFDataType.QUInt8.ToString());
            Console.WriteLine(TFDataType.Resource.ToString());
            Console.WriteLine(TFDataType.String.ToString());
            Console.WriteLine(TFDataType.UInt16.ToString());
            Console.WriteLine(TFDataType.UInt8.ToString());
            Console.WriteLine(TFDataType.Unknown.ToString());
        }
    }
}
