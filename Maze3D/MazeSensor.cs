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
    public class MazeSensor : UIElement3D
    {
        protected string _Name = "";
        public static Dictionary<string, MazeSensor> Sensors = new Dictionary<string, MazeSensor>(StringComparer.CurrentCultureIgnoreCase);
        public static readonly RoutedEvent SensorChangedEvent = EventManager.RegisterRoutedEvent(
        "SensorChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MazeSensor));

        protected Point3D _Position = new Point3D(0, 0, 0);
        protected bool _IsTriggered = false;
        protected bool _IsHorizontal = false;
        protected GeometryModel3D Model { get; set; }

        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(
            nameof(Color), typeof(Color), typeof(MazeSensor), new UIPropertyMetadata((s, e) => ((MazeSensor)s).ColorChanged()));

        public static readonly DependencyProperty MaterialProperty = DependencyProperty.Register(
            nameof(Material), typeof(Material), typeof(MazeSensor), new PropertyMetadata(null));

        public event RoutedEventHandler SensorChanged
        {
            add { AddHandler(SensorChangedEvent, value); }
            remove { RemoveHandler(SensorChangedEvent, value); }
        }

        public MazeSensor() : this($"MazeSensor{Sensors.Count + 1}")
        {

        }

        public MazeSensor(string Name)
        {
            this.Name = Name;
            Model = new GeometryModel3D();
            BindingOperations.SetBinding(Model, GeometryModel3D.MaterialProperty, new Binding(nameof(Material)) { Source = this });
            Visual3DModel = Model;
            SetGeometry();
            Color = Colors.Blue;
        }

        public MazeSensor(string Name, float x, float y, float z) : this(Name)
        {
            Position = new Point3D(x, y, z);
        }

        public MazeSensor(string Name, float x, float y, float z, bool Horizontal) : this(Name, x, y, z)
        {
            IsHorizontal = Horizontal;

        }

        void RaiseSensorChangedEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(MazeSensor.SensorChangedEvent);
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
                if (Sensors.ContainsKey(_Name))
                {
                    Sensors.Remove(_Name);
                }
                _Name = value;
                Sensors[_Name] = this;
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


        public bool IsTriggered
        {
            get
            {
                return _IsTriggered;
            }
            set
            {
                _IsTriggered = value;
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
            if (!_IsTriggered)
            {
                tg.Children.Add(new TranslateTransform3D(_Position.X, _Position.Y, _Position.Z));
                Color = Colors.Gray;
            }
            else
            {
                tg.Children.Add(new TranslateTransform3D(_Position.X, _Position.Y, _Position.Z));
                Color = Colors.Green;

            }
            this.Transform = tg;
        }

        public Material Material
        {
            get { return (Material)GetValue(MaterialProperty); }
            set { SetValue(MaterialProperty, value); }
        }



        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            this.IsTriggered = !IsTriggered;
            RaiseSensorChangedEvent();
        }

        protected virtual void SetGeometry()
        {
            var P1 = new Point3D(_Position.X, _Position.Y - 14, _Position.Z);
            var P2 = new Point3D(_Position.X, _Position.Y + 14, _Position.Z);
            MeshBuilder meshBuilder = new MeshBuilder(false, false);
            //meshBuilder.AddSphere(_Position, 2);
            meshBuilder.AddCylinder(P1, P2, 1);
            Model.Geometry = meshBuilder.ToMesh();
        }

        protected void ColorChanged()
        {
            Material = MaterialHelper.CreateMaterial(Color);
        }
    }
}
