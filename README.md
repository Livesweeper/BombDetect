# BombDetect
A minimal game engine used by Livesweeper

## Features
- Cross platform
- Object oriented (because entity component systems suck)
- Not *too* high level
- Only has a handful of objects, resulting in less bloat

## How to use
### Adding to your project
You can either build the engine and add the libraries as references or include this repo as a submodule in your project.

Make sure to use the `--recursive` tag when cloning.

### Usage
With the small amount of objects that BombDetect has, you should implement your own objects that you need for your game. You can fork the project and add your objects directly to the engine or implement them into your game.

## Credits
- SDL2# (modified to add .NET 6 support), by [@flibitijibibo](https://github.com/flibitijibibo): https://github.com/Livesweeper/SDL2-CS
