using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesAssessment
{
    public class Square
    {
        public ShapeNames Name { get { return ShapeNames.square; } }
        public double Length { get; set; }
        public Colors Color { get; set; }

        public double Area { get { return Length * Length; } }
    }
}
