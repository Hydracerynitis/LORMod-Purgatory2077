// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100010
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System;

namespace Ark
{
    //魔剑    一幕之内命中4个不同的目标时下一幕获得3层强壮与3层易损
    public class PassiveAbility_100010 : PassiveAbilityBase
    {
        private int _damage;
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            BattleUnitModel target = behavior.card.target;
            if (target.bufListDetail.GetActivatedBufList().Find(x => x is BattleUnitBuf_Damaged) != null)
                return;
            ++_damage;
            target.bufListDetail.AddBuf(new BattleUnitBuf_Damaged());
        }
        public override void OnRoundStart()
        {
            if (_damage >= 4)
            {
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 3);
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Vulnerable, 3);
            }
            _damage = 0;
        }
        public class BattleUnitBuf_Damaged : BattleUnitBuf
        {
            public override void OnRoundStart() => this.Destroy();
        }
    }
}
