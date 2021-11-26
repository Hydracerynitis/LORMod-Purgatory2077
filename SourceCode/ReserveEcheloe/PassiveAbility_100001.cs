// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100001
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;

namespace Ark
{
    //转守为攻  使用防御骰拼点时强化所用书页下一颗攻击型骰子
    public class PassiveAbility_100001 : PassiveAbilityBase
    {
        public override void OnRollDice(BattleDiceBehavior behavior)
        {
            if (behavior?.TargetDice == null || behavior.Detail != BehaviourDetail.Guard)
                return;
            behavior.card.AddDiceFace(DiceMatch.NextAttackDice, 1);
            owner.battleCardResultLog?.SetPassiveAbility(this);
        }
    }
}
