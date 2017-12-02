using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;

namespace p17_TFCoreTest
{
    /// <summary>
    /// 17 TFCore测试
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 获取Tensorflow版本
            var version = TFCore.Version;
            Console.WriteLine("TensorflowSharp Version: {0}", version);

            // 获取Tensorflow.dll中所有可用操作描述（ProtocolBuffer格式）
            //var opList = Encoding.UTF8.GetString(TFCore.GetAllOpList().ToArray());
            //Console.WriteLine("Op List: {0}", opList);

            // 获取各种数据类型大小
            Console.WriteLine("BFloat16 size: {0}", TFCore.GetDataTypeSize(TFDataType.BFloat16));
            Console.WriteLine("Bool size: {0}", TFCore.GetDataTypeSize(TFDataType.Bool));
            Console.WriteLine("Complex size: {0}", TFCore.GetDataTypeSize(TFDataType.Complex));
            Console.WriteLine("Complex128 size: {0}", TFCore.GetDataTypeSize(TFDataType.Complex128));
            Console.WriteLine("Complex64 size: {0}", TFCore.GetDataTypeSize(TFDataType.Complex64));
            Console.WriteLine("Double size: {0}", TFCore.GetDataTypeSize(TFDataType.Double));
            Console.WriteLine("Float size: {0}", TFCore.GetDataTypeSize(TFDataType.Float));
            Console.WriteLine("Half size: {0}", TFCore.GetDataTypeSize(TFDataType.Half));
            Console.WriteLine("Int16 size: {0}", TFCore.GetDataTypeSize(TFDataType.Int16));
            Console.WriteLine("Int32 size: {0}", TFCore.GetDataTypeSize(TFDataType.Int32));
            Console.WriteLine("Int64 size: {0}", TFCore.GetDataTypeSize(TFDataType.Int64));
            Console.WriteLine("Int8 size: {0}", TFCore.GetDataTypeSize(TFDataType.Int8));
            Console.WriteLine("QInt16 size: {0}", TFCore.GetDataTypeSize(TFDataType.QInt16));
            Console.WriteLine("QInt32 size: {0}", TFCore.GetDataTypeSize(TFDataType.QInt32));
            Console.WriteLine("QInt8 size: {0}", TFCore.GetDataTypeSize(TFDataType.QInt8));
            Console.WriteLine("QUInt16 size: {0}", TFCore.GetDataTypeSize(TFDataType.QUInt16));
            Console.WriteLine("QUInt8 size: {0}", TFCore.GetDataTypeSize(TFDataType.QUInt8));
            Console.WriteLine("Resource size: {0}", TFCore.GetDataTypeSize(TFDataType.Resource));
            Console.WriteLine("String size: {0}", TFCore.GetDataTypeSize(TFDataType.String));
            Console.WriteLine("UInt16 size: {0}", TFCore.GetDataTypeSize(TFDataType.UInt16));
            Console.WriteLine("UInt8 size: {0}", TFCore.GetDataTypeSize(TFDataType.UInt8));
            Console.WriteLine("Unknown size: {0}", TFCore.GetDataTypeSize(TFDataType.Unknown));
        }
    }
}
