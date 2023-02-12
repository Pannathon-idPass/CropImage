using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Imaging;
using AForge.Math.Geometry;
using static System.Net.Mime.MediaTypeNames;

namespace autocorp
{
    public partial class Form1 : Form
    {
        int selectedindex = 0;
        Show_Picture form = new Show_Picture();
        Bitmap imageBitMap;
        string pathFolder = null;
        public Form1()
        {
            InitializeComponent();
            // Show_Picture Show_Picture = new Show_Picture();
            // Show_Picture.Show();
        }

        private void Get_File(string pathFolder)
        {
            DirectoryInfo d = new DirectoryInfo(pathFolder); //Assuming Test is your Folder

            FileInfo[] Files = d.GetFiles("*.jpg"); //Getting Text files

            foreach (FileInfo file in Files)
            {
                listBox1.Items.Add(file.FullName); // str = str + ", " + file.Name;
            }
            lable_maxlist.Text = Files.Length.ToString();
            label_index_update();
        }

        private void Next_Boxlist_Crop()
        {
            if (listBox1.SelectedIndex + 1 < listBox1.Items.Count ) {
                listBox1.SelectedIndex = listBox1.SelectedIndex + 1;
                label_index_update();
                string pathFileSelected = listBox1.GetItemText(listBox1.SelectedItem);
                DetectSelectedImage(pathFileSelected);
            } 
        }

        private void label_index_update()
        {
            label_index.Text = (listBox1.SelectedIndex + 1).ToString();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pathFileSelected = listBox1.GetItemText(listBox1.SelectedItem);
            Bitmap img = new Bitmap(pathFileSelected);
            imageBitMap = img;
            label_index_update();
           // form.PictureSelected(pathFileSelected);

        }

        public void DetectSelectedImage(string pathFile)
        {
            // Open your image
            string path = pathFile;
            Bitmap image = (Bitmap)Bitmap.FromFile(path);

            // locating objects
            BlobCounter blobCounter = new BlobCounter();

            blobCounter.FilterBlobs = true;
            blobCounter.MinHeight = 50;
            blobCounter.MinWidth = 50;


            RectangleF cloneRect = new RectangleF(0, 0, image.Width, image.Height);
            System.Drawing.Imaging.PixelFormat format = image.PixelFormat;
            Bitmap cloneBitmap = image.Clone(cloneRect, format);

            blobCounter.ProcessImage(setWhiteToBlack(cloneBitmap));
           // blobCounter.ProcessImage(image);
            Blob[] blobs = blobCounter.GetObjectsInformation();

            // check for rectangles
            SimpleShapeChecker shapeChecker = new SimpleShapeChecker();

            foreach (var blob in blobs)
            {
                List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blob);
                List<IntPoint> cornerPoints;

                // use the shape checker to extract the corner points
                if (shapeChecker.IsQuadrilateral(edgePoints, out cornerPoints))
                {
                    // only do things if the corners form a rectangle
                    if (shapeChecker.CheckPolygonSubType(cornerPoints) == PolygonSubType.Rectangle || shapeChecker.CheckPolygonSubType(cornerPoints) == PolygonSubType.Square)
                    {
                        if (blob == blobs[2])
                        {

                            // here i use the graphics class to draw an overlay, but you
                            // could also just use the cornerPoints list to calculate your
                            // x, y, width, height values.
                            List<PointF> Points = new List<PointF>();
                        foreach (var point in cornerPoints)
                        {
                            Points.Add(new PointF(point.X, point.Y));
                        }

                        Graphics g = Graphics.FromImage(image);
                        g.DrawPolygon(new Pen(Color.Red, 1f), Points.ToArray());
                            Random rnd = new Random();
                            CropImage(image, Points); // crop and save
                            //image.Save(@"D:\imagetest\results\" + rnd.Next(100).ToString() + ".jpg");
                         }
                        }
                    }
            }
           // Random rnd = new Random();
           // image.Save(@"D:\imagetest\results\" + rnd.Next(1000).ToString() + ".jpg");
            //next image
            Next_Boxlist_Crop();
        }


        private void CropImage(Bitmap bitmap, List<PointF> points)
        {
            int pminx = 9999, pminy = 9999, pmaxx = 0, pmaxy = 0; System.Drawing.Point[] pcol = new System.Drawing.Point[points.Count]; int i = 0;
            foreach (PointF pc in points)
            {
                if (pc.X > pmaxx) pmaxx = (int)pc.X;
                if (pc.Y > pmaxy) pmaxy = (int)pc.Y;
                if (pc.X < pminx) pminx = (int)pc.X;
                if (pc.Y < pminy) pminy = (int)pc.Y;

                pcol[i] = new System.Drawing.Point((int)pc.X, (int)pc.Y);
                i++;
            }

            TextureBrush textureBrush = new TextureBrush(bitmap);
            Bitmap bmpWrk = new Bitmap(bitmap.Width, bitmap.Height);

            using (Graphics g = Graphics.FromImage(bmpWrk))
            {
                g.FillPolygon(textureBrush, pcol);
            }

            System.Drawing.Rectangle CropRect = new System.Drawing.Rectangle(pminx, pminy, pmaxx - pminx, pmaxy - pminy);

            bitmap = bmpWrk.Clone(CropRect, bmpWrk.PixelFormat);

            string fileName = Path.GetFileName(listBox1.GetItemText(listBox1.SelectedItem));
            bitmap.Save(@"D:\imagetest\results\" + fileName);

        }

        public Bitmap setWhiteToBlack(Bitmap bmp)
        {
            int width = bmp.Width;
            int height = bmp.Height;
            int[] arr = new int[225];
            int i = 0;
            Color p;

            //Grayscale
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    p = bmp.GetPixel(x, y);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;
                    int avg = (r + g + b) / 3;
                    if(avg == 255)
                    {
                        bmp.SetPixel(x, y, Color.FromArgb(a, 0, 0, 0));
                    }
                    else
                    {
                      bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                    }
                }
            }
            return bmp;
        }

        private void btn_crop_image_Click(object sender, EventArgs e)
        {
            string pathFileSelected = listBox1.GetItemText(listBox1.SelectedItem);
            if (pathFolder != null && pathFileSelected != null)
            {
            DetectSelectedImage(pathFileSelected);
            } else
            {
                MessageBox.Show("เลือกโฟร์เดอร์รูปที่ต้องการ Crop");
            }
        }

        private void open_folder_image(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            if (fbd.SelectedPath != null && fbd.SelectedPath != "")
            {
                listBox1.Items.Clear();
                pathFolder = fbd.SelectedPath;
                Get_File(fbd.SelectedPath.ToString());
                if(listBox1.Items.Count > 0) {
                selectedindex = listBox1.SelectedIndex + 1;
                listBox1.SelectedIndex = 0;
                } else
                {
                    listBox1.Items.Clear();
                    MessageBox.Show("ไม่พบไฟล์ jpg");
                }
            }

        }
    }
}
