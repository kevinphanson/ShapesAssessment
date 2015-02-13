using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesAssessment
{
    public class Circle
    {
        public ShapeNames Name { get { return ShapeNames.circle; } }
        public double Radius { get; set; }
        public Colors Color { get; set; }

        public double Area { get { return Math.PI * Radius * Radius; } }
    }
}
