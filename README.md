# Poseidon
Poseidon is an underwater endless shooter where your bullets bite back! Survive as long as possible against waves of angry pufferfish and try not to get overwhelmed!

**Link to project:** https://justice-bole.itch.io/poseidon

![alt tag](https://github.com/justice-bole/Poseidon/blob/main/PoseidonProject/Assets/Art/Gifs/Poseidon.gif)

## How It's Made:

**Tech used:** Unity, C#, Aseprite.

I used Unity game objects like "RigidBody2D", "Camera", and "SpriteRenderer", as well as types like "Vector2" and libraries such as "Mathf" to script behavior like 
movement and shooting. I used interfaces to help simplify behavior like eating and damage, as long as objects use the interface it guarantees they have, for 
example, a damage function that can be called upon and executed when certain conditions are met, this lets multiple objects handle damage in different ways 
while still being compatible with any methods that call the damage function, like when something is hit with a bullet. I used TextMeshPro for text and 
other UI elements like buttons, as well as Unity's canvas object. The players health, survival time, title screen, and game over screen, use the aforementioned
features. For this project I used Aseprite to create all of the art assets myself, including sprites and animations. I used Unity's built in Animator component to 
setup animations and behavior, so that when the player shoots, for example, a "shooting" animation plays, and stops when the player stops shooting. 
I also used the built in particle system to create the particles seen when the player is "eating" or sucking in the water around them. Lastly, I used the 
"SceneManager" to load new scenes, like the game scene and the title scene.

## Lessons Learned:

In this project I implemented more math functions, like calculating where the mouse position is relative to the player position and then getting the player to 
face the mouse position. I also used math to instantiate fish facing outward in a uniform circle around recently defeated pufferfish using trigonometry. 
These functions helped me think more about how math can be applied to game mechanics and behaviors which, in my opinion, is very important in game 
development. Creating complex and interesting patterns for bullets or enemies to travel in often requires creative thinking and math, which I plan to utilize 
more of in my future projects.

## Other Projects:
Take a look at these other projects in my portfolio:

**Tower Knights:** https://github.com/justice-bole/Tower-Knights

**FPS-Controller:** https://github.com/justice-bole/FPS-Controller

**Lissajous Curves:** https://github.com/justice-bole/Python-Projects/tree/main/ProcessingScripts/lissajous_curves
