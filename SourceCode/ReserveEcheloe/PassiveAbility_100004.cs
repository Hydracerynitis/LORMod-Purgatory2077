// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100004
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;

namespace Ark
{
    //法术守恒  使用远程书页时使其中随机一颗骰子最小值+3
    public class PassiveAbility_100004 : PassiveAbilityBase
    {
        private const string Passive = "法术守恒";
        public override void OnUseCard(BattlePlayingCardDataInUnitModel behavior)
        {
            if (behavior.card.GetSpec().Ranged != CardRange.Far)
                return;
            behavior.ApplyDiceStatBonus(DiceMatch.Random(1), new DiceStatBonus(){min = 3});
        }
    }
}
