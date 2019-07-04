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
         DrawText(0, 0, "Empty window");
      }

      public void DrawText(int x, int y, string str)
      {
         if (x >= 0 && x < Width && y >= 0 && y < Height)
            BackBuffer.DrawText(ToWorldX(x), ToWorldY(y), str);
      }

      public void Draw(int x, int y, char c)
      {
         if (x >= 0 && x < Width && y >= 0 && y < Height)
            BackBuffer.Draw(ToWorldX(x), ToWorldY(y), c);
      }

      public void DrawVerticalLine(int col, char c)
      {
         for (var y = 0; y < Height - 1; ++y)
            Draw(col, y, c);
      }

      public void DrawHorizontalLine(int row, char c)
      {
         for (var x = 0; x < Width - 1; ++x)
            Draw(x, row, c);
      }

      private int ToWorldX(int x)
      {
         return x + this.area.X;
      }

      private int ToWorldY(int y)
      {
         return y + this.area.Y;
      }
   }
}