﻿using MistsOfTime.Assets;
using MistsOfTime.Universe;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MistsOfTime.Interface
{
    internal class RegionScreen : IScreen
    {
        private ConsoleKey[] _moveKeys = new ConsoleKey[]
        {
            ConsoleKey.N, ConsoleKey.S, ConsoleKey.E, ConsoleKey.W,
            ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.RightArrow,
            ConsoleKey.LeftArrow
        };

        public event EventHandler<ScreenEventArgs> ChangeActiveScreen;

        internal RegionScreen(Game game)
        {
            Game = game;
            ActionResult = new List<TextObject>();
            ActionResult.Add(new TextObject("", ConsoleColor.Yellow, ConsoleColor.Black));

            Title = new List<TextObject>();
            Title.Add(new TextObject("*******************************[ MISTS OF TIME ]*******************************", 
                ConsoleColor.White, ConsoleColor.Black));

            RegionInfo = SetRegionInfo(Game.Here);
        }

        public List<TextObject> ActionResult { get; set; }
        public List<TextObject> Title { get; set; }
        public List<TextObject> RegionInfo { get; set; }
        public Game Game { get; set; }

        public void Display()
        {
            Display(Title);
            Display(ActionResult);
            ActionResult[0].Text = "";
            Display(RegionInfo);
        }

        public void Display(List<TextObject> textElement)
        {
            if (textElement.Count > 0)
            {
                foreach (TextObject line in textElement)
                {
                    line.WriteLine();
                }
            }
        }

        public void HandleInput(ConsoleKeyInfo keyInfo)
        {
            if (_moveKeys.Contains(keyInfo.Key))
                Move(keyInfo.Key);
        }

        private List<TextObject> SetRegionInfo(Region here)
        {
            var info = new List<TextObject>();
            var coords = Game.Here.Coords + " : " + Game.Here.Name;
            info.Add(new TextObject(coords, ConsoleColor.White, ConsoleColor.Black));
            foreach (string line in Game.Here.Description)
            {
                info.Add(new TextObject(line, ConsoleColor.Gray, ConsoleColor.Black));
            }
            int i = 1;
            foreach(Land land in Game.Here.Lands)
            {
                info.Add(new TextObject("Land " + i + " has a population of " + land.Population + ", and " + land.Trees + " trees.", 
                    ConsoleColor.White, ConsoleColor.Black));
                i++;
            }

            return info;
        }

        private void Move(ConsoleKey dir)
        {
            Region newPlace = Game.Here;
            bool isValidMove = false;
            string result = "";
            switch (dir)
            {
                case ConsoleKey.N:
                case ConsoleKey.UpArrow:
                    isValidMove = Game.World.MoveNorth(Game.Here, out newPlace);
                    result = "You travel north.";
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    isValidMove = Game.World.MoveSouth(Game.Here, out newPlace);
                    result = "You travel south.";
                    break;
                case ConsoleKey.E:
                case ConsoleKey.RightArrow:
                    isValidMove = Game.World.MoveEast(Game.Here, out newPlace);
                    result = "You travel east.";
                    break;
                case ConsoleKey.W:
                case ConsoleKey.LeftArrow:
                    isValidMove = Game.World.MoveWest(Game.Here, out newPlace);
                    result = "You travel west.";
                    break;
            }
            Game.Here = newPlace;
            if (!isValidMove)
                result = LocationData.MovedOutOfBounds;
            else
                RegionInfo = SetRegionInfo(Game.Here);

            ActionResult[0].Text = result;
        }
    }
}
