// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100046
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //黑暗剑模式     慵懒 每一幕开始使自己与随机一名友方恢复5点体力 当核心书页强化到22级时获得黑暗剑+23
    public class PassiveAbility_100046 : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveList_random(owner.faction, 1))
                battleUnitModel.RecoverHP(5);
            owner.RecoverHP(5);
        }
    }
}
