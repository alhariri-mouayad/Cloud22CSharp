using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Shapelibrary
{
    public class Triangle : Shape2D, IEnumerable
    {
        public override float Circumference { get; }
        public override Vector3 Center { get; }
        public override float Area { get; }

        public Vector2[] vectors;

        public Vector2 CornerA { get; }
        public Vector2 CornerB { get; }
        public Vector2 CornerC { get; }

        public Triangle(Vector2 p1, Vector2 p2, Vector2 p3)
        {
            this.CornerA = new Vector2(p1.X, p1.Y);
            this.CornerB = new Vector2(p2.X, p2.Y);
            this.CornerC = new Vector2(p3.X, p3.Y);

            vectors = new[] { p1, p2, p3 };
            float DistanceAtoB = (float)Math.Sqrt((float)Math.Pow((p1.X - p2.X), 2) + (float)Math.Pow((p1.Y - p2.Y), 2));
            float DistanceBtoC = (float)Math.Sqrt((float)Math.Pow((p2.X - p3.X), 2) + (float)Math.Pow((p2.Y - p3.Y), 2));
            float DistanceCtoA = (float)Math.Sqrt((float)Math.Pow((p3.X - p1.X), 2) + (float)Math.Pow((p3.Y - p1.Y), 2));

            // Omkrets = AtoB + BtoC + CtoA
            // Semiperimeter = 1/2 * (omkrets)
            // Area =SquareRoot(Semiperimeter(Semiperimeter-AtoB) * (Semiperimeter-BtoC) * (Semiperimeter-CtoA)

            Circumference = DistanceAtoB + DistanceBtoC + DistanceCtoA;
            var Semiperimeter = 1 / 2 * Circumference;
            this.Area = (float)Math.Sqrt(Semiperimeter * (Semiperimeter - DistanceAtoB) * (Semiperimeter - DistanceBtoC) * (Semiperimeter - DistanceCtoA));

            // center = ((p1.x + p2.x + p3.x)/3, (p1.y + p2.y + p3.y)/3)

            this.Center = new Vector3((p1.X + p2.X + p3.X) / 3, (p1.Y + p2.Y + p3.Y) / 3, 0);

        }
        public IEnumerator GetEnumerator()
        {
            return vectors.GetEnumerator();
        }
        public override string ToString()
        {
            return $"triangle @({Center.X:F1}, {Center.Y:F1}): p1({CornerA.X:F1}, {CornerA.Y:F1}), p2({CornerB.X:F1}, {CornerB.Y:F1}), p3({CornerC.X:F1}, {CornerC.Y:F1})";
        }

    }





}