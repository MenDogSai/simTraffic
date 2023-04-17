using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simTraffic.otherClass
{
    //‘north, south, east and west
    public enum YCourse : byte
    {
        NORTH = 0, 
        SOUTH = 1, 
        EAST  = 2,
        WEST  = 3,
    }
    public enum YDirection : byte
    {
        FOWARD= 0,
        LEFT  = 1,
        RIGHT = 2,
    }
    public struct YMobile
    {
        public int nNumber;
        public float fDegree;
        public YDirection yDirection;
        public YCourse    yCourse;
        public Bitmap     cBitmap;
        public Bitmap     cCarBitmap;
        public Rectangle  cRactangle;
    }
    public class YMobileGroup
    {
        public List<YMobile> yMobiles = new List<YMobile>();
        private int nIndex = 0;
        private int generateCarNumber()
        {
            int nNumber = 0;
            bool bFlag = false;
            Random cRandom = new Random();
            while (bFlag)//number 가 고유 값을 갖기 위한 구문
            {
                nNumber = cRandom.Next(1, int.MaxValue);
                foreach(YMobile yMobile in yMobiles)
                {
                    if(yMobile.nNumber == nNumber)
                        bFlag = true;
                    else
                        bFlag = false;
                }
            }
            return nNumber;
        }
        private YDirection generateYDirection()
        {
            Random cRandom = new Random();
            return (YDirection)cRandom.Next(0, 2);
        }
        private Bitmap generateCarBitmap()
        {
            Random cRandom = new Random();
            int nIndex = cRandom.Next(1, 7);

            if (nIndex == 1) return Properties.Resources.car01;
            else
            if (nIndex == 2) return Properties.Resources.car02;
            else
            if (nIndex == 3) return Properties.Resources.car03;
            else
            if (nIndex == 4) return Properties.Resources.car04;
            else
            if (nIndex == 5) return Properties.Resources.car05;
            else
            if (nIndex == 6) return Properties.Resources.car06;
            else
            if (nIndex == 7) return Properties.Resources.car07;

            return Properties.Resources.car08;
        }
        public void generateCar(YCourse yCourse)
        {
            YMobile yNewMoile     = new YMobile();
            yNewMoile.nNumber     = generateCarNumber();
            yNewMoile.yDirection  = generateYDirection();
            yNewMoile.cBitmap     = generateCarBitmap();
            yNewMoile.yCourse     = yCourse;
            switch (yCourse)
            {
                case YCourse.SOUTH:
                    yNewMoile.fDegree = 0;
                    yNewMoile.cRactangle = new Rectangle(465, 550, yNewMoile.cBitmap.Width, yNewMoile.cBitmap.Height);
                    yNewMoile.cCarBitmap = yNewMoile.cBitmap;
                    break;
                case YCourse.NORTH:
                    yNewMoile.fDegree = 180;
                    yNewMoile.cRactangle = new Rectangle(365, 280, yNewMoile.cBitmap.Width, yNewMoile.cBitmap.Height);
                    yNewMoile.cCarBitmap = rotatedBitmap(yNewMoile.cBitmap, 180);
                    break;
                case YCourse.EAST:
                    yNewMoile.fDegree = 90;
                    yNewMoile.cRactangle = new Rectangle(280, 470, yNewMoile.cBitmap.Width, yNewMoile.cBitmap.Height);
                    yNewMoile.cCarBitmap = rotatedBitmap(yNewMoile.cBitmap, 90);
                    break;
                case YCourse.WEST:
                    // rotatedCar(nIndex, 90);
                    break;
            }
            this.nIndex++;
            yMobiles.Add(yNewMoile);
        }
        public Bitmap rotatedBitmap(Bitmap cNowBitmap, float fDegree)
        {
            int x = 0, y = 0, i = 0, j = 0;
            double dRadian = fDegree * Math.PI / 180.0;
            double dCos = Math.Cos(dRadian);
            double dSin = Math.Sin(-dRadian);
            double dXcenter = cNowBitmap.Width / 2.0;
            double dYcenter = cNowBitmap.Height / 2.0;
            int nWidth = cNowBitmap.Width;
            int nHeight = cNowBitmap.Height;
            Bitmap cNewBitmap = new Bitmap(nWidth, nHeight);

            while (true)
            {
                i = (int)(dCos * (x - dXcenter) - dSin * (y - dYcenter) + dXcenter);
                j = (int)(dSin * (x - dXcenter) + dCos * (y - dYcenter) + dYcenter);

                if ((j >= 0 && j < nHeight) && (i >= 0 && i < nWidth))
                    cNewBitmap.SetPixel(x, y, cNowBitmap.GetPixel(i, j));

                //이중 반복문 내용
                x++;
                y = (x < nWidth) ? y : y + 1;
                x = (x < nWidth) ? x : 0;
                if (y >= nHeight) break;
            }
            return cNewBitmap;
        }
        public void rotatedCar(int nIndex, float fDegree)
        {
            YMobile yMobile = yMobiles[nIndex];
            Bitmap cNowBitmap = yMobiles[nIndex].cBitmap;
            yMobile.cCarBitmap = rotatedBitmap(cNowBitmap, fDegree);
            yMobile.fDegree = fDegree;
            yMobiles[nIndex] = yMobile;
        }
        public void movedCar(int nIndex, int nX, int nY)
        {
            YMobile yMobile = yMobiles[nIndex];
            Point cPoint = new Point(nX, nY);
            yMobile.cRactangle.Location = cPoint;
            yMobiles[nIndex] = yMobile;
        }
    }
}
