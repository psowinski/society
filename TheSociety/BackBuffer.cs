using System;
using System.Text;

namespace TheSociety
{
   public class BackBuffer
   {
      public int Width { get; set; }
      public int LineWidth => Width + 1;
      public int LineEndIndex => Width;
      public int Height { get; set; }

      private char[] data = new char[0];

      public BackBuffer(int width, int height)
      {
         ConsoleEx.SetFont("Kreative Square");
         Console.OutputEncoding = Encoding.UTF8;
         Console.CursorVisible = false;

         Resize(width, height);
      }

      private void Resize(int width, int height)
      {
         Width = width;
         Height = height;

         ResizeBuffer();
         DrawEdge();
      }

      private void ResizeBuffer()
      {
         this.data = new char[Width * Height + Height];
         Console.SetWindowSize(Width + 5, Height + 5);
      }

      public void Flip()
      {
         Console.CursorLeft = 0;
         Console.CursorTop = 0;
         Console.Write(data);
      }

      private void DrawEdge()
      {
         for (var row = 0; row < Height; ++row)
            this.data[row * LineWidth + LineEndIndex] = '\n';
      }

      public void Draw(int x, int y, char c)
      {
         if (x >= 0 && x < Width && y >= 0 && y < Height)
         {
            var xy = y * LineWidth + x;
            this.data[xy] = c;
         }
      }
   }
}
