// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100007
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //迅击    自身第一颗速度骰子中所用的书页所有骰子威力+1
    public class PassiveAbility_100007 : PassiveAbilityBase
    {
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (behavior.card.targetSlotOrder != 0)
                return;
            behavior.ApplyDiceStatBonus(new DiceStatBonus(){ power = 1 });
        }
    }
}
