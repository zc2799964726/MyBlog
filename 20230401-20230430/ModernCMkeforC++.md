## 第一部分：基础知识

选择 Debug, Release, MinSizeRel 或 RelWithDebInfo，并进行指定:cmake —build <dir> —config <cfg>

当需要查看内部情况时，可以让 CMake 的信息更加详细:cmake —build <dir> —verbosecmake —build <dir> -v

同样的效果可以通过设置 CMAKE_VERBOSE_MAKEFILE 缓存变量来实现

# 安装模式的语法cmake —install <dir> [<options>]与其他操作模式一样，CMake 需要一个到生成构建树的路径:cmake —install <dir>

多配置生成器的选项就像在构建阶段一样，可以指定希望安装使用哪种构建类型 (有关更多细节，请参阅构建项目部分)。可用的类型包括 Debug、Release、MinSizeRel 和 RelWithDebInfo:cmake —install <dir> —config <cfg>

组件的选项

安装单个组件时，可以使用以下方式:cmake —install <dir> —component <comp>

安装目录的选项可以在项目配置中指定的安装路径前面，加上已经选择的前缀 (当我们对某些目录有限制的写访问权限时)。以“homeuser”为前缀的“usrlocal”路径变成“homeuserusrlocal”: cmake —install <dir> —prefix <prefix>

CMake 可以像这样运行脚本:# 脚本模式的语法cmake [{-D <var>=<value>}…] -P <cmake-script-file> [— <unparsed-options>…]

有两种方法可以将值传递给这个脚本

• 通过使用-D 选项定义的变量。• 通过可在—后传递的参数。CMake 将为传递给脚本的所有参数 (包括—) 创建CMake_ARGV<n>变量。

运行命令行工具

CMake 提供了一种模式，可以跨平台以相同的方式执行一些常见的方法:

# 命令行工具模式的语法cmake -E < command> [<options>]

由于这种特定模式的使用是相当有限的，不会对其深入讨论。若对细节感兴趣，建议使用 cmake-E 列出所有可用的命令。为了简单地了解一下所提供的功能，CMake 3.20 支持以下命令:

1.4.2 CTest

为了产生和维护高质量的代码，自动化测试非常重要。这就是为什么花了一整个章节来讨论这个主题 (请参考第 8 章)

#### 1.5.6 包配置文件

描述包的 CMake 文件命名为 <PackageName>-config.cmake 和<PackageName>Config.cmake

1.5.7 cmake_install.cmake，CTestTestfile.cmake 和 CPackConfig.cmake 这些文件是由生成阶段的 cmake 可执行文件在构建树中生成的，不应该通过手动编辑。

1.5.8 CMakePresets.json 和 CMakeUserPresets.json

当需要明确缓存变量、所选择的生成器、构建树的路径等时，项目的配置可能会成为一项相对繁忙的任务——特别是当有多种构建项目的方法时。这就处于预设的用武之地了。

用户可以通过 GUI 选择预置，也可以使用命令行—listpresets，并使用—preset= 选项为构建系统选择预置。

CMakePresets.json: 项目作者提供的预设

 CMakeUserPresets.json: 根据自己的偏好定制项目配置用户准备的 (可以将其添加到 VCS 的忽略文件中)

1.5.9 设置 Git 忽略文件

1.6. 脚本和模块

1.6.1 脚本

由 于 在 脚 本 中 没 有 源 代 码/构 建 树 的 概 念， 通 常 持 有 这 些 路 径 引用 的 变 量 将 包 含 当 前工作目录:CMAKE_BINARY_DIR, CMAKE_SOURCE_DIR,CMAKE_CURRENT_BINARY_DIR 和CMAKE_CURRENT_SOURCE_DIR。

1.6.2 实用工具模块

CMake 项目可以使用外部模块来增强它们的功能。模块是用 CMake 语言编写的，包含宏定义、变量和执行各种功能的命令。范围从相当复杂的脚本 (CPack 和 CTest 也提供模块!) 到相当简单的脚本，如 AddFileDependencies 或 TestBigEndian。

CMake 发行版包含了近 90 个不同的实用程序模块，还可以通过浏览列表从网上下载更多，比如在https://github.com/onqtam/awesome-cmake上找到的列表，或者自己编写一个模块。

要使用实用程序模块，需要使用 include(<MODULE>) 指令。下面是一个简单的项目:

我们将了解哪些模块是可用的，因为其与当前的主题相关。若对其他模块感兴趣，可以在https://cmake.org/cmake/help/latest/manual/cmake-modules.7.html找到一个完整的绑定模块列表。

