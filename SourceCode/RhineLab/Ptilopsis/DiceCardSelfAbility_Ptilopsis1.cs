// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_Ptilopsis1
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[使用时]所有友方恢复3点体力并获得1层[充能]
    public class DiceCardSelfAbility_Ptilopsis1 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时]所有友方恢复3点体力并获得1层[充能]";
        public override void OnUseCard()
        {
            foreach (BattleUnitModel alive in BattleObjectManager.instance.GetAliveList(owner.faction))
            {
                alive.RecoverHP(3);
                alive.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.WarpCharge, 1, owner);
            }
        }
        public override string[] Keywords => new string[1]{ "WarpCharge" };
    }
}
