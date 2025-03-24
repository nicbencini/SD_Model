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

```csharp
SD_Point point_1 = new SD_Point(0.5, 0.5, 1);
SD_Point point_2 = new SD_Point(1, 0, 0);
SD_Point point_3 = new SD_Point(0, 0, 1);

SD_Plane new_plane = new SD_Plane(point_1, point_2, point_3);

SD_Vector plane_origin = new_plane.Origin;
SD_Vector plane_x_vec = new_plane.XVector;
SD_Vector plane_y_vec = new_plane.YVector;
SD_Vector plane_z_vec = new_plane.ZVector;
```
## Examples

### 1. Creating a Vector
You can create a 3D vector using different constructors:

```csharp
SD_Vector v1 = new SD_Vector(1.0, 2.0, 3.0); // From individual coordinates
SD_Vector v2 = new SD_Vector(5.0); // Same value for x, y, and z
SD_Vector v3 = new SD_Vector("{4.0, 5.0, 6.0}"); // From a string
```

### 2. Converting a Vector
The `ToString`, `ToArray`, and `ToPoint` methods allow conversion:

```csharp
SD_Vector v = new SD_Vector(1.0, 2.0, 3.0);
Console.WriteLine(v.ToString()); // "{1.0, 2.0, 3.0}"

double[] arr = v.ToArray(); // [1.0, 2.0, 3.0]
SD_Point p = v.ToPoint(); // Convert to point
```

### 3. Basic Vector Operations
Performing arithmetic operations on vectors:

```csharp
SD_Vector v1 = new SD_Vector(3.0, 4.0, 5.0);
SD_Vector v2 = new SD_Vector(1.0, 1.0, 1.0);

SD_Vector v3 = v1 + v2; // Addition: {4.0, 5.0, 6.0}
SD_Vector v4 = v1 - v2; // Subtraction: {2.0, 3.0, 4.0}
SD_Vector v5 = v1 * 2;   // Scalar multiplication: {6.0, 8.0, 10.0}
SD_Vector v6 = v1 / 2;   // Scalar division: {1.5, 2.0, 2.5}
```

### 4. Dot Product and Cross Product
Computing dot and cross products between vectors:

```csharp
SD_Vector v1 = new SD_Vector(1.0, 0.0, 0.0);
SD_Vector v2 = new SD_Vector(0.0, 1.0, 0.0);

double dot = SD_Vector.DotProduct(v1, v2); // 0.0 (Orthogonal vectors)
SD_Vector cross = SD_Vector.CrossProduct(v1, v2); // {0.0, 0.0, 1.0}
```

### 5. Checking Vector Properties
Determining relationships between vectors:

```csharp
SD_Vector v1 = new SD_Vector(2.0, 2.0, 2.0);
SD_Vector v2 = new SD_Vector(4.0, 4.0, 4.0);
SD_Vector v3 = new SD_Vector(1.0, -1.0, 0.0);

bool isParallel = v1.IsParallel(v2); // True
bool isOrthogonal = v1.IsOrthogonal(v3); // False
```

### Example 6: Creating a Line from Two Points
```csharp
SD_Point point1 = new SD_Point(0, 0, 0);
SD_Point point2 = new SD_Point(3, 4, 5);
SD_Line line = new SD_Line(point1, point2);
Console.WriteLine(line.ToString()); // Outputs the start and end points of the line
```

### Example 7: Creating a Line from a Point and a Vector
```csharp
SD_Point startPoint = new SD_Point(1, 2, 3);
SD_Vector direction = new SD_Vector(4, 5, 6);
SD_Line line = new SD_Line(startPoint, direction);
Console.WriteLine(line.ToString());
```

### Example 8: Getting the Midpoint of a Line
```csharp
SD_Point point1 = new SD_Point(0, 0, 0);
SD_Point point2 = new SD_Point(4, 4, 4);
SD_Line line = new SD_Line(point1, point2);
SD_Point midPoint = line.MidPoint();
Console.WriteLine(midPoint.ToString()); // Outputs (2,2,2)
```

### Example 9: Checking if Two Lines are Parallel
```csharp
SD_Point p1 = new SD_Point(0, 0, 0);
SD_Point p2 = new SD_Point(3, 3, 3);
SD_Line line1 = new SD_Line(p1, p2);

SD_Point p3 = new SD_Point(1, 1, 1);
SD_Point p4 = new SD_Point(4, 4, 4);
SD_Line line2 = new SD_Line(p3, p4);

bool isParallel = line1.IsParallel(line2);
Console.WriteLine(isParallel); // Outputs: True
```

### Example 10: Dividing a Line into Equal Parts
```csharp
SD_Point point1 = new SD_Point(0, 0, 0);
SD_Point point2 = new SD_Point(10, 10, 10);
SD_Line line = new SD_Line(point1, point2);

var divisions = line.Divide(4);
foreach (var point in divisions.Item1)
{
    Console.WriteLine(point.ToString()); // Outputs division points
}
```
### Example 11: Check if Point is On Line
```csharp

// Define two points to create a line
SD_Point startPoint = new SD_Point(0, 0, 0);
SD_Point endPoint = new SD_Point(10, 10, 10);
SD_Line line = new SD_Line(startPoint, endPoint);

// Define a point to check
SD_Point pointOnLine = new SD_Point(5, 5, 5);  // Lies on the line
SD_Point pointOffLine = new SD_Point(5, 6, 5); // Does not lie on the line

// Check if points are on the line
Console.WriteLine($"Is (5,5,5) on the line? {line.IsPointOnLine(pointOnLine)}");
Console.WriteLine($"Is (5,6,5) on the line? {line.IsPointOnLine(pointOffLine)}");

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


