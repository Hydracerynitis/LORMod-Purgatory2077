// Decompiled with JetBrains decompiler
// Type: Purgatory.DiceCardSelfAbility_PurgatoryEx
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[装备时] 变为[炎狱]且血量上限与混乱抗性上限提升至150/80 置入[焰淬匕首][狱火之环][咒术点燃]
    public class DiceCardSelfAbility_PurgatoryEx : DiceCardSelfAbilityBase
    {
        public static string Desc = "[装备时] 变为[炎狱]且血量上限与混乱抗性上限提升至150/80 置入[焰淬匕首][狱火之环][咒术点燃]";
        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            unit.view.ChangeSkin("Purgatory");
            unit.allyCardDetail.AddNewCard(new LorId("Purgatory2077", 7));
            unit.allyCardDetail.AddNewCard(new LorId("Purgatory2077", 8));
            unit.allyCardDetail.AddNewCard(new LorId("Purgatory2077", 9));
            unit.bufListDetail.AddBuf(new BattleUnitBuf_battle());
            unit.RecoverHP(60);
            unit.RecoverBreakLife(1);
            unit.ResetBreakGauge();
            unit.breakDetail.nextTurnBreak = false;
        }
        public class BattleUnitBuf_battle : BattleUnitBuf
        {
            public BattleUnitBuf_battle() => stack = 0;
            public override StatBonus GetStatBonus() => new StatBonus(){ hpAdder = 60, breakGageAdder = 45 };
        }
    }
}
