using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesAssessment
{
    public class Triangle
    {
        public ShapeNames Name { get { return ShapeNames.triangle; } }
        public double Base { get; set; }
        public double Height { get; set; }
        public Colors Color { get; set; }

        public double Area { get { return Base * Height / 2; } }
    }
}
