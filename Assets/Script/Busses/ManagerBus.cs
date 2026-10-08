using Assets.Script.AntScr;
using Assets.Script.FoodRelatedScr;
using Assets.Script.StupidDataStoreges;
using Assets.Script.StupidDataStoreges.Interfaces;
using Rubic1.Script.Shared.Sets.Interfaces;
using UnityEngine;

public static class ManagerBus
{
    private static IItemHolder<AntStruct> antHolder = new StupidAntsHolder();
    private static IItemHolder<FoodStruct> foodHolder = new StupidFoodHolder();

    public static IItemHolder<AntStruct> AntHolder { get => antHolder; set => antHolder = value; }
    public static IItemHolder<FoodStruct> FoodHolder { get => foodHolder; set => foodHolder = value; }
}
