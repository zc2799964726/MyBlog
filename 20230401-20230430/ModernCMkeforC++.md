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

1.4.3 CPack

构建并测试了软件之后，我们就可以与世界进行分享。高级用户完全可以接受源代码，这就是他们想要的。然而，由于方便和节省时间，世界上绝大多数人都在使用预编译的二进制文件

1.4.4 CMake 用户界面

1.4.5 CCMake

ccmake 可执行文件是 CMake 面向类 Unix 平台的接口 (它不适用于 Windows)。它不是 CMake包的一部分，所以用户必须单独安装

1.5. 项目文件

即使文件包含 CMake 语言命令，也不能确定它是为开发人员编辑而设计的

1.5.1 源码树

1.5.2 构建树

1.5.3 文件列表

1.5.4 CMakeLists.txt

1.5.5 CMakeCache.txt

当配置阶段第一次运行时，缓存变量将从列表文件中生成并存储在 CMakeCache.txt 中。该文件
位于构建树的根目录中:

#### 1.5.6 包配置文件

从注释中观察到的，EXTERNAL 部分中的缓存项是供用户修改的，而 INTERNAL 部分是由CMake 管理的

1.5.6 包配置文件

描述包的 CMake 文件命名为 <PackageName>-config.cmake 和<PackageName>Config.cmake

1.5.7 cmake_install.cmake，CTestTestfile.cmake 和 CPackConfig.cmake 这些文件是由生成阶段的 cmake 可执行文件在构建树中生成的，不应该通过手动编辑。

1.5.8 CMakePresets.json 和 CMakeUserPresets.json

当需要明确缓存变量、所选择的生成器、构建树的路径等时，项目的配置可能会成为一项相对繁忙的任务——特别是当有多种构建项目的方法时。这就处于预设的用武之地了。用户可以通过 GUI 选择预置，也可以使用命令行—listpresets，并使用—preset= 选项为构建系统选择预置。

CMakePresets.json: 项目作者提供的预设
CMakeUserPresets.json: 根据自己的偏好定制项目配置用户准备的 (可以将其添加到 VCS 的忽略文件中)

1.5.9 设置 Git 忽略文件

1.6. 脚本和模块

1.6.1 脚本

由于在脚本中没有源代码/构建树的概念，通常持有这些路径引用的变量将包含当 前工作目录:CMAKE_BINARY_DIR, CMAKE_SOURCE_DIR,CMAKE_CURRENT_BINARY_DIR 和CMAKE_CURRENT_SOURCE_DIR。

1.6.2 实用工具模块

CMake 项目可以使用外部模块来增强它们的功能。模块是用 CMake 语言编写的，包含宏定义、变量和执行各种功能的命令。范围从相当复杂的脚本 (CPack 和 CTest 也提供模块!) 到相当简单的脚本，如 AddFileDependencies或 TestBigEndian。

CMake 发行版包含了近 90 个不同的实用程序模块，还可以通过浏览列表从网上下载更多，比如在https://github.com/onqtam/awesome-cmake上找到的列表，或者自己编写一个模块。
要使用实用程序模块，需要使用 include(<MODULE>) 指令。下面是一个简单的项目:
我们将了解哪些模块是可用的，因为其与当前的主题相关。若对其他模块感兴趣，可以在https://cmake.org/cmake/help/latest/manual/cmake-modules.7.html找到一个完整的绑定模块列表。

1.6.3 查找模块

CMake 提供了 150 多个模块，这些模块能够定位系统中不同的包，另一种选择是编写自己的模块

2.2.1 注释

2.2.2 执行指令

指令名不区分大小写，但在 CMake 社区中有一个约定，即在指令名中使用 snake_case(即小写单词与下划线连接)。
可以定义自己的指令，会在“控制结构” 一节中介绍这些指令

为了使事情更简单，将在介绍不同示例时介绍相关指令，可以分为三类:
• 脚本指令: 脚本指令可用，会改变指令处理器、访问变量的状态，并影响其他指令和环境。
• 项目指令: 这些指令在项目中可用，操纵项目状态并构建目标
• CTest 指令: 这些指令在 CTest 脚本中可用，管理测试。

2.2.3 指令参数

2.3. 变量

变量名区分大小写，可以包含任何字符。
变量都在内部作为字符串存储，有些智力可以解释为其他数据类型的值 (甚至是列表!)
基本的变量操作指令是 set() 和 unset()，但还有其他指令可以影响变量，如 string() 和 list()

2.3.1 引用变量

引用，需要使用 ${} 语法:message(${MyString1})。这样的插值是由内而外的方式执行的:

${} 用于引用普通变量或缓存变量
$ENV{} 用于引用环境变量

可以通过命令行在—标记之后将参数传递给脚本。值将存储在 CMAKE_ARGV<n> 变量中，传递的参数的计数将存储在 CMAKE_ARGC 变量中。

2.3.2 环境变量

2.3.3 缓存变量

2.3.4 如何正确使用变量作用域

CMake 有两个作用域:
函数作用域: 用于执行用 function() 定义的自定义函数
目录作用域: 当从 add_subdirectory() 指令执行嵌套目录中的 CMakeLists.txt 文件时

首先，需要知道变量作用域的概念如何实现。当创建嵌套作用域时，CMake 只需用来自当前作用域的所有变量的副本填充。后续命令将影响这些副本。但若完成了嵌套作用域的执行，所有的副本都会删除，而原始的父作用域将恢复。
若真的需要更改调用 (父) 作用域中的变量，该怎么办呢
CMake 有一个 PARENT_SCOPE 标志，可以在 set() 和 unset() 指令的末尾添加:set(MyVariable “New Value” PARENT_SCOPE)unset(MyVariable PARENT_SCOPE)
这种解决方法有一定的局限性，因为其不允许访问超过一个级别的变量
使用 PARENT_SCOPE 不会改变当前作用域中的变量

2.4. 列表

要存储列表，CMake 会将所有元素连接成一个字符串，使用分号 (;) 分隔:a;list;of;5;elements

要创建一个列表，可以使用 set() 指令:set(myList 一个包含五个元素的列表)。由于列表的存储方式不同，下面的命令将具有完全相同的效果:

CMake 会自动解包未加引号的参数中的列表。通过传递一个不加引号的 myList 引用，可以有效地向指令传递更多的参数:

message(“the list is:” ${myList})

2.5. 控制结构

2.5.1 条件块

2.5.2 条件指令的语法

只有当字符串等于以下任何一个常量时 (这些比较不区分大小写)，才认为是布尔值 true:
• ON, Y, YES 或 TRUE
• 一个非零的数

这里还有另一个问题——若条件的参数没有加引号，且变量的名称包含一个值
set(FOO BAR)
if(FOO)
根据我们到目前为止所说的，它将是 false，因为 BAR 字符串不满足计算布尔值 true 值的标准。
但情况并非如此，因为 CMake 在涉及到未加引号的变量引用时会出现例外。与带引号的参数不同，
CMake 只会在 if(FOO)为false 时计算它是以下任何一个常量 (这些比较不区分大小写):
• OFF, NO, FALSE, N, IGNORE, NOTFOUND
• 以-NOTFOUND 结尾的字符串
• 一个空字符串
• 零
因此，未定义的变量将赋值为 false:
但先定义一个变量会改变这种情况，并且计算为 true:
若认为不加引号的参数的行为令人困惑，请将变量引用包装在加引号的参数中:if (”${FOO}”)。这将导致在提供的参数传递到 if() 指令之前进行参数求值，并且行为将与字符串的求值一致。CMake 假设用户正在询问是否定义了变量 (并且不显式为 false)。可以显式检查这个事实
if(DEFINED <name>)

**比较**

以下操作符支持比较操作:
EQUAL，LESS，LESS_EQUAL，GREATER 和 GREATER_EQUA

**简单的检查**

• 若值在列表中:<variable|string> in _LIST <variable>
• 若指令可用:command <command-name>
• 若 CMake 策略存在:POLICY <policy-id>(这将在第 3 章中介绍)
• 若使用 add_test() 添加 CTest 测试:test <test-name>
• 若定义了构建目标:target <target-name>

**文件系统检查**

• EXISTS <path-to-file-or-directory>: 检查文件或目录是否存在
这将解析符号链接 (若符号链接的目标存在，则返回 true)。

• <file1> IS_NEWER_THAN <file2>: 检查哪个文件更新
如果 file1 比 (或等于)file2 更新，或者两个文件中有一个不存在，则返回 true。
• IS_DIRECTORY path-to-directory: 检查路径是否为目录
• IS_SYMLINK filename: 检查路径是否为符号链接
• IS_ABSOLUTE path: 检查路径是否为绝对路径

2.5.3 循环

CMake 中的循环相当简单——可以使用 while() 或 foreach() 重复执行同一组命令。这两个命令都支持循环控制机制:
break() 循环停止剩余块的执行，并从封闭循环中断开。
continue() 循环停止当前迭代的执行，并开启下一个迭代。

while循环块用 while() 指令创建，用 endwhile() 关闭。只要 while() 中提供的 <condition> 表达式为true，其后续的指令都会执行

foreach块有几个变体，它有打开和关闭指令:foreach() 和 endforeach()。

foreach(<loop_var> RANGE <max>)
<commands>
endforeach()

CMake 将从 0 迭代到 <max>(包括)。若需要更多的控制，可以使用第二个变量，提供 <min>、<max> 和 <step>(可选)，所有参数必须是非负整数，<min> 必须小于 <max>

foreach(<loop_var> RANGE <min> <max> [<step>]) 
foreach(<loop_variable> IN [LISTS <lists>] [ITEMS <items>])

CMake 将从所有提供的 <lists> 列表变量中获取元素，然后是所有显式声明的 <items> 值，并将它们存储在 <loop_variable> 中，对每个项逐个执行 <commands>。

从3.17版本开始，foreach() 已经学会了如何压缩列表 (ZIP_LISTS):

foreach(<loop_var>… IN ZIP_LISTS <lists>)

压缩列表可以遍历多个列表并处理具有相同索引的各自项:

set(L1 “one;two;three;four”)
foreach(num IN ZIP_LISTS L1 L2)

