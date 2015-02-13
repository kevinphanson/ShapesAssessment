using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesAssessment
{
    public class Rectangle
    {
        public ShapeNames Name { get { return ShapeNames.rectangle; } }
        public double Length { get; set; }
        public double Width { get; set; }
        public Colors Color { get; set; }

        public double Area { get { return Length * Width; } }
    }
}
