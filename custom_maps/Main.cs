﻿using MelonLoader;
using Harmony;
using NKHook6.Api;
using Assets.Scripts.Unity.UI_New.InGame.Races;
using Assets.Scripts.Simulation.Towers.Weapons;
using NKHook6;
using Assets.Scripts.Simulation;
using Assets.Scripts.Unity.UI_New.InGame;
using NKHook6.Api.Extensions;
using Assets.Scripts.Unity.UI_New.Main;
using NKHook6.Api.Events;
using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Models.Towers;

using Assets.Scripts.Unity;



using static NKHook6.Api.Events._Towers.TowerEvents;
using Assets.Scripts.Simulation.Towers;

using static NKHook6.Api.Events._Weapons.WeaponEvents;
using Assets.Scripts.Utils;

using static NKHook6.Api.Events._TimeManager.TimeManagerEvents;
//using Il2CppSystem.Collections;
using NKHook6.Api.Events._Bloons;
using NKHook6.Api.Events._Weapons;
using Assets.Scripts.Unity.UI_New.Popups;
using System.Reflection;
using Assets.Scripts.Models;
using System.Collections.Generic;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Assets.Scripts.Models.GenericBehaviors;
using System;
using System.Linq;
using Assets.Scripts.Models.ServerEvents;
using Assets.Scripts.Data.Cosmetics.Pets;
using Assets.Main.Scenes;
using UnhollowerBaseLib;

using Assets.Scripts.Models.Rounds;
using Assets.Scripts.Models.Store;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Models.Map;
using UnityEngine;
using System.IO;
using UnhollowerRuntimeLib;
using Assets.Scripts.Unity.Map;
using Assets.Scripts.Models.Map.Spawners;
using Assets.Scripts.Unity.UI_New;
using Assets.Scripts.Data.MapSets;
using Assets.Scripts.Unity.Player;
using Assets.Scripts.Unity.UI_New.Main.ModeSelect;
using Assets.Scripts.Unity.UI_New.Main.MapSelect;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using NKHook6.Api.Towers;

namespace custom_maps
{
    public class Main : MelonMod
    {


        public static System.Random r = new System.Random();
        public static bool writingPoint = false;
        public static bool writingArea = false;
        public static int index = 0;
        public static int type = 0;
        public static bool mapeditor = false;
        //public static GameObject cube;
        public static string lastMap = "";
        public static string[] listOfMaps = new string[]
{
                    "tar pits",
                    "bloontoniumcore",
                    "toxic waste",
                    "slons",
                    "btd6irl",
                    "truetrueexpert",
                    "epiloge",
                    "brickout",
                    "grid",
                    "lyne",
                    "heartgate",
};



        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
            EventRegistry.instance.listen(typeof(Main));
            NKHook6.Logger.Log("custom_maps loaded");

        }


