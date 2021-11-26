// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_Saria3
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;
using System;
using System.Collections.Generic;

namespace Ark
{
    //[使用时]消耗[充能]层数最高的友方单位3层[充能]使自身这一幕中进攻型骰子威力+1
    public class DiceCardSelfAbility_Saria3 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时]消耗[充能]层数最高的友方单位3层[充能]使自身这一幕中进攻型骰子威力+1";
        public override string[] Keywords => new string[]{ "WarpCharge" };
        public override void OnUseCard()
        {
            List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList(this.owner.faction);
            if (aliveList.Count <= 0)
                return;
            aliveList.Sort((x, y) => y.bufListDetail.GetKewordBufStack(KeywordBuf.WarpCharge) - x.bufListDetail.GetKewordBufStack(KeywordBuf.WarpCharge));
            if (aliveList[0].bufListDetail.GetActivatedBuf(KeywordBuf.WarpCharge) is BattleUnitBuf_warpCharge activatedBuf && activatedBuf.stack >= 3)
            {
                activatedBuf.UseStack(3, true);
                owner.bufListDetail.AddBuf(new powerUpthisRoundBuf());
            }
        }
        public class powerUpthisRoundBuf : BattleUnitBuf
        {
            public override void BeforeRollDice(BattleDiceBehavior behavior)
            {
                if (behavior.Type != BehaviourType.Atk)
                    return;
                behavior.ApplyDiceStatBonus(new DiceStatBonus() { power = 1 });
            }
            public override void OnRoundEnd() => Destroy();
        }
    }
}
