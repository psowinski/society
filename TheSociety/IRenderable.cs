namespace TheSociety
{
   public interface IRenderable : IUpdatable
   {
      void Render(ISurface surface);
   }
}