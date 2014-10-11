namespace Abstraction
{
    using System;

    public abstract class Figure : IFigure
    {
        private double width;
        private double height;
        private double radius;

        public Figure(double radius)
        {
            this.Radius = radius;
        }

        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Width can not be negative!", "width");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Height can not be negative!", "height");
                }

                this.height = value;
            }
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Radius can not be negative!", "radius");
                }

                this.radius = value;
            }
        }

        public abstract double CalcPerimeter();

        public abstract double CalcSurface();
    }
}