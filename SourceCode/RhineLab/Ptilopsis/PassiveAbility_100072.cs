// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100072
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //技力光环      每三幕时使所有友方单位恢复1点光芒
    public class PassiveAbility_100072 : PassiveAbilityBase
    {
        private int _round=0;
        public override void OnRoundStart()
        {
            ++_round;
            if (_round < 3)
                return;
            _round = 0;
            foreach (BattleUnitModel alive in BattleObjectManager.instance.GetAliveList(this.owner.faction))
                alive.cardSlotDetail.RecoverPlayPoint(1);
        }
    }
}
