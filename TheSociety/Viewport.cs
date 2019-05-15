namespace TheSociety
{
   public class Viewport
   {
      private readonly Window window;
      private readonly World world;
      public int Width => window.Width;
      public int Height => window.Height;

      public Viewport(Window window, World world)
      {
         this.window = window;
         this.world = world;
      }

      private int x = 0;
      public int X
      {
         get => this.x;
         set
         {
            if (value >= 0 && value < world.Width - Width) this.x = value;
         }
      }

      private int y = 0;
      public int Y
      {
         get => this.y;
         set
         {
            if (value >= 0 && value < world.Height - Height) this.y = value;
         }
      }

      public int TranslateX(int x)
      {
         return window.AbsoluteX(x + this.x);
      }
      public int TranslateY(int y)
      {
         return window.AbsoluteY(y + this.y);
      }
   }
}