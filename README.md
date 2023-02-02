# Unity-2D-Template

A barebones Unity Template with automated build configuration with GitHub Actions. Feel free to copy the GitHub actions configuration to your own project.

Contains the following package imports:

- TextMesh Pro (Located in Imports/TextMesh Pro)
- Input System, the new Unity Input package

Some controller scripts are hooked up such as Input and Player Controllers, using events to communicate. See the following for more information:

- [Events - C# Programming Guide](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/events/)
- [Unity-Programming-Patterns](https://github.com/Habrador/Unity-Programming-Patterns#3-observer) and the relevant [code examples](https://github.com/Habrador/Unity-Programming-Patterns/tree/master/Assets/Patterns/3.%20Observer)

## GitHub Actions

You will first need to configure your GitHub secrets with your Unity License. Run the 'Unity GameCI Activation' workflow included, and follow this before you run or configure any other workflows: https://game.ci/docs/github/activation

Build scripts for Windows and WebGL are configured to be run manually. Please see the relevant scripts in the [`.github/workflows`](https://github.com/biggestcookie/Unity-2D-Template/tree/main/.github/workflows) folder in order to configure the relevant script for you to be run automatically.

The WebGL workflow is also configured to automatically build and deploy the game to GitHub Pages. The workflows should be pretty easy to tweak as necessary for different build platforms or deployment environments. See https://game.ci/docs/ for more information.
