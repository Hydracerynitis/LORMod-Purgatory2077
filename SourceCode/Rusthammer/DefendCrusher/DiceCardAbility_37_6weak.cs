// Decompiled with JetBrains decompiler
// Type: Purgatory.DiceCardAbility_37_6weak
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //单方面攻击时本骰子威力+6
    public class DiceCardAbility_37_6weak : DiceCardAbilityBase
    {
        public override void BeforeRollDice()
        {
            if (behavior.IsParrying())
                return;
            behavior.ApplyDiceStatBonus(new DiceStatBonus(){ power = 6 });
        }
    }
}
