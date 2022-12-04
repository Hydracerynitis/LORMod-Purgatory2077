// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardAbility_Catapult
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[命中时] 若目标情感到达五且混乱抗性大于45则使其陷入混乱
    public class DiceCardAbility_Catapult : DiceCardAbilityBase
    {
        public static string Desc = "[命中时] 若目标情感到达五且混乱抗性大于45则使其陷入混乱";
        public override void OnSucceedAreaAttack(BattleUnitModel target)
        {
            if (target == null || target.emotionDetail.EmotionLevel < 5 || target.breakDetail.breakLife <= 45)
                return;
            target.breakDetail.breakGauge = 0;
            target.breakDetail.breakLife = 0;
            target.breakDetail.DestroyBreakPoint();
        }
    }
}
