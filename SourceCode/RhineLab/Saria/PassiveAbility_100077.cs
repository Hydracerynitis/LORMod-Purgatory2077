// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100077
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //精神回复   使用书页消耗”充能“时使随机一名友方单位恢复4点混乱抗性  
    public class PassiveAbility_100077 : PassiveAbilityBase
    {
        public override void OnUseChargeStack()
        {
            foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveList_random(owner.faction, 1))
                battleUnitModel.breakDetail.RecoverBreak(4);
            owner.battleCardResultLog?.SetPassiveAbility(this);
        }
    }
}
