// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100069
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll
using LOR_DiceSystem;

namespace Ark
{
    //以远程书页命中目标时有25%使伤害翻倍
    public class PassiveAbility_GreyThroatPix1 : PassiveAbilityBase
    {
        public override void BeforeGiveDamage(BattleDiceBehavior behavior)
        {
            if (behavior.card.card.GetSpec().Ranged == CardRange.Far && RandomUtil.valueForProb <= 0.25)
                behavior.ApplyDiceStatBonus(new DiceStatBonus() { dmgRate = 100 });
        }
    }
}
