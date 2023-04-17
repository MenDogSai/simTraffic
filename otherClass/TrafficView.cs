using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace simTraffic.otherClass
{
    public partial class trafficView : Form
    {
        int nDegree = 0;
        YMobileGroup yMobileGroups = new YMobileGroup();
        public trafficView()
        {
            InitializeComponent();
        //--깜빡임 방지 코드 시작--//
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        //--깜빡임 방지 코드 끝--//
        private void trafficViewLoad(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            yMobileGroups.generateCar(YCourse.EAST);
            moveTimer.Enabled = true;
        }
        private void moveTimerTick(object sender, EventArgs e)
        {
            //남좌표 465, 550
            nDegree = (nDegree < 90) ? nDegree + 1 : nDegree;
            moveTimer.Enabled = false;
            moveLeft(0, nDegree);
            this.Refresh();
            moveTimer.Enabled = true;
        }

        private void pictureBoxPaint(object sender, PaintEventArgs e)
        {
            if (yMobileGroups.yMobiles.Count == 0) return;
            e.Graphics.DrawImage(yMobileGroups.yMobiles[0].cCarBitmap, yMobileGroups.yMobiles[0].cRactangle);
        }
        private int getCurveX(int nX, int nR, double dDegree)
        {
            //x는 x축 원점, r는 반지름, degree 각도
            //x = x + r * cos(degree * PI / 180);
            double dRadian = dDegree * Math.PI / 180;
            return (int)(nX + (nR * Math.Cos(dRadian)));
        }
        private int getCurveY(int nY, int nR, double dDegree)
        {
            //x는 x축 원점, r는 반지름, degree 각도
            //x = x + r * cos(degree * PI / 180);
            double dRadian = dDegree * Math.PI / 180;
            return (int)(nY + (nR * Math.Sin(dRadian)));
        }
        private void moveLeft(int nIndex, int nDegree)
        {
            YMobile yMobile = yMobileGroups.yMobiles[nIndex];
            yMobile.fDegree = (float)-nDegree;
            YCourse yCourse = yMobile.yCourse;
            nDegree = (nDegree < 90) ? nDegree : 90;
            int nX = 0; int nY = 0;
            switch (yCourse)
            {
                case YCourse.SOUTH:
                    nX = getCurveX(465, 205, -nDegree * 0.7777F);
                    nY = getCurveY(550, 205, -nDegree * 0.7777F);
                    yMobileGroups.movedCar(nIndex, nX - 205, nY);
                    yMobileGroups.rotatedCar(nIndex, -nDegree);
                    break;
                case YCourse.NORTH:
                    nX = getCurveX(365, -205, nDegree * 0.7777F);
                    nY = getCurveY(280, 205, nDegree * 0.7777F);
                    yMobileGroups.movedCar(nIndex, nX + 205, nY);
                    yMobileGroups.rotatedCar(nIndex, 180 - nDegree);
                    break;
                case YCourse.EAST: //new Point(280, 370);
                    nX = getCurveX(280, 205, nDegree * 0.7777F);
                    nY = getCurveY(370, 205, nDegree * 0.7777F);
                    yMobileGroups.movedCar(nIndex, nX + 205, nY);
                    //yMobileGroups.rotatedCar(nIndex, 90 - nDegree);
                    break;
            }
        }

        private void trafficView_Paint(object sender, PaintEventArgs e)
        {
            if (yMobileGroups.yMobiles.Count == 0) return;
            e.Graphics.DrawImage(yMobileGroups.yMobiles[0].cCarBitmap, yMobileGroups.yMobiles[0].cRactangle);
        }
    }
}
