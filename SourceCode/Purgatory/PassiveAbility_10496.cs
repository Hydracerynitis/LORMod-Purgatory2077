// Decompiled with JetBrains decompiler
// Type: Purgatory.PassiveAbility_10496
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //炎狱    情感到达四级时获得一张特殊书页并移除此被动
    public class PassiveAbility_10496 : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            if (owner.emotionDetail.EmotionLevel < 4)
                return;
            owner.allyCardDetail.AddTempCard(new LorId("Purgatory2077", 10));
            owner.passiveDetail.DestroyPassive(this);
        }
    }
}
