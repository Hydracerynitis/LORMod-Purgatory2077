// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100012
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //熏烟散气  每一幕开始时有(烟气层数x10%)的概率对场上的所有单位施加1层“烧伤”
    public class PassiveAbility_100012 : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            if ((double) RandomUtil.valueForProb >= (double) 0.1 * (double) owner.bufListDetail.GetKewordBufStack(KeywordBuf.Smoke))
                return;
            foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveListExceptFaction(owner.faction))
                battleUnitModel.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Burn, 1, owner);
        }
    }
}