2.5.4 定义指令

有两种方法可以定义自己的命令: 可以使用 macro() 或 function()。要解释这两个指令间的区别，
最简单的方法是将它们与 C 风格的宏和实际的 C++ 函数进行比较:

• macro() 的工作方式更像是查找和替换指令，而不是像 function() 这样的实际子例程调用。

• function() 为本地变量创建一个单独的作用域，这与 macro() 命令不同，后者在调用者的变量作用域中工作

CMake 允许通过以下引用访问命令调用中传递的参数

• ${ARGC}: 参数的数量
• ${ARGV}: 所有参数的列表
• ${ARG0}, ${ARG1}, ${ARG2}: 特定索引处的实参值
• ${ARGN}: 最后一个预期参数之后，由调用者传递的匿名参数列表

使用 ARGC 边界外的索引访问数值参数会产生未定义行为。

macro(<name> [<argument> … ])
<commands>
endmacro()

此声明之后，可以通过调用宏的名称来执行宏 (函数调用不区分大小写)。

# chapter02/08-definitions/macro.cmake
macro(MyMacro myVar)
set(myVar "new value")
message("argument: ${myVar}") endmacro()
set(myVar "first value") message("myVar is now: ${myVar}") MyMacro("called value") message("myVar is now: ${myVar}")

下面是这个脚本的输出:
$ cmake -P chapter02/08-definitions/macro.cmake
myVar is now: first value
argument: called value
myVar is now: new value

发生了什么事? 尽管显式地将 myVar 设置为新值，但并不影响 message(”argument:${myVar}”)!

这是因为传递给宏的参数没有视为真正的变量，而是作为常量查找并替换指令。

另一方面，全局作用域中的 myVar 变量从第一个值更改为新值。这种行为称为副作用，是一种糟糕的实践，因为在不了解宏的情况下，很难判断哪些变量可能会受到这种宏的影响。
建议尽可能使用函数，可以避免许多令人头疼的事情。

function(<name> [<argument> … ])
<commands>
endfunction()

若函数调用传递的参数多于声明的参数，多余的参数将解释为匿名参数并存储在 ARGN 变量中。

• CMAKE_CURRENT_FUNCTION
• CMAKE_CURRENT_FUNCTION_LIST_DIR
• CMAKE_CURRENT_FUNCTION_LIST_FILE
• CMAKE_CURRENT_FUNCTION_LIST_LINE
函数的一般语法和概念非常类似于宏，但这一次是有效的。

**CMake 中的过程范式**

![](assets/2023-05-04-23-43-50.png)

CMake 中，用这种过程风格编写代码有点麻烦——需要提前提供计划使用的命令定义:
cmake_minimum_required(…)
project(Procedural)
function(pull_shared_protobuf)
function(setup_first_target)
function(calculate_version)
function(setup_second_target)
function(setup_tests)
setup_first_target()
setup_second_target()
setup_tests()
真是恶梦一场! 这段代码非常难以阅读，因为最微小的细节都在文件的顶部

对于这个问题有一些解决方案: 将命令定义移动到其他文件和跨目录分区作用域 (作用域目录将在第 3 章中详细解释)。但也有一个简单而优雅的解决方案: 在文件的顶部声明一个入口点宏，并在文件的最后调用它:

通过这种方法，代码的编写范围逐渐缩小，因为直到最后我们才真正调用 main() 宏，CMake 不会抱怨未定义命令的执行!

为什么在推荐的函数上使用宏? 可以无限制地访问全局变量，因为没有向 main() 传递参数，所以通常不需要担心这里的警告。

2.6. 实用指令

2.6.1 message() 指令

通过提供 MODE 参数，可以自定义输出的样式，并且在出现错误的情况下，可以停止代码:message(<mode> ”text”) 的执行。
• FATAL_ERROR: 将停止处理和生成。
• SEND_ERROR: 将继续处理，但跳过生成。
• WARNING: 继续处理。
• AUTHOR_WARNING: CMake 警告。继续处理。
• DEPRECATION:
若启用了CMAKE_ERROR_DEPRECATED或CMAKE_WARN_DEPRECATED 变量，将做出相应处理。
• NOTICE 或省略模式 (默认): 将向 stderr 输出一条消息，以吸引用户的注意。
• STATUS: 将继续处理，建议用于用户的主要消息。
• VERBOSE: 将继续处理，用于通常不是很有必要的更详细的信息
• DEBUG: 将继续处理，并包含在项目出现问题时可能有用的详细信息
• TRACE: 将继续处理，并建议在项目开发期间打印消息。通常，在发布项目之前，将这些类型的消息删除

我们已经了解了调试的三个重要部分: 列表、作用域和函数。

当启用命令行标志cmake—log-context时，消息将装饰为点分隔的上下文，并存储在CMAKE_MESSAGE_CONTEXT列表中。

message()的另一个很酷的技巧是在CMAKE_MESSAGE_INDENT列表中添加缩进(与CMAKE_MESSAGE_CONTEXT的方法完全相同):
list(APPEND CMAKE_MESSAGE_INDENT " ")

由于 CMake 没有提供带有断点或其他工具的真正调试器，当事情没有完全按计划进行时，干净的日志就非常重要了。

可以将 CMake 代码划分到单独的文件中，以保持内容的有序和独立性。然后，可以通过 include()
从父列表文件引用:include(< file|module> [OPTIONAL] [RESULT_VARIABLE <var>]) 若提供文件名 (一个扩展名为.cmake)，CMake 将尝试打开并执行它。

这里不会创建嵌套的、单独的作用域，因此对该文件中变量的修改会影响调用作用域。

若需要知道 include()是否成功，可以提供一个带有变量名的 RESULT_VARIABLE 关键字。若成功，则用包含的文件的完整路径填充，失败则用未找到 (NOTFOUND) 填充。

2.6.3 include_guard() 指令

包含有副作用的文件时，可能想要限制它们，以便它们只包含一次。这就是
include_guard([DIRECTORY|GLOBAL])的作用。

将include_guard()放在包含的文件的顶部。当CMake第一次遇到它时，将在当前作用域中进行
记录。若文件再次包含(可能是因为没有控制项目中的所有文件)，将不会处理。

GLOBAL参数。顾名思义，DIRECTORY关键字将在当前目录及其以下应用保护，而GLOBAL关
键字将对整个构建应用保护。

2.6.4 file() 指令

file(READ <filename> <out-var> […])

file({WRITE | APPEND} <filename> <content>…) 

file(DOWNLOAD <url> [< file>] […]) 

file() 指令会以一种与系统无关的方式读取、写入和传输文件，并使用文件系统、文
件锁、路径和存档

2.6.5 execute_process() 指令

有时需要使用系统中可用的工具 (毕竟，CMake 主要是一个构建系统生成器)

execute_process() 可以用来运行其他进程，并收集它们的输出。这个命令非常适合脚本，也可以在配置阶段的项目中使用。

execute_process(COMMAND <cmd1> [<arguments>] … [OPTIONS]) 

CMake 将使用操作系统的 API 来创建子进程 (因此，诸如 &&、|| 和 > 等 shell 操作符将不起作用)

可以通过不止一次地提供 COMMAND <cmd> <arguments> 参数来连接命令，并将一个命令的输出传递给另一个命令。

若进程没有在要求的限制内完成任务，可以选择使用 TIMEOUT <seconds> 参数来终止进程，并且可以根据需要设置 WORKING_DIRECTORY <directory>。

通过 RESULTS_VARIABLE <variable> 参数，可以在列表中收集所有任务的退出代码

若只对最后执行命令的结果感兴趣，请使用单数形式:RESULT_VARIABLE <variable>。

为了收集输出，CMake 提供了两个参数:OUTPUT_VARIABLE 和 ERROR_VARIABLE(以类似的方式使用)。若想合并 stdout 和 stderr，请对两个参数使用相同的变量。

记住，在为其他用户编写项目时，应该确保命令在相应的平台上可用。

第 3 章 CMake 项目

本章中，我们将讨论以下主题:

• 指令和命令
• 划分项目
• 项目结构
• 环境范围
• 配置工具链
• 禁用内构建

3.1. 相关准备

可以在 GitHub 上找到本章中出现的代码 https://github.com/PacktPublishing/Modern-CMake-for-Cpp/tree/main/examples/chapter03。

3.2.1 指定最低的 CMake 版本——cmake_minimum_required()

cmake_minimum_required() 将检查系统是否有正确的 cmake 版本，还将隐式调用另一个指令 cmake_policy(version)，告诉 cmake该项目使用什么正确的策略。这些策略是什么?

为了保持语法的干净和简单，CMake 的团队决定引入一些策略来反映这些变化。每当引入一个向后不兼容的更改时，都会附带一个启用新行为的策略。

当 CMake 使用新策略进行升级时，因为新策略不会启用，所以不需要担心破坏项目

3.2.2 定义语言和元数据–project()

CMake 不需要 project()，包含 CMakeLists.txt 文件的目录都将在项目模式下进行解析。

CMake 隐式地将该指令添加到文件的顶部。但我们需要从指定最低版本开始，所以最好不要忘记使用 project()。

调用此指令将隐式设置以下变量:
• PROJECT_NAME
• CMAKE_PROJECT_NAME (只有在顶层 CMakeLists.txt 中)
• PROJECT_SOURCE_DIR, <PROJECT-NAME>_SOURCE_DIR
• PROJECT_BINARY_DIR, <PROJECT-NAME>_BINARY_DIR

CMake 默认启用 C 和 C++，因此可能希望为 C++ 项目显式地仅指定 CXX。为什么?project() 将为所选语言检测和测试可用的编译器，因此选择正确的编译器，可以在配置阶段跳过对未使用语言的任何检查，从而节省时间。

CMake 还可以使用 enable_language(<lang>) 来修改所使用的语言，这将不会创建元数据。

3.3. 划分项目

随着解决方案的行数和文件数的增长，慢慢地不可避免的事情即将到来: 要么开始对项目进行区分，要么淹没在代码行和大量文件中。

可以通过两种方式解决这个问题: 分配 CMake 代码和将源文件移动到子目录中。

