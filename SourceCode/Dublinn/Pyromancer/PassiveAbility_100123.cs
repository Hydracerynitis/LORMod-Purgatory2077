// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100089
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll
using LOR_DiceSystem;
using System;

namespace Ark
{
    //净浊之焰     使用带有“烧伤”词条的远程战斗书页时使其所有进攻型骰子威力+12，所用书页每拼点失败1次则使其所有进攻型骰子威力-6(每张书页至多触发3次)
    public class PassiveAbility_100123 : PassiveAbilityBase
    {
        private int TriggerCount=3; 
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            if (Harmony_Patch.CheckCondition(curCard.card, "Burn_Keyword") && curCard.card.GetSpec().Ranged == CardRange.Far)
                curCard.ApplyDiceStatBonus(DiceMatch.AllAttackDice, new DiceStatBonus() { power = 12 });
            TriggerCount = 3;
        }
        public override void OnLoseParrying(BattleDiceBehavior behavior)
        {
            if (TriggerCount > 0)
            {
                TriggerCount--;
                behavior.card.ApplyDiceStatBonus(DiceMatch.AllAttackDice, new DiceStatBonus() { power = -6 });
            }
        }
    }
}
