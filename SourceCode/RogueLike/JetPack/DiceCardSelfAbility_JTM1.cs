// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_Ptilopsis4
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[拼点时]自身若处于[匿踪]则摧毁目标下两颗骰子
    public class DiceCardSelfAbility_JTM1 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[拼点时]自身若处于[匿踪]则摧毁目标下两颗骰子";
        public override void OnStartParrying()
        {
            if (owner.IsTargetable(null))
            {
                card.target.currentDiceAction.DestroyDice(DiceMatch.NextDice);
                card.target.currentDiceAction.DestroyDice(DiceMatch.NextDice);
            }
        }
    }
}
