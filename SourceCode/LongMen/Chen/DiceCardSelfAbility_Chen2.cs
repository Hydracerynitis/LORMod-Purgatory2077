// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_Chen2
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[使用时]下一幕开始获得2层[虚弱]与2层[迅捷]
    public class DiceCardSelfAbility_Chen2 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时]下一幕开始获得2层[虚弱]与2层[迅捷]";
        public override void OnUseCard()
        {
            owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Weak, 2, owner);
            owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Quickness, 2, owner);
        }
    }
}