        [HarmonyPatch(typeof(UI), "Awake")]
        public class Awake_Patch
        {
            // Token: 0x060004FA RID: 1274 RVA: 0x0001940C File Offset: 0x0001760C
            [HarmonyPostfix]
            public static void Postfix()
            {
                SpriteRegister.RegisterSpriteFromURL(@"Mods\Maps\tar pits.png", "https://i.imgur.com/gMjFiHW.png", default, out string guid1);
                SpriteRegister.RegisterSpriteFromURL(@"Mods\Maps\bloontoniumcore.png", "https://i.imgur.com/kOUp2zx.png", default, out string guid2);
                SpriteRegister.RegisterSpriteFromURL(@"Mods\Maps\toxic waste.png", "https://i.imgur.com/bCe6jMr.png", default, out string guid3);
                SpriteRegister.RegisterSpriteFromURL(@"Mods\Maps\slons.png", "https://i.imgur.com/RKiVthA.png", default, out string guid4);
                SpriteRegister.RegisterSpriteFromURL(@"Mods\Maps\btd6irl.png", "https://i.imgur.com/dBHHhpK.png", default, out string guid5);
                SpriteRegister.RegisterSpriteFromURL(@"Mods\Maps\truetrueexpert.png", "https://i.imgur.com/e3qETCm.png", default, out string guid6);
                SpriteRegister.RegisterSpriteFromURL(@"Mods\Maps\epiloge.png", "https://i.imgur.com/atZk4U9.png", default, out string guid7);
                SpriteRegister.RegisterSpriteFromURL(@"Mods\Maps\brickout.png", "https://i.imgur.com/9Rp7eee.png", default, out string guid8);
                SpriteRegister.RegisterSpriteFromURL(@"Mods\Maps\grid.png", "https://i.imgur.com/EHrWM6u.png", default, out string guid9);
                SpriteRegister.RegisterSpriteFromURL(@"Mods\Maps\lyne.png", "https://i.imgur.com/ZlL3DqE.png", default, out string guid10);
                SpriteRegister.RegisterSpriteFromURL(@"Mods\Maps\heartgate.png", "https://i.imgur.com/94ZDQzd.png", default, out string guid11);
                UI.instance.mapSet.Maps.items = UI.instance.mapSet.Maps.items.Add(new MapDetails
                {
                    id = "tar pits",
                    isAvailable = true,
                    difficulty = MapDifficulty.Expert,
                    coopMapDivisionType = CoopDivision.FREE_FOR_ALL,
                    unlockDifficulty = MapDifficulty.Beginner,
                    mapMusic = "MusicDarkA",
                    mapSprite = new SpriteReference
                    {
                        guidRef = guid1
                    }
                }).ToArray<MapDetails>();
                UI.instance.mapSet.Maps.items = UI.instance.mapSet.Maps.items.Add(new MapDetails
                {
                    id = "bloontoniumcore",
                    isAvailable = true,
                    difficulty = MapDifficulty.Expert,
                    coopMapDivisionType = CoopDivision.FREE_FOR_ALL,
                    unlockDifficulty = MapDifficulty.Beginner,
                    mapMusic = "MusicDarkA",
                    mapSprite = new SpriteReference
                    {
                        guidRef = guid2
                    }
                }).ToArray<MapDetails>();
                UI.instance.mapSet.Maps.items = UI.instance.mapSet.Maps.items.Add(new MapDetails
                {
                    id = "toxic waste",
                    isAvailable = true,
                    difficulty = MapDifficulty.Expert,
                    coopMapDivisionType = CoopDivision.FREE_FOR_ALL,
                    unlockDifficulty = MapDifficulty.Beginner,
                    mapMusic = "MusicDarkA",
                    mapSprite = new SpriteReference
                    {
                        guidRef = guid3
                    }
                }).ToArray<MapDetails>();
                UI.instance.mapSet.Maps.items = UI.instance.mapSet.Maps.items.Add(new MapDetails
                {
                    id = "slons",
                    isAvailable = true,
                    difficulty = MapDifficulty.Expert,
                    coopMapDivisionType = CoopDivision.FREE_FOR_ALL,
                    unlockDifficulty = MapDifficulty.Beginner,
                    mapMusic = "MusicDarkA",
                    mapSprite = new SpriteReference
                    {
                        guidRef = guid4
                    },
                }).ToArray<MapDetails>();
                UI.instance.mapSet.Maps.items = UI.instance.mapSet.Maps.items.Add(new MapDetails
                {
                    id = "btd6irl",
                    isAvailable = true,
                    difficulty = MapDifficulty.Expert,
                    coopMapDivisionType = CoopDivision.FREE_FOR_ALL,
                    unlockDifficulty = MapDifficulty.Beginner,
                    mapMusic = "MusicDarkA",
                    mapSprite = new SpriteReference
                    {
                        guidRef = guid5
                    },
                }).ToArray<MapDetails>();
                UI.instance.mapSet.Maps.items = UI.instance.mapSet.Maps.items.Add(new MapDetails
                {
                    id = "truetrueexpert",
                    isAvailable = true,
                    difficulty = MapDifficulty.Expert,
                    coopMapDivisionType = CoopDivision.FREE_FOR_ALL,
                    unlockDifficulty = MapDifficulty.Beginner,
                    mapMusic = "MusicDarkA",
                    mapSprite = new SpriteReference
                    {
                        guidRef = guid6
                    },
                }).ToArray<MapDetails>();
                UI.instance.mapSet.Maps.items = UI.instance.mapSet.Maps.items.Add(new MapDetails
                {
                    id = "epiloge",
                    isAvailable = true,
                    difficulty = MapDifficulty.Expert,
                    coopMapDivisionType = CoopDivision.FREE_FOR_ALL,
                    unlockDifficulty = MapDifficulty.Beginner,
                    mapMusic = "MusicDarkA",
                    mapSprite = new SpriteReference
                    {
                        guidRef = guid7
                    },
                }).ToArray<MapDetails>();
                UI.instance.mapSet.Maps.items = UI.instance.mapSet.Maps.items.Add(new MapDetails
                {
                    id = "brickout",
                    isAvailable = true,
                    difficulty = MapDifficulty.Intermediate,
                    coopMapDivisionType = CoopDivision.FREE_FOR_ALL,
                    unlockDifficulty = MapDifficulty.Beginner,
                    mapMusic = "MusicDarkA",
                    mapSprite = new SpriteReference
                    {
                        guidRef = guid8
                    },
                }).ToArray<MapDetails>();
                UI.instance.mapSet.Maps.items = UI.instance.mapSet.Maps.items.Add(new MapDetails
                {
                    id = "grid",
                    isAvailable = true,
                    difficulty = MapDifficulty.Expert,
                    coopMapDivisionType = CoopDivision.FREE_FOR_ALL,
                    unlockDifficulty = MapDifficulty.Beginner,
                    mapMusic = "MusicDarkA",
                    mapSprite = new SpriteReference
                    {
                        guidRef = guid9
                    },
                }).ToArray<MapDetails>();
                UI.instance.mapSet.Maps.items = UI.instance.mapSet.Maps.items.Add(new MapDetails
                {
                    id = "lyne",
                    isAvailable = true,
                    difficulty = MapDifficulty.Expert,
                    coopMapDivisionType = CoopDivision.FREE_FOR_ALL,
                    unlockDifficulty = MapDifficulty.Beginner,
                    mapMusic = "MusicDarkA",
                    mapSprite = new SpriteReference
                    {
                        guidRef = guid10
                    },
                    isDebug = true
                }).ToArray<MapDetails>();
                UI.instance.mapSet.Maps.items = UI.instance.mapSet.Maps.items.Add(new MapDetails
                {
                    id = "heartgate",
                    isAvailable = true,
                    difficulty = MapDifficulty.Expert,
                    coopMapDivisionType = CoopDivision.FREE_FOR_ALL,
                    unlockDifficulty = MapDifficulty.Beginner,
                    mapMusic = "MusicDarkA",
                    mapSprite = new SpriteReference
                    {
                        guidRef = guid11
                    },
                    isDebug = true
                }).ToArray<MapDetails>();

                

            }
        }


