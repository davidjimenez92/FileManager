# File Manager
This exercice is part of the Vueling University. It consists in a Windows Form to create students and save in 3 different formats.
## Implementation
In this project, I tried apply Abstract Factory patter. In a first moment, I was segrate the problem in task, which one was related with the actions necessaries to implement a solution for this project.
## Abstract factory implementation
[Form1.cs](https://github.com/davidjimenez92/FileManager/blob/master/FileManager.Presentation.WinSite/Form1.cs) is the **client** of this.
[StudentDao.cs](https://github.com/davidjimenez92/FileManager/blob/master/FileManager.DataAccess.Data/StudentDao.cs) is the **abstract factory**.
[TxtFactory.cs](https://github.com/davidjimenez92/FileManager/blob/master/FileManager.DataAccess.Data/TxtFactory.cs), [XmlFactory.cs](https://github.com/davidjimenez92/FileManager/blob/master/FileManager.DataAccess.Data/XmlFactory.cs), [JsonFactory.cs](https://github.com/davidjimenez92/FileManager/blob/master/FileManager.DataAccess.Data/JsonFactory.cs) are the **factories**,
that classes create a **product** (txt file, xml file or json file) to save [Student](https://github.com/davidjimenez92/FileManager/blob/master/FileManager.Common.Layer/Student.cs) objects.

## Technology stack
`C# | .Net Framework`
## Author
[David Jiménez Miguel](https://github.com/davidjimenez92)
