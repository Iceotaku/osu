// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Game.Graphics.UserInterface;
using osu.Game.Overlays.Mods;
using osu.Game.Rulesets.Mods;
using osuTK.Input;

namespace osu.Game.Screens.OnlinePlay
{
    public class FreeModSelectScreen : ModSelectScreen
    {
        protected override bool ShowTotalMultiplier => false;

        public new Func<Mod, bool> IsValidMod
        {
            get => base.IsValidMod;
            set => base.IsValidMod = m => m.UserPlayable && value.Invoke(m);
        }

        public FreeModSelectScreen()
        {
            IsValidMod = _ => true;
        }

        protected override ModColumn CreateModColumn(ModType modType, Key[] toggleKeys = null) => new ModColumn(modType, true, toggleKeys);

        protected override IEnumerable<ShearedButton> CreateFooterButtons() => new[]
        {
            new ShearedButton(200)
            {
                Anchor = Anchor.BottomLeft,
                Origin = Anchor.BottomLeft,
                Text = "Select All",
                Action = SelectAll
            },
            new ShearedButton(200)
            {
                Anchor = Anchor.BottomLeft,
                Origin = Anchor.BottomLeft,
                Text = "Deselect All",
                Action = DeselectAll
            }
        };
    }
}