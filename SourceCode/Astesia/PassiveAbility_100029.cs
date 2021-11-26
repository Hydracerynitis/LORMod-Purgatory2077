// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100029
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;

namespace Ark
{
    //莱茵顾问      回避骰子拼点胜利时使所用书页最后一颗骰子威力+2
    public class PassiveAbility_100029 : PassiveAbilityBase
    {
        public override void OnWinParrying(BattleDiceBehavior behavior)
        {
            if (behavior == null || behavior.card?.target == null || behavior.Detail != BehaviourDetail.Evasion)
                return;
            behavior.card.ApplyDiceStatBonus(DiceMatch.LastDice, new DiceStatBonus() { power = 2 });
            owner.battleCardResultLog?.SetPassiveAbility(this);
        }
    }
}
