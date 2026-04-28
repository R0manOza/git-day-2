using System.Drawing;

class Rectangle
{
    double length;
    double width;
    public Rectangle(double l, double w)
    {
        this.length = l;
        this.width = w;
    }
    virtual public double Size()
    {
        return this.length * this.width;
    }
}
class Cuboid : Rectangle
{
    double hight;
    public Cuboid(double l, double w, double h) : base(l, w)
    {
        this.hight = h;
    }
    override public double Size()
    {
        return base.Size() * this.hight;
    }

}
class Program
{
    static void Main(string[] args)
    {
        Rectangle r;
        r = new Cuboid(2, 3, 4);
        double z = r.Size();
        Console.WriteLine(z);

    }

}