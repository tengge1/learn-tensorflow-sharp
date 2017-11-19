# TensorflowSharp教程

TensorFlow™ 是一个使用数据流图进行数值计算的开源软件库。图中的节点代表数学运算， 而图中的边则代表在这些节点之间传递的多维数组（张量）。这种灵活的架构可让您使用一个 API 将计算工作部署到桌面设备、服务器或者移动设备中的一个或多个 CPU 或 GPU。 TensorFlow 最初是由 Google 机器智能研究部门的 Google Brain 团队中的研究人员和工程师开发的，用于进行机器学习和深度神经网络研究， 但它是一个非常基础的系统，因此也可以应用于众多其他领域。

TensorflowSharp是对Tensorflow C语言版接口的封装，便于.net开发人员在项目中使用Tensorflow。

## 目录

[01 HelloWorld](https://github.com/tengge1/learn-tensorflow-sharp/blob/master/p01_HelloWorld/Program.cs)：进行加法和乘法运算，了解TensorflowSharp的基本用法。

[02 UsePlaceholder](https://github.com/tengge1/learn-tensorflow-sharp/blob/master/p02_UsePlaceholder/Program.cs)：使用占位符进行复杂数学运算。

[03 UseVariable](https://github.com/tengge1/learn-tensorflow-sharp/blob/master/p03_UseVariable/Program.cs)：使用变量多次运算。

[p04 UseMatrix](https://github.com/tengge1/learn-tensorflow-sharp/blob/master/p04_UseMatrix/Program.cs)：矩阵与常数相乘。

[p05_MatrixMath](https://github.com/tengge1/learn-tensorflow-sharp/blob/master/p05_MatrixMath/Program.cs)：矩阵与矩阵相乘。

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
