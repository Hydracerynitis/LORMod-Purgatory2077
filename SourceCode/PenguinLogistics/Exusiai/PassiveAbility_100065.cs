// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100065
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //天使祈福      舞台开始时使随机1名友方角色永久获得2层“强壮”与“迅捷”
    public class PassiveAbility_100065 : PassiveAbilityBase
    {
        public override void OnWaveStart()
        {
            foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveList_random(this.owner.faction, 1))
                battleUnitModel.bufListDetail.AddBuf(new BattleUnitBuf_Angel());
        }
        public class BattleUnitBuf_Angel : BattleUnitBuf
        {
            public override void OnRoundStart()
            {
                _owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 2);
                _owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Quickness, 2);
            }
        }
    }
}
