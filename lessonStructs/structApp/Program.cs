// See https://aka.ms/new-console-template for more information

using StructFunctions;
public enum MathThings {
    ADDITION,
    SUBTRACTION,
    MULTIPLICATION,
    Devision
}
public class Ding {
    public static void main()
    {
        Wiskunde wisk = new Wiskunde(7,8);
        
        int tmp = wisk.X.Z[(int)MathThings.ADDITION];

    }
}
