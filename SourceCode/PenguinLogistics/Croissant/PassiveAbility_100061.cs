// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100061
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;
using System;

namespace Ark
{
    //一鎚定音      使用骰子数为1的书页时伤害+50%(不包括反击骰)
    public class PassiveAbility_100061 : PassiveAbilityBase
    {
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            if (curCard.GetOriginalDiceBehaviorList().FindAll(x => x.Type != BehaviourType.Standby).Count != 1)
                return;
            owner.battleCardResultLog?.SetPassiveAbility(this);
            curCard.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus(){ dmgRate = 50 });
        }
    }
}
