// See https://aka.ms/new-console-template for more information


class MyClass {
    public int val = 20;
}

class Program{
    static void MyMethod(MyClass f1, int f2)
    {
        f1.val = f1.val +5;
        f2 = f2+5;
        Console.WriteLine($"f1.val: {f1.val}, f2: {f2}");
    }
    static void MyMethodMetRefs(ref MyClass f1, ref int f2)
    {
        f1.val = f1.val +5;
        f2 = f2+5;
        Console.WriteLine($"f1.val: {f1.val}, f2: {f2}");
    }
    static void Main() {
        MyClass a1 = new MyClass();
        int a2 = 10;
    Console.WriteLine("Normal parameter type:------------------------------------");
        MyMethod(a1,a2);
        Console.WriteLine($"a1.val: {a1.val}, a2: {a2}");
    Console.WriteLine("--------------------------------------------------------");
    a1 = new MyClass();
    a2 = 10;
    Console.WriteLine("reference parameter type:------------------------------------");
        MyMethodMetRefs(ref a1,ref a2);
        Console.WriteLine($"a1.val: {a1.val}, a2: {a2}");
    Console.WriteLine("--------------------------------------------------------");
    a1 = new MyClass();
    a2 = 10;

     

    }

}