但这个解决方案有一些缺陷:

• 来自嵌套目录的变量会污染顶层作用域 (反之亦然):


• 所有的目录将共享相同的配置:

随着项目多年来的成熟，这个问题会更加的明显。若没有粒度度的存在，必须将每个翻译单元视为相同的，并且不能指定不同的编译标志，不能为代码的某些部分选择较新的语言版本，也不能在选定的代码区域设置静默警告。所有内容都是全局的，需要同时对所有源文件进行更改。

• 有一些共享编译触发器:
• 所有的路径都相对于顶层:

另一种方法是使用 add_subdirectory() 指令，引入了一个变量范围等。

3.3.1 作用域的子目录

这个概念，CMake 提供了以下指令:add_subdirectory(source_dir [binary_dir]
                                                [EXCLUDE_FROM_ALL])

这将向构建添加一个源目录，也可以提供一个写入构建文件的路径(binary_dir)。

EXCLUDE_FROM_ALL 关键字将禁用在子目录中定义的目标的默认构建 (将在下一章讨论目标)

• 变量更改与嵌套作用域隔离。
• 可以随心所欲地配置嵌套工件。
• 更改嵌套的 CMakeLists.txt 文件中不需要构建和不相关的目标。
• 路径是目录的本地路径，若需要，可以添加到父 include 路径。


使用 add_library() 生成了全局可见的目标 cars，并使用 target_include_ directories() 将 cars 目录
添加到其公共包括目录中。这允许 main.cpp 包含 cars.h 文件而不提供相对路径:
#include “car.h”

为我们使用了 OBJECT 关键字，这表示只对生成目标文件感兴趣

3.3.2 嵌套项目

上一节中，简要地提到了 add_subdirectory() 中使用的 EXCLUDE_FROM_ALL 参数。

Make 文档建议，若在源码树中有这样的部件，应该在它们的 CMakeLists.txt 文件中有自己的 project() 指令，这样就可以生成自己的构建系统，并且可以独立构建。

既然支持项目嵌套，是否可以以某种方式将一起构建的相关项目连接起来?

3.3.3 外部项目

从一个项目到另一个项目在技术上存在，CMake 将在一定程度上支持这一点

我们可以使用这些工具进行的分区: 包括列表文件、添加子目录和嵌套项目。但应该如何使用它们，使我们的项目保持可维护性、易于导航和扩展呢? 要做到这一点，需要一个定义良好的项目结构。

3.4. 项目结构

随着项目的发展，在列表文件和源代码中查找内容变得越来越困难

所以，一个好的项目结构意味着什么呢? 我们可以从软件开发的其他领域 (例如，系统设计) 借鉴一些规则。

项目应具备以下特点:

• 易导航和扩展• 自包含——例如，特定于项目的文件应该在项目目录中，而不在其他目录中。• 抽象层次结构应该通过可执行文件和二进制文件来表示。

本项目具有以下组件的目录:• cmake: 宏和函数，查找模块和一次性脚本• src: 将存储的二进制文件和库的源代码• doc: 用于构建文档• extern: 从源代码构建的外部项目的配置• test: 包含自动测试的代码

3.5. 环境范围

3.5.1 识别操作系统

很多情况下，了解目标操作系统是很有用的。即使是像文件系统这样普通的东西，Windows 和Unix 在大小写敏感、文件路径结构、扩展名、特权等方面也有很大的不同

统上的大多数命令在另一个系统上是不可用的，或者可以以不同的方式命名 (即使是用一个字母命名——例如，ifconfig和 ipconfig 命令)。

若需要用一个 CMake 脚本支持多个目标操作系统，只要检查CMAKE_SYSTEM_NAME 变量，就可以采取相应的行动

if(CMAKE_SYSTEM_NAME STREQUAL “Linux”)message(STATUS “Doing things the usual way”)elseif(CMAKE_SYSTEM_NAME STREQUAL “Darwin”)message(STATUS “Thinking differently”)elseif(CMAKE_SYSTEM_NAME STREQUAL “Windows”)message(STATUS “I’m supported here too.”)

3.5.2 交叉编译——主机系统和目标系统?

在一台机器上编译要在另一台机器上运行的代码，称为交叉编译

可以 (使用正确的工具集) 通过在 Windows 机器上运行 CMake 来编译 Android 应用程序。交叉编译不在本书的讨论范围内，但是理解它如何影响 CMake 的某些部分是很重要的

允 许 交 叉 编 译 的 必 要 步 骤 之 一 是 将CMAKE_SYSTEM_NAME和CMAKE_SYSTEM_VERSION 变量设置为适合为目标编译的操作系统的值(CMAKE 文档将其称为目标系统)

3.5.3 简化变量

CMake 将预定义一些变量，这些变量将提供关于主机和目标系统的信息

若使用特定的系统，则将适当的变量设置为非 false 值 (即 1 或 true):

• ANDROID, APPLE, CYGWIN, UNIX, IOS, WIN32, WINCE, WINDOWS_PHONE• CMAKE_HOST_APPLE,CMAKE_HOST_SOLARIS,CMAKE_HOST_UNIX,CMAKE_HOST_WIN32对于 32 和 64 位版本的 Windows 和 MSYS，WIN32 和 CMAKE_HOST_WIN32 变量将为真 (此值为遗留原因保留)。此外，UNIX 将适用于 Linux、macOS 和 Cygwin。

3.5.4 主机系统信息

CMake 可以提供更多变量，但为了节省时间，不会查询环境中很少需要的信息，比如处理器是否支持 MMX 或总物理内存是多少

这并不意味着这个信息不可用——只需要用下面的命令显式地进行:

cmake_host_system_information(RESULT <VARIABLE> QUERY <KEY> … ) 需要提供一个目标变量和感兴趣的键的列表。若只提供一个键，则变量将只包含一个值; 否则，它将是一个值列表。

#### 3.5.5 平台是 32 位还是 64 位架构?

3.5.5 平台是 32 位还是 64 位架构?

这个信息可以通过CMAKE_SIZEOF_VOID_P 变量获得，它将包含 64 位的值 8(因为指针是 8 字节宽的) 和 32 位的值 4(4 字节):if(CMAKE_SIZEOF_VOID_P EQUAL 8)message(STATUS “Target is 64 bits”)endif()

3.5.6 系统的端序

架构可以是大端的，也可以是小端的。端序是字的字节顺序或处理器的自然数据单位。大端存储系统将最高位字节存储在最低内存地址，将最低位字节存储在最高内存地址。小端系统正好相反。

大多数情况下，字节顺序并不重要，但当编写需要可移植的位代码时，CMake 将为你提供一个BIG_ENDIAN 或 LITTLE_ENDIAN 值存储在 CMAKE_<lang>_BYTE_ORDER 变量中，其中 <lang> 为 C、CXX、OBJC 或 CUDA。

3.6. 配置工具链

工具链包含构建和运行应用程序时使用的所有工具——例如，工作环境、生成器、CMake 可执行程序本身和编译器。

当构建因一些编译和语法错误而停止时，缺乏经验的用户会有什么感受。他们必须深入研究源代码，并试图理解发生了什么。经过一个小时的调试后，发现正确的解决方案是更新编译器。

3.6.1 设定 C++ 标准

从 C++11 正式发布到现在已经 10 年了，它不再认为是现代 C++ 标准。不建议使用此版本启动项目，除非目标环境非常旧

坚持旧标准的另一个原因是，若正在构建难以升级的历史项目

通常，升级标准不会遇到任何问题

可以在每个目标的基础上覆写:set_property(TARGET <target> PROPERTY CXX_STANDARD <standard>)

3.6.2 坚持支持标准

要求目标的标准:set(CMAKE_CXX_STANDARD_REQUIRED ON)

3.6.3 特定于供应商的扩展

这么说吧，对于一些编译器生产者的需求，C++ 标准的发展有点慢，所以他们决定在语言中添加他们自己的增强——也可以叫插件。为了实现这一点，CMake 会将-std=gnu++14，而不是-std=c++14 添加到编译行。

> 一方面，因为它允许一些方便的功能，这可能是需要的。但另一方面，若切换到另一个编译器(或者您的用户切换到另一个编译器!)，代码可能无法构建。

==确实，交叉编译的时候用到的stl在不同编译环境下，就是不可兼容==

这也是一个每个目标的属性，它有一个默认变量 CMAKE_CXX_EXTENSIONS。CMake 在这里更加自由，并且允许扩展，除非我们告诉它不要这样做:set(CMAKE_CXX_EXTENSIONS OFF)

3.6.4 过程间优化

通常，编译器在单个翻译单元的级别上优化代码，所以.cpp 文件会进行预处理、编译，然后进行优化

稍后，这些文件将传递给链接器以构建一个二进制文件。现代编译器可以在链接之后执行优化 (这称为链接时优化)，以便所有编译单元都可以作为单个模块进行优化

需 要 设 置 的 默 认 变 量 叫 做CMAKE_INTERPROCEDURAL_OPTIMIZATION。 在 设 置 它 之 前， 需 要 确保 支 持， 以 避 免 错误:include(CheckIPOSupported)check_ipo_supported(RESULT ipo_supported)if(ipo_supported)set(CMAKE_INTERPROCEDURAL_OPTIMIZATION True)endif()必须包含一个内置模块来访问 check_ipo_supported() 指令。

3.6.5 检查支持的编译器特性

 们 特 别 感 兴趣 的 是 衡 量 支 持 哪 些 C++ 特 性 (哪 些 不 支 持)。CMake 会 在 配 置 阶 段 询问 编 译 器， 并 在CMAKE_CXX_COMPILE_FEATURES 变量中存储可用特性的列表

# chapter03/07-features/CMakeLists.txtlist(FIND CMAKE_CXX_COMPILE_FEATUREScxx_variable_templates result)if(result EQUAL -1)message(FATAL_ERROR “I really need variable templates.”) endif()

3.6.6 编译测试文件

用 GCC 4.7.x 编译一个应用程序时，我想到了一个特别有趣的场景。我已经在编译器的参考中手动确认，使用的所有 C++11 特性都得到了支持

然而，解决方案仍然不能正常工作

