// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100089
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll
using System.Collections.Generic;
using System;

namespace Ark
{
    //迅斩技巧     自身速度每高于目标2点则使所用书页的所有进攻型骰子威力+1(至多3点)
    public class PassiveAbility_100122 : PassiveAbilityBase
    {
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            int speedDiference = Math.Max(0, curCard.speedDiceResultValue - curCard.target.speedDiceResult[curCard.targetSlotOrder].value);
            curCard.ApplyDiceStatBonus(DiceMatch.AllAttackDice, new DiceStatBonus() { power = Math.Min(speedDiference / 2, 3)});
        }
    }
}
