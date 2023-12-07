using System;

namespace NameSpaceDing {
    delegate void MyDelegate(); //Declare delegate
class Program
{
public static void Method1(){ //Method with delegate signature and return type
Console.WriteLine("Running Method 1");
}
public static void Method2(){ //Method with delegate signature and return type
Console.WriteLine("Running Method 2");
}
delegate int OtherDel(int x,int y);
static void Main(string[] args)
{
MyDelegate MyDel1 = Method1; //Create delegate object and add Method1 to delegate list
MyDelegate MyDel2 = new MyDelegate(Method1);//Create delegate object and add Method1 to delegate list
MyDel1 += Method2; //Add method to the end of the delegate list
MyDel1 -= Method1; //Remove method from delegate list
MyDel1.Invoke(); //Invoke delegate (run all methods in delegate list)
MyDelegate MyDel3 = MyDel1 + MyDel2; //Combine 2 delegates
MyDel3.Invoke();
MyDel2 -= Method1;
MyDel2?.Invoke(); // ? to check if method list is not empty
OtherDel ding = delegate(int x, int y)
{
 return Convert.ToInt32(Math.Pow(x,y));
};
System.Console.WriteLine(ding(2,8));
OtherDel ding2 =  (int x, int y) => {return Convert.ToInt32(Math.Pow(x,y));};
System.Console.WriteLine($"Ding2, lambda: {ding2(5,4)}");
}
}
}