代码静默地忽略了对标准 <regex> 头文件。结果是 GCC 4.7.x 有一个 bug，正则表达式库没有实现

没有检查可以保护您不受这种错误的影响，但是可以通过创建一个测试文件来减少这种行为，该文件可以填充您想要检查的所有特性

CMake 提供了两个配置时间命令，try_compile() 和 try_run()，以验证目标平台上支持所需的一切。

第二个命令提供了更多的自由，因为可以确保代码不仅在编译，而且在正确地执行 (可以测试regex 是否在工作)

当然，这不适用于交叉编译场景 (因为主机无法运行为不同目标构建的可执行文件)

3.7. 禁用内构建

接下来，将详细解释工具链从目标构建二进制工件所采取的所有步骤

这是许多关于 C++ 的书籍所遗漏的部分: 如何正确配置和使用预处理器、编译器和链接器，以及如何优化其行为。

最后，将介绍 CMake 提供的管理依赖关系的所有不同方法，并将解释如何选择最佳方式。

第 4 章 使用目标

“工件”这个不准确的词，是因为 CMake 不限制只生成可执行文件或库。实际上，可以使用生成的构建系统来创建多种类型的输出: 更多的源文件、头文件、目标文件、存档和配置文件——可以是任何东西。所需要的只是一个命令行工具 (如编译器)、可选的输入文件和一个输出路径。

目标是一个非常强大的概念，极大地简化了项目的构建。理解其如何工作，以及如何以最优雅和干净的方式配置它们非常重要

本章中，我们将讨论以下主题:• 目标的概念• 编写自定义命令• 生成器表达式

4.1. 相关准备

4.2. 目标的概念

若曾经使用过 GNU Make，应该已经了解过目标的概念。本质上，它是构建系统用来将文件列表编译为另一个文件的一个方式

它可以是一个编译成.o 对象文件的.cpp 实现文件，一组打包成.o静态库的.o 文件，以及许多其他组合

然而，CMake 可以节省时间，跳过这些食谱的中间步骤，其可以在更高的抽象级别上工作

CMake 会理解如何直接从源文件构建可执行文件。因此，不需要编写显式的配方来编译任何目标文件

所需要的只是一个 add_executable() 指令，该指令带有可执行目标的名称和将成为其元素的文件列表:add_executable(app1 a.cpp b.cpp c.cpp)

生成步骤中，CMake 将创建一个构建系统，并将其填充为方案编译每个源文件，并将它们链接到单个二进制可执行文件中

在 CMake 中，可以使用以下指令创建目标:• add_executable()• add_library()• add_custom_target()

前两个不言自明，在前几章中已经简要地使用过它们来构建可执行程序和库

但是这些定制目标是什么呢?

其允许你指定自己的命令行，在不检查输出是否最新的情况下执行，例如:

• 计算其他二进制文件的校验和。• 运行代码消毒程序并收集结果。• 向数据处理管道发送编译报告。

下面是 add_custom_target() 指令的完整签名:

add_custom_target(Name [ALL] [command1 [args1…]][COMMAND command2 [args2…] …][DEPENDS depend depend depend … ][BYPRODUCTS [files…]][WORKING_DIRECTORY dir][COMMENT comment][JOB_POOL job_pool][VERBATIM] [USES_TERMINAL][COMMAND_EXPAND_LISTS][SOURCES src1 [src2…]])

定制目标的一个好的用例，可能是需要在每个构建中删除特定的文件——例如，以确保代码覆盖率报告不包含过时的数据

需要做的就是像这样定义一个自定义目标:add_custom_target(clean_stale_coverage_filesCOMMAND find . -name “*.gcda” -type f -delete)上面的命令将搜索所有扩展名为.gcda 的文件，并删除它们。不过有一个问题; 与可执行目标和库目标不同，自定义目标只有添加到依赖关系图中才会构建

成熟的应用通常是由许多组件构建，这里指的不是外部依赖关系。具体来说是内部库

从结构的角度来看，将它们添加到项目中是有用的，可以将相关的东西打包在一个逻辑实体中，还可以链接到其他目标——另一个库或可执行文件

这个项目中，有两个库、两个可执行程序和一个自定义目标。这里的用例是为用户提供一个银行应用，该应用程序具有一个漂亮的 GUI(GuiApp)，以及一个命令行版本，可作为自动化脚本(TerminalApp) 的一部分使用

两个可执行程序都依赖于相同的计算库，但只有一个需要绘图库

为了确保应用程序下载正确，将计算一个校验和，将其存储在一个文件中，并通过单独的安全通道分发它

CMake 在为这样的解决方案编写列表文件时非常灵活

chapter04/01-targets/CMakeLists.txtcmake_minimum_required(VERSION 3.19.2)project(BankApp CXX)add_executable(terminal_app terminal_app.cpp)add_executable(gui_app gui_app.cpp)target_link_libraries(terminal_app calculations)target_link_libraries(gui_app calculations drawing)add_library(calculations calculations.cpp)add_library(drawing drawing.cpp)add_custom_target(checksum ALLCOMMAND sh -c “cksum terminal_app>terminal.ck”COMMAND sh -c “cksum gui_app>gui.ck”BYPRODUCTS terminal.ck gui.ckCOMMENT “Checking the

sums…”)

使用 target_link_libraries() 指令将库与可执行文件连接起来。若没有它，可执行文件的编译将会因为未定义的符号而失败

我们在实际声明库之前调用了这个命令。当 CMake 配置项目时，其会收集关于目标，及其属性的信息——名称、依赖项、源文件和其他信息。解析所有文件之后，CMake 将尝试构建一个依赖图。和所有有效的依赖图一样，它们是有向无环图

有着一个明确的方向，确定哪个目标依赖于哪个目标，不过这样的依赖不能形成环

当在构建模式下执行 cmake 时，生成的构建系统将检查已经定义的顶级目标并递归构建它们的依赖项

1. 从顶部开始，构建第 1 组中的两个库。

2. 计算和绘图库完成后，构建组 2 - GuiApp 和 TerminalApp。

3. 构建一个校验和目标，运行指定的命令行生成校验和 (cksum 是一个 Unix 校验和工具)。

有一个小问题——前面的解决方案并不能保证在可执行文件之后构建校验和目标。CMake 不知道校验和依赖于当前的可执行二进制文件，所以可以自由地开始构建

为了解决这个问题，可以把add_dependencies() 指令放在文件的末尾:add_dependencies(checksum terminal_app gui_app)

这将确保 CMake 理解 Checksum 目标和可执行程序之间的关系

不过 target_link_libraries() 和 add_dependencies() 之间有什么区别呢?

第一个用于与实际库一起使用，并允许控制属性传播

第二种方法只能用于顶层目标，以设置它们的构建顺序

随着项目变得越来越复杂，依赖树变得越来越难以理解。如何简化这个过程?

4.2.2 可视化的依赖性

即使是小项目也很有难和与其他开发人员直接分享。最简单的方法是通过一个漂亮的图表

毕竟，一张图片胜过千言万语

我们可以自己做这个工作并画一个图表，就像图 4.1中所做的那样。但这很没意思，而且需要不断更新

幸运的是，CMake 有一个很好的模块来生成点/graphviz 格式的依赖关系图。它支持内部和外部依赖关系!

cmake —graphviz=test.dot .

但是几乎没有人喜欢创建文档——现在，不需要自己来做了!

4.2.3 目标属性

目标具有类似于 C++ 对象字段的工作方式的属性。可以修改其中一些属性，而其他属性只读。

CMake 定义了一个很大的“已知属性”列表 (参见扩展阅读部分)，这些属性取决于目标的类型 (可执行、库或自定义)，还可以添加自己的属性

使用以下命令操作目标器的属性:get_target_property(<var> <target> <property-name>)set_target_properties(<target1> <target2> …PROPERTIES <prop1-name> <value1><prop2-name> <value2> …)

要在屏幕上打印目标属性，需要将其存储在 <var> 变量中，然后 message() 将其发送给用户，需要一个个地读取

另外面，在目标上设置属性可以在多个目标上同时指定多个属性。属性的概念并非目标所独有。CMake 还支持设置其他作用域的属性:GLOBAL、DIRECTORY、SOURCE、INSTALL、TEST 和 CACHE

要操作所有类型的属性，有 get_property() 和 set_property() 指令

可以使用这些低层指令来做set_target_properties() 指令所做的事情:

set_property(TARGET <target> PROPERTY <name> <value>) 最 好 尽 可 能 多 地使 用 高 级 命 令

CMake 提 供 了 更 多 这 样 的 功 能， 范 围 甚 至 更 窄， 比如 在 目 标 上 设 置 特 定 的 属 性。 例 如，add_dependencies(<target> <dep>) 将依 赖 项 附 加 到MANUALLY_ADDED_DEPENDENCIES 目 标 属 性 中。 可 以 使 用get_target_property() 查 询， 就像 使 用 其 他 属 性 一 样。

CMake 中 使 用add_dependencies() 指令只能进行追加操作

接下来的章节中讨论编译和链接时，将介绍更多的属性设置命令。同时，我们会了解到一个目标的属性如何转换到另一个目标。

4.2.4 可传递需求

“传递性使用需求”是 CMake 文档中的神秘的主题之一

我将从解释这个谜题的中间部分开始，一个目标可能依赖于另一个目标。CMake 文档有时将这种依赖关系称为“使用”，例如在一个目标中使用另一个目标

某些情况下，这样的已用目标具有使用目标必须满足的特定需求: 链接一些库，包含一个目录，或要求特定的编译特性

问题是在文档的其他上下文中都不称其为需求。当为单个目标指定相同的需求时，可以设置属性或依赖项。因此，名称的最后一部分可能应该简单地称为“属性”

最后一部分是传递，我相信这一点是正确的 (也许有点太聪明了)。CMake 将使用目标的一些属性/需求附加到使用它们的目标的属性中

来看一个具体的例子，来理解其为什么会存在，以及如何工作的:

target_compile_definitions(<source> <INTERFACE|PUBLIC|PRIVATE> [items1…])

这个目标命令将填充 <source> 目标的 COMPILE_DEFINITIONS 属性

