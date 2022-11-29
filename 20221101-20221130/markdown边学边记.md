本文件是由问题导向而记录下来的

### 如何在 markdown 中表示矩阵？

> https://zhuanlan.zhihu.com/p/269245898

1. 基本语法
· 数学公式放在 $$ 之间。
· 起始标记 \begin{matrix}，结束标记 \end{matrix} 。
· 每一行末尾标记 \\，行间元素之间用 & 分隔。

$$\begin{matrix}
0&1&1\\
1&1&0\\
1&0&1\\
\end{matrix}$$

2. 括号
在起始、结束标记用下列词替换 matrix
pmatrix：小括号边框
bmatrix：中括号边框
Bmatrix：大括号边框
vmatrix：单竖线边框
Vmatrix：双竖线边框

$$\begin{bmatrix}
0&1&1\\
1&1&0\\
1&0&1\\
\end{bmatrix}$$

$$\begin{vmatrix}
0&1&1\\
1&1&0\\
1&0&1\\
\end{vmatrix}$$

$$\begin{Vmatrix}
0&1&1\\
1&1&0\\
1&0&1\\
\end{Vmatrix}$$

3. 省略元素
横省略号：\cdots
竖省略号：\vdots
斜省略号：\ddots

$$\begin{bmatrix}
{a_{11}}&{a_{12}}&{\cdots}&{a_{1n}}\\
{a_{21}}&{a_{22}}&{\cdots}&{a_{2n}}\\
{\vdots}&{\vdots}&{\ddots}&{\vdots}\\
{a_{m1}}&{a_{m2}}&{\cdots}&{a_{mn}}\\
\end{bmatrix}$$

4. 阵列
略

5. 方程组
需要cases环境：起始、结束处以{cases}声明

$$\begin{cases}
a_1x+b_1y+c_1z=d_1\\
a_2x+b_2y+c_2z=d_2\\
a_3x+b_3y+c_3z=d_3\\
\end{cases}
$$