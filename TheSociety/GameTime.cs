using System.Diagnostics;

namespace TheSociety
{
   public class GameTime
   {
      public long TotalElapsed { get; private set; }

      public long TotalElapsedSeconds => TotalElapsed / 1000;

      public long Dt { get; private set; }

      public long DtSeconds => Dt / 1000;

      private Stopwatch stopwatch;
      public void Start()
      {
         this.stopwatch = Stopwatch.StartNew();
      }

      public void Tic()
      {
         var elapsed = this.stopwatch.ElapsedMilliseconds;
         Dt = elapsed - TotalElapsed;
         TotalElapsed = elapsed;
      }
   }
}