有趣的是第二个论点，需要指定三个值 INTERFACE、PUBLIC 或 PRIVATE 中的一个，以控制应该将属性传递给哪个目标。

传递关键字的工作原理如下:• PRIVATE 设置源目标的属性。• INTERFACE 设置相关目标的属性。• PUBLIC 设置源和相关目标的属性。

当不将属性传递到其他目标时，可以将其设置为 PRIVATE。

当需要这样的传递时，使用 PUBLIC

若源目标在其实现 (.cpp 文件) 中不使用该属性，而只在头文件中使用该属性，这些属性会传递给消费者目标，那么就使用INTERFACE。

在配置阶段，CMake 将读取源目标的接口属性，并将其内容附加到目标目标

在 CMake 3.20 中，可以使用 target_link_options() 或直接使用 set_target_properties()指令管理 12个这样的属性:

• AUTOUIC_OPTIONS• COMPILE_DEFINITIONS• COMPILE_FEATURES• COMPILE_OPTIONS• INCLUDE_DIRECTORIES• LINK_DEPENDS• LINK_DIRECTORIES• LINK_LIBRARIES• LINK_OPTIONS• POSITION_INDEPENDENT_CODE• PRECOMPILE_HEADERS• SOURCES

propagation(传播) 关键字的工作原理如下:• PRIVATE 将源附加到目标的私有属性。• INTERFACE 将源附加到目标的接口属性。• PUBLIC 包括以上两种属性的特点。

若正确地为源目标设置了 propagation(传播) 关键字，属性将自动传递到目的目标上——除非有冲突……

4.2.5 处理冲突的传播属性

当目标依赖于多个其他目标时，可能会出现传播属性彼此完全冲突的情况。假设一个使用的目标指定 POSITION_INDEPENDENT_CODE 属性为 True，另一个为 False。CMake 将此理解为冲突

极少数情况下，这可能会变得很重要——例如，若在多个目标中使用相同的库构建软件，然后链接到单个可执行文件

若这些源目标使用同一个库的不同版本，可能会遇到问题。

为了确保只使用相同的特定版本，可以创建一个自定义接口属性INTERFACE_LIB_VERSION，并将版本存储在那里。这还不足以解决问题，因为 CMake 在默认情况下不会传播自定义属性，必须显式地将自定义属性添加到“兼容”属性列表中。

每个目标都有 4 个这样的列表:• COMPATIBLE_INTERFACE_BOOL• COMPATIBLE_INTERFACE_STRING• COMPATIBLE_INTERFACE_NUMBER_MAX• COMPATIBLE_INTERFACE_NUMBER_MIN将属性附加到其中一个，将触发传播和兼容性检查。

OOL 列表将检查传播到目标目标的所有属性是否计算为相同的布尔值。类似地，STRING 将求值为字符串。NUMBER_MAX 和 NUMBER_MIN有点不同——传播值不需要匹配，但目标只会接收最高或最低的值。

# chapter04/02-propagated/CMakeLists.txtcmake_minimum_required(VERSION 3.20.0)project(PropagatedProperties CXX)add_library(source1 empty.cpp)set_property(TARGET source1 PROPERTY INTERFACE_LIB_VERSION4)set_property(TARGET source1 APPEND PROPERTYCOMPATIBLE_INTERFACE_STRING LIB_VERSION)add_library(source2 empty.cpp)set_property(TARGET source2 PROPERTY INTERFACE_LIB_VERSION4)add_library(destination empty.cpp)target_link_libraries(destination source1 source2)

这里创建了三个目标，所有文件都使用相同的空源文件。两个源目标上，用INTERFACE_前缀指定自定义属性。将它们设置为相同的匹配库版本。两个源目标都链接到目标目标。最后，指定一个 STRING 兼容性要求作为 source1 的属性 (没有在这里添加 INTERFACE_前缀)。

CMake 将 这 个 自 定 义 属 性 传 播 到 目 标 目 标， 并 检 查 所 有 源 目 标 的 版本 是 否 完 全 匹 配(compatibility 属性可以只在一个目标上设置)。

既然了解了目标是什么，就看看其他看起来像目标，闻起来像目标，有时也像目标 (鸭子定律)。但事实证明，其并不是真正的目标

4.2.6 实现伪目标

导入目标

若浏览了目录，就会知道将讨论 CMake 如何管理外部依赖项——其他项目、库等。导入的目标基本上是这个过程的产物

CMake 可以定义它们作为 find_ package() 指令的结果。

别名目标

别名目标完全符合期望——不同的名称下创建对目标的另一个引用

add_executable(<name> ALIAS <target>)add_library(<name> ALIAS <target>)

别名目标的属性只读，并且不能安装或导出别名 (在生成的构建系统中不可见)。

使用别名的理由到底是什么呢? 当项目的某些部分 (如子目录) 需要具有特定名称的目标时，就很方便了，而实际的实现可能根据情况在不同的名称下可用

接口库

这是一个有趣的构造——一个库不编译任何东西，而是作为一个实用工具目标。其整个概念是围绕传播属性 (传递使用需求) 构建的。

接口库有两个主要用途——纯头文件库和将一堆传播的属性捆绑到一个逻辑单元中。

使用 add_library(INTERFACE) 创建纯头文件库相当容易:add_library(Eigen INTERFACEsrc/eigen.h src/vector.h src/matrix.h)target_include_directories(Eigen INTERFACE$<BUILD_INTERFACE:${CMAKE_CURRENT_SOURCE_DIR}/src>$<INSTALL_INTERFACE:include/Eigen>)

前面的代码片段中，创建了一个具有三个头文件的特征接口库。接下来，使用生成器表达式，在导出目标时将其 include 目录设置为${CMAKE_CURRENT_SOURCE_DIR}/src，在安装目标时设置为 include/Eigen。要使用这样的库，只需要链接即可:target_link_libraries(executable Eigen)

这里没有实际的链接，但是 CMake 将此命令理解为将所有 INTERFACE 属性传播到可执行目标的请求。

4.2.7 构建目标

这样的构建系统目标是 ALL，CMake 在默认情况下生成它来包含所有顶层列表文件目标，比如可执行文件和库 (不一定是自定义目标)。ALL 是在运行 cmake —build <build tree> 而不选择具体目标时生成的，可以通过向前面的命令添加—target <name> 参数来选择一个

为了优化默认构建，可以像这样从 ALL 目标中排除它们

add_executable(<name> EXCLUDE_FROM_ALL [<source>…])

add_library(<name> EXCLUDE_FROM_ALL [<source>…]) 自定义目标则相反——默认情况下，排除在 ALL 目标之外，除非使用 ALL 关键字显式地定义它们，

4.3. 编写自定义命令

4.4. 生成器表达式

CMake 通过三个阶段构建解决方案——配置、生成和运行构建工具，在配置阶段就有了所有所需的数据。

每隔一段时间，就会遇到“先有鸡，还是先有蛋”的问题。

个目标需要知道另一个目标的二进制工件的路径。但是，只有在解析所有列表文件并完成配置阶段之后，这些信息才可用。

该如何处理这种问题呢? 可以为该信息创建一个占位符，并将其评估推迟到下一个阶段——生成阶段。

这就是生成器表达式(有时称为genex)所做的事

其是围绕目标属性构建的，如LINK_LIBRARIES、INCLUDE_DIRECTORIES、COMPILE_DEFINITIONS、传播属性和其他属性，但不是全部

生成器表达式将在生成阶段计算 (当配置完成并创建构建系统时)，所以不能将其输出捕获到变量中，并打印到控制台

要调试可以使用以下方法:

• 将其写入一个文件 (file() 指令的这个特定版本支持生成器表达式):
• 添加一个自定义目标，并根据命令行显式构建:

custom_target(gendbg COMMAND ${CMAKE_COMMAND} -E echo “$<…>”)

编译可以大致描述为将用高级编程语言编写的指令，转换为低级机器代码的过程

C++ 依赖于静态编译——整个程序在执行之前必须翻译成本机代码

这是 Java 或Python 等语言的另一种替代方法，后者在用户每次运行程序时，都会使用一个特殊的、单独的解释器动态编译程序

C++ 的策略是提供尽可能多的高级工具，同时仍然能够在一个完整的、自包含的应用程序中，为所有的架构提供原生性能

创建和运行 C++ 程序需要几步:

1. 设计应用程序，并仔细编写源码。2. 将单个的.cpp 实现文件 (称为翻译单元) 编译为目标文件。3. 将目标文件链接到一个可执行文件中，并添加所有其他依赖项——动态库和静态库。4. 为了运行该程序，操作系统将使用一个名为加载器的工具，将其机器码和所有必需的动态库映射到虚拟内存。然后加载器读取头文件以检查程序从哪里开始，并将控制权移交给代码。5. C++ 运行时启动。执行一个 special_start 函数来收集命令行参数和环境变量。启动线程，初始化静态符号，并注册清理回调。这样，才能调用 main()(其中代码由开发者书写)。相当多的工作发生在幕后，本章主要关注于列表中的第二步

5.2.1 编译工作

编译是将高级语言转换为低级语言的过程——是通过以特定于给定平台的二进制目标文件格式生成机器代码 (特定处理器可以直接执行的指令)

在 Linux 上，最流行的格式是可执行和可链接格式 (ELF)。Windows 使用 PE/COFF 格式规范。macOS 使用的是 Mach 对象(Mach-O 格式)

目标文件是单个源文件的直接翻译

中的每一个都必须单独编译，然后通过链接器连接到一个可执行程序或库中

所以，当修改代码时，可以通过只重新编译刚修改的文件来节省时间

编译器必须执行以下步骤来创建一个目标文件:

1. 预处理2. 语言分析3. 汇编4. 优化5. 生成二进制文件

预处理 (由大多数编译器自动调用) 是实际编译前的一步

作用是以非常基本的方式操作源代码，可执行 #include 指令，用定义的值替换标识符 (#define 指令和-D 标志)，使用简单的宏，并有条件地包含或排除基于 #if、#elif 和 #endif 指令的部分代码。预处理器并不了解 C++代码，所以其只是一个高级点的查找和替换工具

