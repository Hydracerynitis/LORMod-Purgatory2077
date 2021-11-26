// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_Sora1
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[战斗开始]这一幕中所有友方命中目标时恢复2点体力
    public class DiceCardSelfAbility_Sora1 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[战斗开始]这一幕中所有友方命中目标时恢复2点体力";
        public override string[] Keywords => new string[1]{ "bstart_Keyword" };
        public override void OnStartBattle()
        {   
            foreach (BattleUnitModel alive in BattleObjectManager.instance.GetAliveList(owner.faction))
                alive.bufListDetail.AddBuf(new RecoverthisRoundBuf());
        }
        public class RecoverthisRoundBuf : BattleUnitBuf
        {
            public override void OnSuccessAttack(BattleDiceBehavior behavior) => _owner.RecoverHP(2);
            public override void OnRoundEnd() => this.Destroy();
        }
    }
}
