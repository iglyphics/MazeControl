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
    public class MazePathSensor : MazeSensor
    {
        public MazePathSensor() : base()
        {
        }

        public MazePathSensor(string Name) : base(Name)
        {
        }

        public MazePathSensor(string Name, float x, float y, float z) : base(Name, x, y, z)
        {
        }

        public MazePathSensor(string Name, float x, float y, float z, bool Horizontal) : base(Name, x, y, z, Horizontal)
        {
        }

        protected override void SetGeometry()
        {
            var P1 = new Point3D(_Position.X, _Position.Y - 14, _Position.Z);
            var P2 = new Point3D(_Position.X, _Position.Y + 14, _Position.Z);
            
            MeshBuilder meshBuilder = new MeshBuilder(false, false);
            //meshBuilder.AddSphere(_Position, 2);
            meshBuilder.AddCylinder(P1, P2, 1);

            P1 = new Point3D(_Position.X, _Position.Y - 14, _Position.Z);
            P2 = new Point3D(_Position.X, _Position.Y - 12, _Position.Z);
            meshBuilder.AddCylinder(P1, P2, 3);

            P1 = new Point3D(_Position.X, _Position.Y + 12, _Position.Z);
            P2 = new Point3D(_Position.X, _Position.Y + 14, _Position.Z);
            meshBuilder.AddCylinder(P1, P2, 3);

            Model.Geometry = meshBuilder.ToMesh();
        }
    }
}