        [HarmonyPatch(typeof(MapButton), "ShowMedal")]
        public class ShowMedal_Patch
        {
            [HarmonyPrefix]
            public static bool Prefix(MapButton __instance, Btd6Player player, Animator medalAnimator, string mapId, string difficulty, string mode)
            {
                //Console.WriteLine("ShowMedal");
                //Console.WriteLine(player == null);
                //Console.WriteLine(player.debugUnlockAllModes = true);
                player.debugUnlockAllModes = true;
                //player.CompleteMap("lyne");
                //player.CompleteMap("heartgate");
                //player.MarkSeenMapUnlock("lyne");
                //player.MarkSeenMapUnlock("lyne");
                //player.MarkSeenMapUnlock("heartgate");
                foreach (var item in UI.instance.mapSet.Maps.items)
                {
                    player.MarkSeenMapUnlock(item.id);
                }
                //player.kno
                //Console.WriteLine(mapId);
                //Console.WriteLine(difficulty);
                //Console.WriteLine(mode);
                return true;
            }
        }



        [HarmonyPatch(typeof(MapLoader), "Load")]
        public class MapLoad_Patch
        {
            [HarmonyPrefix]
            public static bool Prefix(MapLoader __instance, ref string map, Il2CppSystem.Action<MapModel> loadedCallback)
            {
                lastMap = map;
                //if (map == "tar pits") map = "#ouch";
                //if (map == "bloontoniumcore") map = "#ouch";
                //if (map == "toxic waste") map = "#ouch";
                //if (map == "slons") map = "#ouch";
                //if (map == "btd6irl") map = "#ouch";
                //if (map == "truetrueexpert") map = "#ouch";
                if (listOfMaps.Contains(lastMap))
                    map = "MuddyPuddles";

                return true;
            }
        }


