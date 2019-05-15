using System.Collections.Generic;

namespace TheSociety
{
   public class FrameWindow : Window
   {
      public FrameWindow(BackBuffer backBuffer) : base(backBuffer)
      {
         Children = new List<Window>();
      }

      public List<Window> Children { get; }

      public override void Draw()
      {
         if (!Visible) return;

         DrawHorizontalLine(X, '\u2550');
         DrawHorizontalLine(Height - 1, '\u2550');
         DrawVerticalLine(X, '\u2551');
         DrawVerticalLine(Width - 1, '\u2551');
         DrawCorners();

         DrawChildren();
      }

      private void DrawChildren()
      {
         foreach (var window in Children)
         {
            if(window.Visible)
               window.Draw();
         }
      }

      private void DrawCorners()
      {
         this.BackBuffer.Draw(X, Y, '\u2554');
         this.BackBuffer.Draw(Width - 1, 0, '\u2557');
         this.BackBuffer.Draw(X, Height - 1, '\u255A');
         this.BackBuffer.Draw(Width - 1, Height - 1, '\u255D');
      }

      public Area ClientArea => new Area(X + 1, Y + 1, Width - 2, Height - 2);
   }
}