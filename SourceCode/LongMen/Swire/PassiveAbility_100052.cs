// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100052
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //作战指导      下令战斗时若自身拥有“强壮”时使所有友方获得1层“振奋”
    public class PassiveAbility_100052 : PassiveAbilityBase
    {
        public override void OnStartBattle()
        {
            if (owner.bufListDetail.GetKewordBufStack(KeywordBuf.Strength) <= 0)
                return;
            owner.battleCardResultLog?.SetPassiveAbility(this);
            foreach (BattleUnitModel alive in BattleObjectManager.instance.GetAliveList(owner.faction))
                alive.bufListDetail.AddKeywordBufByCard(KeywordBuf.BreakProtection, 1, owner);
        }
    }
}
