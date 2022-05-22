using System.Drawing;

namespace Pokemon_Simulator
{
    public enum Type
    {
        Normal,
        Fighting,
        Flying,
        Poison,
        Ground,
        Rock,
        Bug,
        Ghost,
        Steel,
        Fire,
        Water,
        Grass,
        Electric,
        Psychic,
        Ice,
        Dragon,
        Dark,
        Fairy,
        None
    }

    public static class TypeData
    {
        public static float CalculateEffectiveness(Type pokemonType, Type moveType)
        {
            switch (pokemonType)
            {
                case Type.None:
                    return 1;
                case Type.Normal:
                    if (moveType == Type.Rock) return 0.5f;
                    else if (moveType == Type.Ghost) return 0;
                    else if (moveType == Type.Steel) return 0.5f;
                    return 1;
                case Type.Fighting:
                    if (moveType == Type.Normal) return 2;
                    else if (moveType == Type.Flying) return 0.5f;
                    else if (moveType == Type.Poison) return 0.5f;
                    else if (moveType == Type.Rock) return 2;
                    else if (moveType == Type.Bug) return 0.5f;
                    else if (moveType == Type.Ghost) return 0;
                    else if (moveType == Type.Steel) return 2;
                    else if (moveType == Type.Psychic) return 0.5f;
                    else if (moveType == Type.Ice) return 2;
                    else if (moveType == Type.Dark) return 2;
                    else if (moveType == Type.Fairy) return 0.5f;
                    return 1;
                case Type.Flying:
                    if (moveType == Type.Fighting) return 2;
                    else if (moveType == Type.Rock) return 0.5f;
                    else if (moveType == Type.Bug) return 2;
                    else if (moveType == Type.Steel) return 0.5f;
                    else if (moveType == Type.Grass) return 2;
                    else if (moveType == Type.Electric) return 0.5f;
                    return 1;
                case Type.Poison:
                    if (moveType == Type.Poison) return 0.5f;
                    else if (moveType == Type.Ground) return 0.5f;
                    else if (moveType == Type.Rock) return 0.5f;
                    else if (moveType == Type.Ghost) return 0.5f;
                    else if (moveType == Type.Steel) return 0;
                    else if (moveType == Type.Grass) return 2;
                    else if (moveType == Type.Fairy) return 2;
                    return 1;
                case Type.Ground:
                    if (moveType == Type.Flying) return 0;
                    else if (moveType == Type.Rock) return 2;
                    else if (moveType == Type.Bug) return 0.5f;
                    else if (moveType == Type.Steel) return 2;
                    else if (moveType == Type.Bug) return 0.5f;
                    else if (moveType == Type.Fire) return 2;
                    else if (moveType == Type.Grass) return 0.5f;
                    else if (moveType == Type.Electric) return 2;
                    return 1;
                case Type.Rock:
                    if (moveType == Type.Rock) return 0.5f;
                    else if (moveType == Type.Flying) return 2;
                    else if (moveType == Type.Ground) return 0.5f;
                    else if (moveType == Type.Bug) return 2;
                    else if (moveType == Type.Steel) return 0.5f;
                    else if (moveType == Type.Fire) return 2;
                    else if (moveType == Type.Ice) return 2;
                    return 1;
                case Type.Bug:
                    if (moveType == Type.Fighting) return 0.5f;
                    else if (moveType == Type.Flying) return 0.5f;
                    else if (moveType == Type.Poison) return 0.5f;
                    else if (moveType == Type.Rock) return 2;
                    else if (moveType == Type.Ghost) return 0.5f;
                    else if (moveType == Type.Steel) return 0.5f;
                    else if (moveType == Type.Fire) return 0.5f;
                    else if (moveType == Type.Grass) return 2;
                    else if (moveType == Type.Psychic) return 2;
                    else if (moveType == Type.Dark) return 2;
                    else if (moveType == Type.Fairy) return 0.5f;
                    return 1;
                case Type.Ghost:
                    if (moveType == Type.Normal) return 0;
                    else if (moveType == Type.Ghost) return 2;
                    else if (moveType == Type.Psychic) return 2;
                    else if (moveType == Type.Dark) return 0.5f;
                    return 1;
                case Type.Steel:
                    if (moveType == Type.Rock) return 2;
                    else if (moveType == Type.Steel) return 0.5f;
                    else if (moveType == Type.Fire) return 0.5f;
                    else if (moveType == Type.Water) return 0.5f;
                    else if (moveType == Type.Electric) return 0.5f;
                    else if (moveType == Type.Ice) return 2;
                    else if (moveType == Type.Fairy) return 2;
                    return 1;
                case Type.Fire:
                    if (moveType == Type.Rock) return 0.5f;
                    else if (moveType == Type.Bug) return 2;
                    else if (moveType == Type.Steel) return 2;
                    else if (moveType == Type.Fire) return 0.5f;
                    else if (moveType == Type.Water) return 0.5f;
                    else if (moveType == Type.Grass) return 2;
                    else if (moveType == Type.Ice) return 2;
                    else if (moveType == Type.Dragon) return 0.5f;
                    return 1;
                case Type.Water:
                    if (moveType == Type.Ground) return 2;
                    else if (moveType == Type.Rock) return 2;
                    else if (moveType == Type.Fire) return 2;
                    else if (moveType == Type.Water) return 0.5f;
                    else if (moveType == Type.Grass) return 0.5f;
                    else if (moveType == Type.Dragon) return 0.5f;
                    return 1;
                case Type.Grass:
                    if (moveType == Type.Flying) return 0.5f;
                    else if (moveType == Type.Poison) return 0.5f;
                    else if (moveType == Type.Ground) return 2;
                    else if (moveType == Type.Rock) return 2;
                    else if (moveType == Type.Bug) return 0.5f;
                    else if (moveType == Type.Steel) return 0.5f;
                    else if (moveType == Type.Fire) return 0.5f;
                    else if (moveType == Type.Water) return 2;
                    else if (moveType == Type.Grass) return 0.5f;
                    else if (moveType == Type.Dragon) return 0.5f;
                    return 1;
                case Type.Electric:
                    if (moveType == Type.Flying) return 2;
                    else if (moveType == Type.Ground) return 0;
                    else if (moveType == Type.Water) return 2;
                    else if (moveType == Type.Grass) return 0.5f;
                    else if (moveType == Type.Electric) return 0.5f;
                    else if (moveType == Type.Dragon) return 0.5f;
                    return 1;
                case Type.Psychic:
                    if (moveType == Type.Fighting) return 2;
                    else if (moveType == Type.Poison) return 2;
                    else if (moveType == Type.Steel) return 0.5f;
                    else if (moveType == Type.Psychic) return 0.5f;
                    else if (moveType == Type.Dark) return 0;
                    return 1;
                case Type.Ice:
                    if (moveType == Type.Flying) return 2;
                    else if (moveType == Type.Ground) return 2;
                    else if (moveType == Type.Steel) return 0.5f;
                    else if (moveType == Type.Fire) return 0.5f;
                    else if (moveType == Type.Water) return 0.5f;
                    else if (moveType == Type.Grass) return 2;
                    else if (moveType == Type.Ice) return 0.5f;
                    else if (moveType == Type.Dragon) return 2;
                    return 1;
                case Type.Dragon:
                    if (moveType == Type.Steel) return 0.5f;
                    else if (moveType == Type.Dragon) return 2;
                    else if (moveType == Type.Fairy) return 0;
                    return 1;
                case Type.Dark:
                    if (moveType == Type.Fighting) return 0.5f;
                    else if (moveType == Type.Ghost) return 2;
                    else if (moveType == Type.Psychic) return 2;
                    else if (moveType == Type.Dark) return 0.5f;
                    else if (moveType == Type.Fairy) return 0.5f;
                    return 1;
                case Type.Fairy:
                    if (moveType == Type.Fighting) return 2;
                    else if (moveType == Type.Poison) return 0.5f;
                    else if (moveType == Type.Steel) return 0.5f;
                    else if (moveType == Type.Fire) return 0.5f;
                    else if (moveType == Type.Dragon) return 2;
                    else if (moveType == Type.Dark) return 2;
                    return 1;
            }
            return 1;
        }

