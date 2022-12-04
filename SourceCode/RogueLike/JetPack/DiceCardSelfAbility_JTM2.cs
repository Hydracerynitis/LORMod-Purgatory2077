// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_Ptilopsis4
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[使用时]自身下一幕中进入[匿踪]与[晕眩]
    public class DiceCardSelfAbility_JTM2 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时]自身下一幕中进入[匿踪]与[晕眩]";
        public override void OnUseCard()
        {
            owner.bufListDetail.AddReadyBuf(new Stealth());
            owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Stun, 1,owner);
        }
    }
}
