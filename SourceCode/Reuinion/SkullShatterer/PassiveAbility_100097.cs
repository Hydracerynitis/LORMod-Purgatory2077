// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100097
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;

namespace Ark
{
    //黄昏/病入膏肓       进攻型骰子威力+2且混乱伤害+25%/以近战书页进行单方面攻击时摧毁本书页剩余的其他骰子
    public class PassiveAbility_100097 : PassiveAbilityBase
    { 
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (!behavior.IsParrying() && behavior.card.card.GetSpec().Ranged == CardRange.Near)
            {
                owner.battleCardResultLog?.SetPassiveAbility(this);
                behavior.card.DestroyDice(DiceMatch.AllDice);
            }
            if (!IsAttackDice(behavior.Detail))
                return;
            owner.battleCardResultLog?.SetPassiveAbility(this);
            behavior.ApplyDiceStatBonus(new DiceStatBonus(){ power = 2, breakRate = 25 });
        }
    }
}
