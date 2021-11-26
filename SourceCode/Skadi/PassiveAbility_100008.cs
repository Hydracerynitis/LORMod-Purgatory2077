// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100008
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //追加赏金  拼点失败时获得1点负面情感
    public class PassiveAbility_100008 : PassiveAbilityBase
    {
        public override void OnLoseParrying(BattleDiceBehavior behavior) => owner.battleCardResultLog?.AddEmotionCoin(EmotionCoinType.Negative, owner.emotionDetail.CreateEmotionCoin(EmotionCoinType.Negative));
    }
}
