// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100030
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System;

namespace Ark
{
    //星象连接      每一幕中分别命中3个不同的目标时抽取1张书页并恢复1点光芒
    public class PassiveAbility_100030 : PassiveAbilityBase
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
            if (_damage >= 3)
            {
                owner.allyCardDetail.DrawCards(1);
                owner.cardSlotDetail.RecoverPlayPoint(1);
            }
            _damage = 0;
        }
        public class BattleUnitBuf_Damaged : BattleUnitBuf
        {
            public override void OnRoundStart() => Destroy();
        }
    }
}
