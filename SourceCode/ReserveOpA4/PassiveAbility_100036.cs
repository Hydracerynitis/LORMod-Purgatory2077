// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100036
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //黑钢先锋      使用书页恢复光芒时使随机一名友方单位也恢复1点光芒
    public class PassiveAbility_100036 : PassiveAbilityBase
    { 
        public void OnRecoverPlayPoint()
        {
            foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveList_random(owner.faction, 1))
                battleUnitModel.cardSlotDetail.RecoverPlayPoint(1);
        }
    }
}
