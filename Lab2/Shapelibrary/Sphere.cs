using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Shapelibrary
{
    public class Sphere : Shape3D
    {
        public override Vector3 Center { get; }
        public override float Area { get; }
        public override float Volume { get; }
        public float Radius { get; }


        public Sphere(Vector3 center, float radius)
        {
            //   V = 4/3*Pi*r^3     A=4*Pi*r^2

            this.Center = new Vector3(center.X, center.Y, center.Z);
            Radius = radius;

            this.Volume = (float)(4 / 3 * Math.PI * Math.Pow(radius, 3));
            this.Area = (float)(4 * Math.PI * Math.Pow(radius, 2));

        }

        public override string ToString()
        {
            return $"Sphere @({Center.X:F1}, {Center.Y:F1}, {Center.Z:F1}): r = {Radius:F1}";
        }

    }
}