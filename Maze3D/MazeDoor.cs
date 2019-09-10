using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace Maze3D
{
    public class MazeDoor : UIElement3D
    {
        public static Dictionary<string, MazeDoor> Doors = new Dictionary<string, MazeDoor>();
        public static readonly RoutedEvent DoorChangedEvent = EventManager.RegisterRoutedEvent(
        "DoorChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MazeDoor));

        //public event DoorChangedEventArgs DoorChanged;
        private Point3D _Position = new Point3D(0, 0, 0);
        private Timer ActionTimer;
        private bool _IsClosed = true;
        private bool _IsHorizontal = false;
        protected GeometryModel3D Model { get; set; }
        private string _Name = $"MazeDoor{Doors.Count + 1}";

        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(
            nameof(Color), typeof(Color), typeof(MazeDoor), new UIPropertyMetadata((s, e) => ((MazeDoor)s).ColorChanged()));

        public static readonly DependencyProperty MaterialProperty = DependencyProperty.Register(
            nameof(Material), typeof(Material), typeof(MazeDoor), new PropertyMetadata(null));

        public event RoutedEventHandler DoorChanged
        {
            add { AddHandler(DoorChangedEvent, value); }
            remove { RemoveHandler(DoorChangedEvent, value); }
        }

        public MazeDoor() : this($"MazeDoor{Doors.Count + 1}")
        {

        }

        public MazeDoor(string Name)
        {
            Model = new GeometryModel3D();
            BindingOperations.SetBinding(Model, GeometryModel3D.MaterialProperty, new Binding(nameof(Material)) { Source = this });
            Visual3DModel = Model;
            SetGeometry();
            Color = Colors.Red;
            this.Name = Name;
        }

        public MazeDoor(string Name, float x, float y, float z) : this(Name)
        {
            Position = new Point3D(x, y, z);
        }

        public MazeDoor(string Name, float x, float y, float z, bool Horizontal) : this(Name, x, y, z)
        {
            IsHorizontal = Horizontal;
        }


        void RaiseDoorChangedEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(MazeDoor.DoorChangedEvent);
            RaiseEvent(newEventArgs);
        }

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (Doors.ContainsKey(_Name))
                {
                    Doors.Remove(_Name);
                }
                _Name = value;
                Doors[_Name] = this;
            }
        }

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value.ChangeAlpha(200)); }
        }

        public Point3D Position
        {
            get
            {
                return _Position;
            }
            set
            {
                _Position = value;
                Update();
            }
        }

        public void MakeHorizontal()
        {
            _IsHorizontal = true;
        }


        public bool IsClosed
        {
            get
            {
                return _IsClosed;
            }
            set
            {
                _IsClosed = value;
                Update();
            }
        }

        public bool IsHorizontal
        {
            get
            {
                return _IsHorizontal;
            }
            set
            {
                _IsHorizontal = value;
                Update();
            }
        }

        public void Update()
        {
            var tg = new Transform3DGroup();
            if (_IsHorizontal)
            {
                tg.Children.Add(new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), 90)));
            }
            if (_IsClosed)
            {
                tg.Children.Add(new TranslateTransform3D(_Position.X, _Position.Y, _Position.Z));
                Color = Colors.Red;
            }
            else
            {
                tg.Children.Add(new TranslateTransform3D(_Position.X, _Position.Y, _Position.Z - 19));
                Color = Colors.Green;

            }
            this.Transform = tg;
        }

        public Material Material
        {
            get { return (Material)GetValue(MaterialProperty); }
            set { SetValue(MaterialProperty, value); }
        }

        public void Open()
        {
            IsClosed = false;
        }

        public void Close()
        {
            IsClosed = true;
        }

     

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            this.IsClosed = !IsClosed;
            RaiseDoorChangedEvent();
            //DoorChanged?.Invoke(this, new DoorChangedEventArgs("test", IsClosed));
        }

        //protected override void OnMouseDown(MouseButtonEventArgs e)
        //{
        //    this.IsClosed = !IsClosed;
        //}

        private void SetGeometry()
        {
            MeshBuilder meshBuilder = new MeshBuilder(false, false);
            meshBuilder.AddBox(_Position, 3, 20, 20);
            Model.Geometry = meshBuilder.ToMesh();
        }

        private void ColorChanged()
        {
            Material = MaterialHelper.CreateMaterial(Color);
        }
    }
}
