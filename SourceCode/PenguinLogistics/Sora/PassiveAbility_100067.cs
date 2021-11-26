// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100067
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //Encore    每一幕开始光芒不高于1点时获得2点光芒
    public class PassiveAbility_100067 : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            if (owner.cardSlotDetail.PlayPoint > 1)
                return;
            owner.cardSlotDetail.RecoverPlayPoint(2);
        }
    }
}
