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
        int colors(byte reds,byte greens ,byte blues) {
            return blues | greens << 8 | reds  <<8;
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
            canvas.DrawImage(bitmap, new Point(0, 0));
            canvas.Display();
            Console.ReadKey();
           
        }
    }
}
