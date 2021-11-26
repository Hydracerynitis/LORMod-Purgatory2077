// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_DU12
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //"[使用时]消耗1层[振奋]使本书页所有骰子威力+2"
    public class DiceCardSelfAbility_DU12 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时]消耗1层[振奋]使本书页所有骰子威力+2";
        public override void OnUseCard()
        {
            foreach (BattleUnitBuf activatedBuf in owner.bufListDetail.GetActivatedBufList())
            {
                if (activatedBuf.bufType == KeywordBuf.BreakProtection && activatedBuf.stack >= 1)
                {
                    --activatedBuf.stack;
                    card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus(){ power = 2 });
                }
            }
        }
    }
}
