using System;

namespace TheSociety
{
   public enum WorldTile
   {
      Grass,
      FlowerWhite,
      FlowerBlack,
      House
   }

   public class World
   {
      public World()
      {
         var rnd = new Random();
         for (var row = 0; row < Height; ++row)
         {
            for (var col = 0; col < Width; ++col)
            {
               var v = rnd.Next(0, 99);
               if (v < 1)
                  this.map[col, row] = WorldTile.FlowerBlack;
               else if (v < 2)
                  this.map[col, row] = WorldTile.FlowerWhite;
               else
                  this.map[col, row] = WorldTile.Grass;

            }
         }
         this.map[Width / 2, Height / 2] = WorldTile.House;
      }

      private readonly WorldTile[,] map = new WorldTile[100, 100];
      public int Width => this.map.GetLength(0);
      public int Height => this.map.GetLength(1);

      public WorldTile this[int col, int row] => this.map[col, row];

      public void Render(Viewport viewport, Window drawable)
      {
         for (var row = 0; row < viewport.Height; ++row)
         {
            for (var col = 0; col < viewport.Width; ++col)
            {
               var tile = this.map[viewport.TranslateX(col), viewport.TranslateY(row)];
               var c = TileToChar(tile);
               drawable.Draw(col, row, c);
            }
         }
      }

      private char TileToChar(WorldTile tile)
      {
         switch (tile)
         {
            case WorldTile.FlowerWhite: return '\u2740';
            case WorldTile.FlowerBlack: return '\u273F';
            case WorldTile.House: return '\u25ED';
            default: return '\u2591';
         }
      }
   }

}