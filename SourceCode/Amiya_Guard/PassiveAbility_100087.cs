// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100087
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //情绪吸收/奇美拉      获得负面情感硬币时对自身造成4点混乱伤害 /本幕结束拥有5层忍耐时下一幕获得0费的清算书页
    public class PassiveAbility_100087 : PassiveAbilityBase
    {
        public override void OnRoundEnd()
        {   
            if (owner.bufListDetail.GetKewordBufStack(KeywordBuf.Endurance) < 5)
                return;
            owner.allyCardDetail.AddNewCard(new LorId("Purgatory2077", 111));
        }
    }
}
