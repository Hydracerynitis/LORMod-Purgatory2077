// Decompiled with JetBrains decompiler
// Type: Purgatory.DiceCardAbility_15_10up
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //每失去25%体力 本骰子威力+8
    public class DiceCardAbility_15_10up : DiceCardAbilityBase
    {
        public override void BeforeRollDice()
        {
            if (card?.target == null)
                return;
            double ratio = 1.0 - owner.hp / owner.MaxHp;
            int power;
            for (power = 0; ratio > 0.25; ++power)
                ratio -= 0.25;
            behavior.ApplyDiceStatBonus(new DiceStatBonus(){ power = power *8 });
        }
    }
}
