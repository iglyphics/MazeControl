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
    public class MazeMouse : UIElement3D
    {
        //private const string PinkyModel = @"C:\Users\rhughes\Downloads\Pinky.stl";
        private const string PinkyModel = @".\Pinky.stl";
        protected GeometryModel3D Model { get; set; }
        private Point3D _Position = new Point3D(0, 0, 0);
        private float _Angle = 0;


        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(
            nameof(Color), typeof(Color), typeof(MazeMouse), new UIPropertyMetadata((s, e) => ((MazeMouse)s).ColorChanged()));

        public static readonly DependencyProperty MaterialProperty = DependencyProperty.Register(
            nameof(Material), typeof(Material), typeof(MazeMouse), new PropertyMetadata(null));

        public MazeMouse()
        {
            SetGeometry(PinkyModel);
            //ModelVisual3D Pinky3D = new ModelVisual3D();
            //Pinky3D.Content = Display3d(PinkyModel);
            //Pinky3D.SetName("pinky");
            
            //Color = Colors.Brown;
        }

        public MazeMouse(float x, float y, float z) : this()
        {
            Position = new Point3D(x, y, z);
        }

        public MazeMouse(float x, float y, float z, float Angle) : this(x, y, z)
        {
            this.Angle = Angle;

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

        public void Update()
        {
            var tg = new Transform3DGroup();
            tg.Children.Add(new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), Angle)));
            tg.Children.Add(new TranslateTransform3D(_Position.X, _Position.Y, _Position.Z));
            this.Transform = tg;
        }

        private void SetGeometry(string model)
        {
            Model3DGroup device = null;
            try
            {
                //Import 3D model file
                ModelImporter import = new ModelImporter();
                System.Windows.Media.Media3D.Material mat = MaterialHelper.CreateMaterial(
            //new SolidColorBrush(Colors.SaddleBrown));
            new SolidColorBrush(Colors.Pink));
                import.DefaultMaterial = mat;
                //Load the 3D model file
                device = import.Load(model);
            }
            catch (Exception e)
            {
                // Handle exception in case can not file 3D model
                MessageBox.Show("Exception Error : " + e.StackTrace);
            }
            Visual3DModel = device;
        }

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public Material Material
        {
            get { return (Material)GetValue(MaterialProperty); }
            set { SetValue(MaterialProperty, value); }
        }

        private void ColorChanged()
        {
            Material = MaterialHelper.CreateMaterial(Color);
        }
    }
}
