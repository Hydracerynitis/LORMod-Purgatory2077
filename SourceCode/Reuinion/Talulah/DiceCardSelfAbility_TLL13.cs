// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;
using LOR_DiceSystem;

namespace Ark
{
    //自身[烧伤]层数不低于30且剩余光芒足够则自动使用
    public class DiceCardSelfAbility_TLL13 : DiceCardSelfAbilityBase
    {
        public static string Desc = "自身[烧伤]层数不低于30且剩余光芒足够则自动使用";
        public override void OnEnterCardPhase(BattleUnitModel unit, BattleDiceCardModel self)
        {
            if (unit.allyCardDetail.GetHand().Contains(self) && unit.bufListDetail.GetKewordBufStack(KeywordBuf.Burn) >= 30 && unit.cardSlotDetail.PlayPoint >= self.GetCost())
            {
                int num = unit.speedDiceCount - 1;
                unit.SetCurrentOrder(num);
                unit.speedDiceResult[num].isControlable = false;
                BattleUnitModel target = unit.ChangeAttackTarget(self, num);
                if (target == null)
                    target = RandomUtil.SelectOne<BattleUnitModel>(BattleObjectManager.instance.GetAliveList_opponent(unit.faction));
                int targetSlot = UnityEngine.Random.Range(0, target.speedDiceResult.Count);
                unit.cardSlotDetail.AddCard(self, target, targetSlot);
            }
        }
    }
}
