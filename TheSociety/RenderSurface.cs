using System;

namespace TheSociety
{
   public class RenderSurface : ISurface
   {
      private readonly Window window;

      public RenderSurface(Window window, Viewport viewport)
      {
         this.window = window ?? throw new ArgumentNullException(nameof(window));
         this.Viewport = viewport ?? throw new ArgumentNullException(nameof(viewport));
      }

      public Viewport Viewport { get; }

      public void Render(int x, int y, char c)
      {
         this.window.Draw(this.Viewport.FromWorldX(x), this.Viewport.FromWorldY(y), c);
      }

      //public void DrawVerticalLine(int col, char c)
      //{
      //   this.window.DrawVerticalLine(this.Viewport.FromWorldX(col), c);
      //}

      //public void DrawHorizontalLine(int row, char c)
      //{
      //   this.window.DrawHorizontalLine(this.Viewport.FromWorldY(row), c);
      //}
   }
}