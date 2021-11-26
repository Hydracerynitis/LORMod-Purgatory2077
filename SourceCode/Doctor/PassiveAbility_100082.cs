// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100082
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //绝佳指挥      舞台开启时获得永久“匿踪” 且每一幕开始恢复2点光芒并抽取2张书页 当没有友方存活时自身死亡
    public class PassiveAbility_100082 : PassiveAbilityBase
    {
        public override bool isTargetable => false;
        public override void OnRoundStart()
        {
            owner.allyCardDetail.DrawCards(2);
            owner.cardSlotDetail.RecoverPlayPoint(2);
        }
        public override void OnDieOtherUnit(BattleUnitModel unit)
        {
            if (BattleObjectManager.instance.GetAliveList(owner.faction).Count > 1)
                return;
            owner.Die();
        }
    }
}
