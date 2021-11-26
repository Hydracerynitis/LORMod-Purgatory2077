// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100071
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //机械光环      每一幕开始时使所有友方单位获得1层“充能”
    public class PassiveAbility_100071 : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            foreach (BattleUnitModel alive in BattleObjectManager.instance.GetAliveList(owner.faction))
                alive.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.WarpCharge, 1);
        }
    }
}
