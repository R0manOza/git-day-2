delegate int MyType(int x);


class Program {
    MyType f;
    void Echo(int x )
    {
        int r;
        r = this.f(x);
        Console.WriteLine(r);
    }



    static void Main(String[]args)
    {
        Program p;
     p = new Program();
        p.Echo(3);
    }
}