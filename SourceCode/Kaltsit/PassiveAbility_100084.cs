// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100084
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;

namespace Ark
{
    //多重加固      反击骰拼点胜利时获得1颗3-6的招架骰子
    public class PassiveAbility_100084 : PassiveAbilityBase
    {
        public override void OnWinParrying(BattleDiceBehavior behavior)
        {
            if (behavior.Type != BehaviourType.Standby)
                return;
            BattleDiceCardModel playingCard = BattleDiceCardModel.CreatePlayingCard(ItemXmlDataList.instance.GetCardItem(new LorId("Purgatory2077", 114514)));
            if (playingCard == null)
                return;
            foreach (BattleDiceBehavior diceCardBehavior in playingCard.CreateDiceCardBehaviorList())
                owner.cardSlotDetail.keepCard.AddBehaviourForOnlyDefense(playingCard, diceCardBehavior);
        }
    }
}
