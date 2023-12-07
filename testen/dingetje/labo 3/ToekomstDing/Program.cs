using System;
using System.Collections.Generic;

namespace NameSpaceDing
{
   public interface IThing
   {
       public int ID { get; set;}
   }
   public interface IHuman: IThing
   {
       public string Name { get; set; }
       public int Age { get; set; }
   }
   public interface IRobot : IThing
   {
      public string ModelNumber {get; set;}
   }
   public class Robot: IRobot
   {
       private string _modelNumber;
       public string ModelNumber
       {
           get { return _modelNumber; }
           set { _modelNumber = value; }
       }
       public int ID { get; set; }
   }
   public class Human: IHuman
   {
    private string _name;
    private int _age;
    public string Name
    {
        get {return _name;}
        set {_name = value;}
    }
    public int Age
    {
        get{return _age;}
        set{_age = value;}
    } 
    public int ID {get; set;}
   }
   public static class StartDing
   {
       public static int CountOccurrences(string input, char target)
       {
           return input.Count(c => c == target);
       }
       public static void Main(string[] args)
       {
           List<IThing> lstThings = new List<IThing>();
           List<int> lstValidIDS = new List<int> { 1, 2, 3, 4, 5 };
           do
           {
               string input = System.Console.ReadLine();
               if (input == "end")
               {
                  break;
               }
               else
               {
                  int NumberOfArgs = CountOccurrences(input, ',');
               //   System.Console.WriteLine(NumberOfArgs);
                  List<string> ListOfARgs = new List<string>();
                  ListOfARgs = input.Split(",").ToList();
                  if (NumberOfArgs == 1)
                  {
                      Robot robot = new Robot();
                      robot.ModelNumber = ListOfARgs[0];
                      robot.ID = Convert.ToInt32(ListOfARgs[1]);
                      lstThings.Add(robot);
                     // System.Console.WriteLine(robot.ID);
                  }
                  else if (NumberOfArgs == 2)
                  {
                    Human human = new Human();
                    human.Name = ListOfARgs[0];
                    human.Age = Convert.ToInt32(ListOfARgs[1]);
                    human.ID = Convert.ToInt32(ListOfARgs[2]);
                    lstThings.Add(human);
                  }
               }
           } while (true);
           string invalidThings = "";
           foreach (IThing c in lstThings)
           {
                if (lstValidIDS.IndexOf(c.ID) == -1)
                {
                   
                    if (c.GetType().ToString() == "NameSpaceDing.Robot")
                    {
                        invalidThings += $"\nRobot with id: {c.ID}";
                    }
                    else 
                    {
                        invalidThings += $"\nHuman with id: {c.ID}";
                    }
                }
           }
           System.Console.WriteLine(invalidThings);
       }
   }
}
