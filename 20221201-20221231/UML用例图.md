### UML图10种

> 参考：https://plantuml.com/zh/guide

#### 1用例图

用例
用例用圆括号括起来（两个圆括号看起来就像椭圆）。
也可以用关键字 usecase 来定义用例。还可以用关键字 as 定义一个别名，这个别名可以在以后定义关
系的时候使用。
@startuml
(First usecase)
(Another usecase) as (UC2)
usecase UC3
usecase (Last\nusecase) as UC4
@enduml

角色用两个冒号包裹起来。
也可以用 actor 关键字来定义角色。还可以用关键字 as 来定义一个别名，这个别名可以在以后定义关
系的时候使用。

火柴人 默认
@startuml
:First Actor:
:Another\nactor: as Man2
actor Woman3
actor :Last actor: as Person1
@enduml

用户头像
@startuml
skinparam actorStyle awesome
:User: --> (Use)
"Main Admin" as Admin
"Use the application" as (Use)
Admin --> (Admin the application)
@enduml

用箭头--> 连接角色和用例。
横杠-越多，箭头越长。通过在箭头定义的后面加一个冒号及文字的方式来添加标签。

#### 2类图

见 类关系.md

#### 3对象图
(感觉和类图很像)
使用关键字 object 定义实例。
@startuml
object firstObject
object "My Second Object" as o2
@enduml

@startuml
object Object01
object Object02
object Object03
object Object04
object Object05
object Object06
object Object07
object Object08
Object01 <|-- Object02
Object03 *-- Object04
Object05 o-- "4" Object06
Object07 .. Object08 : some labels
@enduml

用冒号加属性名的形式声明属性。
也可以用大括号批量声明属性

@startuml
object user
user : name = "Dummy"
user : id = 123
@enduml

@startuml
object user {
name = "Dummy"
id = 123
}
@enduml

#### 4时序图
plantUML的例子
https://plantuml.com/zh/sequence-diagram

有一个在线的网站看可以在线画时序图
https://www.websequencediagrams.com/
例子
@startuml
== 初始化 ==
note left of 用户 #FFAAAA
用户登录
end note

用户 -> 认证中心: 登录操作
|||
认证中心 -> 缓存: 存放(key=token+ip,value=token)token
|||
用户 <- 认证中心 : 认证成功返回token
用户 -> 认证中心: 下次访问头部携带token认证
|||
认证中心 <- 缓存: key=token+ip获取token
|||
其他服务 <- 认证中心: 存在且校验成功则跳转到用户请求的其他服务
|||
其他服务 -> 用户: 信息
@enduml

关键字 activate 和 deactivate 用来表示参与者的生命活动。
一旦参与者被激活，它的生命线就会显示出来。
@startuml
participant User
User -> A: DoWork
activate A
A -> B: << createRequest >>
activate B
B -> C: DoWork
activate C
C --> B: WorkDone
destroy C
B --> A: RequestCreated
deactivate B
A -> User: Done
deactivate A
@enduml

也可以使用自动激活关键字（autoactivate），这需要与 return 关键字配合：

@startuml
autoactivate on
alice -> bob : hello
bob -> bob : self call
bill -> bob #005500 : hello from thread 2
bob -> george ** : create
return done in thread 2
return rc
bob -> george !! : delete
return success
@enduml


包裹参与者
可以使用 box 和 end box 画一个盒子将参与者包裹起来。
还可以在 box 关键字之后添加标题或者背景颜色。

@startuml
box "Internal Service" #LightBlue
participant Bob
participant Alice
end box
participant Other
Bob -> Alice : hello
activate Alice
Alice -> Other : hello
@enduml

#### 5活动图

使用 (*) 作为活动图的开始点和结束点。
有时，可能想用 (*top) 强制开始点位于图示的顶端。
使用--> 绘制箭头。

@startuml
(*) --> "First Activity"
"First Activity" --> (*)
@enduml

可以使用-> 定义水平方向箭头，还可以使用下列语法强制指定箭头的方向：
• -down-> (default arrow)
• -right-> or ->
• -left->
• -up->

可以使用关键字 if/then/else 创建分支。

@startuml
(*) --> "Initialization"
if "Some Test" then
-->[true] "Some Activity"
--> "Another activity"
-right-> (*)
else
->[false] "Something else"
-->[Ending process] (*)
endif
@enduml

用关键字 partition 定义分区，还可以设置背景色 (用颜色名或者颜色值)。
定义活动的时候，它自动被放置到最新的分区中。
用} 结束分区的定义。

@startuml
partition Conductor {
(*) --> "Climbs on Platform"
--> === S1 ===
--> Bows
}
partition Audience #LightSkyBlue {
=== S1 === --> Applauds
}
partition Conductor {
Bows --> === S2 ===
--> WavesArmes
Applauds --> === S2 ===
}
partition Orchestra #CCCCEE {
WavesArmes --> Introduction
--> "Play music"
}
@enduml

#### 6状态图

使用 ([*]) 开始和结束状态图。
使用--> 添加箭头。

@startuml
[*] --> State1
State1 --> [*]
State1 : this is a string
State1 : this is another string
State1 -> State2
State2 --> [*]
@enduml

#### 7部署图

声明元素

@startuml
actor actor
agent agent
artifact artifact
boundary boundary
card card
cloud cloud
component component
control control
database database
entity entity
file file
folder folder
frame frame
interface interface
node node
package package
queue queue
stack stack
rectangle rectangle
storage storage
usecase usecase
@enduml

可以在元素之间创建简单链接

@startuml
node node1
node node2
node node3
node node4
node node5
node1 -- node2
node1 .. node3
node1 ~~ node4
node1 == node5
@enduml