将代码分解成多个部分，并跨多个翻译单元共享声明的能力，是代码重用的基础。

接下来是语言分析。编译器将逐个字符扫描文件 (包含预处理器包含的所有头文件) 并执行词法分析，将其分组为有意义的标记——关键字、操作符、变量名等。然后，将记号分组到记号链中，并验证它们的顺序和存在是否遵循 C++ 的规则——这个过程称为语法分析或解析(通常，这是打印错误方面最引人注目的部分)

执行语义分析——编译器试图检测文件中的语句是否真正有意义。例如，必须满足类型正确性检查 (不能将整数赋值给字符串变量)。

汇编是根据平台可用的指令集，将这些记号转换为特定于 CPU 的指令

有些编译器实际上创建一个汇编输出文件，该文件稍后可以传递给特定的汇编程序，以生成 CPU 可以执行的机器代码

其他的则直接从内存生成相同的机器代码。通常，这样的编译器包含一个选项，可以生成人类可读的汇编文本 (这样做可能不值得)。

优化发生在整个编译过程中，在每个阶段都有

生成第一版汇编后有一个显式的阶段，该阶段负责最小化寄存器的使用并删除不使用的代码。一个有趣且重要的优化是内联扩展或内联。编译器将“剪切”函数体并“粘贴”它，而不是调用 (标准没有定义在什么情况下会发生这种情况——这取决于编译器的实现)。这个过程加快了执行速度并减少了内存的使用，但不利于调试 (执行的代码不再位于原来的行)

生成二进制文件由根据目标平台指定的格式将优化的机器代码写入目标文件组成。这个目标文件还没有准备好执行——必须传递给下一个工具，链接器，其将适当地重新定位我们的目标文件的部分，并解析对外部符号的引用

5.2.2 初始配置

CMake 提供了多个指令来影响每个阶段:

• target_compile_features(): 需要具有特定功能的编译器来编译此目标。• target_sources(): 向已定义的目标添加源。• target_include_directories(): 设置预处理器的包含路径。• target_compile_definitions(): 设置预处理定义。• target_compile_options(): 特定于编译器的选项。• target_precompile_headers(): 预编译头文件。以上所有指令都接受类似的参数:target_…(<target name> <INTERFACE|PUBLIC|PRIVATE><value>)所以，其支持属性传播，并且可以用于可执行程序和库。

所有指令都支持生成器表达式。

要求编译器提供特定的特性

需要为出错做好准备，并致力于为软件的用户提供明确的信息

可用的编译器 X 并没有提供所需的特性 y。这比用户在不兼容的工具链中所产生的错误要好得
多。

CMake 很了解 C++ 标准，并支持这些 compiler_ids 的编译器特性

5.2.3 管理目标源

当 使 用add_executable() 或 add_library() 时，需要提供文件列表。

随着解决方案的增长，每个目标的文件列表也会增长

 一个诱惑可能是在 GLOB 模式下使用 file() 指令——可以从子目录收集所有文件并将它们存储在一个变量中

但不建议这种方法。CMake 根据列表文件中的更改生成构建系统，所以若不做更改，构建可能会在没有任何警告的情况下中断 (从长时间的调试经验中我们知道，这是最糟糕的中断类型)

除此之外，没有在目标声明中列出所有的源代码将破坏诸如 CLion (CLion 只解析一些命令来理解项目)等 IDE 的代码检查

若不建议在目标声明中使用变量，如何有条件地添加源文件

可以使用 target_sources() 指令追加源文件到之前创建的目标

这样，每个平台都可以获得自己的一组兼容文件，但是长长的文件列表应该如何处理呢? 好吧，我们只能接受有些东西还不完美，并继续手动添加它们。

5.3. 预处理配置

预处理器在构建过程中起着巨大的作用，但其功能却又如此简单和有限

将介绍如何提供包含文件的路径

以及如何使用预处理器定义

还将解释如何使用 CMake 配置包含的头文件

5.3.1 提供包含文件的路径

预处理器最基本的特性是能够使用 #include 指令包含.h/.hpp 头文件。它有两种形式:• #include <path-spec>: 尖括号式• #include ”path-spec”: 引号式

通常，尖括号形式将检查标准包含目录，包括标准 C++ 库和标准 C 库头文件存储在系统中的目录。

引号式将开始在当前文件的目录中搜索包含的文件，然后在目录中查找带尖括号的目录

CMake 提供了一个指令来操作头文件的搜索路径，以找到需要包含的头文件:

target_include_directories(<target> [SYSTEM] [AFTER|BEFORE]<INTERFACE|PUBLIC|PRIVATE> [item1…][<INTERFACE|PUBLIC|PRIVATE> [item2…] …])

可以添加希望编译器检查的自定义路径，CMake 会将它们添加到生成的构建系统中的编译器调用中，这将提供一个特定于编译器的标志 (通常是-I)。

使用 BEFORE 或 AFTER 确定路径是应该添加到目标 INCLUDE_DIRECTORIES 属性的前面还是后面，这仍然由编译器决定是在默认目录之前还是之后检查这里提供的目录 (通常是在之前)。

SYSTEM 关键字通知编译器所提供的目录是标准的系统目录 (与尖括号形式一起使用)。对于许多编译器，这个值将作为-system 标志提供。

5.3.2 预处理宏定义

这看起来很简单，但若我们想根据外部因素 (如操作系统、体系结构或其他东西)来调整这些部分，会发生什么情况呢? 好消息! 可以将值从 CMake 传递到 C++ 编译器，这一点也不复杂。

target_compile_definitions() 指令就可以做到这一点:

chapter05/02-definitions/CMakeLists.txtset(VAR 8)add_executable(defined definitions.cpp)target_compile_definitions(defined PRIVATE ABC“DEF=${VAR}”)

这些定义通常以-D 标志——-DFOO=1——传递给编译器，一些开发者仍然在这个命令中使用这个标志:target_compile_definitions(hello PRIVATE -DFOO)

CMake 可以识别这一点，并将删除任何前导-D 标志。也会忽略空字符串，所以可以这样写:target_compile_definitions(hello PRIVATE -D FOO)

使用 Git 进行编译版本跟踪

5.3.3 配置头文件

若有多个变量，可以通过 target_compile_definitions() 传递定义可能会有一点开销。但不能只提供一个头文件，其中包含引用各种变量的占位符，然后让 CMake 填充它们吗?

可以使用 configure_file(<input> <output>) 指令，可以从这样的模板生成新的文件

configure_file() 指令还有许多格式化和文件权限选项。若感兴趣请查看在线文档以获取详细信息 (链接在扩展阅读部分)

5.4. 配置优化器

优化器将分析前一阶段的输出，并使用大量的技巧，开发者可能会认为这些技巧很脏，因为它们不遵守干净代码的原则

优化器的关键作用是提高代码的性能 (使用较少的 CPU 周期、较少的寄存器和较少的内存)

当优化器遍历源代码时，将对其进行大量转换，以至于几乎无法阅读，会变成为目标 CPU 专门准备的版本

优化器不仅将决定哪些函数可以删除或压缩，还会移动代码，甚至复制代码! 若能够完全确定某些代码行没有意义，其将从一个重要函数的中间删除(开发者不太会注意)

它将重用内存，因此许多变量可以在不同的时间段占用相同的插槽

若可以在这里或那里减少一些指令周期，把相应的控制结构转变成完全不同的结构。

这里描述的技术，若由程序员手动应用到源代码中，将会造成源代码变成可怕的、不可读的混乱符号集。很难阅读的同时，这些符号也很难写，也就更难于人为推演了。

另一方面，若编译器应用这些代码，其将完全按照所写的顺序进行

优化器是一头无情的野兽，只服务于一个目的: 使执行快速，无论输出将如何混乱

许多编译器默认情况下不会启用任何优化 (包括 GCC)，但在其他情况下就不是这样了

能快走为什么要慢走? 要更改这些内容，可以使用 target_compile_options() 指令，并确切地指定想从编译器获得的内容。

该指令的语法与本章其他指令类似:

target_compile_options(<target> [BEFORE]<INTERFACE|PUBLIC|PRIVATE> [items1…][<INTERFACE|PUBLIC|PRIVATE> [items2…] …])

target_compile_options() 是一个通用指令。还可以用来为类似编译器的-D 定义提供其他参数，为此 CMake 还提供了 target_compile_definition() 指令。总是建议尽可能使用CMake 指令，因为其在所有支持的编译器上以相同的方式工作。

5.4.1 优化级别

优化器的所有不同行为，都可以通过编译选项传递的特定标志进行配置

要了解所有这些方法挺花时间的，并且需要了解大量关于编译器、处理器和内存内部工作原理的知识

若只想要在大多数情况下运行良好的最佳可能场景，能做什么呢? 可以找到一个通用的解决方案——优化级说明符

大多数编译器提供了从 0 到 3 的四个基本优化级别，用-O<level> 选项来指定。-O0 表示不进行优化，通常这是编译器的默认级别

-O2 认为是完全优化，生成高度优化的代码，但以最慢的编译时间为代价

有一个介于两者之间的-O1 级别，这 (取决于需要) 可能是一个很好的折衷方案——其支持合理数量的优化机制，而不会大幅降低编译速度

可以使用-O3，这是完全优化，就像-O2 一样，但使用更积极的方法实现子程序内联和循环向量化

还有一些优化变量会优化生成文件的大小 (不一定是速度)，-Os

有一个超级激进的优化，-Ofast，不严格遵守 C++ 标准的-O3 优化。最明显的区别是-fast-math 和-ffinite-math 标志的使用，若程序是关于精确计算的 (大多数都是这样)，最好望不使用这个参数

CMake 了解不是所有的编译器都是相同的。因此，其通过为编译器提供一些默认标志来标准化开发人员的体验，存储在所用语言 (CXX 用于 C++) 和构建配置 (DEBUG 或RELEASE) 的系统范围(不是特定于目标的) 变量中:

• CMAKE_CXX_FLAGS_DEBUG 等于 -g• CMAKE_CXX_FLAGS_RELEASE 等于 -O3 -DNDEBUG

然后，可以通过添加更多标志来微调优化:

