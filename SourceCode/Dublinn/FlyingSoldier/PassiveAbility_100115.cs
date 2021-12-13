// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100089
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;

namespace Ark
{
    //近地悬浮/枪长剑短     战斗开始时这一幕所有物理抗性临时变为免疫，陷入混乱时移除本被动且回满混乱抗性并解除混乱 /本被动未在舞台中被移除时无法使用近战战斗书页
    public class PassiveAbility_100115 : PassiveAbilityBase
    {
        public override AtkResist GetResistHP(AtkResist origin, BehaviourDetail detail)
        {
            return AtkResist.Immune;
        }
        public override void OnBreakState()
        {
            owner.breakDetail.RecoverBreakLife(1);
            owner.breakDetail.nextTurnBreak = false;
            owner.breakDetail.ResetBreakDefault();
            owner.passiveDetail.DestroyPassive(this);
            owner.view.ChangeSkin("DU14");
            owner.view.StartEgoSkinChangeEffect("Character");
        }
    }
}
