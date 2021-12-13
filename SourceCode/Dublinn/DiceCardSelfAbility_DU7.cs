// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_DU7
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[使用时] 使所有友方单位获得1层[振奋]
    public class DiceCardSelfAbility_DU7 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时] 使所有友方单位获得1层[振奋]";
        public override string[] Keywords => new string[1]{ "bstart_Keyword" };
        public override void OnStartBattle()
        {
            foreach (BattleUnitModel alive in BattleObjectManager.instance.GetAliveList(card.owner.faction))
                alive.bufListDetail.AddKeywordBufByCard(KeywordBuf.BreakProtection, 1, owner);
        }
    }
}
