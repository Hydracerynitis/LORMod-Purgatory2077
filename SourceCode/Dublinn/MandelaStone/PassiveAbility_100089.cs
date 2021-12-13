// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100089
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll
using System.Collections.Generic;
using LOR_DiceSystem;

namespace Ark
{
    //曼德拉石像     舞台开启将物理抗性设置为免疫，若陷入混乱时这一幕减少受到的伤害6点并在下一幕“匿踪”，随后回满混乱抗性并使物理抗性复原(整场接待至多触发1次)
    public class PassiveAbility_100089 : PassiveAbilityBase
    {
        public static Dictionary<UnitBattleDataModel, bool> p_100089 = new Dictionary<UnitBattleDataModel, bool>();
        private bool Trigger =true;
        private bool InvisTrigger = false;
        public override bool isTargetable => !InvisTrigger;
        public override void OnWaveStart()
        {
            if (p_100089.ContainsKey(owner.UnitData))
                Trigger = p_100089[owner.UnitData];
            if (Trigger)
            {
                owner.Book.SetResistHP(BehaviourDetail.Slash, AtkResist.Immune);
                owner.Book.SetResistHP(BehaviourDetail.Penetrate, AtkResist.Immune);
                owner.Book.SetResistHP(BehaviourDetail.Hit, AtkResist.Immune);
            }
        }
        public override void OnBattleEnd_alive()
        {
            if (!p_100089.ContainsKey(owner.UnitData))
                p_100089.Add(owner.UnitData, Trigger);
            else
                p_100089[owner.UnitData] = Trigger;
        }
        public override int GetDamageReduction(BattleDiceBehavior behavior)
        {
            if (owner.IsBreakLifeZero() && InvisTrigger)
                return -6;
            return base.GetDamageReduction(behavior);
        }
        public override void OnBreakState()
        {
            if (Trigger)
            {
                Trigger = false;
                InvisTrigger = true;
            }
        }
        public override void OnRoundEnd()
        {
            if (InvisTrigger)
            {
                owner.breakDetail.nextTurnBreak = false;
                owner.breakDetail.RecoverBreakLife(1);
                owner.breakDetail.ResetGauge();
                owner.Book.SetOriginalResists();
                InvisTrigger = false;
            }
        }
    }
}
