using System;

class Circle
{
    double r;
    public double Radius
    {
        get { return this.r; }
        set { this.r = value; }
    }
    public Circle(double radius)
    {
        Radius = radius;
    }
    public double Perimeter
    {
       get { return 2 * Math.PI * this.r; }
    }
     set { this.r = value / (2 * Math.PI); }
    {
}
class Program {
    static void Main(string[] args)
    {
        Circle c = new Ci
            rcle();
        c.Radius = 9;
        Console.WriteLine(c.Perimeter);
        c.Perimeter = 100;
        Console.WriteLine(c.Radius);
    }
}