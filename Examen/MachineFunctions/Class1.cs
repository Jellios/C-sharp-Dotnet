namespace MachineFunctions
{
public class Class1
{

}
public interface IShape : IComparable
{
    string Name { get;}
    double Volume { get;}

    void CalculateVolume();

}
public interface IHasRadius
{
    int Radius { get; }
}
public class Cube : IShape
{
    public string Name {get; set;}

    public double Volume {get; set;}
    private int _size;


    public int Size { get { return _size; } set { _size = value; } }

   
    public int CompareTo(object other)
    {
        IShape x = (IShape)other;
        if (this.Volume > x.Volume)
        {
            return 1;
        }
        else if (this.Volume == x.Volume)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }
    public void CalculateVolume()
    {
       Volume = Math.Pow(_size,3);
    }
}

public class Sphere : IShape, IHasRadius
{
    public string Name {get; set;}
    public double Volume {get; set;}

    public int Radius {get; set;}
   
    public int CompareTo(object other)
    {
        IShape x = (IShape)other;
        if (this.Volume > x.Volume)
        {
            return 1;
        }
        else if (this.Volume == x.Volume)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }
    public void CalculateVolume()
    {
        Volume = (4/3)*Math.PI*Math.Pow(Radius,3);
    }
}
public class Cylinder : IShape, IHasRadius
{
    public string Name {get; set;}
    public int Radius {get; set;}
    public double Volume{get; set;}

    public void CalculateVolume()
    {
        Volume = Math.PI*Math.Pow(Radius,2)*_height;
    }
    
    private int _height;

    public int Height
    {
        get { return _height; }
        set { _height = value; }
    }
    public int CompareTo(object other)
    {
        IShape x = (IShape)other;
        if (this.Volume > x.Volume)
        {
            return 1;
        }
        else if (this.Volume == x.Volume)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }
}
 public class Machine
    {
        private List<IShape> _partsList;
        
        public List<IShape> PartsList {get; set;}
        public Machine()
        {
            _partsList = new List<IShape>();
        }
        public void AddPart(IShape x)
        {
            this._partsList.Add(x);
        }
        public void AddCube(Cube x)
        {
            this.AddPart(x);
        }
        public void AddSphere(Sphere x)
        {
            this.AddPart(x);
        }
        public void AddCylinder(Cylinder x)
        {
            this.AddPart(x);
        }
        public double GetTotalVolume()
        {
           IEnumerable<IShape> volumes = from s in _partsList select s;
           double sum = 0;
           foreach (IShape s in volumes)
           {
            s.CalculateVolume();
            sum+= s.Volume;
           }
           return sum;
        }
    }
}