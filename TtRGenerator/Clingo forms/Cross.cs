using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtRGenerator.Clingo_forms;

namespace TtRGenerator.Models
{
    public class Cross
    {
        public Edge E1 { get; set; }
        public Edge E2 { get; set; }
        public int Status { get; set; }

        public double Z1 { get; set; }
        public double Z2 { get; set; }


        public Cross(Edge e1, Edge e2)
        {
            E1 = e1;
            E2 = e2;

            Z1 = CalculateZ(E1, E2);
            Z2 = CalculateZ(E2, E1);

            Status = CalculateStatus(E1, E2, Z1, Z2);

        }

        private double CalculateZ(Edge e1, Edge e2)
        {
            //Współrzędne wektorów 
            double x1 = VectorX(e1.Start, e1.End); double y1 = VectorY(e1.Start, e1.End);
            double x2 = VectorX(e1.Start, e2.Start); double y2 = VectorY(e1.Start, e2.Start);
            double x3 = VectorX(e1.Start, e2.End); double y3 = VectorY(e1.Start, e2.End);

            //Iloczyn wektorowy = wyznacznik macierzy
            //det   [x1 x2]
            //      [y1 y2]
            double i1 = x1 * y2 - x2 * y1;
            //det   [x1 x3]
            //      [y1 y3]
            double i2 = x1 * y3 - x3 * y1;

            return i1 * i2;

        }

        private double VectorX(VerticesClingo n1, VerticesClingo n2)
        {
            return n2.Latitude - n1.Latitude;
        }

        private double VectorY(VerticesClingo n1, VerticesClingo n2)
        {
            return n2.Longitude - n1.Longitude;
        }

        /// <summary>
        /// Metoda wyznaczająca status
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <param name="Z1"></param>
        /// <param name="Z2"></param>
        /// <returns>int Status = 0,1,2</returns>
        private int CalculateStatus(Edge e1, Edge e2, double Z1, double Z2)
        {
            //Sytuacja: 1   status: 2-krzyżują się
            //--        Przykład AD BC

            //Sytuacja: 2   status: 2-krzyżują się
            //-0        Przykład AC BE
            //0-        Przykład BE AC

            //Sytuacja: 3   status: 1-nie krzyżują się
            //-+        Przykład CE AD
            //+-        Przykład AD CE

            //Sytuacja: 4   status: 1-nie krzyżują się
            //0+        Przykład CE AB
            //+0        Przykład AB CE

            //Sytuacja: 5   status: 1-nie krzyżują się
            //++        Przykład AB DE

            //Sytuacja: 6   status: ?
            //00           

            ////Status 3 - krzyżują się ale w sposób liniowy

            int isTheSameXorY = IsTheSameXorY(e1, e2);

            //sytuacja      4,5              4,5                   3                   3
            if ((Z1 > 0 && Z2 >= 0) || (Z1 >= 0 && Z2 > 0) || (Z1 > 0 && Z2 < 0) || (Z1 < 0 && Z2 > 0))
                return 1; // nie krzyżują się 

            //sytuacja          1,2                1,2
            else if ((Z1 <= 0 && Z2 < 0) || (Z1 < 0 && Z2 <= 0))
                return 2;  //krzyżują się

            //sytuacja 6
            else if (Z1 == 0 && Z2 == 0 && isTheSameXorY == 0)
            {

                bool b1 = CollinearCheck0(e1, e2);
                bool b2 = CollinearCheck0(e2, e1);

                if (b1 == true || b2 == true)
                    return 3;
                else
                    return 1;
            }
            //sytuacja 6
            else if (Z1 == 0 && Z2 == 0 && isTheSameXorY == 1)
            {

                bool b1 = CollinearCheck1(e1, e2);
                bool b2 = CollinearCheck1(e2, e1);

                if (b1 == true || b2 == true)
                    return 3;
                else
                    return 1;
            }

            //sytuacja 6
            else if (Z1 == 0 && Z2 == 0 && isTheSameXorY == 2)
            {

                bool b1 = CollinearCheck2(e1, e2);
                bool b2 = CollinearCheck2(e2, e1);

                if (b1 == true || b2 == true)
                    return 3;
                else
                    return 1;
            }


            return 0;

        }

