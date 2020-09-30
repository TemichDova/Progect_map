using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Progect_map_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = Random_points(10);
            foreach (POint _point in rand)
            {
                Console.WriteLine("Name:{0} | {1}; {2}", _point.name_point,_point.lon,_point.lng);
            }
            var cen = Segment_center(rand[0].lon, rand[0].lng, rand[1].lon, rand[1].lng);
            Console.WriteLine("_______________________________________________________");
            Console.WriteLine("Name:{0} | {1}; {2}", cen.name_point, cen.lon, cen.lng);
            Console.WriteLine("_______________________________________________________");
            var r1 = Long_points(rand[0].lon, rand[0].lng, cen.lon, cen.lng);
            var r2 = Long_points(cen.lon, cen.lng, rand[1].lon, rand[1].lng);
            Console.WriteLine("{0}  {1}",r1,r2);

            Console.WriteLine("список_______________________________________________________");
            Eror(rand,cen,r1);
            Console.ReadLine();
        }
        //Генерация данных
        static List<POint> Random_points(int _step)
        {
            Random random = new Random();
            List<POint> temp_list = new List<POint>();
            for (int i=0;i<=_step;i++)
            {
                
                temp_list.Add(new POint() { id_point=i, name_point="Point_name_"+i, lon= random.NextDouble(),lng= random.NextDouble(), });
                //Thread.Sleep(1);
            }
            return temp_list;
        }
        //нахождение центра отрезка между точками
        static POint Segment_center(double _x1, double _y1, double _x2, double _y2)
        {
            var center_x = (_x1 + _x2) / 2;
            var center_y = (_y1 + _y2) / 2;
            return new POint() { name_point = "Center_point", lon = center_x, lng=center_y };
        }
        //Длина между центром и начальной точкой / радиус окружности от центральной точки 
        static double Long_points(double _x1, double _y1, double _x2, double _y2) {
            var temp = Math.Sqrt(Math.Pow((_x2-_x1),2)+ Math.Pow((_y2 - _y1), 2)) ;
            return temp;
        }
        //Нахождение точек в радиусе 
        static void Eror(List<POint> _points, POint _center, double _radius)
        {
           
            _points.Remove(_points[0]);
            _points.Remove(_points[0]);
           

            List<POint> newPoints = new List<POint>();
            foreach (POint point in _points)
            {
                var long_poi = Long_points(_center.lon,_center.lng,point.lon,point.lng);
                if (long_poi<=_radius)
                {
                    // _points.Remove(point);           
                    newPoints.Add(point);
                }
            }
            foreach (POint point in newPoints)
            {
                Console.WriteLine("Name:{0} | {1}; {2}", point.name_point, point.lon, point.lng);
            }
        }

        static List<POint> Line_points(List<POint> _points)
        {

            return null;
        }

    }
    class POint{
        public int id_point { get; set; }
        public double lon { get; set; }
        public double lng { get; set; }
        public string name_point { get; set; }
        public List<int> line_points { get; set; }
    }
}
