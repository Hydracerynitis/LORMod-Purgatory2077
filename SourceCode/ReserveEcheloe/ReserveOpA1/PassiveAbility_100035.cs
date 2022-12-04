// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100035
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;

namespace Ark
{
    //电锯派对      以斩击骰子命中目标时立即施加1层“流血” 以穿刺骰子命中目标时立即施加2层“流血”<
    public class PassiveAbility_100035 : PassiveAbilityBase
    {
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            if (behavior.Detail == BehaviourDetail.Slash)
            {
                owner.ShowPassiveTypo(this);
                behavior.card.target?.bufListDetail?.AddKeywordBufThisRoundByEtc(KeywordBuf.Bleeding, 1, owner);
            }
            else if (behavior.Detail == BehaviourDetail.Penetrate)
            {
                owner.ShowPassiveTypo(this);
                behavior.card.target?.bufListDetail?.AddKeywordBufThisRoundByEtc(KeywordBuf.Bleeding, 2, owner);
            }
        }
    }
}
