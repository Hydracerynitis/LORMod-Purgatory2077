// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100075
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //自动无人机     下令战斗时若自身拥有至少1层“充能”则消耗1层“充能”使其他友方恢复2点混乱抗性
    public class PassiveAbility_100075 : PassiveAbilityBase
    {
        public override void OnStartBattle()
        {
            if (this.owner.bufListDetail.GetActivatedBuf(KeywordBuf.WarpCharge) is BattleUnitBuf_warpCharge activatedBuf && activatedBuf.stack >= 1)
            {
                activatedBuf.UseStack(1, true);
                foreach (BattleUnitModel alive in BattleObjectManager.instance.GetAliveList(this.owner.faction))
                    alive.breakDetail.RecoverBreak(2);
            }
        }
    }
}
