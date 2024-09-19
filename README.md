[![Build Status](https://codefirst.iut.uca.fr/api/badges/cyprien.forge/SAE2.01/status.svg)](https://codefirst.iut.uca.fr/cyprien.forge/SAE2.01)  
[![Duplicated Lines (%)](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=SAE201&metric=duplicated_lines_density&token=f95119286a2026a0c4863eec53ce412523335144)](https://codefirst.iut.uca.fr/sonar/dashboard?id=SAE201)

# Dou Shou Qi - SAE2.01

![Title](Images/DouShouQi_Title.png)

## Presentation

Click on the link below to watch a video of our Dou Shou Qi game

| [DouShouQi Trailer](https://opencast.dsi.uca.fr/paella/ui/watch.html?id=e553be22-2ce0-4ab7-b346-0dd5f9f4b6ac) |
| -- |

<iframe src="https://opencast.dsi.uca.fr/paella/ui/watch.html?id=e553be22-2ce0-4ab7-b346-0dd5f9f4b6ac" width="530" height="315" frameborder="0" scrolling="no" marginwidth="0" marginheight="0" allowfullscreen="true" webkitallowfullscreen="true" mozallowfullscreen="true" allowfullscreen> </iframe>


## Context

As part of our SAE2.01, we're in charge to concept an application based on a board game named "Dou Shou Qi".

The different resources got to be develop in C#, .NET and XAML.

This project is definitly organized around a few milestone dates for each tasks.

The deliverables are actually a functional console application and a graphical user interface.

## Organization and Resources

### Part 1 : Design of the app and views

The objective of this first part is to define our application and views in XAML.

* [App context]([https://codefirst.iut.uca.fr/git/cyprien.forge/SAE2.01/wiki/Contexte](https://github.com/CyprienForge/DouShouQi/wiki/Contexte))
* [Personas](https://codefirst.iut.uca.fr/git/cyprien.forge/SAE2.01/wiki/Personas)
* [User stories](https://codefirst.iut.uca.fr/git/cyprien.forge/SAE2.01/wiki/Personas)
* [Sketchs](https://codefirst.iut.uca.fr/git/cyprien.forge/SAE2.01/wiki/Sketch)
* [Storyboards](https://codefirst.iut.uca.fr/git/cyprien.forge/SAE2.01/wiki/Storyboard)
* [Use Case](https://codefirst.iut.uca.fr/git/cyprien.forge/SAE2.01/wiki/Diagramme-de-cas-d%27utilisation)

### Part 2 : Conception and programming the model

The purpose of this second part is to design our app by making some UML diagrams and program the operation of our application (model) in C#.

* [Package diagram](https://codefirst.iut.uca.fr/git/cyprien.forge/SAE2.01/wiki/Diagramme-de-paquetage)
* [Class diagram](https://codefirst.iut.uca.fr/git/cyprien.forge/SAE2.01/wiki/Diagramme-de-classe)
* [Sequence diagram](https://codefirst.iut.uca.fr/git/cyprien.forge/SAE2.01/wiki/Diagramme-de-s%C3%A9quence)
* [Architecture description](https://codefirst.iut.uca.fr/git/cyprien.forge/SAE2.01/wiki/Description-de-l%27architecture-de-l%27application)

### Part 3 : Link between views and model of the app

The goal here is to finally join the views made during the first part to the model and the operation of the app realized in the second part, by using the Data Binding in XAML and C#.

We have to make sure the user could navigate between pages, display data and have the ability to edit it, and more.

The two important sub-parts are the management of user actions and data binding.  

### Part 4 : Data persistance and personal adds

In this part of this project, we need to make sure that the data is kept. 

Changes made by the user aren't supposed to be lost every time he leaves the application.

In the case of the Dou Shou Qi, it permits the user to save and load a game. This is an essential feature.

The data persistence can take many different forms : 

* Binary
* Text
* XML
* JSON
* Database
* ...

Moreover, we can also add personal features to make the application more interesting.

### Part 5 : Testing, Documentation and Continuous Integration

This part consists of creating functional tests, unit tests, automatically generate the documentation during generating, and overall automate everything by continuous integration 

* Test model, data persistence and personnal feature
* Automatically manage and generate  the code documentation in html format (with doxygen) 
* Automate these tests into a continuous integrations flow

In reality, this part is hidden to users.
It only serves to devs for upgrading the quality, the code production and the team work.

Furthermore, tests goal is to find out the bugs rather than users to discover them. 

The CI (Continuous Integration) permits to automate compilation tests and unit tests execution on a server. Additionally, this allows a feedback on the code quality.

And the CD (Continuous Deployment) makes it possible to generate for each commit (git) the technical documentation.

### Part 6 : Deployment

The application must be followed by its installer allowing its deployment on each machine with the targeted OS.

Therefore, the app should :

* Compile
* Run without bugs (the least possible)
* Can be installed
* Be as successful as possible

### Part 7 : Promotional video

Finally, we must provide a 1-3' video of our app. There is a double goal :

* Add value to our CV
* Present our team work

### Conception

You must find all the conception elements in the Wiki page, wishing you a nice discovering !

### Personal Features

Obviously, to make our application even more unique we added several personal features :

- Few animations on button clicked
- Settings page (only game ambiant song is adjustable)
- Pawn and Game board sounds
- Valid moves on pawn clicked
- Page transitions

We tried to put an access to the settings and the rules from the Board page thought.
But when we return to the Board page, all the pawns are reload from the beginning.

## Creators

* [NGUYEN Tommy](https://codefirst.iut.uca.fr/git/tommy.nguyen2)
* [FORGE Cyprien](https://codefirst.iut.uca.fr/git/cyprien.forge)

## Deployment

At the moment, DouShouQi.exe has victory and history features that are not working due to a persistence issue (we guess).

| Deployment Command to execute from 'SAE2.01/sources' |
| :--------: |
| dotnet publish SAE2.01/SAE2.01/DouShouQi.csproj -f net8.0-windows10.0.19041.0 -c Release -p:RuntimeIdentifierOverride=win10-x64 -p:WindowsPackageType=None -p:WindowsAppSDKSelfContained=true -o ../publish -p:PublishSingleFile=true |
