using System;
using Terraria;

namespace WorldRefill.Ext
{
    public class MainExt : Main
    {
        private string _seedText = "";
        private int _seed;
        public string SeedText => _seedText;
        public int Seed => _seed;
        public static int oceanDistance = 250;
        public static int beachDistance = 380;
        public static int UnderworldLayer => Main.maxTilesY - 200;
        public static double oceanLevel => (Main.worldSurface + Main.rockLayer) / 2.0 + 40.0;
        public void SetSeed(string seedText)
        {
            //CRC32 crc32 = new CRC32();
            _seedText = seedText;
#if ModdedOTAPI
            WorldGen.currentWorldSeed = seedText;
#else
            WorldGenExt.currentWorldSeed = seedText;
#endif
            if (!int.TryParse(seedText, out _seed))
            {
                //_seed = crc32.ComputeHash(seedText);
                Console.WriteLine("Invalid Seed, numeric only");
            }
            _seed = ((_seed == int.MinValue) ? int.MaxValue : Math.Abs(_seed));
        }
        public static bool oceanDepths(int x, int y)
        {
            if ((double)y > oceanLevel)
            {
                return false;
            }
            if (x < beachDistance || x > Main.maxTilesX - beachDistance)
            {
                return true;
            }
            return false;
        }
    }
}
