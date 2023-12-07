using System;

namespace StructFunctions;
enum MathThings {
    ADDITION,
    SUBTRACTION,
    MULTIPLICATION,
    Devision
}
public struct Numbers{
    public int X;
    public int Y;

    public int[] Z;

    public Numbers(int a, int b)
    {
        this.X = a;
        this.Y = b;
        this.Z = new int[4];
        this.Z[0] = a+b;
        this.Z[1] = a-b;
        this.Z[2] = a*b;
        this.Z[3] = a/b;  
    }
    
}
public class Wiskunde
{
    public Wiskunde(int a, int b) {
       this.x = new Numbers(a,b);
    }

    private Numbers x;

    public Numbers X {
        get {return x;}
        set {x = value;}
    }
}
