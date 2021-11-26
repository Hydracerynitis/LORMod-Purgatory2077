// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardAbility_Angelina
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[命中时] 下一幕对目标施加1层[束缚]与[虚弱]
    public class DiceCardAbility_Angelina : DiceCardAbilityBase
    {
        public static string Desc = "[命中时] 下一幕对目标施加1层[束缚]与[虚弱]";
        public override string[] Keywords => new string[2]{ "Binding_Keyword", "Weak_Keyword" };
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            target?.bufListDetail.AddKeywordBufByCard(KeywordBuf.Binding, 1, owner);
            target?.bufListDetail.AddKeywordBufByCard(KeywordBuf.Weak, 1, owner);
        }
    }
}
