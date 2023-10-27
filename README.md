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

In the game there are balls in four colors (red, blue, black and yellow). </br>
The red ball belongs to us while the blue ball belongs to the bot. The yellow ball belongs to both players and its main purpose is to add some action. The black ball is a rolling ball that appears every half minute which cannot be hit, its purpose is to hit the players legs to drop their health down. </br>
A shot can only be fired once there is no shot in the air.
A player can only shoot an arrow while standing on the ground and not moving. Hitting any of the balls (red, blue and yellow), will cause the ball to explode into two smaller balls. Note that a player hitting the opponent's ball will not blow up its ball.
During the game, boxes fall from the sky. There are five types of boxes, plus health, minus health, plus score, minus score, plus shot and to freeze the player. 
When you grabbed a box "plus shot", you can fire several shots at the same time (up to 3 shots). 
The box of "minus/plus score/health" lowers or increases 50 score/health. 
The box that freezing a player freezes him for a couple of seconds.</br>
A player has 1000 health.</br>
A normal bullet hit will give you 50 points, but if the ball hits you - you drop down 50 health. A yellow ball is a ball which the health it takes and the number of points it gives you is a random number between 0-100. A black ball will drop your health down by 20. </br>
Good Luck!










