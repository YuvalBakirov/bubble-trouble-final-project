# bubble-trouble-final-project

Game development final project in Software Engineering College

## Introduction

In this project I implemented my OOP, C# and game development knowledge that I got to learn during the thirteenth grade of Software Engineering at Hakfar Hayarok College.
This is a 2D game ran using Monogame (open-source and cross-platform game development framework) and XNA framework integrated within it. 
</br>
"Bubble Trouble" is a two-dimensional game with artificial intelligence (Bot) in which two characters compete with each other.￼￼￼
The main goal of the game is to hit as many of your balls as possible in order to gain a higher score.
Each player has health and a number of points.
A game ends as soon as one of the players runs out of life or as soon as the time runs out, and the player with the higher score wins. 


## Screenshots

<img width="452" alt="image" src="https://github.com/YuvalBakirov/bubble-trouble-final-project/assets/38374216/d5fcc47e-a483-415f-a013-2ec9fabb7d65">
<img width="452" alt="image" src="https://github.com/YuvalBakirov/bubble-trouble-final-project/assets/38374216/34b4b41b-40c8-41d1-b71d-ede9d27d5c50">
<img width="452" alt="image" src="https://github.com/YuvalBakirov/bubble-trouble-final-project/assets/38374216/82ca7a3e-2584-44c2-bf08-8dec2c584214">
<img width="452" alt="image" src="https://github.com/YuvalBakirov/bubble-trouble-final-project/assets/38374216/d75e3eb2-0aa0-455f-ad6a-6014eb811dfc">
<img width="452" alt="image" src="https://github.com/YuvalBakirov/bubble-trouble-final-project/assets/38374216/3dbd7414-006b-49cb-8eab-bace909892fd">
<img width="452" alt="image" src="https://github.com/YuvalBakirov/bubble-trouble-final-project/assets/38374216/f265023b-10eb-4ade-93a7-a8646ce0a5bc">
<img width="112" alt="image" src="https://github.com/YuvalBakirov/bubble-trouble-final-project/assets/38374216/c8c23408-03cf-4019-8cf5-b5642ed72722">
<img width="112" alt="image" src="https://github.com/YuvalBakirov/bubble-trouble-final-project/assets/38374216/9937482e-4809-4ee6-9283-cab23467c4a7">

## The progress of the game

In the game map there are balls in four colors, (red, blue, black and yellow). </br>
The red ball belongs to me while the blue ball belongs to the bot accordingly. The yellow ball, on the other hand, belongs to both players and its main purpose is to change the scoring structure of the players and to add some action and leave a chance for the loser. The black ball is a rolling ball that appears every half minute which cannot be hit, its purpose is to hit the players legs and take their lives. </br>
A player can only shoot an arrow while standing on the ground and not moving. Hitting any of the balls (red, blue and yellow), will cause the ball to explode into two more balls twice as small. Of course, a player hitting the opponent's ball will not blow up his ball.
A shot can only be fired once there is no shot in the air. You can fire several shots at the same time only when you grabbed a box that contains the option to fire one more shot at the same time (up to three shots at the same time). </br>
During the game, boxes fall from the sky. There are five types of boxes, plus life, minus life, plus score, minus score, plus shot and freezes the player. A box falls to the ground and disappears only when a similar box is drawn to fall again.</br>
The player has 1000 lives. A normal bullet hit will give 50 points, but if the ball hits you, you drop down 50 health. A yellow ball is a ball whose number of lives it takes and the number of points it brings at the moment of impact is random between 0-100. A black ball will drop 20 health and cannot add score. A box of score and life lowers or increases 50 life/score.










