// Decompiled with JetBrains decompiler
// Type: Ark.Harmony_Patch
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using HarmonyLib;
using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Ark
{
    public class Harmony_Patch: ModInitializer
    {
        public static string AssemblyPath;
        public static Dictionary<string, Sprite> CardUI = new Dictionary<string, Sprite>();
        public static Dictionary<UnitBattleDataModel, int> WarpUseHistory = new Dictionary<UnitBattleDataModel, int>();
        public static bool HasMethod(Type type, string methodName)
        {
            foreach (MemberInfo method in type.GetMethods())
            {
                if (method.Name == methodName)
                    return true;
            }
            return false;
        }
        public override void OnInitializeMod()
        {
            try
            {
                string assemblyPath = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
                AssemblyPath = assemblyPath.Substring(0, assemblyPath.Length - 11);
                Harmony harmony = new Harmony("Ark");
                MethodInfo method1 = typeof(Harmony_Patch).GetMethod("BattlePlayingCardSlotDetail_SetOnRecoverPlayPoint_Post");
                harmony.Patch(typeof(BattlePlayingCardSlotDetail).GetMethod("RecoverPlayPointByCard", AccessTools.all), postfix: new HarmonyMethod(method1));
                MethodInfo method2 = typeof(Harmony_Patch).GetMethod("BattleUnitBuf_warpCharge_UseStack_Post");
                harmony.Patch(typeof(BattleUnitBuf_warpCharge).GetMethod("UseStack", AccessTools.all), postfix: new HarmonyMethod(method2));
                MethodInfo method3 = typeof(Harmony_Patch).GetMethod("BattleUnitEmotionDetail_CreateEmotionCoinAfter");
                harmony.Patch(typeof(BattleUnitEmotionDetail).GetMethod("CreateEmotionCoin", AccessTools.all), postfix: new HarmonyMethod(method3));
                MethodInfo method6 = typeof(Harmony_Patch).GetMethod("StageLibraryFloorModel_InitUnitList");
                harmony.Patch(typeof(StageLibraryFloorModel).GetMethod("InitUnitList", AccessTools.all), prefix: new HarmonyMethod(method6));
                MethodInfo method7 = typeof(Harmony_Patch).GetMethod("BattleDiceCardUI_SetCard");
                harmony.Patch(typeof(BattleDiceCardUI).GetMethod("SetCard", AccessTools.all), postfix: new HarmonyMethod(method7));
                MethodInfo method8 = typeof(Harmony_Patch).GetMethod("BattleDiceCardModel_GetBehaviourList");
                harmony.Patch(typeof(BattleDiceCardModel).GetMethod("GetBehaviourList",AccessTools.all), postfix: new HarmonyMethod(method8));
                MethodInfo method9 = typeof(Harmony_Patch).GetMethod("BattleDiceCardModel_CreateDiceCardBehaviorList");
                harmony.Patch(typeof(BattleDiceCardModel).GetMethod("CreateDiceCardBehaviorList", AccessTools.all), postfix: new HarmonyMethod(method9));
                MethodInfo method10 = typeof(Harmony_Patch).GetMethod("BattleUnitModel_CheckCardAvailable");
                harmony.Patch(typeof(BattleUnitModel).GetMethod("CheckCardAvailable", AccessTools.all), postfix: new HarmonyMethod(method10));
                harmony.Patch(typeof(BattleUnitModel).GetMethod("CheckCardAvailableForPlayer", AccessTools.all), postfix: new HarmonyMethod(method10));
                MethodInfo method11 = typeof(Harmony_Patch).GetMethod("BattleUnitModel_OnLoseParrying");
                harmony.Patch(typeof(BattleUnitModel).GetMethod("OnLoseParrying", AccessTools.all), postfix: new HarmonyMethod(method11));
                MethodInfo method12 = typeof(Harmony_Patch).GetMethod("BattleUnitModel_OnWinParrying");
                harmony.Patch(typeof(BattleUnitModel).GetMethod("OnWinParrying", AccessTools.all), postfix: new HarmonyMethod(method12));
            }
            catch (Exception ex)
            {
                File.WriteAllText(AssemblyPath + "/testHPError.txt", ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }
        public static void BattlePlayingCardSlotDetail_SetOnRecoverPlayPoint_Post(BattlePlayingCardSlotDetail __instance, BattleUnitModel ____self)
        {
            foreach (PassiveAbilityBase passive in ____self.passiveDetail.PassiveList)
            {
                if(HasMethod(passive.GetType(), "OnRecoverPlayPoint"))
                {
                    try
                    {
                        passive.GetType().GetMethod("OnRecoverPlayPoint").Invoke(passive, (object[])null);
                    }
                    catch (Exception ex)
                    {
                        File.AppendAllText(AssemblyPath + "/SORPPError.txt", ex.Message +"\n" + ex.StackTrace+"\n\n");
                    }
                }
            }
        }
        public static void BattleUnitBuf_warpCharge_UseStack_Post(int v, bool isCard, ref bool __result, BattleUnitBuf_warpCharge __instance, BattleUnitModel ____owner)
        {
            if (!(__result && isCard))
                return;
            if (WarpUseHistory.ContainsKey(____owner.UnitData))
                WarpUseHistory[____owner.UnitData] += v;
            else
                WarpUseHistory.Add(____owner.UnitData, v);
            foreach (PassiveAbilityBase passive in ____owner.passiveDetail.PassiveList)
            {
                if (HasMethod(passive.GetType(), "OnUseChargeNum"))
                {
                    try
                    {
                        passive.GetType().GetMethod("OnUseChargeNum").Invoke(passive, new object[1] { v });
                    }
                    catch (Exception ex)
                    {
                        File.AppendAllText(AssemblyPath + "/OUCNError.txt", ex.Message + "\n" + ex.StackTrace + "\n\n");
                    }
                }
            }
        }
        public static void BattleUnitEmotionDetail_CreateEmotionCoinAfter(BattleUnitEmotionDetail __instance, BattleUnitModel ____self, int __result, EmotionCoinType coinType, int count)
        {
            if (!____self.passiveDetail.HasPassive<PassiveAbility_100087>() || __result <= 0 || coinType != EmotionCoinType.Negative)
                return;
            ____self.breakDetail.TakeBreakDamage(4);
        }
        public static UnitBattleDataModel AddCustomFixUnitModel(StageLibraryFloorModel __instance, StageModel stage, LibraryFloorModel floor, int EquipID)
        {
            LorId lorId = new LorId("Purgatory2077", EquipID);
            UnitDataModel data = new UnitDataModel(lorId, floor.Sephirah, true);
            data.SetTemporaryPlayerUnitByBook(lorId);
            data.SetCustomName(data.bookItem.Name);
            data.CreateDeckByDeckInfo();
            data.forceItemChangeLock = true;
            UnitBattleDataModel unitBattleDataModel = new UnitBattleDataModel(stage, data);
            unitBattleDataModel.Init();
            return unitBattleDataModel;
        }
        public static void UnitModelList(StageLibraryFloorModel __instance, StageModel stage, LibraryFloorModel floor, List<int> battleUnits)
        {
            List<UnitBattleDataModel> unitBattleDataModelList = new List<UnitBattleDataModel>();
            foreach (int battleUnit in battleUnits)
                unitBattleDataModelList.Add(AddCustomFixUnitModel(__instance, stage, floor, battleUnit));
            Traverse.Create((object)__instance).Field("_unitList").SetValue((object)unitBattleDataModelList);
        }
        public static bool StageLibraryFloorModel_InitUnitList(StageLibraryFloorModel __instance,StageModel stage,  LibraryFloorModel floor)
        {
            if (stage.ClassInfo.id.packageId != "Purgatory2077")
                return true;
            switch (stage.ClassInfo.id.id)
            {
                case 3:
                    UnitModelList(__instance, stage, floor, new List<int>(){ 3, 4, 5, 6 });
                    return false;
                case 13:
                    UnitModelList(__instance, stage, floor, new List<int>() {3, 4, 5, 6 });
                    return false;
                case 17:
                    UnitModelList(__instance, stage, floor, new List<int>() { 103 });
                    return false;
                case 18:
                    UnitModelList(__instance, stage, floor, new List<int>() { 103, 104, 105});
                    return false;
                case 20:
                    UnitModelList(__instance, stage, floor, new List<int>() { 103, 104, 105 });
                    return false;
            }
            return true;
        }
        public static void BattleDiceCardUI_SetCard(BattleDiceCardUI __instance, ref Color ___colorFrame, BattleDiceCardModel cardModel, ref Color ___colorLineardodge, ref Color ___colorLineardodge_deactive, params BattleDiceCardUI.Option[] options)
        {
            if (__instance.CardModel == null)
                return;
            if (CardUI.Count <= 0)
            {
                CardUI.Add("LeftPage", __instance.img_Frames[0].sprite);
                CardUI.Add("DiceCard", __instance.img_Frames[1].sprite);
                CardUI.Add("RightPage", __instance.img_Frames[4].sprite);
            }
            if (cardModel.HasBuf<RhineShade>())
            {
                ___colorFrame = new Color(1f, 1f, 1f, 1f);
                ___colorLineardodge = new Color(1f, 1f, 1f, 0.0f);
                ___colorLineardodge_deactive = ___colorLineardodge;
                __instance.img_Frames[0].sprite = BaseMod.Harmony_Patch.ArtWorks["Ark_LeftPage_RHINELABBase"];
                __instance.img_Frames[1].sprite = BaseMod.Harmony_Patch.ArtWorks["Ark_DiceCard_RHINELABbuf"];
                __instance.img_Frames[2].sprite = BaseMod.Harmony_Patch.ArtWorks["Ark_DiceCard_RHINELABbuf"];
                __instance.img_Frames[3].sprite = BaseMod.Harmony_Patch.ArtWorks["Ark_DiceCard_RHINELABbuf"];
                __instance.img_Frames[4].sprite = BaseMod.Harmony_Patch.ArtWorks["Ark_RightPage_RHINELABBase"];
                __instance.GetType().GetMethod("SetFrameColor", AccessTools.all).Invoke(__instance, new object[]{ ___colorFrame });
                __instance.GetType().GetMethod("SetLinearDodgeColor", AccessTools.all, null, new Type[]{typeof (Color) }, null).Invoke(__instance, new object[] { ___colorLineardodge });
            }
            else if(CardUI.Count>0)
            {
                __instance.img_Frames[0].sprite = CardUI["LeftPage"];
                __instance.img_Frames[1].sprite = CardUI["DiceCard"];
                __instance.img_Frames[2].sprite = CardUI["DiceCard"];
                __instance.img_Frames[3].sprite = CardUI["DiceCard"];
                __instance.img_Frames[4].sprite = CardUI["RightPage"];
            }
            List<DiceBehaviour> newlist = cardModel.GetBehaviourList();
            bool isHide = options.Contains<BattleDiceCardUI.Option>(BattleDiceCardUI.Option.HideDiceAbilityInfo);
            for (int index = 0; index < newlist.Count; ++index)
            {
                __instance.ui_behaviourDescList[index].SetBehaviourInfo(newlist[index], cardModel.GetID(), newlist, isHide);
                __instance.ui_behaviourDescList[index].gameObject.SetActive(true);
                Sprite sprite = newlist[index].Type == BehaviourType.Standby ? UISpriteDataManager.instance.CardStandbyBehaviourDetailIcons[(int)newlist[index].Detail] : UISpriteDataManager.instance._cardBehaviourDetailIcons[(int)newlist[index].Detail];
                __instance.img_behaviourDetatilList[index].sprite = sprite;
                __instance.img_behaviourDetatilList[index].gameObject.SetActive(true);
            }
            for (int count = newlist.Count; count < __instance.ui_behaviourDescList.Count; ++count)
            {
                __instance.ui_behaviourDescList[count].gameObject.SetActive(false);
                __instance.img_behaviourDetatilList[count].gameObject.SetActive(false);
            }
        }
        public static void BattleDiceCardModel_GetBehaviourList(BattleDiceCardModel __instance,ref List<DiceBehaviour> __result)
        {
            if (__instance.HasBuf<RhineShade>())
            {
                List<DiceBehaviour> copiedList = new List<DiceBehaviour>();
                foreach(DiceBehaviour dice in __result)
                {
                    DiceBehaviour newDice = dice.Copy();
                    if (newDice.Type != BehaviourType.Atk)
                        newDice.Type = BehaviourType.Atk;
                    if (newDice.Detail == BehaviourDetail.Guard)
                    {
                        newDice.Detail = BehaviourDetail.Slash;
                        newDice.MotionDetail = MotionDetail.J;
                    }
                    if (newDice.Detail == BehaviourDetail.Evasion)
                    {
                        newDice.Detail = BehaviourDetail.Penetrate;
                        newDice.MotionDetail = MotionDetail.Z;
                    }
                    copiedList.Add(newDice);
                }
                __result = copiedList;
            }
        }
        public static void BattleDiceCardModel_CreateDiceCardBehaviorList(BattleDiceCardModel __instance, ref List<BattleDiceBehavior> __result)
        {
            if (__instance.HasBuf<RhineShade>())
            {
                List<BattleDiceBehavior> copiedList = new List<BattleDiceBehavior>();
                foreach (BattleDiceBehavior dice in __result)
                {
                    if (dice.behaviourInCard.Type != BehaviourType.Atk)
                        dice.behaviourInCard.Type = BehaviourType.Atk;
                    if (dice.behaviourInCard.Detail == BehaviourDetail.Guard)
                    {
                        dice.behaviourInCard.Detail = BehaviourDetail.Slash;
                        dice.behaviourInCard.MotionDetail = MotionDetail.J;
                    }
                        
                    if (dice.behaviourInCard.Detail == BehaviourDetail.Evasion)
                    {
                        dice.behaviourInCard.Detail = BehaviourDetail.Penetrate;
                        dice.behaviourInCard.MotionDetail = MotionDetail.Z;
                    }
                    copiedList.Add(dice);
                }
                __result = copiedList;
            }
        }
        public static void BattleUnitModel_CheckCardAvailable(BattleUnitModel __instance,BattleDiceCardModel card, ref bool __result)
        {
            if (card.CreateDiceCardSelfAbilityScript() is DiceCardSelfAbility_Silence3 silence3 && !card.HasBuf<RhineShade>())
                __result = false;
            else if (__instance.passiveDetail.PassiveList.Find(x => x is PassiveAbility_100090) is PassiveAbility_100090 passive100090 && card.GetSpec().Ranged == CardRange.Far)
                __result = passive100090.UseFar;
            else if (__instance.passiveDetail.PassiveList.Find(x => x is PassiveAbility_100115)!=null && card.GetSpec().Ranged == CardRange.Near)
                __result = false;
        }
        public static void BattleUnitModel_OnLoseParrying(BattleUnitModel __instance)
        {
            foreach(BattleUnitModel unit in BattleObjectManager.instance.GetAliveList(__instance.faction).FindAll(x => x!=__instance))
            {
                foreach (PassiveAbilityBase passive in unit.passiveDetail.PassiveList)
                {
                    if (HasMethod(passive.GetType(), "OnAllyLoseParry"))
                    {
                        try
                        {
                            passive.GetType().GetMethod("OnAllyLoseParry").Invoke(passive, new object[] { __instance });
                        }
                        catch (Exception ex)
                        {
                            File.AppendAllText(AssemblyPath + "/OALPError.txt", ex.Message + "\n" + ex.StackTrace + "\n\n");
                        }
                    }
                }
            }
        }
        public static void BattleUnitModel_OnWinParrying(BattleUnitModel __instance)
        {
            foreach (BattleUnitModel unit in BattleObjectManager.instance.GetAliveList(__instance.faction).FindAll(x => x != __instance))
            {
                foreach (PassiveAbilityBase passive in unit.passiveDetail.PassiveList)
                {
                    if (HasMethod(passive.GetType(), "OnAllyWinParry"))
                    {
                        try
                        {
                            passive.GetType().GetMethod("OnAllyWinParry").Invoke(passive, new object[] { __instance });
                        }
                        catch (Exception ex)
                        {
                            File.AppendAllText(AssemblyPath + "/OAWPError.txt", ex.Message + "\n" + ex.StackTrace + "\n\n");
                        }
                    }
                }
            }
        }
        public static bool CheckCondition(BattleDiceCardModel card, string Keyword)
        {
            if (card != null)
            {
                DiceCardXmlInfo xmlData = card.XmlData;
                if (xmlData == null)
                    return false;
                if (xmlData.Keywords.Contains(Keyword))
                    return true;
                List<string> abilityKeywords = Singleton<BattleCardAbilityDescXmlList>.Instance.GetAbilityKeywords(xmlData);
                for (int index = 0; index < abilityKeywords.Count; ++index)
                {
                    if (abilityKeywords[index] == Keyword)
                        return true;
                }
                foreach (DiceBehaviour behaviour in card.GetBehaviourList())
                {
                    List<string> keywordsByScript = Singleton<BattleCardAbilityDescXmlList>.Instance.GetAbilityKeywords_byScript(behaviour.Script);
                    for (int index = 0; index < keywordsByScript.Count; ++index)
                    {
                        if (keywordsByScript[index] == Keyword)
                            return true;
                    }
                }
            }
            return false;
        }
    }
}