        //Metoda sprawdzająca przecinanie gdy odcinki są współliniowe (działa jeśli 3 punkty nie mają takiego samego x lub takiego samego y)
        //Przypadek 5.0
        private bool CollinearCheck0(Edge e1, Edge e2)
        {
            //Sprawdzenie przecinania w poziomie
            bool horizontal = false;
            double xless = 0;
            double xmore = 0;
            if (e1.Start.Latitude <= e1.End.Latitude)
            {
                xless = (double)e1.Start.Latitude;
                xmore = (double)e1.End.Latitude;
            }
            else
            {
                xless = (double)e1.End.Latitude;
                xmore = (double)e1.Start.Latitude;
            }

            if ((e2.Start.Latitude > xless && e2.Start.Latitude < xmore)
                || (e2.End.Latitude > xless && e2.End.Latitude < xmore))
            {
                horizontal = true;
            }


            //Sprawdzenie przecinania w pionie
            bool vertical = false;
            double yless = 0;
            double ymore = 0;
            if (e1.Start.Longitude <= e1.End.Longitude)
            {
                yless = (double)e1.Start.Longitude;
                ymore = (double)e1.End.Longitude;
            }
            else
            {
                yless = (double)e1.End.Longitude;
                ymore = (double)e1.Start.Longitude;
            }

            if ((e2.Start.Longitude > yless && e2.Start.Longitude < ymore)
                || (e2.End.Longitude > yless && e2.End.Longitude < ymore))
            {
                vertical = true;
            }

            //Liczenie odległości
            double l0 = CalculateDistance(e1.Start, e1.End);


            double l1 = CalculateDistance(e2.Start, e1.Start);
            double l2 = CalculateDistance(e2.Start, e1.End);

            double l3 = CalculateDistance(e2.End, e1.End);
            double l4 = CalculateDistance(e2.End, e1.End);


            //-----------------------------
            if (horizontal && vertical && l0 == l1 + l2 && l0==l3+l4)
            {
                //Przecina się
                return true;
            }
            //Nie przecina się
            return false;
        }
        //Metoda licząca odległość miedzy wierzchołkami
        public static double CalculateDistance(VerticesClingo v1, VerticesClingo v2)
        {
            double dx = (double)v1.Longitude - (double)v2.Longitude;
            double dy = (double)v1.Latitude - (double)v2.Latitude;

            double distance = Math.Sqrt(dx * dx + dy * dy);

            return distance;
        }

        //Metoda sprawdzająca przecinanie gdy odcinki są współliniowe (działa jeśli 3 punkty mają taki sam x)
        //Przypadek 5.1
        private bool CollinearCheck1(Edge e1, Edge e2)
        {
            //Sprawdzenie przecinania w pionie
            double yless = 0;
            double ymore = 0;
            if (e1.Start.Longitude <= e1.End.Longitude)
            {
                yless = (double)e1.Start.Longitude;
                ymore = (double)e1.End.Longitude;
            }
            else
            {
                yless = (double)e1.End.Longitude;
                ymore = (double)e1.Start.Longitude;
            }

            if ((e2.Start.Longitude > yless && e2.Start.Longitude < ymore)
                || (e2.End.Longitude > yless && e2.End.Longitude < ymore))
            {
                //Przecina się
                return true;
            }
            //Nie przecina się
            return false;
        }

        //Metoda sprawdzająca przecinanie gdy odcinki są współliniowe (działa jeśli 3 punkty mają taki sam y)
        //Przypadek 5.2
        private bool CollinearCheck2(Edge e1, Edge e2)
        {
            //Sprawdzenie przecinania w poziomie
            double xless = 0;
            double xmore = 0;
            if (e1.Start.Latitude <= e1.End.Latitude)
            {
                xless = (double)e1.Start.Latitude;
                xmore = (double)e1.End.Latitude;
            }
            else
            {
                xless = (double)e1.End.Latitude;
                xmore = (double)e1.Start.Latitude;
            }

            if ((e2.Start.Latitude > xless && e2.Start.Latitude < xmore)
                || (e2.End.Latitude > xless && e2.End.Latitude < xmore))
            {
                return true;
            }

            return false;
        }

        private int IsTheSameXorY(Edge e1, Edge e2)
        {
            if (
                (e1.Start.Latitude == e1.End.Latitude) &&
                (e1.Start.Latitude == e2.Start.Latitude) &&
                (e1.Start.Latitude == e2.End.Latitude)
                )
                return 1;
            else if (
                (e1.Start.Longitude == e1.End.Longitude) &&
                (e1.Start.Longitude == e2.Start.Longitude) &&
                (e1.Start.Longitude == e2.End.Longitude)
                )
            {
                return 2;
            }

            return 0;
        }
    }
}
