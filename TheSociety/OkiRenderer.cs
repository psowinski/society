using System;

namespace TheSociety
{
   public class OkiRenderer : IRenderable
   {
      private readonly Oki oki;

      public OkiRenderer(Oki oki)
      {
         this.oki = oki ?? throw new ArgumentNullException(nameof(oki));
      }

      public void Render(ISurface surface)
      {
         surface.Render(oki.X, oki.Y, this.oki.Face == OkiFace.White ? '\u2687' : '\u2689');
      }

      public void Update(GameTime time)
      {
         this.oki.Update(time);
      }
   }
}