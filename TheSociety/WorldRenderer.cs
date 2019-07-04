using System;

namespace TheSociety
{
   public class WorldRenderer : IRenderable
   {
      private readonly World world;

      public WorldRenderer(World world)
      {
         this.world = world ?? throw new ArgumentNullException(nameof(world));
      }

      public void Render(ISurface surface)
      {
         var viewport = surface.Viewport;

         var fromX = viewport.ToWorldX(0);
         var width = viewport.ToWorldX(viewport.Width);

         var y = viewport.ToWorldY(0);
         var height = viewport.ToWorldY(viewport.Height);

         for (; y < height; ++y)
         {
            for (var x = fromX; x < width; ++x)
            {
               var tile = this.world[x, y];
               var c = TileToChar(tile);
               surface.Render(x, y, c);
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

      public void Update(GameTime time)
      {
         this.world.Update(time);
      }
   }
}