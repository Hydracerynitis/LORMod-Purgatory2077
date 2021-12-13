// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_DU3
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[使用时] 下一幕获得1层[振奋]并抽1张牌
    public class DiceCardSelfAbility_DU3 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时] 下一幕获得1层[振奋]并抽1张牌";
        public override string[] Keywords => new string[1]{ "DrawCard_Keyword" };
        public override void OnUseCard()
        {
            owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.BreakProtection, 1, owner);
            owner.allyCardDetail.DrawCards(1);
        }
    }
}
