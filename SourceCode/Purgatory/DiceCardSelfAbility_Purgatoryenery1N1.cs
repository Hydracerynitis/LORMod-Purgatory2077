// Decompiled with JetBrains decompiler
// Type: Purgatory.DiceCardSelfAbility_Purgatoryenery1N1
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[战斗开始]恢复2点光芒并使自身这一幕所有骰子威力-1
    public class DiceCardSelfAbility_Purgatoryenery1N1 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[战斗开始]恢复2点光芒并使自身这一幕所有骰子威力-1";
        public override string[] Keywords => new string[1]{ "bstart_Keyword" };
        public override void OnStartBattle()
        {
            owner.cardSlotDetail.RecoverPlayPointByCard(2);
            owner.bufListDetail.AddBuf(new Buf());
        }
        public class Buf : BattleUnitBuf
        {
             public override void BeforeRollDice(BattleDiceBehavior behavior) => behavior.ApplyDiceStatBonus(new DiceStatBonus(){ power = -1 });
            public override void OnRoundEnd() => Destroy();
        }
    }
}
