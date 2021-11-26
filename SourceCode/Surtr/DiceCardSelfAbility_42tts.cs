// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42tts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //情感等级不低于2时即可使用此书页 [使用时]所用核心书页为[史尔特尔]则恢复1点光芒
    public class DiceCardSelfAbility_42tts : DiceCardSelfAbilityBase
    {
        public static string Desc = "情感等级不低于2时即可使用此书页 [使用时]所用核心书页为[史尔特尔]则恢复1点光芒";
        public override bool OnChooseCard(BattleUnitModel owner) => owner.emotionDetail.EmotionLevel >= 2;
        public override void OnUseCard()
        {
            if (owner.Book.GetBookClassInfoId() != new LorId("Purgatory2077", 8) && owner.Book.GetBookClassInfoId() != new LorId("Purgatory2077", 10000007))
                return;
            owner.cardSlotDetail.RecoverPlayPointByCard(1);
        }
    }
}
