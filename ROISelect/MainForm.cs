using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace ROISelect
{
    public partial class form_main : Form
    {
        public form_main()
        {
            InitializeComponent();
            roi = new SFR();

            pictureBox_full.Image = new Bitmap(pictureBox_full.Width, pictureBox_full.Height);
            pictureBox_part.Image = new Bitmap(pictureBox_part.Width, pictureBox_part.Height);

            pictureBox_part.Tag = new PointF[] { PointF.Empty, PointF.Empty };

        }

        private SFR roi;


        private void button_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();


            if(ofd.ShowDialog() == DialogResult.OK &&
               !string.IsNullOrEmpty(ofd.FileName))
            {
                roi.OriginalImage = new Bitmap(ofd.FileName);



                using (Graphics g = Graphics.FromImage(pictureBox_full.Image))
                {
                    g.Clear(Color.Transparent);

                    float picBoxSize = pictureBox_full.Width;


                    roi.ResizeRate = picBoxSize / Math.Max(roi.OriginalImage.Width, roi.OriginalImage.Height);
                                                                                          
                    float reWidth = roi.ResizeRate * roi.OriginalImage.Width;
                    float reHeight = roi.ResizeRate * roi.OriginalImage.Height;

                    if (roi.OriginalImage.Width > roi.OriginalImage.Height)
                        roi.ResizeOffset = new PointF(0, (picBoxSize - reHeight) / 2);
                    else
                        roi.ResizeOffset = new PointF((picBoxSize - reWidth) / 2, 0);

                    g.DrawImage(
                            roi.OriginalImage,
                            new RectangleF(roi.ResizeOffset, new SizeF(reWidth, reHeight)),
                            new RectangleF(0, 0, roi.OriginalImage.Width, roi.OriginalImage.Height),
                            GraphicsUnit.Pixel);

                }
                pictureBox_full.Invalidate();

               
                label_path.Text = ofd.FileName;
            }



        }

        private void tabControl_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabcontrol = sender as TabControl;
            DataGridView dgv = dataGridView_points;



            pictureBox_full.MouseClick -= roi.PictureBox_main_MouseClick;



            if (tabcontrol.SelectedIndex == 1)       //select center
            {
                roi.mode = SFR.SelectionMode.Center;
                pictureBox_full.Tag = dgv;




                pictureBox_full.MouseClick += new MouseEventHandler(roi.PictureBox_main_MouseClick);



                //                using (Graphics g = Graphics.FromImage(pictureBox_full.Image))
                //                {
                //
                //                    foreach (DataGridViewRow row in dgv.Rows)
                //                    {
                //                        const int size = 2;
                //                        PointF p = (PointF)row.Cells[ROI.DGV_Location].Value;
                //
                //
                //                        g.DrawEllipse(Pens.Red, new RectangleF(p.X - size / 2, p.Y - size / 2, size, size));
                //                    }
                //                }



            }
            else if (tabcontrol.SelectedIndex == 2)
            {
                roi.mode = SFR.SelectionMode.Roi;
                roi.SelectIndex = 0;
                roi.SelectEdge = 0;
                roi.RefreshPicturBox_part(pictureBox_part);
            }


            pictureBox_full.Invalidate();
        }

      
     

        private void button_next_Click(object sender, EventArgs e)
        {
            if (roi.SelectIndex == 4 && roi.SelectEdge == 1)
                return;
                    

            if (roi.SelectEdge == 1)
            {
                roi.SelectEdge = 0;

                if (roi.SelectIndex != 4)
                    roi.SelectIndex++;
            }   
            else
                roi.SelectEdge++;


            //read prev rectangle
            int i = roi.SelectIndex;
            int edge = roi.SelectEdge;

            if (roi.SaveRoies[i][roi.SelectEdge] != RectangleF.Empty)
            {
                var picBox = pictureBox_part;

                ((PointF[])picBox.Tag)[0] = roi.SaveRoies[i][edge].Location;
                ((PointF[])picBox.Tag)[1] = new PointF(roi.SaveRoies[i][edge].Right, roi.SaveRoies[i][edge].Bottom);

            }


            roi.RefreshPicturBox_part(pictureBox_part);
            pictureBox_full.Invalidate();
        }

        private void button_prev_Click(object sender, EventArgs e)
        {
            if (roi.SelectIndex == 0 && roi.SelectEdge == 0)
                return;

         

            if (roi.SelectEdge == 0)
            {
                roi.SelectEdge = 1;

                if (roi.SelectIndex != 0)
                    roi.SelectIndex--;
            }
            else
                roi.SelectEdge--;


            //read prev rectangle
            int i = roi.SelectIndex;
            int edge = roi.SelectEdge;

            if (roi.SaveRoies[i][roi.SelectEdge] != RectangleF.Empty)
            {
                var picBox = pictureBox_part;

                ((PointF[])picBox.Tag)[0] = roi.SaveRoies[i][edge].Location;
                ((PointF[])picBox.Tag)[1] = new PointF(roi.SaveRoies[i][edge].Right, roi.SaveRoies[i][edge].Bottom);

            }


            roi.RefreshPicturBox_part(pictureBox_part);
            pictureBox_full.Invalidate();
        }

        private void button_revomePoint_Click(object sender, EventArgs e)
        {
            if (dataGridView_points.RowCount > 1)
            {
                dataGridView_points.Rows.RemoveAt(dataGridView_points.RowCount - 2);
                pictureBox_full.Invalidate();
            }
        }

        private void PictureBox_main_Paint(object sender, PaintEventArgs e)
        {
            DataGridView dgv = ((sender as Control).Tag) as DataGridView;

            if (dgv == null)
                return;

            if (roi.mode == SFR.SelectionMode.Center)
            {
                const int size = 5;

                for (int i= 0; i != dgv.RowCount - 1;++i)
                {
                    DataGridViewRow row = dgv.Rows[i];
                    PointF p = (PointF)row.Cells[SFR.DGV_Location].Value;
                    p = roi.PointShift_ToNew(p);
                    
                    e.Graphics.FillEllipse(
                        new SolidBrush(Color.Red),
                        new RectangleF(p.X - size / 2, p.Y - size / 2, size, size));

                }
            }
            else if (roi.mode == SFR.SelectionMode.Roi)
            {
                PointF p = roi.PointShift_ToNew(roi.GetLFPoint());

                e.Graphics.DrawRectangle(
                    Pens.Green,
                    new Rectangle(new Point((int)p.X, (int)p.Y), new Size((int)(SFR.RectangleSize_Roi*roi.ResizeRate), (int)(SFR.RectangleSize_Roi*roi.ResizeRate))));
            }
        }
        #region picturebox_part_event

        private bool isMouseDown = false;


        private void pictureBox_part_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            PictureBox picBox = sender as PictureBox;



            ((PointF[])picBox.Tag)[0] = new PointF(e.X, e.Y);
           
            pictureBox_part.Invalidate();
        }
        private void pictureBox_part_MouseMove(object sender, MouseEventArgs e)
        {


            if(isMouseDown)
            {
                PictureBox picBox = sender as PictureBox;



                PointF np = new PointF(e.X, e.Y);


             
                if (np.X < 0)
                    np.X = 0;

                if (np.X > picBox.Width - 1)
                    np.X = picBox.Width - 1;

                if (np.Y < 0)
                    np.Y = 0;
                       
                if (np.Y > picBox.Height - 1)
                    np.Y = picBox.Height - 1;

                double offsetX = np.X - ((PointF[])picBox.Tag)[0].X;
                double offsetY = np.Y - ((PointF[])picBox.Tag)[0].Y;


                if (Math.Abs(offsetX) > Math.Abs(offsetY))
                {
                    if (Math.Abs(offsetX) < Math.Abs(offsetY * 2))
                        np.Y = ((PointF[])picBox.Tag)[0].Y + Math.Sign(offsetY) * (float)Math.Abs(offsetX) / 2;
                    else
                        np.X = ((PointF[])picBox.Tag)[0].X + Math.Sign(offsetX) * (float)Math.Abs(offsetY) / 2;
                }
                else
                {
                    if (Math.Abs(offsetX*2) > Math.Abs(offsetY))
                        np.X = ((PointF[])picBox.Tag)[0].X + Math.Sign(offsetX) * (float)Math.Abs(offsetY) / 2;
                    
                    else
                        np.Y = ((PointF[])picBox.Tag)[0].Y + Math.Sign(offsetY) * (float)Math.Abs(offsetX) / 2;
                }
                    
              

                ((PointF[])picBox.Tag)[1] = new PointF(np.X, np.Y);

                pictureBox_part.Invalidate();
            }
        }

        private void pictureBox_part_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {

                PictureBox picBox = sender as PictureBox;

                //save
                PointF lf = roi.GetLFPoint();
                PointF location = new PointF(Math.Max(((PointF[])picBox.Tag)[0].X, ((PointF[])picBox.Tag)[1].X) + lf.X, Math.Max(((PointF[])picBox.Tag)[0].Y, ((PointF[])picBox.Tag)[1].Y) + lf.Y);
                SizeF size = new SizeF(Math.Abs(((PointF[])picBox.Tag)[0].X - ((PointF[])picBox.Tag)[1].X), Math.Abs(((PointF[])picBox.Tag)[0].Y - ((PointF[])picBox.Tag)[1].Y));
                roi.SaveRoies[roi.SelectIndex][roi.SelectEdge] = new RectangleF(location, size);


                pictureBox_part.Invalidate();
                isMouseDown = false;

            }
        }
        private void pictureBox_part_MouseLeave(object sender, EventArgs e)
        {
            if (isMouseDown)
            {
                PictureBox picBox = sender as PictureBox;


                //save
                PointF lf = roi.GetLFPoint();
                PointF location = new PointF(Math.Max(((PointF[])picBox.Tag)[0].X, ((PointF[])picBox.Tag)[1].X) + lf.X, Math.Max(((PointF[])picBox.Tag)[0].Y, ((PointF[])picBox.Tag)[1].Y) + lf.Y);
                SizeF size = new SizeF(Math.Abs(((PointF[])picBox.Tag)[0].X - ((PointF[])picBox.Tag)[1].X), Math.Abs(((PointF[])picBox.Tag)[0].Y - ((PointF[])picBox.Tag)[1].Y));
                roi.SaveRoies[roi.SelectIndex][roi.SelectEdge] = new RectangleF(location, size);


                pictureBox_part.Invalidate();
                isMouseDown = false;
            }
        }
            
        private void pictureBox_part_Paint(object sender, PaintEventArgs e)
        {
            PictureBox picBox = sender as PictureBox;


            PointF tfst = new PointF(Math.Min(((PointF[])picBox.Tag)[0].X, ((PointF[])picBox.Tag)[1].X), Math.Min(((PointF[])picBox.Tag)[0].Y, ((PointF[])picBox.Tag)[1].Y));
            PointF tsec = new PointF(Math.Max(((PointF[])picBox.Tag)[0].X, ((PointF[])picBox.Tag)[1].X), Math.Max(((PointF[])picBox.Tag)[0].Y, ((PointF[])picBox.Tag)[1].Y));

            e.Graphics.DrawRectangle(Pens.Red, tfst.X, tfst.Y, tsec.X - tfst.X, tsec.Y - tfst.Y);
        }

        #endregion


    }
}
