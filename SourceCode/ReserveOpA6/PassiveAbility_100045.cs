// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100045
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;

namespace Ark
{
    //魔刀出鞘      若第一颗速度骰所用书页为远程书页，则使这张书页中的所有骰子威力+2
    public class PassiveAbility_100045 : PassiveAbilityBase
    {
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (behavior.card.targetSlotOrder != 0 && behavior.card.card.GetSpec().Ranged != CardRange.Far)
                return;
            behavior.ApplyDiceStatBonus(new DiceStatBonus(){ power = 2 });
        }
    }
}
