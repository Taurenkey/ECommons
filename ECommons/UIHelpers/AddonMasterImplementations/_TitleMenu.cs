﻿using FFXIVClientStructs.FFXIV.Component.GUI;

namespace ECommons.UIHelpers.AddonMasterImplementations;
public partial class AddonMaster
{
    public unsafe class _TitleMenu : AddonMasterBase
    {
        public _TitleMenu(nint addon) : base(addon)
        {
        }

        public _TitleMenu(void* addon) : base(addon)
        {
        }

        public bool IsReady
        {
            get
            {
                return GenericHelpers.IsScreenReady()
                    && GenericHelpers.IsAddonReady(Base)
                    && Base->UldManager.NodeListCount > 3
                    && Base->UldManager.NodeList[7]->IsVisible()
                    && Base->GetNodeById(3)->Color.A == 0xFF
                    && !GenericHelpers.TryGetAddonByName<AtkUnitBase>("TitleDCWorldMap", out _)
                    && !GenericHelpers.TryGetAddonByName<AtkUnitBase>("TitleConnect", out _);
            }
        }

        public AtkComponentButton* StartButton => Base->GetButtonNodeById(4);
        public AtkComponentButton* DataCenterButton => Base->GetButtonNodeById(5);
        public AtkComponentButton* MoviesAndTitlesButton => Base->GetButtonNodeById(6);
        public AtkComponentButton* OptionsButton => Base->GetButtonNodeById(7);
        public AtkComponentButton* LicenseButton => Base->GetButtonNodeById(8);
        public AtkComponentButton* ExitButton => Base->GetButtonNodeById(9);

        public override string AddonDescription { get; } = "Title menu";

        public void Start() => ClickButtonIfEnabled(StartButton);
        public void DataCenter() => ClickButtonIfEnabled(DataCenterButton);
        public void MoviesAndTitles() => ClickButtonIfEnabled(MoviesAndTitlesButton);
        public void Options() => ClickButtonIfEnabled(OptionsButton);
        public void License() => ClickButtonIfEnabled(LicenseButton);
        public void Exit() => ClickButtonIfEnabled(ExitButton);
    }
}
