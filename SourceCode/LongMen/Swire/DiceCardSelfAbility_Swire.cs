// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_Swire
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[战斗开始]这一幕使所有友方获得1层[强壮]并在下一幕获得1层[虚弱]
    public class DiceCardSelfAbility_Swire : DiceCardSelfAbilityBase
    {
        public static string Desc = "[战斗开始]这一幕使所有友方获得1层[强壮]并在下一幕获得1层[虚弱]";
        public override string[] Keywords => new string[2]{ "bstart_Keyword", "Strength_Keyword" };
        public override void OnStartBattle()
        {
            foreach (BattleUnitModel alive in BattleObjectManager.instance.GetAliveList(owner.faction))
            {
                alive.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Strength, 1, owner);
                alive.bufListDetail.AddKeywordBufByCard(KeywordBuf.Weak, 1, owner);
            }
        }
    }
}
