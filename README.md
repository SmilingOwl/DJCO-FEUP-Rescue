# FEUP Rescue

Project for the Computer Games Development (DJCO) class of the Master in Informatics and Computer Engineering (MIEIC) at the Faculty of Engineering of the University of Porto (FEUP).

- [Game Concept](#1.-game-concept)
- [Playing Instructions](#playing-instructions)
- [Screenshots](#screenshots)
- [Development Environment and Installation](#development-environment-and-installation)
- [Promotional Video](#promotional-video)


Game developed by [Helena Montenegro](https://github.com/helenaMontenegro) and [Juliana Marques](https://github.com/SmilingOwl).

## 1. Game Concept 

FEUP Rescue is a 2D horizontal side-scrolling game developed in Unity.
The game is set at FEUP, where a group of 5 thieves is stealing computers. The goal is to defeat all the thieves while recovering the stolen computers. During the gameplay, the player will come across various obstacles, some of which might hurt him, and power-ups found at FEUP to help him win.


### 1.1. Premise 

***“Oh no! FEUP is being assaulted by thieves. They are taking all the computers! You are the only one who can stop them! Run through FEUP and defeat all the five thieves, while retrieving the stolen computers and avoiding the obstacles you’ll find in the way. But be careful, the thieves have dropped spikes on the floor to hurt you!”***


## 2. Playing Instructions
### 2.1. Player Movement

The player moves with the arrows in the keyboard or with A and D keys. He can move to the right and to the left, as well as jump using the up arrow or W key. The player can also attack by using the space key.


### 2.2. Obstacles

The player has to jump over the following obstacles:
The benches and dustbins are objects already available at FEUP, while the spikes are dropped by the thieves in order to hurt the player. If the player collides with spikes, he loses some of his life.


### 2.3. Collectables and Power-Ups

During the game, the player can collect many objects, simply by colliding with them:
* The **computer** is meant to be collected and contributes to the score of the game.
* The **coffee** makes the player faster, increasing his velocity for 2 seconds.
* The **apple** regenerates the player’s life.
* The **orange juice** makes the hero immune to any damage for 2 seconds.
* The **bomb** can be used to defeat a thief. The bomb is thrown to the nearest thief using the B key.


### 2.4. Enemies

The player has to defeat **5 thieves**. The thieves attack the hero with a bat when he comes close.
The player can attack the thief by punching him, using the space key. When the player has a bomb, he can use it on the nearest thief using the key B, which defeats automatically the thief.


### 2.5. Game Victory

The player **wins** when he defeats all **5 thieves**. Once the player wins, the score is calculated, taking into account the number of computers the player has recovered, whether or not he found the bomb and, on the time that the player needed to win the game.


### 2.6. Game Over

The player **loses** if:
* He lets a thief escape without defeating him.
* He loses all his life.
* He gets thrown out of the screen by being dragged by an obstacle or by a thief.


### 2.7. Pause Menu

The player can pause the game by clicking ESC. To restart the game, the player can either click on ESC again, or use the mouse to click on the Restart button on the Pause Menu.

## 3. Screenshoots
<img src="https://github.com/helenaMontenegro/DJCO-FEUP-Rescue/blob/master/FEUP%20Rescue/Screenshots/mainMenu.PNG" width="800"><br><br>
<img src="https://github.com/helenaMontenegro/DJCO-FEUP-Rescue/blob/master/FEUP%20Rescue/Screenshots/print1.png" width="800"><br><br>
<img src="https://github.com/helenaMontenegro/DJCO-FEUP-Rescue/blob/master/FEUP%20Rescue/Screenshots/print3.png" width="800"><br><br>

## 4. Development Environment and Installation

The game was developed using Unity 2D, with version: 2019.3.2f1

To play the game, simply run the file “FEUP Rescue.exe”.

**Happy gamming and turn on the sound!!**

## 5. Promotional Video

[Video](https://www.youtube.com/watch?v=whh4L6wxcsk)
