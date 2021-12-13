// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardAbility_DU6
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //本骰子受到自身[振奋]层数的威力增加
    public class DiceCardAbility_DU6 : DiceCardAbilityBase
    {
        public static string Desc = "本骰子受到自身[振奋]层数的威力增加";
        public override void BeforeRollDice()
        {
            int kewordBufStack = this.owner.bufListDetail.GetKewordBufStack(KeywordBuf.BreakProtection);
            if (kewordBufStack <= 0)
                return;
            behavior.ApplyDiceStatBonus(new DiceStatBonus(){ power = kewordBufStack });
        }
    }
}
