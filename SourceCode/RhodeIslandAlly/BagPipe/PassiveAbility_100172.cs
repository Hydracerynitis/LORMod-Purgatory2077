// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100069
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll
using LOR_DiceSystem;
namespace Ark
{
    //维多利亚的文学  当有一名友方单位拼点失败时使其获得2点正面情感硬币(每一幕至多触发2次)
    public class PassiveAbility_100172 : PassiveAbilityBase
    {
        public int TriggerCount = 2;
        public override void OnRoundStart()
        {
            TriggerCount = 2;
        }
        public void OnAllyLoseParry(BattleUnitModel ally)
        {
            if (TriggerCount > 0)
            {
                TriggerCount--;
                ally.emotionDetail.CreateEmotionCoin(EmotionCoinType.Positive, 2);
            }
        }
    }
}
