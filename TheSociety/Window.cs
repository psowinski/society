using System.Collections.Generic;

namespace TheSociety
{
   public class Window
   {
      public readonly BackBuffer BackBuffer;

      public Window(BackBuffer backBuffer)
      {
         this.BackBuffer = backBuffer;
         area.Width = backBuffer.Width;
         area.Height = backBuffer.Height;
         Visible = true;
      }

      private Area area;

      public int X => area.X;
      public int Y => area.Y;
      public int Width => area.Width;
      public int Height => area.Height;
      public bool Visible { get; set; }

      public void Resize(int width, int height)
      {
         this.area.Width = width;
         this.area.Height = height;
      }

      public void Move(int x, int y)
      {
         this.area.X = x;
         this.area.Y = y;
      }

      public void Area(Area area)
      {
         this.area = area;
      }

      public virtual void Draw()
      {
         BackBuffer.Draw(X, Y, 'W');
      }

      public void DrawVerticalLine(int col, char c)
      {
         for (int y = 0; y < Height - 1; ++y)
            this.BackBuffer.Draw(col, y, c);
      }

      public void DrawHorizontalLine(int row, char c)
      {
         for (int x = 0; x < Width - 1; ++x)
            this.BackBuffer.Draw(x, row, c);
      }

      public int AbsoluteX(int x)
      {
         return x + this.area.X;
      }

      public int AbsoluteY(int y)
      {
         return y + this.area.Y;
      }
   }
}