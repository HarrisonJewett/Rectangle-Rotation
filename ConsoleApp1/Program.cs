using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleRotation {
    class Program {
        static void Main(string[] args) {
           
            //Create and init new rectangle
            Rectangle testRec = new Rectangle();
            testRec.points = new Point[4];
            for (int i = 0; i < testRec.points.Length; i++) {
                testRec.points[i] = new Point();
            }

            //Create a 2D array to hold input coordinates
            float[,] recCoords = new float[4, 4];

            Console.WriteLine("Input desired Rectangle Coords: ");

            float xCoord, yCoord;

            for (int i = 0; i < testRec.points.Length; i++) {
                while (true) {
                    Console.Write("Point " + (i + 1) + " x value: ");
                    String temp = Console.ReadLine();
                    if (float.TryParse(temp, out xCoord)) {
                        break;
                    }
                    else {
                        Console.Clear();
                        Console.WriteLine("Please input a valid float.");
                    }
                }
                while (true) {
                    Console.Write("Point " + (i + 1) + " y value: ");
                    String temp = Console.ReadLine();
                    if (float.TryParse(temp, out yCoord)) {
                        break;
                    }
                    else {
                        Console.Clear();
                        Console.WriteLine("Please input a valid float.");
                    }
                }
                testRec.points[i].SetX(xCoord);
                testRec.points[i].SetY(yCoord);
            }
            Console.Clear();
            Console.Write("Set Points: ");
            for (int i = 0; i < 4; i++) {
                Console.Write("(" + testRec.points[i].GetX() + "," + testRec.points[i].GetY() + ")");
            }
            Console.WriteLine("\n");

            Point testPoint = new Point();

            Console.WriteLine("Desired rotation point Coordinates: ");
            while (true) {
                Console.Write("X value: ");
                String temp = Console.ReadLine();
                if (float.TryParse(temp, out xCoord)) {
                    break;
                }
                else {
                    Console.Clear();
                    Console.WriteLine("Please input a valid float.");
                }
            }
            while (true) {
                Console.Write("Y value: ");
                String temp = Console.ReadLine();
                if (float.TryParse(temp, out yCoord)) {
                    break;
                }
                else {
                    Console.Clear();
                    Console.WriteLine("Please input a valid float.");
                }
            }
            float rotAngle;
            while (true) {
                Console.Write("Rotation angle: ");
                String temp = Console.ReadLine();
                if (float.TryParse(temp, out rotAngle)) {
                    break;
                }
                else {
                    Console.Clear();
                    Console.WriteLine("Please input a valid float.");
                }
            }
            testPoint.SetX(xCoord);
            testPoint.SetY(yCoord);

            testRec.Rotate(testPoint, rotAngle);

            Console.Write("New Points: ");
            for (int i = 0; i < 4; i++) {
                Console.Write("(" + testRec.points[i].GetX() + "," + testRec.points[i].GetY() + ")");
            }

            Console.ReadLine();
        }
    }
}


public struct Rectangle {

    /* Each point represents one of the Rectangle's corners/ */
    public Point[] points;

    public void Rotate(Point origin, float angle) {

        Console.Write("Previous Points: ");
        for (int i = 0; i < 4; i++) {
            Console.Write("(" + points[i].GetX() + "," + points[i].GetY() + ")");
        }
        Console.WriteLine("\n");

        for (int i = 0; i < 4; i++) {

            //Convert angle to raidians
            double radian = ((2 * Math.PI) / 360) * angle;

            //get distance between origin and rectangle point, which will also serve as hypotenuse 
            double distance = Math.Sqrt(((points[i].GetX() - origin.GetX()) * (points[i].GetX() - origin.GetX())) + ((points[i].GetY() - origin.GetY()) * (points[i].GetY() - origin.GetY())));

            //New angle to find right angle triangle
            double angleB = Math.Atan((points[i].GetY() - origin.GetY()) / (points[i].GetX() - origin.GetX()));
            double newAngle = angleB + radian;

            //get new coordinates for point. new x and y coordinates are relative to the referance point so points must be added back
            float newX = origin.GetX() + (float)(distance * Math.Cos(newAngle));
            float newY = origin.GetY() + (float)(distance * Math.Sin(newAngle));

            //set Rectangle's new coords
            points[i].SetX(newX);
            points[i].SetY(newY);
        }
    }
}

public struct Point {
    float x, y;

    Point(float a, float b) {
        x = a;
        y = b;
    }
    public float GetX() {
        return x;
    }
    public float GetY() {
        return y;
    }
    public void SetX(float newX) {
        x = newX;
    }
    public void SetY(float newY) {
        y = newY;
    }
}