// Decompiled with JetBrains decompiler
// Type: Purgatory.DiceCardSelfAbility_PurgatoryplayB1W1
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[战斗开始]使所有敌方单位获得1层[烧伤]与1层[虚弱]
    public class DiceCardSelfAbility_PurgatoryplayB1W1 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[战斗开始]使所有敌方单位获得1层[烧伤]与1层[虚弱]";
        public override string[] Keywords => new string[3]{ "bstart_Keyword", "Weak_Keyword", "Burn_Keyword" };
        public override void OnStartBattle()
        {
            foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveListExceptFaction(owner.faction))
            {
                battleUnitModel.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Weak, 1, owner);
                battleUnitModel.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Burn, 1, owner);
            }
        }
    }
}
