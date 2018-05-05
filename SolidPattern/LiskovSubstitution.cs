using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPattern
{
    public class Rectangle
    {
        /* Derived classes must be substitutable for their base classes.
         * The Liskov Substitution Principle (LSP): functions that use pointers to base classes must be able to use objects of derived classes without knowing it. */

        public virtual int Height { get; set; }
        public virtual int Width { get; set; }
        public Rectangle()
        {

        }
        public Rectangle(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public override string ToString()
        {
            return $"{nameof(Height)} is {Height} and {nameof(Width)} is {Width}";
        }

    }

    public class Square : Rectangle
    {

        public override int Width
        {
            set
            {
                base.Width = base.Height = value;
            }
        }

        public override int Height
        {
            set
            {
                base.Width = base.Height = value;
            }
        }
    }

    public class Demo
    {
        public int Area(Rectangle rec) => rec.Width * rec.Height;

    }
}