• 使用-f 选项启用它们: -finline-functions.• 使用-fno 选项禁用它们: -fno-inline-functions

5.4.2 函数内联

这是一种非常有趣的优化技术。其工作原理是，从有问题的函数中提取代码，并将其放在调用函数的所有位置，替换原始调用并节省宝贵的 CPU 周期

当然，内联有一些重要的副作用; 若函数多次使用，则必须将其复制到所有位置(意味着更大的文件大小和更多的内存使用)

除此之外，当调试代码时，会对我们产生严重影响。内联代码不再是其最初编写的行号，因此不容易 (有时甚至不可能) 跟踪

为了避免这个问题，需要为调试版本禁用内联 (代价是不能测试与发布版本完全相同)

可以通过为目标指定-O0 级别，或者直接在负责的标志后面执行:• -finline-functions-called-once: 只有 GCC 可用• -finline-functions: Clang 和 GCC 都可用• -finline-hint-functions: 只有 Clang 可用• -finline-functions-called-once: 只有 GCC 可用可以使用-fno-inline-…，显式禁用内联

5.4.3 循环展开

每个编译器提供的该标志版本略有不同:• -floop-unroll: GCC• -funroll-loops: Clang

注意，在 GCC 上是用-O3 会隐式使用-floop-unroll-and-jam 标志。

注意，在 GCC 上是用-O3 会隐式使用-floop-unroll-and-jam 标志

5.4.4 循环向量化

考虑下面的例子:int a[128];int b[128];// initialize bfor (i = 0; i<128; i++)a[i] = b[i] + 5;

前面的代码将循环 128 次，但若有一个功能强大的 CPU，可以通过同时计算数组中的两个或多个元素来更快地执行代码。这是可行的，因为连续的元素之间没有依赖关系，数组之间的数据也没有重叠

智能编译器可以将前面的循环转换为类似的东西 (发生在汇编级别):

for (i = 0; i<32; i+=4) {a[ i ] = b[ i ] + 5;a[i+1] = b[i+1] + 5;a[i+2] = b[i+2] + 5;a[i+3] = b[i+3] + 5;}

GCC 将在-O3 处启用这种循环的自动向量化，Clang 默认启用它。这两个编译器提供了不同的标志来启用/禁用向量化:

• -ftree-vectorize -ftree-slp-vectorize 在 GCC 中启用向量化• -fno-vectorize -fno-slp-vectorize 在 Clang 中禁用向量化

向量化的性能来自于利用 CPU 供应商提供的特殊指令，而不是简单地用展开版本替换原来的循环形式。

5.5. 编译过程

作为开发者和构建工程师，还需要考虑编译的其他方面——完成编译所需的时间，以及在构建解决方案的过程中发现和修复错误的难易程度。

5.5.1 减少编译时间

每天 (或每小时) 需要多次重新编译的繁忙项目中，尽可能快地编译是至关重要的。这不仅会影响代码编译-测试循环的紧凑程度，还会影响注意力和工作流程。

由于有独立的翻译单元，C++ 已经非常擅长管理编译时间。CMake 将只负责重新编译受最近更改影响的源代码

预编译头文件

头文件 (.h) 在实际编译开始之前由预处理器包含在翻译单元中，所以每次.cpp 实现文件更改时都必须重新编译。若多个翻译文件使用相同的共享头文件，那么每次包含它时都必须编译它

从 3.16 版本开始，CMake 提供了一个命令来启用头预编译。

这允许编译器将头文件与实现文件分开处理，从而加快编译速度。

target_precompile_headers(<target><INTERFACE|PUBLIC|PRIVATE> [header1…][<INTERFACE|PUBLIC|PRIVATE> [header2…] …])

添加的头文件列表存储在 PRECOMPILE_HEADERS 目标属性中。第 4 章已经介绍，可以使用PUBLIC 或 INTERFACE 关键字，通过传播的属性与依赖的目标共享，但对于通过 install() 指令导出的目标不行。其他项目不应该强制使用预编译的头文件。

若需要内部预编译头文件，并且仍然想安装-导出目标文件，$<BUILD_INTERFACE:…> 的生成器表达式将防止头文件出现在使用中，但仍然会添加到使用export() 指令从构建树导出的目标中。

CMake 将把所有头文件的名称放在一个 cmake_pch.h|xx 文件中，然后该文件将预编译为一个特定于编译器的二进制文件，扩展名为.pch、.gch 或.pchi。

统一构建

CMake 3.16 还引入了另一个编译时间优化特性——统一构建或巨型构建。统一构建用 #include指令组合多个实现源文件 (毕竟，编译器不知道包含的是头文件还是实现)。其中，有些是真的有用的，而另一些是潜在的有害的。

当这两个源文件都包含 #include ”header.h” 时，由于有头文件包含守卫，相应的头文件只会解析一次 (假设没有忘记添加这些守卫)。这没有预编译头文件那么优雅，但这是一个选项

这种类型构建的第二个好处是，优化器现在可以在更大的规模上执行，并在所有绑定的源之间优化过程间调用，这类似于链接时优化

然而，这些好处是有代价的。当减少了目标文件的数量和处理步骤时，也增加了处理更大文件所需的内存量。此外，减少了可并行工作的数量

编译器实际上并不擅长多线程编译——构建系统通常会启动许多编译任务，在不同的线程上同时执行所有文件。当把所有的文件聚集在一起时，这会使编译过程变得更加困难，因为 CMake 现在会在我们创建多少个大型构建之间调度并行构建

统一构建中，还需要考虑一些 C++ 语义含义，这些可能不太容易捕捉到——跨文件隐藏符号的匿名命名空间现在的作用域是组。静态全局变量、函数和宏定义也会发生同样的情况

要启用统一构建，有两个选项:

• 将 CMAKE_UNITY_BUILD 变量设置为 true ——在此之后，定义的每个目标上都会初始化UNITY_BUILD 属性。• 在每个应该使用统一构建的目标上手动设置 UNITY_BUILD 为 true。

第二个选项是通过以下函数实现的:set_target_properties(<target1> <target2> …PROPERTIES UNITY_BUILD true)

从 3.18 版本开始，可以决定显式地定义如何将文件与命名组捆绑在一起

为此，改变目标的UNITY_BUILD_MODE 属性为 GROUP(默认总是 BATCH)

然后，需要将源文件分配给组，通过设置他们的 UNITY_GROUP 属性为设置的名称:

set_property(SOURCE <src1> <src2>…PROPERTY UNITY_GROUP “GroupA”)

然后，CMake 将忽略 UNITY_BUILD_BATCH_SIZE，并将组中的所有文件添加到单个统一构建中。

不支持 C++20 的模块

若密切关注 C++ 标准发布，就应该了解 C++20 中引入的新特性——模块。这是一个重大的游戏规则改变者，其允许使用头文件时避免许多麻烦，减少构建时间，并允许更干净、更紧凑的代码，更容易浏览和推理

本质上，不需要创建单独的头文件和实现文件，而是创建一个带有模块声明的文件:

export module hello_world;import <iostream>;export void hello() {std::cout << “Hello world!\n”;}然后，可以通过导入使用:import hello_world;int main() {hello();}

注意，这里不再依赖于预处理器; 模块有自己的关键字——import、export 和 module

主流编译器的最新版本已经可以执行支持模块的所有必要任务

当这个备受期待的特性完成并在稳定版本中可用时，我建议深入研究它。希望它能够简化和加快编译速度，这是目前可用的方法都无法媲美的

5.5.2 查找错误

作为开发者，花了很多时间来寻找 bug。这是一个可悲的事实。

这就是为什么我们应该小心地设置环境，使这个过程尽可能简单。为此，需要使用target_compile_options() 配置编译器。那么，哪些编译选项可以帮助我们呢?

错误和警告的配置

软件开发中有很多压力很大的事情——在半夜修复关键的bug，在大型系统中处理高可见度、代价高昂的故障，处理烦人的编译错误，特别是那些难以理解或难以修复的错误。

一个很好的建议就是为所有构建启用-Werror 标志作为默认值。这个标志的作用非常简单——所有警告都视为错误，除非解决了所有警告，否则代码不会编译

虽然这看起来像是一个好主意，但这从来都不是一个好主意

警告不是错误是有原因的，这要由你来决定怎么做。开发者有忽视警告的自由，特别是当对解决方案进行试验和创建原型时，通常是一件好事。

另一方面，若有一段完美的、没有任何警告的、完美的代码，未来的修改破坏这种状态就太可惜了

用警告视为错误，并持续使用有什么坏处呢? 似乎没有。至少在编译器升级之前是这样

最简单的答案是，当在编写一个公共库时

然后，真的希望避免因为代码是在更严格的环境中编译而发出抱怨，抱怨代码不规范

若决定启用它，请确保跟上了编译器的新版本，及其引入的警告。

若觉得内部需要学究气，请使用-Wpedantic 标志。这是一个有趣的选项——启用了严格的 ISO C 和 ISO C++ 要求的所有警告

请注意，不能使用此标志检查代码是否符合标准——其只会查找需要诊断消息的非 ISO 实践。

更宽容和接地气的开发者将满足-Wall 和可选的-Wextra，这些是认为是非常有用和有意义的警告。

调试构建

有时候，编译会崩溃。这通常发生在我们试图重构一堆代码或清理构建系统时。

我们已经知道如何打印更详细的CMake 输出，但是如何分析每个阶段实际发生的事情呢?各个阶段的调试有一个-save-temps 标志可以传递给编译器 (GCC 和 Clang 都有)，将强制每个阶段的输出存储在一个文件而不是内存中:

上面的代码段通常会产生两个文件:• <buildtree>/CMakeFiles/<target>.dir/<source>.ii: 存储预处理阶段的输出，用注释解释源代码的每个部分来自哪里:

• <buildtree>/CMakeFiles/<target>.dir/<source>.s: 语言分析阶段的输出，为汇编阶段做好准备:

头文件的调试问题

错误包含的文件是一个非常难调试的问题

这是我在公司的第一份工作，将整个代码库从一个构建系统移植到另一个。若发现自己处于一个需要精确理解哪些路径用来包含请求的头文件的位置，可以使用-H:

