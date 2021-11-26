// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_Grani1
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[战斗开始]使随机2名友方获得1层[守护]与[忍耐]
    public class DiceCardSelfAbility_Grani1 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[战斗开始]使随机2名友方获得1层[守护]与[忍耐]";
        public override string[] Keywords => new string[2]{ "bstart_Keyword", "Strength_Keyword" };
        public override void OnStartBattle()
        {
            foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveList_random(owner.faction, 2))
            {
                battleUnitModel.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Endurance, 1, owner);
                battleUnitModel.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Protection, 1, owner);
            }
        }
    }
}
