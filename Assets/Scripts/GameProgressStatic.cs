namespace SliceVegetables
{
    public enum KnifeLevel
    {
        Base,
        Chef,
        Katana
    }

    public static class GameProgressStatic
    {
        public static int BestLevelScore = 0;
        public static int TotalScore = 0;
        public static KnifeLevel Knife = KnifeLevel.Base;
    }
}
