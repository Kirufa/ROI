using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ROISelect
{
    public class ROI
    {
        public enum SelectionMode
        {
           Center,Roi
        }


        public SelectionMode mode;


        public Bitmap OriginalImage;
        public List<PointF> CenterPoints;
       

        public const int DGV_Location = 1;
        public const int DGV_Index = 0;

        public float ResizeRate;
        public PointF ResizeOffset;


        public PointF PointShift_ToOrigin(PointF point)
        {
            return new PointF((point.X - ResizeOffset.X) / ResizeRate, 
                              (point.Y - ResizeOffset.Y) / ResizeRate);
        }

        public PointF PointShift_ToNew(PointF point)
        {
            return new PointF(point.X * ResizeRate + ResizeOffset.X,
                              point.Y * ResizeRate + ResizeOffset.Y);
        }

        #region Select Roi

        public const int RectangleSize_Roi = 200;
        public const int RectangleSize_Ori = 270;

        public List<int[]> Edges;
        public List<RectangleF[]> SaveRoies;
        public PointF LFPoint;

        public int SelectIndex;
        public int SelectEdge;

        public PointF GetLFPoint()
        {
            int i = SelectIndex;
            int edge = SelectEdge;

            PointF p = CenterPoints[i];

            switch (Edges[i][edge])
            {
                case 0:
                    p = new PointF(CenterPoints[i].X + RectangleSize_Ori / 2 - RectangleSize_Roi / 2,
                                   CenterPoints[i].Y - RectangleSize_Roi / 2);
                    break;
                case 1:
                    p = new PointF(CenterPoints[i].X - RectangleSize_Roi / 2,
                                   CenterPoints[i].Y - RectangleSize_Ori / 2 - RectangleSize_Roi / 2);
                    break;
                case 2:
                    p = new PointF(CenterPoints[i].X - RectangleSize_Ori / 2 - RectangleSize_Roi / 2,
                                   CenterPoints[i].Y - RectangleSize_Roi / 2);
                    break;
                case 3:
                    p = new PointF(CenterPoints[i].X - RectangleSize_Roi / 2,
                                   CenterPoints[i].Y + RectangleSize_Ori / 2 - RectangleSize_Roi / 2);
                    break;

            }

            return p;
        }
        public void RefreshPicturBox_part(PictureBox picBox)
        {
            int i = SelectIndex;
            int edge = SelectEdge;

            PointF p = GetLFPoint();
                      

            using (Graphics g = Graphics.FromImage(picBox.Image))         
                g.DrawImage(
                    OriginalImage,
                    new RectangleF(Point.Empty, picBox.Size),
                    new RectangleF(p, new SizeF(RectangleSize_Roi, RectangleSize_Roi)),
                    GraphicsUnit.Pixel);


          
            picBox.Invalidate();

            LFPoint = p;
        }






        #endregion






        public ROI()
        {
            CenterPoints = new List<PointF>();
            Edges = new List<int[]>();



            //0:>  1:^  2:<  3:v

            Edges.Add(new int[2] { 0, 3 });
            Edges.Add(new int[2] { 2, 3 });
            Edges.Add(new int[2] { 2, 3 });
            Edges.Add(new int[2] { 0, 1 });
            Edges.Add(new int[2] { 1, 2 });

            SaveRoies = new List<RectangleF[]>();

            for (int i = 0; i != 5; ++i)
                SaveRoies.Add(new RectangleF[] { RectangleF.Empty, RectangleF.Empty });




        }


        public void PictureBox_main_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox picbox = sender as PictureBox;
            DataGridView dgv = ((sender as Control).Tag) as DataGridView;

            if (dgv.Rows.Count > 5)
                return;

            PointF p = new PointF(e.X, e.Y);
            p = PointShift_ToOrigin(p);


            dgv.Rows.Add(dgv.RowCount, p);
            CenterPoints.Add(p);

            picbox.Invalidate();

        }

        



    }
}
