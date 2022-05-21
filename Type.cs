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
    }
}
