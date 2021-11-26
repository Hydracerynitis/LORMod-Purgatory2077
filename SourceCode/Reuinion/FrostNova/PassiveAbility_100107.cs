// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100107
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;

namespace Ark
{
    //冰环        自身免疫“束缚”且使用远程书页进行拼点时下一幕中对目标施加1层“束缚”
    public class PassiveAbility_100107 : PassiveAbilityBase
    {
        public override bool IsImmune(KeywordBuf buf) => buf == KeywordBuf.Binding;
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (behavior.TargetDice == null || behavior.card.card.GetSpec().Ranged != CardRange.Far)
                return;
            owner.battleCardResultLog?.SetPassiveAbility(this);
            behavior.TargetDice.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Binding, 1);
        }
    }
}
