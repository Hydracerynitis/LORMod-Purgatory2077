// Decompiled with JetBrains decompiler
// Type: Purgatory.PassiveAbility_10491
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //失神    血量与体力低于50时无法再行动
    public class PassiveAbility_10491 : PassiveAbilityBase
    {
        private bool _defeated;
        public override void OnRoundStart()
        {
            owner.SetDeadSceneBlock(true);
            if (!_defeated && (int) owner.hp > 50)
                return;
            _defeated = true;
            owner.view.charAppearance.ChangeMotion(ActionDetail.Damaged);
        }
        public override bool isTargetable => !_defeated;

        public override int SpeedDiceBreakedAdder() => _defeated ? 10 : 0;

        public override int GetMinHp() => 50;

        public override void AfterTakeDamage(BattleUnitModel attacker, int dmg)
        {
            if ((int) owner.hp > 50 || owner.IsBreakLifeZero() || _defeated)
                return;
            this.owner.breakDetail.LoseBreakLife();
        }

        public override void OnRoundEndTheLast()
        {
            if ((double) owner.hp <= (double) 50)
            {
                _defeated = true;
                owner.view.charAppearance.ChangeMotion(ActionDetail.Damaged);
            }
            if (!_defeated)
                return;
            owner.Die();
        }
    }
}
