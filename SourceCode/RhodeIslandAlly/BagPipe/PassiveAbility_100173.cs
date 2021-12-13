// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100069
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll
using LOR_DiceSystem;
using System.Collections.Generic;
namespace Ark
{
    //精密填弹  进攻骰命中目标时有25%额外追加攻击一次
    public class PassiveAbility_100173 : PassiveAbilityBase
    {
        private List<BattleDiceBehavior> BonusAttack = new List<BattleDiceBehavior>();
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            if(!BonusAttack.Contains(behavior) && RandomUtil.valueForProb <= 0.25)
            {
                BonusAttack.Add(behavior);
                behavior.GiveDamage(behavior.card.target);
            }
        }
    }
}
