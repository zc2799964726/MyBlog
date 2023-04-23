## 第一部分：基础知识

选择 Debug, Release, MinSizeRel 或 RelWithDebInfo，并进行指定:cmake —build <dir> —config <cfg>

当需要查看内部情况时，可以让 CMake 的信息更加详细:cmake —build <dir> —verbosecmake —build <dir> -v

同样的效果可以通过设置 CMAKE_VERBOSE_MAKEFILE 缓存变量来实现

### 安装模式的语法cmake —install <dir> [<options>]与其他操作模式一样，CMake 需要一个到生成构建树的路径:cmake —install <dir>

多配置生成器的选项就像在构建阶段一样，可以指定希望安装使用哪种构建类型 (有关更多细节，请参阅构建项目部分)。可用的类型包括 Debug、Release、MinSizeRel 和 RelWithDebInfo:cmake —install <dir> —config <cfg>

组件的选项

安装单个组件时，可以使用以下方式:cmake —install <dir> —component <comp>

安装目录的选项可以在项目配置中指定的安装路径前面，加上已经选择的前缀 (当我们对某些目录有限制的写访问权限时)。以“homeuser”为前缀的“usrlocal”路径变成“homeuserusrlocal”: cmake —install <dir> —prefix <prefix>

CMake 可以像这样运行脚本:# 脚本模式的语法cmake [{-D <var>=<value>}…] -P <cmake-script-file> [— <unparsed-options>…]

有两种方法可以将值传递给这个脚本

• 通过使用-D 选项定义的变量。• 通过可在—后传递的参数。CMake 将为传递给脚本的所有参数 (包括—) 创建CMake_ARGV<n>变量。

运行命令行工具

CMake 提供了一种模式，可以跨平台以相同的方式执行一些常见的方法:

### 命令行工具模式的语法cmake -E < command> [<options>]

由于这种特定模式的使用是相当有限的，不会对其深入讨论。若对细节感兴趣，建议使用 cmake-E 列出所有可用的命令。为了简单地了解一下所提供的功能，CMake 3.20 支持以下命令:

1.4.2 CTest

为了产生和维护高质量的代码，自动化测试非常重要。这就是为什么花了一整个章节来讨论这个主题 (请参考第 8 章)