        public override void OnUpdate()
        {
            base.OnUpdate();

            bool inAGame = InGame.instance != null && InGame.instance.bridge != null;
            if (inAGame)
            {
                if (Input.GetKeyDown(KeyCode.Alpha4))
                {

                }


            }
        }



        [HarmonyPatch(typeof(UnityToSimulation), "InitMap")]
        public class InitMap_Patch
        {

            [HarmonyPrefix]
            public static bool Prefix(UnityToSimulation __instance, ref MapModel map)
            {

                foreach (var ar in map.areas)
                {
                    //Console.WriteLine(ar.height);
                }

                //GameObject.Destroy(GameObject.Find("Cube"));

                if (!listOfMaps.Contains(lastMap)) return true;


                //cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //cube.transform.position = new Vector3(0, -0.5001f, 0);
                //cube.transform.localScale = new Vector3(-300, 1f, -235);

                Texture2D tex = null;
                string filePath = @"Mods\Maps\" + lastMap + ".png";
                byte[] fileData = File.ReadAllBytes(filePath);
                fileData = Resize(fileData, 1652, 1064);//, 699, 519);
                                                        //if (File.Exists(filePath))
                                                        //{
                                                        //    fileData = File.ReadAllBytes(filePath);
                                                        //    tex = new Texture2D(2, 2);
                                                        //    ImageConversion.LoadImage(tex, fileData);
                                                        //}

                if (File.Exists(filePath))
                {
                    //fileData = File.ReadAllBytes(filePath);
                    //float divx = 2;
                    //float divy = 1.21f;
                    //int marginx = 190;
                    //int marginy = 430;
                    float divx = 2;
                    float divy = 1.21f;
                    int marginx = 450;
                    int marginy = 890;

                    Bitmap old = new Bitmap(Image.FromStream(new MemoryStream(fileData)));//new Bitmap(filePath);
                    Bitmap newImage = new Bitmap(old.Width + marginx, old.Height + marginy);
                    //var paddingColor = new System.Drawing.Color(255, 255, 255);
                    using (var graphics = System.Drawing.Graphics.FromImage(newImage))
                    {
                        //graphics.Clear(paddingColor);
                        int x = (int)((newImage.Width - old.Width) / divx);
                        int y = (int)((newImage.Height - old.Height) / divy);
                        graphics.DrawImage(old, x, y);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            fileData = ms.ToArray();
                        }
                    }


                    tex = new Texture2D(2, 2);
                    ImageConversion.LoadImage(tex, fileData);
                }
                var ob2 = GameObject.Find("MuddyPuddlesTerrain");
                ob2.GetComponent<Renderer>().material.mainTexture = tex;
                //ob2.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, 0);
                //ob2.GetComponent<Renderer>().material.mainTextureScale = new Vector2(1, 1);
                foreach (var ob in UnityEngine.Object.FindObjectsOfType<GameObject>())
                {
                    if (ob.name.Contains("Candy") || ob.name.Contains("Gift") || ob.name.Contains("Snow") || ob.name.Contains("Ripples") || ob.name.Contains("Grass") || ob.name.Contains("Christmas") || ob.name.Contains("WhiteFlower") || ob.name.Contains("Tree") || ob.name.Contains("Rock") || ob.name.Contains("Shadow") || ob.name.Contains("WaterSplashes"))// || ob.name.Contains("Body")   || ob.name.Contains("Ouch") || ob.name.Contains("Statue")|| ob.name.Contains("Chute")  || ob.name.Contains("Jump") || ob.name.Contains("Timer") || ob.name.Contains("Wheel") || ob.name.Contains("Body") || ob.name.Contains("Axle") || ob.name.Contains("Leg") || ob.name.Contains("Clock") ||
                        if (ob.name != "MuddyPuddlesTerrain")
                            ob.transform.position = new Vector3(1000, 1000, 1000);
                    //if (ob.name.Contains("Tree"))
                    //    GameObject.Destroy(ob);
                }


