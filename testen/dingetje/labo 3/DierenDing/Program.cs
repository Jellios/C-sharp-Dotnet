using System;

namespace DierenDingetje
{

    public interface IRaceable : IComparable<IRaceable>
    {
        int Speed { get; }
    }
    public interface IVolumeObject : IComparable<IVolumeObject>
    {
        int Volume { get; }
    }
    public interface ISoundable
    {
        string MakeSound();
    }

    public interface IAnimal : IRaceable, IVolumeObject, ISoundable
    {
    }
    public interface IVehicle : IRaceable, IVolumeObject, ISoundable
    { }
    public interface IShape : IVolumeObject
    { }

    public class Cat : IAnimal
    {
        public int Speed => 10;
        public int Volume => 2;

        public string MakeSound()
        {
            return "Miauuuuuw";
        }

        public int CompareTo(IVolumeObject other)
        {
            if (this.Volume > other.Volume)
            {
                return 1;
            }
            else if (this.Volume == other.Volume)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
        public int CompareTo(IRaceable other)
        {
            if (this.Speed > other.Speed)
            {
                return 1;
            }
            else if (this.Speed == other.Speed)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
    public class Dog : IAnimal
    {
        public int Speed => 20;
        public int Volume => 4;

        public string MakeSound()
        {
            return "Wooooof";
        }

        public int CompareTo(IVolumeObject other)
        {
            if (this.Volume > other.Volume)
            {
                return 1;
            }
            else if (this.Volume == other.Volume)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
        public int CompareTo(IRaceable other)
        {
            if (this.Speed > other.Speed)
            {
                return 1;
            }
            else if (this.Speed == other.Speed)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
    public class Turtle : IAnimal
    {
        public int Speed => 2;
        public int Volume => 1;

        public string MakeSound()
        {
            return "*Turtle noices*";
        }

        public int CompareTo(IVolumeObject other)
        {
            if (this.Volume > other.Volume)
            {
                return 1;
            }
            else if (this.Volume == other.Volume)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
        public int CompareTo(IRaceable other)
        {
            if (this.Speed > other.Speed)
            {
                return 1;
            }
            else if (this.Speed == other.Speed)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
    public class Car : IVehicle
    {
        public int Speed => 80;
        public int Volume => 25;

        public string MakeSound()
        {
            return "Vrooooooooooooooooom";
        }

        public int CompareTo(IVolumeObject other)
        {
            if (this.Volume > other.Volume)
            {
                return 1;
            }
            else if (this.Volume == other.Volume)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
        public int CompareTo(IRaceable other)
        {
            if (this.Speed > other.Speed)
            {
                return 1;
            }
            else if (this.Speed == other.Speed)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
    public class Cube : IShape
    {
        public int Volume => 10;
        public int CompareTo(IVolumeObject other)
        {
            if (this.Volume > other.Volume)
            {
                return 1;
            }
            else if (this.Volume == other.Volume)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
    public static class StartDingetje
    {
        public static void Main(string[] args)
        {
            List<IAnimal> animals = new() { new Cat(), new Dog(), new Turtle() };
            List<IVehicle> vehicles = new() { new Car() };
            List<IShape> shapes = new() { new Cube() };
        //    IEnumerable<IRaceable> raceAbles = animals.Concat<IRaceable>(vehicles).ToList();
            IEnumerable<IRaceable> raceAbles = animals.Concat<IRaceable>(vehicles).ToList();
            List<IRaceable> lstRace = new List<IRaceable>();
            lstRace.Add(new Cat());
            lstRace.Add(new Cat());
            lstRace.Add(new Cat());

            lstRace.Add(new Car());

            foreach (IRaceable obj1 in lstRace)
            {
                System.Console.WriteLine($"{obj1.GetType()}:\t {obj1.Speed}");
            }
            lstRace.Sort();
            System.Console.WriteLine("\n\n");
            foreach (IRaceable obj1 in lstRace)
            {
                System.Console.WriteLine($"{obj1.GetType()}:\t {obj1.Speed}");
            }


            IEnumerable<ISoundable> soundAbles = animals.Concat<ISoundable>(vehicles).ToList();
            foreach (ISoundable obj1 in soundAbles)
            {
                //  System.Console.WriteLine($"The {obj1.GetType()} goes:\t {obj1.MakeSound()}");
            }
            IEnumerable<IVolumeObject> volumeObjects = animals.Concat<IVolumeObject>(vehicles).ToList();
            //    System.Console.WriteLine($"List before being sorted: ");
            List<IVolumeObject> tmp = volumeObjects.ToList();
            foreach (IVolumeObject obj1 in tmp)
            {
                //  System.Console.WriteLine($"The {obj1.GetType()} has a volume of:\t {obj1.Volume}");
            }
            //  System.Console.WriteLine("\n After sorted:");
            tmp.Sort();
            foreach (IVolumeObject obj1 in tmp)
            {
                // System.Console.WriteLine($"The {obj1.GetType()} has a volume of:\t {obj1.Volume}");
            }

        }

    }


}