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
    //自身不低于5层[腐蚀]即可使用\n[装备时] 若自身本幕结束未[陷入混乱] 则将自身的[腐蚀]给予指向目标
    public class DiceCardSelfAbility_Wonly6 :DiceCardSelfAbilityBase 
    {
        public static string Desc = "自身不低于5层[腐蚀]即可使用\n[装备时]若自身本幕结束未[陷入混乱] 则将自身的[腐蚀]给予指向目标";
        public override bool OnChooseCard(BattleUnitModel owner)
        {
            return owner.bufListDetail.GetKewordBufStack(KeywordBuf.Decay) >= 5;
        }
        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            unit.bufListDetail.AddBuf(new TransferDecay(targetUnit));
        }
        public class TransferDecay : BattleUnitBuf
        {
            private BattleUnitModel target;
            public TransferDecay(BattleUnitModel target)
            {
                this.target = target;
            }
            public override void OnRoundEnd()
            {
                if (!_owner.IsBreakLifeZero())
                {
                    int stack = _owner.bufListDetail.GetKewordBufStack(KeywordBuf.Decay);
                    target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Decay, stack, _owner);
                    _owner.bufListDetail.RemoveBufAll(KeywordBuf.Decay);
                }
            }
        }
    }
}
