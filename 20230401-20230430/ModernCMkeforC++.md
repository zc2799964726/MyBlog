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

