using System;
using System.Diagnostics;
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
         var worldWindow = mainWindow.Children[1];
         var viewport = new Viewport(worldWindow.Width, worldWindow.Height, world.Width, world.Height);

         var surface = new RenderSurface(worldWindow, viewport);

         var scene = new Scene();
         scene.Items.Add(new WorldRenderer(world));
         scene.Items.Add(new OkiRenderer(new Oki(5, 5)));
         scene.Items.Add(new OkiRenderer(new Oki(7, 5)));
         scene.Items.Add(new OkiRenderer(new Oki(7, 7)));
         scene.Items.Add(new OkiRenderer(new Oki(6, 3)));
         scene.Items.Add(new OkiRenderer(new Oki(4, 8)));

         var gameTime = new GameTime();
         gameTime.Start();

         var run = true;
         while (run)
         {
            scene.Update(gameTime);

            mainWindow.Draw();
            scene.Render(surface);
            backBuffer.Flip();

            run = ProcessKeys(viewport);
            gameTime.Tic();
         }
      }

      private static bool ProcessKeys(Viewport viewport)
      {
         if (Console.KeyAvailable)
         {
            switch (Console.ReadKey(true).Key)
            {
               case ConsoleKey.Escape:
                  return false;
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
         return true;
      }

      private static FrameWindow CreateWindows(BackBuffer backBuffer)
      {
         var mainWindow = new FrameWindow(backBuffer);
         var splitter = new SplitterWindow(backBuffer, backBuffer.Width / 2 + 1);

         var mainArea = mainWindow.ClientArea;
         var leftWindow = new Window(backBuffer);
         leftWindow.Area(mainArea.LimitVertically(splitter.Column));
         var rightWindow = new Window(backBuffer);
         rightWindow.Area(mainArea.StartVertically(splitter.Column + 1));

         mainWindow.Children.Add(splitter);
         mainWindow.Children.Add(leftWindow);
         mainWindow.Children.Add(rightWindow);
         return mainWindow;
      }
   }
}
