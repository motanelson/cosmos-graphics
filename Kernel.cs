using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Point = Cosmos.System.Graphics.Point;
using Sys = Cosmos.System;

namespace CosmosKernel4
{
    public class Kernel : Sys.Kernel
    {
        Canvas canvas;
        void rets(Bitmap b, int x, int y, int x1, int y1, int colors)
        {

            hlines(b, x, y, x1, colors);
            hlines(b, x, y1, x1, colors);
            vlines(b, x, y, y1, colors);
            vlines(b, x1, y, y1, colors);


        }
        void boxs(Bitmap b, int x, int y,int x1, int y1, int colors)
        {
            int n = 0;
    

            if (y1>=y) {
                for (n = 0; n < y1 - y; n++)
                {
                    hlines(b,x, y + n, x1, colors);  
                }
            }
        }
        void vlines(Bitmap b, int x, int y, int y1, int colors)
        {
            int n = 0;
            int[] bt = b.rawData;
            if (x < b.Width && y < b.Height && x > -1 && y > -1 && y1 < b.Height && y1 > -1 && y1 >= y)
            {
                for (n = 0; n < y1 - y; n++)
                {
                    bt[y * b.Width + x + (n* b.Width)] = colors;
                }
            }
        }
        void hlines(Bitmap b, int x, int y,int x1, int colors)
        {
            int n = 0;
            int[] bt = b.rawData;
            if (x < b.Width && y < b.Height && x > -1 && y > -1 && x1 < b.Width && x1 > -1 && x1 >= x) {
                for (n = 0; n < x1 - x;n++)
                {
                    bt[y * b.Width + x+n] = colors;
                }
            }
        }
        void psets(Bitmap b,int x , int y,int colors)
        {
            int n = 0;
            int[] bt = b.rawData;
            if (x< b.Width && y<b.Height && x>-1 && y>-1) bt[y*b.Width+x] = colors;
        }
        int colors(byte reds,byte greens ,byte blues) {
            return blues | greens << 8 | reds  <<16;
        }
        Bitmap createsbitmap(uint x, uint y)
        {
            Bitmap bitmap = new Bitmap(x, y, ColorDepth.ColorDepth32);
            return bitmap;
        }
        void fills(Bitmap b,int colors)
        {
            int n = 0;
            int[] bt = b.rawData;
            for (n = 0; n < b.Height * b.Width; n++) bt[n] = colors;
        }
        protected override void BeforeRun()
        {
            Console.WriteLine("start.");
            canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(640, 480, ColorDepth.ColorDepth32));
            canvas.Clear(Color.Green);
        }

        protected override void Run()
        {
            Pen pen = new Pen(Color.DarkGreen);
            int nb = 640 * 480;
            int[] bt = new int[nb];
            int n = 0;
            int x = 0;
            int y = 0;
            int xx = 639;
            int maxx = 640;
            int maxy = 480;
            int yy = 479;
            Bitmap bitmap = createsbitmap((uint)maxx,(uint) maxy);
            fills(bitmap, colors(0, 0xff, 0));
            rets(bitmap,100,100,200,200,colors(0, 0, 0));
            canvas.DrawImage(bitmap, new Point(0, 0));
            canvas.Display();
            Console.ReadKey();
           
        }
    }
}
