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
using UnityEngine;
using UnityEngine.UI;

namespace Ark
{
    public class Harmony_Patch: ModInitializer
    {
        public static string AssemblyPath;
        public static Dictionary<UnitBattleDataModel, bool> p_100089 = new Dictionary<UnitBattleDataModel, bool>();
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
            if (true)
            {
                ___colorFrame = new Color(1f, 1f, 1f, 1f);
                ___colorLineardodge = new Color(1f, 1f, 1f, 0.0f);
                ___colorLineardodge_deactive = ___colorLineardodge;
                __instance.img_Frames[0].sprite = BaseMod.Harmony_Patch.ArtWorks["Ark_LeftPage_RHINELABBase"];
                __instance.img_Frames[1].sprite = BaseMod.Harmony_Patch.ArtWorks["Ark_DiceCard_RHINELABbuf"];
                __instance.img_Frames[2].sprite = BaseMod.Harmony_Patch.ArtWorks["Ark_DiceCard_RHINELABbuf"];
                __instance.img_Frames[3].sprite = BaseMod.Harmony_Patch.ArtWorks["Ark_DiceCard_RHINELABbuf"];
                Image imgFrame = __instance.img_Frames[4];
                imgFrame.sprite = BaseMod.Harmony_Patch.ArtWorks["Ark_RightPage_RHINELABBase"];
                __instance.GetType().GetMethod("SetFrameColor", AccessTools.all).Invoke(__instance, new object[]{ ___colorFrame });
                __instance.GetType().GetMethod("SetLinearDodgeColor", AccessTools.all, null, new Type[]{typeof (Color) }, null).Invoke(__instance, new object[] { ___colorLineardodge });
            }
        }
    }
}
