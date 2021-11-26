// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100095
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;

namespace Ark
{
    //闪现        回避骰子与防御型骰子拼点胜利时可以继续使用
    public class PassiveAbility_100095 : PassiveAbilityBase
    {
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (behavior.Detail != BehaviourDetail.Evasion || behavior.TargetDice.Detail != BehaviourDetail.Guard)
                return;
            owner.battleCardResultLog?.SetPassiveAbility(this);
            behavior.isBonusEvasion = true;
        }
    }
}
