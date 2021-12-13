// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_DU11
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[使用时]消耗1层[守护]使所有友方单位下一幕获得2层[振奋]
    public class DiceCardSelfAbility_DU11 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时]消耗1层[守护]使所有友方单位下一幕获得2层[振奋]";
        public override void OnUseCard()
        {
            foreach (BattleUnitBuf activatedBuf in owner.bufListDetail.GetActivatedBufList())
            {
                if (activatedBuf.bufType == KeywordBuf.Protection && activatedBuf.stack >= 1)
                {
                    --activatedBuf.stack;
                    foreach (BattleUnitModel alive in BattleObjectManager.instance.GetAliveList(owner.faction))
                        alive.bufListDetail.AddKeywordBufByCard(KeywordBuf.BreakProtection, 2, owner);
                }
            }
        }
    }
}
