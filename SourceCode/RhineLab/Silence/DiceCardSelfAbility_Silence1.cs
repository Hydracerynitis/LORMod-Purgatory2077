// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_Silence1
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[使用时]本书页所有骰子获得[充能]层数的最大值提升
    public class DiceCardSelfAbility_Silence1 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时] 本书页所有骰子获得[充能]层数的最大值提升";
        public override void OnUseCard()
        {
            card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus() { max = owner.bufListDetail.GetKewordBufStack(KeywordBuf.WarpCharge) });
        }
        public override string[] Keywords => new string[1]{ "WarpCharge" };
    }
}
