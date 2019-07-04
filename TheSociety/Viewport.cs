namespace TheSociety
{
   public class Viewport
   {
      private readonly int rangeX;
      private readonly int rangeY;
      public int Width { get; }
      public int Height { get; }

      public Viewport(int width, int height, int rangeX, int rangeY)
      {
         this.rangeX = rangeX;
         this.rangeY = rangeY;
         Width = width;
         Height = height;
      }

      private int x = 0;
      public int X
      {
         get => this.x;
         set
         {
            if (value >= 0 && value < rangeX - Width) this.x = value;
         }
      }

      private int y = 0;
      public int Y
      {
         get => this.y;
         set
         {
            if (value >= 0 && value < rangeY - Height) this.y = value;
         }
      }

      public int ToWorldX(int col)
      {
         return col + this.x;
      }

      public int ToWorldY(int row)
      {
         return row + this.y;
      }

      public int FromWorldX(int col)
      {
         return col - this.x;
      }

      public int FromWorldY(int row)
      {
         return row - this.y;
      }
   }
}