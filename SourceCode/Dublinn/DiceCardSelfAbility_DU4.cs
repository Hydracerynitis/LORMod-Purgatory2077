// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_DU4
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[战斗开始] 这一幕与下一幕获得3层[守护][振奋]
    public class DiceCardSelfAbility_DU4 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[战斗开始] 这一幕与下一幕获得3层[守护][振奋]";
        public override string[] Keywords => new string[1] { "bstart_Keyword" };
        public override void OnStartBattle()
        {
            owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.BreakProtection, 3, owner);
            owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Protection, 3, owner);
            owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.BreakProtection, 3, owner);
            owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Protection, 3, owner);
        }
    }
}
