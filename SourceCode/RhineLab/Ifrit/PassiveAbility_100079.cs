// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100079
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //莱茵回路      造成伤害时消耗自身1层“充能”追加3点伤害
    public class PassiveAbility_100079 : PassiveAbilityBase
    {
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            if (owner.bufListDetail.GetActivatedBuf(KeywordBuf.WarpCharge) is BattleUnitBuf_warpCharge activatedBuf && activatedBuf.stack >= 1)
            {
                activatedBuf.UseStack(1, true);
                this.owner.battleCardResultLog?.SetPassiveAbility(this);
                behavior.card.target.TakeDamage(3, DamageType.Passive);
            }
        }
    }
}
