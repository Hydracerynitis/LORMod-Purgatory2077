// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100074
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //辅助模块      使用书页获得”充能“时有40%使所有友方也获得1层“充能”
    public class PassiveAbility_100074 : PassiveAbilityBase
    {
        public override void OnAddKeywordBufByCardForEvent(KeywordBuf keywordBuf, int stack, BufReadyType readyType)
        {
            if(keywordBuf==KeywordBuf.WarpCharge  && RandomUtil.valueForProb < 0.4)
            {
                foreach (BattleUnitModel alive in BattleObjectManager.instance.GetAliveList(owner.faction))
                {
                    if (readyType == BufReadyType.ThisRound)
                        alive.bufListDetail.AddKeywordBufThisRoundByEtc(keywordBuf, 1);
                    else if (readyType == BufReadyType.NextRound)
                        alive.bufListDetail.AddKeywordBufByEtc(keywordBuf, 1);
                    else if (readyType == BufReadyType.NextNextRound)
                        alive.bufListDetail.AddKeywordBufNextNextByCard(keywordBuf, 1);
                }
            
            }
        }
    }
}
