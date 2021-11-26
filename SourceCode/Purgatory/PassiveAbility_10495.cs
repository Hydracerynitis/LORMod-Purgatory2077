// Decompiled with JetBrains decompiler
// Type: Purgatory.PassiveAbility_10495
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //时空混乱      过去与未来的记忆纠缠在一起 不再温暖的梦
    public class PassiveAbility_10495 : PassiveAbilityBase
    {
        private bool _undie=false;
        public override void OnRoundEndTheLast()
        {
            if ((double) this.owner.hp > 101.0 || _undie)
                return;
            _undie = true;
            owner.RecoverBreakLife(1);
            owner.ResetBreakGauge();
            owner.breakDetail.nextTurnBreak = false;
        }
        public override int GetMinHp() => !_undie ? 100 : base.GetMinHp();

        public override int SpeedDiceNumAdder() => _undie ? 2 : 0;
    }
}
