// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100032
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;
using System;

namespace Ark
{
    //集中防御  所用书页中防御型骰子数量少于3时防御型骰子威力+1
    public class PassiveAbility_100032 : PassiveAbilityBase
    {
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            if (curCard.GetOriginalDiceBehaviorList().FindAll(x => x.Type == BehaviourType.Def).Count >= 3)
                return;
            owner.battleCardResultLog?.SetPassiveAbility(this);
            curCard.ApplyDiceStatBonus(DiceMatch.AllDefenseDice, new DiceStatBonus(){ power = 1 });
        }
    }
}
