// Decompiled with JetBrains decompiler
// Type: Purgatory.DiceCardSelfAbility_Purgatory1Burn
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[使用时]使所有单位获得1层[烧伤]
    public class DiceCardSelfAbility_Purgatory1Burn : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时]使所有单位获得1层[烧伤]";
        public override string[] Keywords => new string[1]{ "Burn_Keyword" };
        public override void OnUseCard()
        {
            foreach (BattleUnitModel alive in BattleObjectManager.instance.GetAliveList())
                alive.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Burn, 1, owner);
        }
     }
}
