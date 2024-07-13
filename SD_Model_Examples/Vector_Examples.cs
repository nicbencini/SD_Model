using SD_Model;
using SD_Model.Geometry;
using SD_Model.Vector;

//Create vector.

SD_Vector vector_1 = new SD_Vector(1, 1, 0);

string vector_string = vector_1.ToString();

Console.WriteLine(vector_string);

//Create plane.

SD_Point point_1 = new SD_Point(0.5, 0.5, 1);
SD_Point point_2 = new SD_Point(1, 0, 0);
SD_Point point_3 = new SD_Point(0, 0, 1);

SD_Plane new_plane = new SD_Plane(point_1, point_2, point_3);

SD_Vector plane_origin = new_plane.Origin;
SD_Vector plane_x_vec = new_plane.XVector;
SD_Vector plane_y_vec = new_plane.YVector;
SD_Vector plane_z_vec = new_plane.ZVector;

Console.WriteLine(new_plane.ToString());
