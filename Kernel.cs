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
            
            Bitmap bitmap =  new Bitmap(640, 480, ColorDepth.ColorDepth32);

            bt=bitmap.rawData;
            int n = 0;
            int x = 0;
            int y = 0;
            int xx = 639;
            int maxx = 640;
            int maxy = 480;
            int yy = 479;
            for (n = 0; n < nb; n++)
            {
                bt[n]=0xff00;
                
            }

            canvas.DrawImage(bitmap, new Point(0, 0));
            canvas.Display();
            Console.ReadKey();
           
        }
    }
}
