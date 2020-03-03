# File Manager
This exercice is part of the Vueling University. It consists in a Windows Form to create students and save in 3 different formats.
## Implementation
In this project, I applied Abstract Factory patter and use Reflection in [FileFactory.cs](https://github.com/davidjimenez92/FileManager/blob/master/FileManager.DataAccess.Data/FileFactory.cs) to instance objects in runtime. In a first moment, I was segrate the problem in task, which one was related with the actions necessaries to implement a solution for this project.
## Abstract factory implementation
[Form1.cs](https://github.com/davidjimenez92/FileManager/blob/master/FileManager.Presentation.WinSite/Form1.cs) is the **client** of this.
[IAbstractFactory.cs](https://github.com/davidjimenez92/FileManager/blob/master/FileManager.DataAccess.Data/IAbstractFactory.cs) is the **abstract factory**.
[VuelingFile.cs](https://github.com/davidjimenez92/FileManager/blob/master/FileManager.DataAccess.Data/TxtFactory.cs) is  the **factory**,
that class create a **products**  [XmlFile.cs](https://github.com/davidjimenez92/FileManager/blob/master/FileManager.DataAccess.Data/XmlFile.cs), [JsonFile.cs](https://github.com/davidjimenez92/FileManager/blob/master/FileManager.DataAccess.Data/JsonFile.cs) and [TxtFile.cs](https://github.com/davidjimenez92/FileManager/blob/master/FileManager.DataAccess.Data/TxtFile.cs) objects.

## Technology stack
`Visual Studio 2019 Comunity editio | C# | .Net Framework`
## Author
[David Jiménez Miguel](https://github.com/davidjimenez92)
