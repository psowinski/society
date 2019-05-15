using System;

namespace TheSociety
{
   public enum WorldTile
   {
      Empty,
      Center
   }

   public class World
   {
      public World()
      {
         var rnd = new Random();
         for (var row = 0; row < Height; ++row)
         {
            for (var col = 0; col < Width; ++col)
               this.map[col, row] = rnd.Next(0, 100) < 10 ? WorldTile.Center : WorldTile.Empty;
         }
      }
      private readonly WorldTile[,] map = new WorldTile[100, 100];
      public int Width => this.map.GetLength(0);
      public int Height => this.map.GetLength(1);

      public WorldTile this[int col, int row] => this.map[col, row];

      public void Render(Viewport viewport, BackBuffer backBuffer)
      {
         for (var row = 0; row < viewport.Height; ++row)
         {
            for (var col = 0; col < viewport.Width; ++col)
            {
               var tile = this.map[viewport.TranslateX(col), viewport.TranslateY(row)];
               var c = TileToChar(tile);
               backBuffer.Draw(col, row, c);
            }
         }
      }

      private char TileToChar(WorldTile tile)
      {
         switch (tile)
         {
            case WorldTile.Center: return '\u25ED';
            default: return '\u2591';
         }
      }
   }

}