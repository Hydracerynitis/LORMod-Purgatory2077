// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardAbility_Catapultplayer
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[命中时] 若目标情感到达五且混乱抗性大于45则使其受到25点额外混乱伤害
    public class DiceCardAbility_Catapultplayer : DiceCardAbilityBase
    {
        public static string Desc = "[命中时] 若目标情感到达五且混乱抗性大于45则使其受到25点额外混乱伤害";
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            if (target == null || target.emotionDetail.EmotionLevel < 5 || target.breakDetail.breakLife <= 45)
                return;
            target.TakeBreakDamage(25, DamageType.Card_Ability, owner);
        }
    }
}
