// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100089
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll
using System.Collections.Generic;
using LOR_DiceSystem;

namespace Ark
{
    //折射缴械     当单方面攻击自身或与自身拼点的目标速度高于自身时使其所用书页威力无效化
    public class PassiveAbility_100120 : PassiveAbilityBase
    {
        public override void OnStartTargetedOneSide(BattlePlayingCardDataInUnitModel attackerCard)
        {
            if (owner.speedDiceResult.Count <= 0)
                return;
            if (attackerCard.speedDiceResultValue > owner.speedDiceResult[attackerCard.targetSlotOrder].value)
                attackerCard.ignorePower = true;
        }
        public override void OnStartParrying(BattlePlayingCardDataInUnitModel card)
        {
            if (card.speedDiceResultValue < card.target.currentDiceAction.speedDiceResultValue)
                card.target.currentDiceAction.ignorePower = true;
        }
    }
}
