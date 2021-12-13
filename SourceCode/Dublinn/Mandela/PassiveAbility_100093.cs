// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100089
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;

namespace Ark
{
    //破碎之蔓     体力低于50永久陷入混乱 舞台切换时体力恢复至100
    public class PassiveAbility_100093 : PassiveAbilityBase
    {
        public override void OnWaveStart()
        {
            if (owner.hp <= 100)
                owner.SetHp(100);
        }
        public override void OnRoundStart()
        {
            if (owner.hp <= 50)
            {
                owner.breakDetail.breakGauge = 0;
                owner.breakDetail.breakLife = 0;
                owner.breakDetail.DestroyBreakPoint();
                owner.view.ChangeSkin("CPS2");
            }
        }
    }
}
