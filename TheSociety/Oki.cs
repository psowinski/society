using System;

namespace TheSociety
{
   public enum OkiFace
   {
      White,
      Black
   }

   public class Oki : IUpdatable
   {
      private readonly int faceChangeFrequency;

      public Oki(int x, int y)
      {
         X = x;
         Y = y;

         this.faceChangeFrequency = new Random().Next(3, 10);
      }

      public int X { get; }
      public int Y { get; }

      public OkiFace Face { get; private set; }

      public void Update(GameTime time)
      {
            Face = time.TotalElapsedSeconds % this.faceChangeFrequency == 0 ? OkiFace.Black : OkiFace.White;
      }
   }
}