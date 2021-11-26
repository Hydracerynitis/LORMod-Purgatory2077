// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100038
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;
using System;

namespace Ark
{
    //集中穿破  使用只有一颗骰子(不包括反击骰)的远程书页时，造成的混乱+25%反震伤害+100%
    public class PassiveAbility_100038 : PassiveAbilityBase
    {
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            if (curCard.GetOriginalDiceBehaviorList().FindAll(x => x.Type != BehaviourType.Standby).Count != 1 && curCard.card.GetSpec().Ranged != CardRange.Far)
                return;
            owner.battleCardResultLog?.SetPassiveAbility(this);
            curCard.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus(){ breakRate = 25, guardBreakMultiplier = 2 });
        }
    }
}
