// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_Silence2
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[使用时]获得2层[充能]并使随机一名友方单位获得3层[充能]
    public class DiceCardSelfAbility_Silence2 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时]获得2层[充能]并使随机一名友方单位获得3层[充能]";
        public override void OnUseCard()
        {
            owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.WarpCharge, 2, owner);
            foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveList_random(owner.faction, 1))
                battleUnitModel.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.WarpCharge, 3, owner);
        }
        public override string[] Keywords => new string[1]{ "WarpCharge" };
    }
}
