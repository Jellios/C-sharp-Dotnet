using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MachineFunctions;
namespace UserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public MachineFunctions.Machine machine;
        public int type = 0;


        public MainWindow()
        {
            InitializeComponent();
            machine = new MachineFunctions.Machine();
            AddCubeButton.Click += AddCube;
            AddSphereButton.Click += AddSphere;
            AddCilinderButton.Click += AddCilinder;
            CalculateTotalVolumeButton.Click += ShowTotalVolume;
            OrderAscButton.Click += OnSortButtonPressed;
            CalculatePriceButton.Click += CalculatePrice;
            Status.Content = "Idle";
        }

        public int StatusSetter()
        {
            Status.Content = "Calibrating";
            Thread.Sleep(1000);
            AddCubeButton.IsEnabled = false;
            switch (type)
            {
                case 1:
                    Status.Content = "Creating Cube";
                    Thread.Sleep(1000);
                    break;
                case 2:
                    Status.Content = "Creating Cilinder";
                    Thread.Sleep(2000);
                    break;
                case 3:
                    Status.Content = "Creating Sphere";
                    Thread.Sleep(3000);
                    break;
            }
            AddCubeButton.IsEnabled = true;
            Status.Content = "Idle";
            return 1;
        }
        public bool CheckNumberOfParameters(List<string> lst, int x)
        {

            if (lst.Count() == x)
            {
                return true;
            }
            return false;
        }
        public void OnSortButtonPressed(object sender, RoutedEventArgs e)
        {
            machine.PartsList.Sort();
        }
        public void AddCube(object sender, RoutedEventArgs e)
        {
            if (Input.Text != "")
            {
                List<string> lst = Input.Text.Split(',').ToList();
                if (CheckNumberOfParameters(lst, 2))
                {
                    type = 1;
                    // Task TaskA = new Task(StatusSetter);
                    //TaskA.Start();
                    //Task[] tasks = {TaskA};
                    //Thread.Sleep(5000);
                    //   await StatusSetter();
                    StatusSetter();
                    Cube x = new Cube();
                    x.Name = lst[0];
                    x.Size = Convert.ToInt32(lst[1]);
                    machine.AddCube(x);
                    x.CalculateVolume();
                    this.Parts.Items.Add(new MyItem { Description = $"Cube with for {x.Name}", Volume = x.Volume, ItemType = "Cube" });
                    MessageBox.Show("Part is ready");
                }
            }


            // AddCubeButton.Content = "aaaagh";

        }
        public void ShowTotalVolume(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"the total volume is: {machine.GetTotalVolume()}");
        }
        public void AddSphere(object sender, RoutedEventArgs e)
        {

            if (Input.Text != "")
            {
                List<string> lst = Input.Text.Split(',').ToList();
                if (CheckNumberOfParameters(lst, 2))
                {
                    Sphere x = new Sphere();
                    x.Name = lst[0];
                    x.Radius = Convert.ToInt32(lst[1]);
                    machine.AddSphere(x);
                    x.CalculateVolume();
                    this.Parts.Items.Add(new MyItem { Description = $"Sphere with for {x.Name}", Volume = x.Volume, ItemType = "Sphere" });
                     MessageBox.Show("Part is ready");
                }
            }
        }
        public void CalculatePrice(object sender, RoutedEventArgs e)
        {
            var selectedItem = Parts.SelectedItems[0];
            double price = 0;
       /*     switch (selectedItem.ItemType)
            {
                case "Cube":
                price = 0.10 * selectedItem.Volume;
                break;
                case "Sphere":
                case "Cilinder":
                price = 0.15 * selectedItem;
                break;
            } */
            MessageBox.Show($"The price  is: {selectedItem}");
        }
        public void AddCilinder(object sender, RoutedEventArgs e)
        {
            if (Input.Text != "")
            {
                List<string> lst = Input.Text.Split(',').ToList();
                if (CheckNumberOfParameters(lst, 3))
                {
                    Cylinder x = new Cylinder();
                    x.Name = lst[0];
                    x.Radius = Convert.ToInt32(lst[1]);
                    x.Height = Convert.ToInt32(lst[2]);
                    machine.AddCylinder(x);
                    x.CalculateVolume();
                    this.Parts.Items.Add(new MyItem { Description = $"Cilinder with for {x.Name}", Volume = x.Volume, ItemType = "Cilinder" });
                  MessageBox.Show("Part is ready");
                }
            }
        }
    }
    public class MyItem
    {
        public string ItemType {get; set;}
        public string Description { get; set; }

        
        public double Volume { get; set; }
        
    }
}