                //foreach (var ob in UnityEngine.Object.FindObjectsOfType<GameObject>())
                //{
                //    if (ob.GetComponent<Renderer>())
                //    {
                //        if (ob.name.Contains("Candy") || ob.name.Contains("Statue") || ob.name.Contains("Body") || ob.name.Contains("Chute") || ob.name.Contains("Gift") || ob.name.Contains("Snow") || ob.name.Contains("Jump") || ob.name.Contains("Timer") || ob.name.Contains("Ripples") || ob.name.Contains("Clock") || ob.name.Contains("Grass") || ob.name.Contains("Christmas") || ob.name.Contains("WhiteFlower") || ob.name.Contains("Tree") || ob.name.Contains("Rock") || ob.name.Contains("Wheel") || ob.name.Contains("Body") || ob.name.Contains("Axle") || ob.name.Contains("Shadow") || ob.name.Contains("Leg") || ob.name.Contains("WaterSplashes") || ob.name.Contains("Ouch"))
                //            ob.transform.position = new Vector3(1000, 1000, 1000);
                //        if (ob.name.Contains("Statue"))
                //            GameObject.Destroy(ob);
                //    }
                //}
                //cube.GetComponent<Renderer>().material = GameObject.Find("OuchTerrainGrateless").GetComponent<Renderer>().material;
                //cube.GetComponent<Renderer>().material.mainTexture = tex;
                if (lastMap == "tar pits")
                {
                    map.areas = TarPitsData.areas();
                    map.spawner = TarPitsData.spawner();
                    map.paths = TarPitsData.pathmodel();
                }
                if (lastMap == "bloontoniumcore")
                {
                    map.areas = BloontoniumcoreData.areas();
                    map.spawner = BloontoniumcoreData.spawner();
                    map.paths = BloontoniumcoreData.pathmodel();
                }
                if (lastMap == "toxic waste")
                {
                    map.areas = ToxicWasteData.areas();
                    map.spawner = ToxicWasteData.spawner();
                    map.paths = ToxicWasteData.pathmodel();
                }
                if (lastMap == "slons")
                {
                    map.areas = SlonsData.areas();
                    map.spawner = SlonsData.spawner();
                    map.paths = SlonsData.pathmodel();
                }
                if (lastMap == "btd6irl")
                {
                    map.areas = btd6irlData.areas();
                    map.spawner = btd6irlData.spawner();
                    map.paths = btd6irlData.pathmodel();
                }
                if (lastMap == "truetrueexpert")
                {
                    map.areas = TrueTrueExpertData.areas();
                    map.spawner = TrueTrueExpertData.spawner();
                    map.paths = TrueTrueExpertData.pathmodel();
                }
                if (lastMap == "epiloge")
                {
                    map.areas = EpilogeData.areas();
                    map.spawner = EpilogeData.spawner();
                    map.paths = EpilogeData.pathmodel();
                }
                if (lastMap == "brickout")
                {
                    map.areas = BrickoutData.areas();
                    map.spawner = BrickoutData.spawner();
                    map.paths = BrickoutData.pathmodel();
                }
                if (lastMap == "grid")
                {
                    map.areas = GridData.areas();
                    map.spawner = GridData.spawner();
                    map.paths = GridData.pathmodel();
                }
                if (lastMap == "lyne")
                {
                    map.areas = LyneData.areas();
                    map.spawner = LyneData.spawner();
                    map.paths = LyneData.pathmodel();
                }
                if (lastMap == "heartgate")
                {
                    map.areas = HeartGateData.areas();
                    map.spawner = HeartGateData.spawner();
                    map.paths = HeartGateData.pathmodel();
                }
                if (GameObject.Find("Rain"))
                    GameObject.Find("Rain").active = false;
                return true;
            }

        }



        public static byte[] Resize(byte[] data, int width, int height)
        {
            using (var stream = new MemoryStream(data))
            {
                var image = Image.FromStream(stream);

                //var height = (width * image.Height) / image.Width;
                //var thumbnail = image.GetThumbnailImage(width, height, null, IntPtr.Zero);
                Bitmap b = ResizeImage(image, width, height);//new Bitmap(image, 1652, 1064);
                //b.Save("test.png", ImageFormat.Png);

                using (var thumbnailStream = new MemoryStream())
                {
                    b.Save(thumbnailStream, ImageFormat.Png);
                    return thumbnailStream.ToArray();
                }
            }
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = System.Drawing.Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }


















        //used only for epiloge
        [HarmonyPatch(typeof(TowerModel), "IsTowerPlaceableInAreaType")]
        public class IsTowerPlaceableInAreaType_Patch
        {

            [HarmonyPrefix]
            static bool Prefix(ref bool __result, AreaType areaType)
            {
                if (lastMap != "epiloge") return true;
                __result = true;
                return false;
            }
        }



        [HarmonyPatch(typeof(Tower), "Initialise")]
        public class TowerInitialise_Patch
        {

            [HarmonyPrefix]
            public static bool Prefix(Tower __instance, ref Model modelToUse)
            {
                if (lastMap != "epiloge") return true;
                var wep = modelToUse.Cast<TowerModel>();
                var builder = new TowerBuilder(wep);
                builder.SetFootprint(new FootprintModel("", true, true, true));
                modelToUse = builder.build();
                return true;
            }
        }

        [HarmonyPatch(typeof(Tower), "UpdatedModel")]
        public class UpdatedModel_Patch
        {

            [HarmonyPrefix]
            public static bool Prefix(Tower __instance, ref Model modelToUse)
            {
                if (lastMap != "epiloge") return true;
                var wep = modelToUse.Cast<TowerModel>();
                var builder = new TowerBuilder(wep);
                builder.SetFootprint(new FootprintModel("", true, true, true));
                modelToUse = builder.build();
                return true;
            }
        }




        //public static List<AreaModel> getTrackAreas(List<PointInfo> pointsList,float margin)
        //{
        //    List<AreaModel> newareas = new List<AreaModel>();

        //    var area0 = new Il2CppSystem.Collections.Generic.List<Assets.Scripts.Simulation.SMath.Vector2>();
        //    area0.Add(new Assets.Scripts.Simulation.SMath.Vector2(-147.633f, -115.2764f));
        //    area0.Add(new Assets.Scripts.Simulation.SMath.Vector2(146.1904f, -114.1706f));
        //    area0.Add(new Assets.Scripts.Simulation.SMath.Vector2(146.6712f, 114.1708f));
        //    area0.Add(new Assets.Scripts.Simulation.SMath.Vector2(-147.633f, 114.7236f));
        //    newareas.Add(new AreaModel("lol0", new Assets.Scripts.Simulation.SMath.Polygon(area0), 0, (AreaType)2));

        //    var points = pointsList.ToArray();
        //    for (var j = 0; j < points.Length - 1; j++)
        //    {
        //        var point1 = pointsList[j];
        //        var point2 = pointsList[j + 1];
        //        var area = new Il2CppSystem.Collections.Generic.List<Assets.Scripts.Simulation.SMath.Vector2>();
        //        area.Add(new Assets.Scripts.Simulation.SMath.Vector2(point1.point.x + margin, point1.point.y));
        //        area.Add(new Assets.Scripts.Simulation.SMath.Vector2(point1.point.x - margin, point1.point.y));
        //        area.Add(new Assets.Scripts.Simulation.SMath.Vector2(point2.point.x + margin, point2.point.y));
        //        area.Add(new Assets.Scripts.Simulation.SMath.Vector2(point2.point.x - margin, point2.point.y));
        //        newareas.Add(new AreaModel("lol0", new Assets.Scripts.Simulation.SMath.Polygon(area), 0, (AreaType)2));


        //    }
        //    return newareas;
        //}




    }
}