        public static Color GetTypeColor(Type type)
        {
            switch(type)
            {
                case Type.Normal:
                    return Color.FromArgb(168, 168, 120);
                case Type.Fighting:
                    return Color.FromArgb(192, 48, 40);
                case Type.Flying:
                    return Color.FromArgb(168, 144, 240);
                case Type.Poison:
                    return Color.FromArgb(160, 64, 160);
                case Type.Ground:
                    return Color.FromArgb(224, 192, 104);
                case Type.Rock:
                    return Color.FromArgb(184, 160, 56);
                case Type.Bug:
                    return Color.FromArgb(168, 184, 32);
                case Type.Ghost:
                    return Color.FromArgb(112, 88, 152);
                case Type.Steel:
                    return Color.FromArgb(184, 184, 208);
                case Type.Fire:
                    return Color.FromArgb(240, 128, 48);
                case Type.Water:
                    return Color.FromArgb(104, 144, 240);
                case Type.Grass:
                    return Color.FromArgb(120, 200, 80);
                case Type.Electric:
                    return Color.FromArgb(248, 208, 48);
                case Type.Psychic:
                    return Color.FromArgb(248, 88, 136);
                case Type.Ice:
                    return Color.FromArgb(152, 216, 216);
                case Type.Dragon:
                    return Color.FromArgb(112, 56, 248);
                case Type.Dark:
                    return Color.FromArgb(112, 88, 72);
                case Type.Fairy:
                    return Color.FromArgb(255, 101, 213);
            }
            return Color.FromArgb(104, 160, 144);
        }
    }
}
