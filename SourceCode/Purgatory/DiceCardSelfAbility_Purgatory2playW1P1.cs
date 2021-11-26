// Decompiled with JetBrains decompiler
// Type: Purgatory.DiceCardSelfAbility_Purgatory2playW1P1
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[战斗开始]这一幕中随机对2名敌方角色施加1层[虚弱]与1层[破绽]
    public class DiceCardSelfAbility_Purgatory2playW1P1 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[战斗开始]这一幕中随机对2名敌方角色施加1层[虚弱]与1层[破绽]";
        public override string[] Keywords => new string[3]{ "bstart_Keyword", "Weak_Keyword", "Disarm_Keyword" };
        public override void OnStartBattle()
        {
            foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveList_random(owner.faction == Faction.Enemy ? Faction.Player : Faction.Enemy, 2))
            {
                battleUnitModel.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Weak, 1, owner);
                battleUnitModel.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Disarm, 1, owner);
            }
        }
    }
}
