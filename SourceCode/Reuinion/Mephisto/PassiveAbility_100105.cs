// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100105
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //活性再生      每一幕使所有友方单位恢复1体力(包括自己)
    public class PassiveAbility_100105 : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            foreach (BattleUnitModel alive in BattleObjectManager.instance.GetAliveList(owner.faction))
                alive.RecoverHP(1);
        }
    }
}
