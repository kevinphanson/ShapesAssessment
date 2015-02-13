using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShapesAssessment
{
    public partial class Form1 : Form
    {
        List<Shape> shapeList = new List<Shape>();
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("[select one]");
            comboBox1.Items.Add("triangle");
            comboBox1.Items.Add("square");
            comboBox1.Items.Add("circle");
            comboBox1.Items.Add("rectangle");
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            shapeList = ProcessInput();
            foreach (Shape s in shapeList.OrderBy(sl=>sl.Area))
            {
                textBox2.Text += string.Format("{0}, {1:0.00}, {2}{3}", s.Name, s.Area, s.Color, Environment.NewLine);
            }
            foreach (Shape s in shapeList.OrderBy(sl => sl.Color))
            {
                textBox3.Text += string.Format("{0}, {1:0.00}, {2}{3}", s.Name, s.Area, s.Color, Environment.NewLine);
            }
        }

        List<Shape> ProcessInput()
        {
            var input = textBox1.Text.Replace("\r\n", ",").Split(',');

            List<object> shapes = new List<object>();

            if (input.Length >= 3)
            {
                int i = 0;
                while (i < input.Length)
                {
                    string n = input[i];
                    switch ((ShapeNames)Enum.Parse(typeof(ShapeNames), n))
                    {
                        case ShapeNames.triangle:
                            if (input.Length >= i + 4)
                                shapes.Add(BuildTriangle(input[i], input[i + 1], input[i + 2], input[i + 3]));
                            i += 4;
                            break;
                        case ShapeNames.circle:
                            if (input.Length >= i + 3)
                                shapes.Add(BuildCircle(input[i], input[i + 1], input[i + 2]));
                            i += 3;
                            break;
                        case ShapeNames.square:
                            if (input.Length >= i + 3)
                                shapes.Add(BuildSquare(input[i], input[i + 1], input[i + 2]));
                            i += 3;
                            break;
                        case ShapeNames.rectangle:
                            if (input.Length >= i + 4)
                                shapes.Add(BuildRectangle(input[i], input[i + 1], input[i + 2], input[i + 3]));
                            i += 4;
                            break;
                        default:
                            break;
                    }
                }
            }

            List<Shape> sl = new List<Shape>();
            foreach (object o in shapes)
            {
                System.Type type = o.GetType();
                if (type == typeof(Triangle))
                    sl.Add(new Shape() { Name =((Triangle)o).Name, Area = ((Triangle)o).Area, Color = ((Triangle)o).Color });
                if (type == typeof(Square))
                    sl.Add(new Shape() { Name =((Square)o).Name, Area = ((Square)o).Area, Color = ((Square)o).Color });
                if (type == typeof(Circle))
                    sl.Add(new Shape() { Name =((Circle)o).Name, Area = ((Circle)o).Area, Color = ((Circle)o).Color });
                if (type == typeof(Rectangle))
                    sl.Add(new Shape() { Name =((Rectangle)o).Name, Area = ((Rectangle)o).Area, Color = ((Rectangle)o).Color });
            }

            return sl;
        }

        private Triangle BuildTriangle(string p1, string p2, string p3, string p4)
        {
            double b, h;
            if (!double.TryParse(p2, out b))
            {
                throw new Exception("invalid input");
            }
            if (!double.TryParse(p3, out h))
            {
                throw new Exception("invalid input");
            }
            Colors c = (Colors)Enum.Parse(typeof(Colors), p4);

            return new Triangle() { Base = b, Height = h, Color = c };
        }

        private Circle BuildCircle(string p1, string p2, string p3)
        {
            double r;
            if (!double.TryParse(p2, out r))
            {
                throw new Exception("invalid input");
            }
            Colors c = (Colors)Enum.Parse(typeof(Colors), p3);

            return new Circle() { Radius = r, Color = c };
        }

        private Square BuildSquare(string p1, string p2, string p3)
        {
            double l;
            if (!double.TryParse(p2, out l))
            {
                throw new Exception("invalid input");
            }
            Colors c = (Colors)Enum.Parse(typeof(Colors), p3);

            return new Square() { Length = l, Color = c };
        }

        private Rectangle BuildRectangle(string p1, string p2, string p3, string p4)
        {
            double w, l;
            if (!double.TryParse(p2, out w))
            {
                throw new Exception("invalid input");
            }
            if (!double.TryParse(p3, out l))
            {
                throw new Exception("invalid input");
            }
            Colors c = (Colors)Enum.Parse(typeof(Colors), p4);

            return new Rectangle() { Width = w, Length = l, Color = c };
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            string shape = comboBox1.GetItemText(comboBox1.SelectedItem);
            shapeList = ProcessInput();

            foreach (Shape s in shapeList.OrderBy(sl => sl.Area).Where(sl => sl.Name.ToString() == shape))
            {
                textBox4.Text += string.Format("{0}, {1:0.00}, {2}{3}", s.Name, s.Area, s.Color, Environment.NewLine);
            }
            foreach (Shape s in shapeList.OrderBy(sl => sl.Color).Where(sl => sl.Name.ToString() == shape))
            {
                textBox5.Text += string.Format("{0}, {1:0.00}, {2}{3}", s.Name, s.Area, s.Color, Environment.NewLine);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "triangle, 5, 6, yellow\r\nsquare, 8, red\r\ncircle, 3, blue\r\ntriangle, 5, 6, green\r\nrectangle, 10, 5, purple";
        }


    }
}
