// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_OrchidFuckYou
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[使用时]若有敌对目标[强壮]层数不少于4则使其这一幕与下一幕获得[威力无效]
    public class DiceCardSelfAbility_OrchidFuckYou : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时]若有敌对目标[强壮]层数不少于4则使其这一幕与下一幕获得[威力无效]";
        public override void OnUseCard()
        {
            foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveList_opponent(owner.faction))
            {
                if (battleUnitModel.bufListDetail.GetKewordBufStack(KeywordBuf.Strength) > 3)
                {
                    battleUnitModel.bufListDetail.AddKeywordBufByCard(KeywordBuf.NullifyPower, 1, owner);
                    battleUnitModel.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.NullifyPower, 1, owner);
                }
            }
            }
        }
}
