# C# Extensions Library

Enhance your C# programming experience with this library of extensions for fundamental data types and classes in C#. Easily extend the capabilities of `string`, `int`, `DateTime`, and more with a collection of useful methods and utilities. Simplify common tasks, improve code readability, and boost productivity with these C# type extensions.

## Table of Contents

- [C# Extensions Library](#c-extensions-library)
  - [Table of Contents](#table-of-contents)
  - [Features](#features)
  - [Installation](#installation)
  - [Usage](#usage)
  - [Contributing](#contributing)

## Features

- **String Extensions:** Additional methods for string manipulation, formatting, and validation.
- **Integer Extensions:** Handy utilities for integer manipulation and conversions.
- **DateTime Extensions:** Simplify date and time operations, parsing, and formatting.
- **And More:** Explore a growing collection of extensions for other core data types and classes.

## Installation

You can add this library to your project using [NuGet](https://www.nuget.org/):

```bash
nuget install CSharpExtensionsLibrary
```

## Usage

```csharp
// Example of how to use the StringExtensions
using CSharpExtensionsLibrary;

class Program
{
    static void Main()
    {
        //ConvertCase 
        string text = "Hello, World!";
        string titleCase = input.ConvertCase(StringConvertCaseType.TitleCase);
        // Result: "Hello World"
        string invertCase = input.ConvertCase(StringConvertCaseType.InvertCase);
        // Result: "HELLO WORLD"

        // Generate a random string of length 10 with default character sets
        string randomString1 = StringExtensions.GenerateRandomText(10);
        Console.WriteLine("Random String 1: " + randomString1);
        // Generate a random string of length 8 with only lowercase letters
        string randomString2 = StringExtensions.GenerateRandomText(8, includeUpperChars: false, includeLowerChars: true, includeNumbers: false, includeSpecialChars: false);
        Console.WriteLine("Random String 2: " + randomString2);
        // Generate a random string of length 12 with all character sets
        string randomString3 = StringExtensions.GenerateRandomText(12, includeUpperChars: true, includeLowerChars: true, includeNumbers: true, includeSpecialChars: true);
        Console.WriteLine("Random String 3: " + randomString3);
    }
}
```

## Contributing

Contributions to this library are welcome! If you'd like to add more extensions, fix issues, or improve documentation, please follow these steps:

1. Fork the repository.
2. Create a new branch for your changes: git checkout -b feature/your-feature-name.
3. Commit your changes: git commit -m "Add your feature description".
4. Push your changes to your fork: git push origin feature/your-feature-name.
5. Open a pull request on this repository.
6. Please ensure that your code follows best practices, is well-documented, and includes unit tests where appropriate.