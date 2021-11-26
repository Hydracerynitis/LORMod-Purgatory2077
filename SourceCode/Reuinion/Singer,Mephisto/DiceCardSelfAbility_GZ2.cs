// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;
using LOR_DiceSystem;

namespace Ark
{
    //[拼点开始] 下一幕将本书页所有骰子加入反击池
    public class DiceCardSelfAbility_GZ2 :DiceCardSelfAbilityBase 
    {
        public static string Desc = "[拼点开始] 下一幕将本书页所有骰子加入反击池";
        public override void OnStartParrying() => owner.bufListDetail.AddBuf(new CounterDice(card.card.GetID()));
        public class CounterDice: BattleUnitBuf
        {
            private LorId Cardid;
            public CounterDice(LorId id)
            {
                Cardid = id;
            }
            public override void OnDrawCard()
            {
                base.OnRoundStart();
                DiceCardXmlInfo cardItem = ItemXmlDataList.instance.GetCardItem(Cardid);
                List<BattleDiceBehavior> behaviourList = new List<BattleDiceBehavior>();
                int num = 0;
                foreach (DiceBehaviour diceBehaviour2 in cardItem.DiceBehaviourList)
                {
                    BattleDiceBehavior battleDiceBehavior = new BattleDiceBehavior();
                    battleDiceBehavior.behaviourInCard = diceBehaviour2.Copy();
                    battleDiceBehavior.SetIndex(num++);
                    behaviourList.Add(battleDiceBehavior);
                }
                this._owner.cardSlotDetail.keepCard.AddBehaviours(cardItem, behaviourList);
                Destroy();
            }
        }
    }
}
