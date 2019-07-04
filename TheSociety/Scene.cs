using System.Collections.Generic;

namespace TheSociety
{
   public class Scene : IRenderable
   {
      public List<IRenderable> Items = new List<IRenderable>();

      public void Render(ISurface surface)
      {
         foreach (var item in Items)
            item.Render(surface);
      }

      public void Update(GameTime time)
      {
         foreach (var item in Items)
            item.Update(time);
      }
   }
}