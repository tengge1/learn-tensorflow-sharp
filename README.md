# TensorflowSharp教程

Tensorflow是一个人工智能框架。TensorflowSharp是对Tensorflow C语言版接口的封装，便于.net开发人员在项目中使用Tensorflow。

## 示例

TensorflowSharp的用法还是很简单的

```C#
// 创建图
var g = new TFGraph();

// 定义常量
var a = g.Const(2);
var b = g.Const(3);

// 加法和乘法运算
var add = g.Add(a, b);
var mul = g.Mul(a, b);

// 创建会话
var sess = new TFSession(g);

// 计算加法
var result1 = sess.GetRunner().Run(add).GetValue();
Console.WriteLine("a+b={0}", result1);

// 计算乘法
var result2 = sess.GetRunner().Run(mul).GetValue();
Console.WriteLine("a*b={0}", result2);

// 关闭会话
sess.CloseSession();
```

执行后输出结果

```
a+b=5
a*b=6
```

## 目录

[01 HelloWorld](https://github.com/tengge1/learn-tensorflow-sharp/blob/master/p01_HelloWorld/Program.cs)：TensorflowSharp入门。

[02 UsePlaceholder](https://github.com/tengge1/learn-tensorflow-sharp/blob/master/p02_UsePlaceholder/Program.cs)：占位符的使用。

[03 UseVariable](https://github.com/tengge1/learn-tensorflow-sharp/blob/master/p03_UseVariable/Program.cs)：变量的使用。

[04 InitVariable](https://github.com/tengge1/learn-tensorflow-sharp/blob/master/p04_InitVariable/Program.cs)：变量的初始化。

[05 UseMatrix](https://github.com/tengge1/learn-tensorflow-sharp/blob/master/p05_UseMatrix/Program.cs)：矩阵相加、数乘、矩阵相乘。

[p06_LinearRegression](https://github.com/tengge1/learn-tensorflow-sharp/blob/master/p06_LinearRegression/Program.cs)：线性回归（未实现）。

[p07_MNIST](https://github.com/tengge1/learn-tensorflow-sharp/blob/master/p07_MNIST/Program.cs)：手写数字识别。

## 注意事项

1. 国内目前无法访问Tensorflow官网，但是可以访问谷歌提供的[Tensorflow官网镜像](https://tensorflow.google.cn/)。

2. 国内使用NuGet安装TensorflowSharp很容易失败，可以直接从[Nuget官网](https://www.nuget.org/packages/TensorFlowSharp/)下载，然后改后缀名zip，解压后手工安装。

3. TensorflowSharp项目使用的.net版本**必须**高于4.6.1，本教程使用的版本是4.7.0，可以在属性选项卡中设置。

4. TensorflowSharp项目必须使用64位CPU，需要在属性选项卡生成中，**去掉首选32位的勾选**。

5. 本教程需要在根目录新建`Libs`文件夹，请将第二步解压出来的`TensorFlowSharp.dll`放在该文件夹；另外运行示例还需要把`libtensorflow.dll`复制到每个项目的`bin/Debug`目录。如果提示找不到Tensorflow命名空间，请重新添加引用。

## 网站

* Tensorflow官网：http://www.tensorflow.org

* Google Tensorflow镜像：https://tensorflow.google.cn/

* Tensorflow开源项目：https://github.com/tensorflow/tensorflow

* TensorflowSharp开源项目：https://github.com/migueldeicaza/TensorFlowSharp

* TensorflowSharp NuGet主页：https://www.nuget.org/packages/TensorFlowSharp/

* Tensorflow中文社区：http://www.tensorfly.cn/
