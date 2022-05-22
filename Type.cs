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
        public static float CalculateEffectiveness(Type moveType, Type pokemonType)
        {
            switch (moveType)
            {
                case Type.None:
                    return 1;
                case Type.Normal:
                    if (pokemonType == Type.Rock) return 0.5f;
                    else if (pokemonType == Type.Ghost) return 0;
                    else if (pokemonType == Type.Steel) return 0.5f;
                    return 1;
                case Type.Fighting:
                    if (pokemonType == Type.Normal) return 2;
                    else if (pokemonType == Type.Flying) return 0.5f;
                    else if (pokemonType == Type.Poison) return 0.5f;
                    else if (pokemonType == Type.Rock) return 2;
                    else if (pokemonType == Type.Bug) return 0.5f;
                    else if (pokemonType == Type.Ghost) return 0;
                    else if (pokemonType == Type.Steel) return 2;
                    else if (pokemonType == Type.Psychic) return 0.5f;
                    else if (pokemonType == Type.Ice) return 2;
                    else if (pokemonType == Type.Dark) return 2;
                    else if (pokemonType == Type.Fairy) return 0.5f;
                    return 1;
                case Type.Flying:
                    if (pokemonType == Type.Fighting) return 2;
                    else if (pokemonType == Type.Rock) return 0.5f;
                    else if (pokemonType == Type.Bug) return 2;
                    else if (pokemonType == Type.Steel) return 0.5f;
                    else if (pokemonType == Type.Grass) return 2;
                    else if (pokemonType == Type.Electric) return 0.5f;
                    return 1;
                case Type.Poison:
                    if (pokemonType == Type.Poison) return 0.5f;
                    else if (pokemonType == Type.Ground) return 0.5f;
                    else if (pokemonType == Type.Rock) return 0.5f;
                    else if (pokemonType == Type.Ghost) return 0.5f;
                    else if (pokemonType == Type.Steel) return 0;
                    else if (pokemonType == Type.Grass) return 2;
                    else if (pokemonType == Type.Fairy) return 2;
                    return 1;
                case Type.Ground:
                    if (pokemonType == Type.Flying) return 0;
                    else if (pokemonType == Type.Rock) return 2;
                    else if (pokemonType == Type.Bug) return 0.5f;
                    else if (pokemonType == Type.Steel) return 2;
                    else if (pokemonType == Type.Bug) return 0.5f;
                    else if (pokemonType == Type.Fire) return 2;
                    else if (pokemonType == Type.Grass) return 0.5f;
                    else if (pokemonType == Type.Electric) return 2;
                    return 1;
                case Type.Rock:
                    if (pokemonType == Type.Rock) return 0.5f;
                    else if (pokemonType == Type.Flying) return 2;
                    else if (pokemonType == Type.Ground) return 0.5f;
                    else if (pokemonType == Type.Bug) return 2;
                    else if (pokemonType == Type.Steel) return 0.5f;
                    else if (pokemonType == Type.Fire) return 2;
                    else if (pokemonType == Type.Ice) return 2;
                    return 1;
                case Type.Bug:
                    if (pokemonType == Type.Fighting) return 0.5f;
                    else if (pokemonType == Type.Flying) return 0.5f;
                    else if (pokemonType == Type.Poison) return 0.5f;
                    else if (pokemonType == Type.Rock) return 2;
                    else if (pokemonType == Type.Ghost) return 0.5f;
                    else if (pokemonType == Type.Steel) return 0.5f;
                    else if (pokemonType == Type.Fire) return 0.5f;
                    else if (pokemonType == Type.Grass) return 2;
                    else if (pokemonType == Type.Psychic) return 2;
                    else if (pokemonType == Type.Dark) return 2;
                    else if (pokemonType == Type.Fairy) return 0.5f;
                    return 1;
                case Type.Ghost:
                    if (pokemonType == Type.Normal) return 0;
                    else if (pokemonType == Type.Ghost) return 2;
                    else if (pokemonType == Type.Psychic) return 2;
                    else if (pokemonType == Type.Dark) return 0.5f;
                    return 1;
                case Type.Steel:
                    if (pokemonType == Type.Rock) return 2;
                    else if (pokemonType == Type.Steel) return 0.5f;
                    else if (pokemonType == Type.Fire) return 0.5f;
                    else if (pokemonType == Type.Water) return 0.5f;
                    else if (pokemonType == Type.Electric) return 0.5f;
                    else if (pokemonType == Type.Ice) return 2;
                    else if (pokemonType == Type.Fairy) return 2;
                    return 1;
                case Type.Fire:
                    if (pokemonType == Type.Rock) return 0.5f;
                    else if (pokemonType == Type.Bug) return 2;
                    else if (pokemonType == Type.Steel) return 2;
                    else if (pokemonType == Type.Fire) return 0.5f;
                    else if (pokemonType == Type.Water) return 0.5f;
                    else if (pokemonType == Type.Grass) return 2;
                    else if (pokemonType == Type.Ice) return 2;
                    else if (pokemonType == Type.Dragon) return 0.5f;
                    return 1;
                case Type.Water:
                    if (pokemonType == Type.Ground) return 2;
                    else if (pokemonType == Type.Rock) return 2;
                    else if (pokemonType == Type.Fire) return 2;
                    else if (pokemonType == Type.Water) return 0.5f;
                    else if (pokemonType == Type.Grass) return 0.5f;
                    else if (pokemonType == Type.Dragon) return 0.5f;
                    return 1;
                case Type.Grass:
                    if (pokemonType == Type.Flying) return 0.5f;
                    else if (pokemonType == Type.Poison) return 0.5f;
                    else if (pokemonType == Type.Ground) return 2;
                    else if (pokemonType == Type.Rock) return 2;
                    else if (pokemonType == Type.Bug) return 0.5f;
                    else if (pokemonType == Type.Steel) return 0.5f;
                    else if (pokemonType == Type.Fire) return 0.5f;
                    else if (pokemonType == Type.Water) return 2;
                    else if (pokemonType == Type.Grass) return 0.5f;
                    else if (pokemonType == Type.Dragon) return 0.5f;
                    return 1;
                case Type.Electric:
                    if (pokemonType == Type.Flying) return 2;
                    else if (pokemonType == Type.Ground) return 0;
                    else if (pokemonType == Type.Water) return 2;
                    else if (pokemonType == Type.Grass) return 0.5f;
                    else if (pokemonType == Type.Electric) return 0.5f;
                    else if (pokemonType == Type.Dragon) return 0.5f;
                    return 1;
                case Type.Psychic:
                    if (pokemonType == Type.Fighting) return 2;
                    else if (pokemonType == Type.Poison) return 2;
                    else if (pokemonType == Type.Steel) return 0.5f;
                    else if (pokemonType == Type.Psychic) return 0.5f;
                    else if (pokemonType == Type.Dark) return 0;
                    return 1;
                case Type.Ice:
                    if (pokemonType == Type.Flying) return 2;
                    else if (pokemonType == Type.Ground) return 2;
                    else if (pokemonType == Type.Steel) return 0.5f;
                    else if (pokemonType == Type.Fire) return 0.5f;
                    else if (pokemonType == Type.Water) return 0.5f;
                    else if (pokemonType == Type.Grass) return 2;
                    else if (pokemonType == Type.Ice) return 0.5f;
                    else if (pokemonType == Type.Dragon) return 2;
                    return 1;
                case Type.Dragon:
                    if (pokemonType == Type.Steel) return 0.5f;
                    else if (pokemonType == Type.Dragon) return 2;
                    else if (pokemonType == Type.Fairy) return 0;
                    return 1;
                case Type.Dark:
                    if (pokemonType == Type.Fighting) return 0.5f;
                    else if (pokemonType == Type.Ghost) return 2;
                    else if (pokemonType == Type.Psychic) return 2;
                    else if (pokemonType == Type.Dark) return 0.5f;
                    else if (pokemonType == Type.Fairy) return 0.5f;
                    return 1;
                case Type.Fairy:
                    if (pokemonType == Type.Fighting) return 2;
                    else if (pokemonType == Type.Poison) return 0.5f;
                    else if (pokemonType == Type.Steel) return 0.5f;
                    else if (pokemonType == Type.Fire) return 0.5f;
                    else if (pokemonType == Type.Dragon) return 2;
                    else if (pokemonType == Type.Dark) return 2;
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
