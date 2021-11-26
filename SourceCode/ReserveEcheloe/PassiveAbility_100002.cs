// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100002
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;
using System.Collections.Generic;

namespace Ark
{
    //指向射击 以远程书页命中目标时使一名友方单位获得1层“强壮”(每一幕至多触发3次)
    public class PassiveAbility_100002 : PassiveAbilityBase
    {
        private int _time;
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            if (behavior.card.card.GetSpec().Ranged != CardRange.Far || !this.IsAttackDice(behavior.Detail) || (behavior.card.target == null || _time > 3))
                return;
            owner.battleCardResultLog?.SetPassiveAbility(this);
            List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList(owner.faction);
            if(aliveList.Count>0)
                RandomUtil.SelectOne<BattleUnitModel>(aliveList).bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 1);
            ++_time;
        }

        public override void OnRoundStart() => this._time = 0;
    }
}
