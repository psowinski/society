namespace TheSociety
{
   public struct Area
   {
      public Area(int x, int y, int width, int height)
      {
         X = x;
         Y = y;
         Width = width;
         Height = height;
      }

      public int X { get; set; }
      public int Y { get; set; }
      public int Width { get; set; }
      public int Height { get; set; }

      public Area LimitVertically(int limit)
      {
         return new Area(X, Y, limit - X, Height);
      }

      public Area StartVertically(int at)
      {
         return new Area(at, Y, Width - at, Height);
      }

   }
}