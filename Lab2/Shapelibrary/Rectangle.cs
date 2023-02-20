using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Shapelibrary
{
    public class Rectangle : Shape2D
    {
        public override float Circumference { get; }
        public override Vector3 Center { get; }
        public override float Area { get; }
        public Vector2 Size { get; }




        public Rectangle(Vector2 center, Vector2 size)
        {
            //Area = size.x * size.y
            //circumference = size.x + size.x + size.y + size.y = size.x*2 + size.y*2

            this.Center = new Vector3(center, 0);
            this.Area = size.X * size.Y;
            this.Size = size;
            this.Circumference = size.X * 2 + size.Y * 2;
        }

        public Rectangle(Vector2 center, float width)
        {
            //Area = width*width
            //circumference = width + width + width + width = width * 4


            this.Center = new Vector3(center, 0);
            this.Area = width * width;
            this.Size = new Vector2(width, width);
            this.Circumference = width * 4;
        }


        public string IsSquare
        {
            get
            {
                if (Size.X == Size.Y)
                {
                    return "Square";
                }
                else
                {
                    return "Rectangle";
                }
            }
        }

        public override string ToString()
        {
            return $"{IsSquare} @({Center.X:F1}, {Center.Y:F1}): w = {Size.X:F1} h= {Size.Y:F1}";
        }
    }
}