chapter05/07-debug/CMakeLists.txtadd_executable(debug hello.cpp)target_compile_options(debug PRIVATE -H)

目标文件名之后，输出中的每一行都包含到头文件的路径。行首的一个点表示顶层包含 (#include指令在 hello.cpp 中)。两个圆点表示该文件包含在 <iostream>中。每一个进一步的点表示另一个嵌套级别。

若是一个特别有动力的人，可以使用一个叫做反汇编的工具，有了大量的知识 (和一点运气)，就能理解可能发生的事情。

相反，可以要求编译器将源代码存储在生成的二进制文件中，以及包含已编译代码和原始代码之间引用的映射

可以将调试器与正在运行的程序挂钩，并查看在任何给定时刻正在执行哪一行源程序

这两个用例是两个配置的原因:Debug 和 Release。CMake 会在默认情况下向编译器提供一些标志来管理这个过程，首先将它们存储在全局变量中:

• CMAKE_CXX_FLAGS_DEBUG 包含 -g• CMAKE_CXX_FLAGS_RELEASE 包含 -DNDEBUG

-g 标志仅仅表示添加调试信息，以操作系统的本机格式提供——stabs、COFF、XCOFF 或DWARF。这些格式可以用诸如 gdb(GNU 调试器) 这样的调试器访问，这对于像 CLion 这样的 IDE已经足够好了 (底层使用 gdb)

对于 RELEASE 配置，CMake 将添加-DNDEBUG 标志。这是一个预处理器定义，表明不是调试构建。启用此选项时，一些面向调试的宏可能无法工作。其中之一是 assert，在 <assert.h> 头文件中可用

在练习断言式编程，但仍然需要在发布版本中使用 assert()，该怎么办? 要么改变 CMake 提供的默认值 (从 CMAKE_CXX_FLAGS_RELEASE 中移除NDEBUG)，要么通过在包含头文件之前取消宏的定义:

#undef NDEBUG#include <assert.h>

5.6. 总结

毫无疑问，编译是一个复杂的过程。对于所有的边缘案例和特定的需求，若没有一个好的工具，管理起来会很困难，CMake 在这方面支持得很好。

首先讨论了什么是编译，以及在构建和运行操作系统中的应用程序方面的位置

然后，研究了编译的各个阶段，以及管理它们的内部工具。这对于解决在更高级的情况下可能遇到的所有问题非常有用

然后，研究了如何要求 CMake 验证主机上可用的编译器，是否满足要构建的代码的所有必要要求。

然后，讨论了优化器，探讨了优化的所有一般级别以及它们所暗示的标志类型，也详细讨论了其中的一些级别——finline、flop-unroll 和 ftree-vectorize。

最后，研究如何管理编译的可行性了。

这里讨论了两个主题——减少编译时间 (通过扩展，加强开发者的注意力) 和查找错误

第 6 章 进行链接

就会发现 CMake 并没有提供那么多与链接相关的指令。不可否认，target_link_libraries() 是真正配置此步骤的指令。那么，为什么要用一整章的篇幅来阐述一条命令呢?在计算机科学中没有容易的东西，链接操作也不例外

我们将讨论目标文件的内部结构，重定位和引用解析如何工作，以及其用途

我们将讨论最终可执行文件与它的组件之间的区别，以及系统如何复刻构建流程

然后，我们将向您介绍各种库——静态、动态和模块，它们都称为库，但几乎没有什么相似之处

构建正确链接的可执行文件很大程度上依赖于有效的配置(并注意位置无关代码 (PIC) 等小细节)。

理重复的符号有时是非常棘手的，特别是使用动态库时。然后，将了解为什么链接器有时无法找到外部符号，即使在可执行文件与适当的库链接时也是如此

最后，将了解如何节省时间，并使用链接器来准备使用专用框架进行测试的解决方案。

6.2. 掌握正确的链接方式

在第 5 章中讨论了 C++ 程序的生命周期，由五个主要阶段组成——编写、编译、链接、加载和执行

这些区段非常类似于可执行文件的最终版本，其将放入 RAM 中以运行我们的应用程序，但不能直接将这个文件加载到内存中。因为每个目标文件都有自己的一组区段。若只是把它们连在一起，就会遇到各种各样的问题。将浪费大量的空间和时间，因为需要更多的 RAM 页，指令和数据将很难复制到 CPU 缓存中。整个系统必须要复杂得多，并且会浪费宝贵的 CPU 周期，在运行时跳过许多 (可能是数万个).text、.data 和其他部分。

我们要做的是把对象文件的每个部分，和所有其他对象文件中相同类型的部分放在一起

这个过程称为重定位 (这就是 ELF 文件类型为目标文件重定位的原因)。

其次，链接器需要解析引用

每当来自翻译单元的代码引用另一个翻译单元中定义的符号时(例如：通过包含其头或使用 extern 关键字)，编译器读取该声明并相信定义就在某个地方，稍后将提供该定义

链接器负责收集这些对外部符号的未解析引用，查找并填充它们在合并到可执行文件后驻留的地址

若开发者不知道其是如何工作的，这部分链接可能是问题的来源。最终可能会得到无法解析的引用，这些引用找不到外部符号，或者恰恰相反——提供了太多的定义，链接器不知道选择哪一个

6.3. 构建不同类型的库

编译源代码之后，可能希望避免在同一个平台上再次编译，甚至尽可能地与外部项目共享

可以简单地将所有对象文件放到一个对象中并共享。可以用一个简单的 add_library() 指令创建这些库 (与 target_link_libraries() 一起使用)

按照惯例，所有库都有共同的前缀 lib，并使用特定于系统的扩展来表示它们是哪种类型的库:• 静态库在类 Unix 系统上的后缀为.a，在 Windows 上的后缀为.lib。• 动态库在类 Unix 系统上的后缀为.so，在 Windows 上的后缀为.dll。

在 构 建 库 (静 态、 动 态 或 模 块) 时， 经 常 会 遇 到 此 过程 的 名 称 链 接

与看起来不同的是，链接器并不是用来创建前面所有的库的。执行重定位和引用解析也有例外。

6.3.1 静态库

add_library(<name> [<source>…])

若 BUILD_SHARED_LIBS 变量没有设置为 ON，前面的代码将生成一个静态库

什么是静态库? 本质上是存储在存档中的原始对象文件的集合。类 Unix 系统上，可以通过 ar工具创建此类库

静态库是提供代码编译版本的最古老和最基本的机制

静态库可能包含一些额外的索引，以加快最终的链接过程。每个平台都使用自己的方法来生成这些内容。类 Unix 系统使用 ranlib 工具来实现。

6.3.2 动态库

add_library(<name> SHARED [<source>…])

也可以通过设置 BUILD_SHARED_LIBS 变量为 ON 并使用短版本来实现:

与静态库的区别很明显。动态库是使用链接器构建的，将执行链接的两个阶段。

个操作系统会将这样一个库的单个实例与第一个使用它的程序一起加载到内存中，所有随后启动的程序都将提供相同的地址(这要感谢虚拟内存的复杂机制)

只有.data 和.bss 段将分别为使用库的每个进程创建 (以便每个进程可以修改自己的变量而不影响其他使用者)。

6.3.3 模块库

要构建模块库，需要使用 MODULE 关键字:add_library(<name> MODULE [<source>…])

这 是 动 态 库 的 一 种， 目 的 是 作 为 运 行 时 加 载 的 插 件使 用， 而 不 是 在 编 译 过 程 中 链 接 到可 执 行 文 件

共 享 模 块 不 会 在 程 序 启 动 时 自 动 加 载(像普 通 的 共 享 库 一 样)

只 有 程 序 通 过LoadLibrary(Windows) 或 dlopen()/dlsym() (Linux/macOS) 等系统调用显式地请求它时，才会使用的到。

不应该尝试将可执行文件与模块链接起来，因为这并不能保证在所有平台上都能工作。若需要这样做，请使用动态库

6.3.4 位置无关的代码

所有共享库和模块的源代码都应该在编译时启用位置无关代码标志。CMake 检查目标的POSITION_INDEPENDENT_CODE 属性，并适当添加特定于编译器的编译标志，如 gcc 或 clang的-fPIC

PIC 是关于将符号 (对函数和全局变量的引用) 映射到其运行时地址

译库期间，不知道哪些进程可能会使用。不可能预先确定库将在虚拟内存中的什么位置或以什么顺序加载。所以符号的地址是未知的，与库机器码的相对位置也是未知的

为了解决这个问题，需要另一种间接方式。PIC 将向我们的输出添加一个新部分——全局偏移表 (GOT)

只有在第一次执行访问引用符号的指令时，内存中指向符号的实际值才会填充。这时，加载器将在GOT 中设置该特定条目 (这就是术语延迟加载的来源)。

6.4. 用定义规则解决问题

6.4.1 动态链接的重复符号

## 第二部分：进行构建

> 开发者需要遵循ODR。

==单一定义规则ODR==

#### 6.5. 连接顺序和未定义符号

6.4.2 使用命名空间——不要依赖链接器

6.5. 连接顺序和未定义符号

链接器经常会异想天开，毫无理由地抱怨事情。对于刚开始使用这个工具的开发者来说，这是一项考验。

target_link_libraries(main nested outer)

那么，对’b’ 错误的未定义引用是从哪里来的呢?解析未定义符号的工作方式是这样的——链接器从左向右处理二进制文件。

我们确实正确地解析了对 a 变量的引用，但对 b 没有。需要做的是颠倒链接的顺序，使 nested排在 outer 之后:target_link_libraries(main outer nested)

另一个不那么优雅的选项是重复库 (这对循环引用很有用):target_link_libraries(main nested outer nested)

6.6. 分离 main() 进行测试

链接器会执行 ODR，并确保所有外部符号在链接过程中提供的定义。我们可能会遇到的问题是，构建的正确测试。
主要目标只是提供所需的 main() 函数，包含所有逻辑的程序目标。现在，可以通过创建另一个可执行文件，以及包含测试逻辑的 main() 来测试它。
现实场景中，GoogleTest 或 Catch2 等框架会提供 main()，可用于替换程序的入口点并运行所有已定义的测试
