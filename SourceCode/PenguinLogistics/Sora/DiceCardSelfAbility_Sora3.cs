// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_Sora3
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[使用时]所有友方恢复10点体力与5点混乱抗性 自身获得4层[易损]
    public class DiceCardSelfAbility_Sora3 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时]所有友方恢复10点体力与5点混乱抗性 自身获得4层[易损]";
        public override string[] Keywords => new string[1]{ "bstart_Keyword" };
        public override void OnUseCard()
        {
            owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Vulnerable, 4, null);
            foreach (BattleUnitModel alive in BattleObjectManager.instance.GetAliveList(this.owner.faction))
            {
                alive.RecoverHP(10);
                alive.breakDetail.RecoverBreak(5);
            }
        }
    }
}
