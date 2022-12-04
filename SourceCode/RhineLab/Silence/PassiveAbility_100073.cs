// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100073
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //强化消耗       使用书页消耗充能时若剩余至少1层"充能"则消耗1层"充能"抽取1张书页(每一幕至多触发1次)
    public class PassiveAbility_100073 : PassiveAbilityBase
    {
        private bool Activate;
        public override void OnRoundStart()
        {
            Activate = false;
        }
        public override void OnUseChargeStack()
        {
            if (Activate)
                return;
            if (owner.bufListDetail.GetActivatedBuf(KeywordBuf.WarpCharge) is BattleUnitBuf_warpCharge activatedBuf && activatedBuf.stack >= 1)
            {
                activatedBuf.stack-=1;
                owner.allyCardDetail.DrawCards(1);
                owner.battleCardResultLog?.SetPassiveAbility(this);
                Activate = true;
            }
        }
    }
}
