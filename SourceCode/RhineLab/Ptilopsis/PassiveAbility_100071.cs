// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100071
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll
using System.Collections.Generic;

namespace Ark
{
    //机械光环      每一幕开始时使手中随机2张书页获得"莱茵镀层"(不可转移)”
    public class PassiveAbility_100071 : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            List<BattleDiceCardModel> hand = owner.allyCardDetail.GetHand();
            for(int i=0; i<2; i++)
            {
                if (hand.Count <= 0)
                    return;
                BattleDiceCardModel card = RandomUtil.SelectOne<BattleDiceCardModel>(hand);
                card.AddBuf(new RhineShade());
                hand.Remove(card);
            }
        }
    }
}
