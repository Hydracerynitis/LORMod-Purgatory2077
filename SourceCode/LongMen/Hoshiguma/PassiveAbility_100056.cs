// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100056
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //战盾反击      被单方面攻击时以一颗斩击骰子(6-10)迎击 (非反击骰 每一幕至多触发1次)
    public class PassiveAbility_100056 : PassiveAbilityBase
    {
        public override void OnStartBattle()
        {
            BattleDiceCardModel playingCard = BattleDiceCardModel.CreatePlayingCard(ItemXmlDataList.instance.GetCardItem(new LorId("Purgatory2077", 121)));
            if (playingCard == null)
                return;
            owner.cardSlotDetail.keepCard.AddBehaviours(playingCard.XmlData, playingCard.CreateDiceCardBehaviorList());
        }
    }
}
