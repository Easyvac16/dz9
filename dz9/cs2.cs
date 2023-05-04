using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz9
{
    class MyMethods
    {
        public void DisplayCurrentTime()
        {
            Console.WriteLine("Поточний час: " + DateTime.Now.ToString("HH:mm:ss"));
        }

        public void DisplayCurrentDate()
        {
            Console.WriteLine("Поточна дата: " + DateTime.Now.ToString("yyyy-MM-dd"));
        }

        public void DisplayCurrentDayOfWeek()
        {
            Console.WriteLine("Поточний день тижня: " + DateTime.Now.DayOfWeek);
        }

        public double CalculateTriangleArea(double baseLength, double height)
        {
            return 0.5 * baseLength * height;
        }

        public double CalculateRectangleArea(double length, double width)
        {
            return length * width;
        }
    }
    internal class cs2
    {
        public static void task_2()
        {
            MyMethods myMethods = new MyMethods();

            // Виклик методів з використанням делегатів
            Action currentTimeDelegate = myMethods.DisplayCurrentTime;
            currentTimeDelegate();

            Action currentDateDelegate = myMethods.DisplayCurrentDate;
            currentDateDelegate();

            Action currentDayOfWeekDelegate = myMethods.DisplayCurrentDayOfWeek;
            currentDayOfWeekDelegate();

            Func<double, double, double> triangleAreaDelegate = myMethods.CalculateTriangleArea;
            double triangleArea = triangleAreaDelegate(3.0, 4.0);
            Console.WriteLine("Площа трикутника: " + triangleArea);

            Func<double, double, double> rectangleAreaDelegate = myMethods.CalculateRectangleArea;
            double rectangleArea = rectangleAreaDelegate(3.0, 4.0);
            Console.WriteLine("Площа прямокутника: " + rectangleArea);
            Console.WriteLine("\n");
        }
    }
}
