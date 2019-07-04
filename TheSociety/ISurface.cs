namespace TheSociety
{
   public interface ISurface
   {
      Viewport Viewport { get; }

      void Render(int x, int y, char c);

      //void DrawVerticalLine(int col, char c);

      //void DrawHorizontalLine(int row, char c);
   }
}