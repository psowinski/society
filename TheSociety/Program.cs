using System;
using System.Text;

namespace TheSociety
{
   class Program
   {
      static void Main(string[] args)
      {

         var backBuffer = new BackBuffer(83, 42);
         var mainWindow = CreateWindows(backBuffer);

         var world = new World();
         var viewport = new Viewport(mainWindow.Children[1], world);

         var run = true;
         while (run)
         {
            mainWindow.Draw();
            world.Render(viewport, backBuffer);
            backBuffer.Flip();
            switch (Console.ReadKey(true).Key)
            {
               case ConsoleKey.Escape:
                  run = false;
                  break;
               case ConsoleKey.LeftArrow:
                  viewport.X -= 1;
                  break;
               case ConsoleKey.RightArrow:
                  viewport.X += 1;
                  break;
               case ConsoleKey.UpArrow:
                  viewport.Y -= 1;
                  break;
               case ConsoleKey.DownArrow:
                  viewport.Y += 1;
                  break;
            }
         }
      }

      private static FrameWindow CreateWindows(BackBuffer backBuffer)
      {
         var mainWindow = new FrameWindow(backBuffer);
         var splitter = new SplitterWindow(backBuffer, backBuffer.Width / 2 + 1);

         var mainArea = mainWindow.ClientArea;
         var leftWindow = new Window(backBuffer);
         leftWindow.Area(mainArea.LimitVertically(splitter.Column + 1));
         var rightWindow = new Window(backBuffer);
         rightWindow.Area(mainArea.StartVertically(splitter.Column + 1));

         mainWindow.Children.Add(splitter);
         mainWindow.Children.Add(leftWindow);
         mainWindow.Children.Add(rightWindow);
         return mainWindow;
      }
   }
}
