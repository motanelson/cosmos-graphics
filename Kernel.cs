using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
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
            int n = 0;
            int x = 0;
            int y = 0;
            int xx = 639;
            int yy = 479;
            for (n = 0; n < 5; n++)
            {
                canvas.DrawRectangle(pen, x, y, xx, yy);
                x += 100;
                y += 100;
                xx = xx - 100;
                yy = yy - 100;
            }
            
            
            canvas.Display();
            Console.ReadKey();
           
        }
    }
}
