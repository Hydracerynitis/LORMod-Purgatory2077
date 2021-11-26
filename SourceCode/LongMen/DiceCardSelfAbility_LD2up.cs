// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_LD2up
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[使用时]这一幕中随机使2名友方单位获得2层[强壮]
    public class DiceCardSelfAbility_LD2up : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时]这一幕中随机使2名友方单位获得2层[强壮]";
        public override void OnUseCard()
        {
            foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveList_random(owner.faction, 2))
                battleUnitModel.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Strength, 2, owner);
        }
    }
}
