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
    public class MazePumpDial : UIElement3D
    {
        public static Dictionary<string, MazePumpDial> Dials = new Dictionary<string, MazePumpDial>();
        public static readonly RoutedEvent DialChangedEvent = EventManager.RegisterRoutedEvent(
        "DialChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MazePumpDial));

        //public event DoorChangedEventArgs DoorChanged;
        private Point3D _Position = new Point3D(0, 0, 0);
        private float _Angle = 0;
        protected GeometryModel3D Model { get; set; }
        private string _Name = $"MazePumpDial{Dials.Count + 1}";

        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(
            nameof(Color), typeof(Color), typeof(MazePumpDial), new UIPropertyMetadata((s, e) => ((MazePumpDial)s).ColorChanged()));

        public static readonly DependencyProperty MaterialProperty = DependencyProperty.Register(
            nameof(Material), typeof(Material), typeof(MazePumpDial), new PropertyMetadata(null));

        public event RoutedEventHandler DialChanged
        {
            add { AddHandler(DialChangedEvent, value); }
            remove { RemoveHandler(DialChangedEvent, value); }
        }

        public MazePumpDial() : this($"MazePumpDial{Dials.Count + 1}")
        {

        }

        public MazePumpDial(string Name)
        {
            Model = new GeometryModel3D();
            BindingOperations.SetBinding(Model, GeometryModel3D.MaterialProperty, new Binding(nameof(Material)) { Source = this });
            Visual3DModel = Model;
            SetGeometry();
            Color = Colors.DarkKhaki;
            this.Name = Name;
        }

        public MazePumpDial(string Name, float x, float y, float z) : this(Name)
        {
            Position = new Point3D(x, y, z);
        }

        void RaiseDialChangedEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(MazePumpDial.DialChangedEvent);
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
                if (Dials.ContainsKey(_Name))
                {
                    Dials.Remove(_Name);
                }
                _Name = value;
                Dials[_Name] = this;
            }
        }

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value.ChangeAlpha(255)); }
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

        public float Angle
        {
            get
            {
                return _Angle;
            }
            set
            {
                _Angle = value;
                Update();
            }
        }

        public void Dispense()
        {
            Angle -= 10;
        }

        public void Update()
        {
            var tg = new Transform3DGroup();
            tg.Children.Add(new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), Angle)));
            tg.Children.Add(new TranslateTransform3D(_Position.X, _Position.Y, _Position.Z));

            this.Transform = tg;
        }

        public Material Material
        {
            get { return (Material)GetValue(MaterialProperty); }
            set { SetValue(MaterialProperty, value); }
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            Angle -= 10;
            RaiseDialChangedEvent();
            //DoorChanged?.Invoke(this, new DoorChangedEventArgs("test", IsClosed));
        }

        //protected override void OnMouseDown(MouseButtonEventArgs e)
        //{
        //    this.IsClosed = !IsClosed;
        //}

        private void SetGeometry()
        {
            var P1 = new Point3D(_Position.X, _Position.Y, _Position.Z);
            var P2 = new Point3D(_Position.X, _Position.Y, _Position.Z + 14);
            var P3 = new Point3D(_Position.X, _Position.Y + 3, _Position.Z + 13);
            MeshBuilder meshBuilder = new MeshBuilder(false, false);
            //meshBuilder.AddSphere(_Position, 2);
            meshBuilder.AddCylinder(P1, P2, 5);
            meshBuilder.AddBox(P3, 2, 7, 3);
            Model.Geometry = meshBuilder.ToMesh();
        }

        private void ColorChanged()
        {
            Material = MaterialHelper.CreateMaterial(Color);
        }
    }
}
