using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Shapelibrary
{
    public class Cuboid : Shape3D
    {
        public override Vector3 Center { get; }
        public override float Area { get; }
        public override float Volume { get; }
        public Vector3 Size { get; }


        public Cuboid(Vector3 center, Vector3 size)
        {
            // Volume = x*y*z , Area = 2*x*y + 2*y*z + 2*x*z

            this.Volume = size.X * size.Y * size.Z;
            this.Center = new Vector3(center.X, center.Y, center.Z);
            this.Area = 2 * (size.X * size.Y) + 2 * (size.Z * size.Y) + 2 * (size.X * size.Z);
            this.Size = size;
        }
        public Cuboid(Vector3 center, float width)
        {
            // Volume = x*x*x , Area = 6*x*x
            this.Center = new Vector3(center.X, center.Y, center.Z);
            this.Area = width * width * 6;
            this.Volume = width * width * width;
            this.Size = new Vector3(width, width, width);
        }
        public string IsCube
        {
            get
            {
                if (Size.X == Size.Y)
                {
                    return "Cube";
                }
                else
                {
                    return "Cuboid";
                }
            }
        }

        public override string ToString()
        {
            return $"{IsCube} @({Center.X:F1}, {Center.Y:F1}, {Center.Z:F1}): w = {Size.X:F1}, h = {Size.Y:F1}, l = {Size.Z:F1}";
        }
    }
}