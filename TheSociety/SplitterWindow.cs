using System;

namespace TheSociety
{
   public class SplitterWindow : Window
   {
      public int Column { get; }

      public SplitterWindow(BackBuffer backBuffer, int column) : base(backBuffer)
      {
         this.Column = column;
      }

      public override void Draw()
      {
         if (!Visible) return;

         DrawVerticalLine(this.Column, '\u2551');
         DrawIntersection();
      }

      private void DrawIntersection()
      {
         Draw(this.Column, Y, '\u2566');
         Draw(this.Column, Height - 1, '\u2569');
      }
   }
}