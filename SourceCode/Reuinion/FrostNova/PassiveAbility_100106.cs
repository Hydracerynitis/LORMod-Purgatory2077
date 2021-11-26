// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100106
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;

namespace Ark
{
    //寒潮        受到致死伤害时使这一幕体力不会低于1，下一幕开始回满所有体力与混乱抗性(整场接待至多触发1次)
    public class PassiveAbility_100106 : PassiveAbilityBase
    {
        private int _phase = 1;
        private bool _nextPhase;
        public override bool isImmortal
        {
            get
            {
                if (owner.UnitData.floorBattleData.param3 == 1 && owner.faction == Faction.Player)
                    return true;
                return owner.UnitData.floorBattleData.param2 == 1 && owner.faction == Faction.Enemy;
            }
        }
        public override bool BeforeTakeDamage(BattleUnitModel attacker, int dmg)
        {
            if (_phase == 1 &&  owner.hp - dmg <= 1.0)
                _nextPhase = true;
            return base.BeforeTakeDamage(attacker, dmg);
        }
        public override void OnRoundEndTheLast()
        {
            if (_phase != 1 || !_nextPhase &&  owner.hp > 1.0)
                return;
            _phase = 2;
            if (owner.faction == Faction.Player)
                owner.UnitData.floorBattleData.param3 = _phase;
            else
                owner.UnitData.floorBattleData.param2 = _phase;
            _nextPhase = true;
            owner.RecoverBreakLife(1);
            owner.ResetBreakGauge();
            owner.breakDetail.nextTurnBreak = false;
            owner.RecoverHP(owner.MaxHp);
        }
    }
}
