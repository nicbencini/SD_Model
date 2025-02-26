# SD_Model

**SD_Model** is a self-contained 3D geometry and vector library written in C# for .NET Standard 2.1. It provides tools to handle 3D geometry interactions without relying on external dependencies.

## Features

- **3D Geometry Operations**: Perform calculations and manipulations on 3D objects.
- **Vector Mathematics**: Utilize vector operations essential for 3D computations.
- **Cross-Platform Compatibility**: Built on .NET Standard 2.1, ensuring compatibility with .NET 5 and later versions.

## Getting Started

### Prerequisites

- [.NET 5 SDK or later](https://dotnet.microsoft.com/download/dotnet/5.0)

### Installation

Clone the repository:

```bash
git clone https://github.com/nicbencini/SD_Model.git
```

Navigate to the project directory:

```bash
cd SD_Model
```

Build the solution:

```bash
dotnet build
```

### Usage

To use SD_Model in your project:

1. Add a reference to `SD_Model` in your project.
2. Import the necessary namespaces:
   
   ```csharp
   using SD_Model.Geometry;
   using SD_Model.Vectors;
   ```

3. Utilize the classes and methods provided by the library.

For example, to create a vector and perform operations:

```csharp
var vector1 = new Vector3D(1, 2, 3);
var vector2 = new Vector3D(4, 5, 6);

var result = vector1.Add(vector2);
Console.WriteLine($"Resulting Vector: {result}");
```

## Documentation

Detailed documentation is available in the `docs` folder of the repository. It includes:

- **Class References**: Descriptions and usage of classes.
- **Examples**: Sample code demonstrating library features.
- **API Documentation**: Detailed information on available methods and properties.

## Contributing

Contributions are welcome! To contribute:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/YourFeature`).
3. Commit your changes (`git commit -m 'Add new feature'`).
4. Push to the branch (`git push origin feature/YourFeature`).
5. Open a pull request.

For major changes, please open an issue first to discuss what you would like to change.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

*Note: This README provides an overview of the SD_Model project. For more detailed information, please refer to the documentation within the repository.*

## Contact
Email: nicbencini@gmail.com
LinkedIn: [Nicolo Bencini](https://www.linkedin.com/in/nicolo-bencini/)


