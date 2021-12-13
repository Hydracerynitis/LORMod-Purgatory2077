// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100089
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll
using System.Collections.Generic;
using LOR_DiceSystem;

namespace Ark
{
    //石之盾     舞台切换时保留当前混乱抗性，若陷入混乱则立即解除混乱状态，且还原抗性并永久移出此被动 当此被动未被移出时所有物理抗性均为抵抗
    public class PassiveAbility_100092 : PassiveAbilityBase
    {
        public static Dictionary<UnitBattleDataModel, int> p_100092 = new Dictionary<UnitBattleDataModel, int>();
        public override void OnWaveStart()
        {
            if (p_100092.ContainsKey(owner.UnitData))
            {
                if (p_100092[owner.UnitData] == 0)
                {
                    owner.view.ChangeSkin("CPS");
                    owner.view.StartEgoSkinChangeEffect("Character");
                    owner.passiveDetail.PassiveList.Remove(this);
                    if (owner.passiveDetail.PassiveList.Find(x => x is PassiveAbility_100093) is PassiveAbility_100093 passive)
                        passive.OnWaveStart();
                    return;
                }

                else
                    owner.breakDetail.breakGauge = p_100092[owner.UnitData];
            }
            owner.view.ChangeSkin("CPS1");
            owner.view.StartEgoSkinChangeEffect("Character");

        }
        public override AtkResist GetResistHP(AtkResist origin, BehaviourDetail detail)
        {
            return AtkResist.Resist;
        }
        public override void OnBreakState()
        {
            owner.breakDetail.RecoverBreakLife(1);
            owner.breakDetail.nextTurnBreak = false;
            owner.breakDetail.ResetBreakDefault();
            owner.passiveDetail.DestroyPassive(this);
            owner.view.ChangeSkin("CPS");
            owner.view.StartEgoSkinChangeEffect("Character");
            if (p_100092.ContainsKey(owner.UnitData))
                p_100092[owner.UnitData] = 0;
            else
                p_100092.Add(owner.UnitData, 0);
        }
        public override void OnBattleEnd_alive()
        {
            if (p_100092.ContainsKey(owner.UnitData))
                p_100092[owner.UnitData] = owner.breakDetail.breakGauge;
            else
                p_100092.Add(owner.UnitData, owner.breakDetail.breakGauge);
        }
    }
}
