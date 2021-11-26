// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_Chen3
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[使用时]抽取2张书页并在下一幕获得1层[迅捷]
    public class DiceCardSelfAbility_Chen3 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时]抽取2张书页并在下一幕获得1层[迅捷]";
        public override void OnUseCard()
        {
            owner.allyCardDetail.DrawCards(2);
            owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Quickness, 1, owner);
        }
    }
}
