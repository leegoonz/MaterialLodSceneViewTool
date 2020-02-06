# MaterialLodSceneViewTool
MaterialLodSceneViewTool are provide to non-playing mode on SceneView editor When changing materials Lod list for preview results own your characters.
MATERIALS LOD FOR INGAME PLAY.
Organization / Netease Pangu Studio Technical Art Team.
Author / JP.Lee

Commit schedule : 2016-9-26.

To be honest, this is already four years ago.
Most recently I do not use this method.
Because many easier methods have already been discovered.

老实说，这已经是四年前了。
最近我不使用这种方法。
因为已经发现了许多更简单的方法。

Overview
What is this have purpose of requirement.
In the game, according to the change of the quality template set by the user, the calculation quality of the Shader used in the game, the type of Shader, etc. will be automatically changed. The change materials has decided to use Shader LOD and Material Quality Phase Set (based on the quality setting, it will be replaced with a predefined Material).
The advantages are relatively simple to achieve overall.
Disadvantages are fine-thinking about the management of Material.

游戏中，根据用户设置的品质模板的改变，游戏中使用的Shader的运算品质，Shader的种类等，都会自动变更。变更要素已经决定使用Shader LOD和Material Quality Phase Set（根据品质设定，会更换成预先定义的Material）。
优点整体实现较为简单。
缺点美术得对Matrial的管理费点心思。


Shader structure of QUALITY PHASE.


Depending on the distance, you can use shaders optimized for each quality. # Performance issues # Metal roughness values have a performance difference of about 25% When using variables instead of textures. You need to divide the quality level and the LOD level, set the rules and use the variable parameters.
随着距离的不同，可以使用根据各品质别设置的灯光模型的优化Shader。#性能问题#Metallic Roughness值上面使用贴图和使用变量参数，性能上有25%左右的差别。我们要划分好品质等级和LOD等级，定好规则，使用变量参数。

美术材质球品质设置脚本
<img src="https://leegoonzblog.files.wordpress.com/2020/02/image-3.png" width="90%"></img>
