﻿Imports System.Drawing
Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports System.Windows.Forms
Imports SinglePlayerApartment.SinglePlayerApartment
Imports PDMCarShopGUI

Public Class Mechanic
    Inherits Script

    Public Shared Path As String
    Public Shared playerHash As String
    Public Shared GarageMenu, GarageMenu2, GrgMoveMenu, GrgTransMenu, MechanicMenu, PhoneMenu, AS3Menu, IW4Menu, IW4HLMenu, DPHMenu, DPHHLMenu, DTMenu, ETMenu, ETHLMenu, RMMenu, RMHLMenu, TTMenu, TTHLMenu, WPMenu, VBMenu As UIMenu
    Public Shared NC2044Menu, HA2862Menu, HA2868Menu, WO3655Menu, NC2045Menu, MR2117Menu, HA2874Menu, WD3677Menu, MW2113Menu, ETP1Menu, ETP2Menu, ETP3Menu As UIMenu
    Public Shared MichaelPegasusMenu, FranklinPegasusMenu, TrevorPegasusMenu, Player3PegasusMenu, PegasusConfirmMenu As UIMenu
    Public Shared _menuPool As MenuPool
    Public Shared AS3, IW4, IW4HL, DPH, DPHHL, DT, ET, ETHL, RM, RMHL, TT, TTHL, WP, VB As String
    Public Shared NC2044, HA2862, HA2868, WO3655, NC2045, MR2117, HA2874, WD3677, MW2113, ETP1, ETP2, ETP3 As String
    Public Shared MPV0, MPV1, MPV2, MPV3, MPV4, MPV5, MPV6, MPV7, MPV8, MPV9 As Vehicle
    Public Shared FPV0, FPV1, FPV2, FPV3, FPV4, FPV5, FPV6, FPV7, FPV8, FPV9 As Vehicle
    Public Shared TPV0, TPV1, TPV2, TPV3, TPV4, TPV5, TPV6, TPV7, TPV8, TPV9 As Vehicle
    Public Shared PPV0, PPV1, PPV2, PPV3, PPV4, PPV5, PPV6, PPV7, PPV8, PPV9 As Vehicle
    Public Shared MPV, FPV, TPV, PPV As Vehicle
    Public Shared itemAS3, itemIW4, itemIW4HL, itemDPH, itemDPHHL, itemDT, itemET, itemETHL, itemRM, itemRMHL, itemTT, itemTTHL, itemWP, itemVB As UIMenuItem
    Public Shared itemNC2044, itemHA2862, itemHA2868, itemWO3655, itemNC2045, itemMR2117, itemHA2874, itemWD3677, itemMW2113, itemETP1, itemETP2, itemETP3 As UIMenuItem
    Public Shared GarageMenuItem(10) As UIMenuItem
    Public Shared GrgMoveMenuItem(10) As UIMenuItem
    Public Shared GrgTransMenuItem(10) As UIMenuItem
    Public Shared GarageMenuSelectedItem, GarageMenuSelectedFile, MoveMenuSelectedItem, MoveMenuSelectedFile, MoveMenuSelectedIndex, SelectedGarage, PegasusSelectedVehicleFile As String

    Public Shared AltaPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3_alta_street\"
    Public Shared IntegrityPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4_integrity_way\"
    Public Shared Integrity2PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4_integrity_way_hl\"
    Public Shared PerroPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\del_perro_heights\"
    Public Shared Perro2PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\del_perro_heights_hl\"
    Public Shared DreamPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\dream_tower\"
    Public Shared EclipsePathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower\"
    Public Shared Eclipse2PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_hl\"
    Public Shared RichardPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\richard_majestic\"
    Public Shared Richard2PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\richard_majestic_hl\"
    Public Shared TinselPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\tinsel_tower\"
    Public Shared Tinsel2PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\tinsel_tower_hl\"
    Public Shared WeazelPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\weazel_plaza\"
    Public Shared VespucciPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\vespucci_blvd\"
    Public Shared NorthConker2044Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2044_north_conker\"
    Public Shared HillcrestAve2862Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2862_hillcreast_ave\"
    Public Shared HillcrestAve2868Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2868_hillcreast_ave\"
    Public Shared WildOats3655Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3655_wild_oats\"
    Public Shared NorthConker2045Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2045_north_conker\"
    Public Shared MiltonRoad2117Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2117_milton_road\"
    Public Shared HillcrestAve2874Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2874_hillcreast_ave\"
    Public Shared Whispymound3677Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\"
    Public Shared MadWayne2113Dri As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2113_mad_wayne\"
    Public Shared EclipseP1PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps1\"
    Public Shared EclipseP2PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps2\"
    Public Shared EclipseP3PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps3\"

    Public Shared MichaelPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Pegasus\Michael\"
    Public Shared FranklinPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Pegasus\Franklin\"
    Public Shared TrevorPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Pegasus\Trevor\"
    Public Shared Player3PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Pegasus\Player3\"
    Public Shared SoundPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Sounds\"

    Public Sub New()
        Try
            'New Language
            Website.BennysOriginal = ReadCfgValue("BennysOriginal", langFile)
            Website.DockTease = ReadCfgValue("DockTease", langFile)
            Website.LegendaryMotorsport = ReadCfgValue("LegendaryMotorsport", langFile)
            Website.ElitasTravel = ReadCfgValue("ElitasTravel", langFile)
            Website.PedalToMetal = ReadCfgValue("PedalToMetal", langFile)
            Website.SouthernSA = ReadCfgValue("SouthernSA", langFile)
            Website.WarstockCache = ReadCfgValue("WarstockCache", langFile)
            Garage = ReadCfgValue("Garage", langFile)
            GrgOptions = ReadCfgValue("GrgOptions", langFile)
            GrgRemove = ReadCfgValue("GrgRemove", langFile)
            GrgRemoveAndDrive = ReadCfgValue("GrgRemoveAndDrive", langFile)
            GrgMove = ReadCfgValue("GrgMove", langFile)
            GrgSell = ReadCfgValue("GrgSell", langFile)
            GrgSelectVeh = ReadCfgValue("GrgSelectVeh", langFile)
            GrgTooHot = ReadCfgValue("GrgTooHot", langFile)
            GrgPlate = ReadCfgValue("GrgPlate", langFile)
            GrgRename = ReadCfgValue("GrgRename", langFile)
            GrgTransfer = ReadCfgValue("GrgTransfer", langFile)
            _Mechanic = ReadCfgValue("_Mechanic", langFile)
            _Pegasus = ReadCfgValue("_Pegasus", langFile)
            PegasusDeliver = ReadCfgValue("PegasusDeliver", langFile)
            PegasusDelete = ReadCfgValue("PegasusDelete", langFile)
            _Phone = ReadCfgValue("_Phone", langFile)
            ChooseVeh = ReadCfgValue("ChooseVeh", langFile)
            ChooseVehDesc = ReadCfgValue("ChooseVehDesc", langFile)
            ReturnVeh = ReadCfgValue("ReturnVeh", langFile)
            'End Language

            If playerHash = "225514697" Then
                playerName = "Michael"
            ElseIf playerHash = "-1692214353" Then
                playerName = "Franklin"
            ElseIf playerHash = "-1686040670" Then
                playerName = "Trevor"
            ElseIf playerHash = "1885233650" Or "-1667301416" Then
                playerName = "Player3"
            Else
                playerName = "None"
            End If

            AS3 = ReadCfgValue("3ASowner", saveFile)
            IW4 = ReadCfgValue("4IWowner", saveFile)
            IW4HL = ReadCfgValue("4IWHLowner", saveFile)
            DPH = ReadCfgValue("DPHwoner", saveFile)
            DPHHL = ReadCfgValue("DPHHLowner", saveFile)
            DT = ReadCfgValue("SSowner", saveFile)
            ET = ReadCfgValue("ETowner", saveFile)
            ETHL = ReadCfgValue("ETHLowner", saveFile)
            RM = ReadCfgValue("RMowner", saveFile)
            RMHL = ReadCfgValue("RMHLowner", saveFile)
            TT = ReadCfgValue("TTowner", saveFile)
            TTHL = ReadCfgValue("TTHLowner", saveFile)
            WP = ReadCfgValue("WPowner", saveFile)
            VB = ReadCfgValue("VPBowner", saveFile2)
            NC2044 = ReadCfgValue("2044NCowner", saveFile2)
            HA2862 = ReadCfgValue("2862HAowner", saveFile2)
            HA2868 = ReadCfgValue("2868HAowner", saveFile2)
            WO3655 = ReadCfgValue("3655WODowner", saveFile2)
            NC2045 = ReadCfgValue("2045NCowner", saveFile2)
            MR2117 = ReadCfgValue("2117MRowner", saveFile2)
            HA2874 = ReadCfgValue("2874HAowner", saveFile2)
            WD3677 = ReadCfgValue("3677WDowner", saveFile2)
            MW2113 = ReadCfgValue("2113MWowner", saveFile2)
            ETP1 = ReadCfgValue("ETP1owner", saveFile2)
            ETP2 = ReadCfgValue("ETP2owner", saveFile2)
            ETP3 = ReadCfgValue("ETP3owner", saveFile2)

            itemAS3 = New UIMenuItem(_3AltaStreet._Name & _3AltaStreet.Unit)
            itemIW4 = New UIMenuItem(_4IntegrityWay._Name & _4IntegrityWay.Unit)
            itemIW4HL = New UIMenuItem(HL4IntegrityWay._Name & HL4IntegrityWay.Unit)
            itemDPH = New UIMenuItem(DelPerroHeight._Name & DelPerroHeight.Unit)
            itemDPHHL = New UIMenuItem(HLDelPerro._Name & HLDelPerro.Unit)
            itemDT = New UIMenuItem(DreamTower._Name & DreamTower.Unit)
            itemET = New UIMenuItem(EclipseTower._Name & EclipseTower.Unit)
            itemETHL = New UIMenuItem(HLEclipseTower._Name & HLEclipseTower.Unit)
            itemRM = New UIMenuItem(RichardMajestic._Name & RichardMajestic.Unit)
            itemRMHL = New UIMenuItem(HLRichardMajestic._Name & HLRichardMajestic.Unit)
            itemTT = New UIMenuItem(TinselTower._Name & TinselTower.Unit)
            itemTTHL = New UIMenuItem(HLTinselTower._Name & HLTinselTower.Unit)
            itemWP = New UIMenuItem(WeazelPlaza._Name & WeazelPlaza.Unit)
            itemVB = New UIMenuItem(VespucciBlvd._Name & VespucciBlvd.Unit)
            itemNC2044 = New UIMenuItem(NorthConker2044._Name & NorthConker2044.Unit)
            itemHA2862 = New UIMenuItem(HillcrestAve2862._Name & HillcrestAve2862.Unit)
            itemHA2868 = New UIMenuItem(HillcrestAve2868._Name & HillcrestAve2868.Unit)
            itemWO3655 = New UIMenuItem(WildOats3655._Name & WildOats3655.Unit)
            itemNC2045 = New UIMenuItem(NorthConker2045._Name & NorthConker2045.Unit)
            itemMR2117 = New UIMenuItem(MiltonRd2117._Name & MiltonRd2117.Unit)
            itemHA2874 = New UIMenuItem(HillcrestAve2874._Name & HillcrestAve2874.Unit)
            itemWD3677 = New UIMenuItem(Whispymound3677._Name & Whispymound3677.Unit)
            itemMW2113 = New UIMenuItem(MadWayne2113._Name & MadWayne2113.Unit)
            itemETP1 = New UIMenuItem(EclipseTowerPS1._Name & EclipseTowerPS1.Unit)
            itemETP2 = New UIMenuItem(EclipseTowerPS2._Name & EclipseTowerPS2.Unit)
            itemETP3 = New UIMenuItem(EclipseTowerPS3._Name & EclipseTowerPS3.Unit)

            AddHandler Tick, AddressOf OnTick
            AddHandler KeyDown, AddressOf OnKeyDown

            My.Settings.Mechanic = [Enum].Parse(GetType(Keys), ReadCfgValue("Mechanic", settingFile), False)
            My.Settings.Save()

            _menuPool = New MenuPool()
            CreatePhoneMenu()
            CreateMechanicMenu()
            CreateVehMenuApartments(AS3Menu, itemAS3, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3_alta_street\")
            CreateVehMenuApartments(DTMenu, itemDT, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\dream_tower\")
            CreateVehMenuApartments(ETMenu, itemET, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower\")
            CreateVehMenuApartments(ETHLMenu, itemETHL, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_hl\")
            CreateVehMenuApartments(IW4Menu, itemIW4, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4_integrity_way\")
            CreateVehMenuApartments(IW4HLMenu, itemIW4HL, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4_integrity_way_hl\")
            CreateVehMenuApartments(DPHMenu, itemDPH, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\del_perro_heights\")
            CreateVehMenuApartments(DPHHLMenu, itemDPHHL, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\del_perro_heights_hl\")
            CreateVehMenuApartments(RMMenu, itemRM, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\richard_majestic\")
            CreateVehMenuApartments(RMHLMenu, itemRMHL, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\richard_majestic_hl\")
            CreateVehMenuApartments(TTMenu, itemTT, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\tinsel_tower\")
            CreateVehMenuApartments(TTHLMenu, itemTTHL, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\tinsel_tower_hl\")
            CreateVehMenuApartments(WPMenu, itemWP, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\weazel_plaza\")
            CreateVehMenuVespucciBlvd()
            CreateVehMenuApartments(NC2044Menu, itemNC2044, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2044_north_conker\")
            CreateVehMenuApartments(HA2862Menu, itemHA2862, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2862_hillcreast_ave\")
            CreateVehMenuApartments(HA2868Menu, itemHA2868, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2868_hillcrest_ave\")
            CreateVehMenuApartments(WO3655Menu, itemWO3655, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3655_wild_oats\")
            CreateVehMenuApartments(NC2045Menu, itemNC2045, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2045_north_conker\")
            CreateVehMenuApartments(MR2117Menu, itemMR2117, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2117_milton_road\")
            CreateVehMenuApartments(HA2874Menu, itemHA2874, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2874_hillcreast_ave\")
            CreateVehMenuApartments(WD3677Menu, itemWD3677, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\")
            CreateVehMenuApartments(MW2113Menu, itemMW2113, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2113_mad_wayne\")
            CreateVehMenuApartments(ETP1Menu, itemETP1, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps1\")
            CreateVehMenuApartments(ETP2Menu, itemETP2, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps2\")
            CreateVehMenuApartments(ETP3Menu, itemETP3, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps3\")
            CreateConfirmPegasusMenu()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateConfirmPegasusMenu()
        Try
            PegasusConfirmMenu = New UIMenu("", _Pegasus.ToUpper(), New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            PegasusConfirmMenu.SetBannerType(Rectangle)
            _menuPool.Add(PegasusConfirmMenu)
            PegasusConfirmMenu.AddItem(New UIMenuItem(PegasusDeliver))
            PegasusConfirmMenu.AddItem(New UIMenuItem(PegasusDelete))
            PegasusConfirmMenu.RefreshIndex()
            AddHandler PegasusConfirmMenu.OnItemSelect, AddressOf PegasusConfirmItemSelectHandler
            AddHandler PegasusConfirmMenu.OnMenuClose, AddressOf PegasusConfirmMenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateMPegasusMenu()
        Try
            MichaelPegasusMenu = New UIMenu("", _Pegasus.ToUpper(), New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MichaelPegasusMenu.SetBannerType(Rectangle)
            _menuPool.Add(MichaelPegasusMenu)
            MichaelPegasusMenu.MenuItems.Clear()
            For Each File As String In IO.Directory.GetFiles(MichaelPathDir, "*.cfg")
                Dim VehicleName As String = ReadCfgValue("VehicleName", File)
                Dim VehicleNick As String = ReadCfgValue("VehicleNick", File)
                Dim PlateNumber As String = ReadCfgValue("PlateNumber", File)
                Dim VehDispName As String
                If VehicleNick = "" Then VehDispName = VehicleName Else VehDispName = VehicleNick
                Dim item As New UIMenuItem(VehDispName & " (" & PlateNumber & ")", ChooseVehDesc)
                With item
                    .Car = File
                End With
                MichaelPegasusMenu.AddItem(item)
            Next
            MichaelPegasusMenu.RefreshIndex()
            AddHandler MichaelPegasusMenu.OnItemSelect, AddressOf PegasusItemSelectHandler
            AddHandler MichaelPegasusMenu.OnMenuClose, AddressOf PegasusConfirmMenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateFPegasusMenu()
        Try
            FranklinPegasusMenu = New UIMenu("", _Pegasus.ToUpper(), New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            FranklinPegasusMenu.SetBannerType(Rectangle)
            _menuPool.Add(FranklinPegasusMenu)
            FranklinPegasusMenu.MenuItems.Clear()
            For Each File As String In IO.Directory.GetFiles(FranklinPathDir, "*.cfg")
                Dim VehicleName As String = ReadCfgValue("VehicleName", File)
                Dim VehicleNick As String = ReadCfgValue("VehicleNick", File)
                Dim PlateNumber As String = ReadCfgValue("PlateNumber", File)
                Dim VehDispName As String
                If VehicleNick = "" Then VehDispName = VehicleName Else VehDispName = VehicleNick
                Dim item As New UIMenuItem(VehDispName & " (" & PlateNumber & ")", ChooseVehDesc)
                With item
                    .Car = File
                End With
                FranklinPegasusMenu.AddItem(item)
            Next
            FranklinPegasusMenu.RefreshIndex()
            AddHandler FranklinPegasusMenu.OnItemSelect, AddressOf PegasusItemSelectHandler
            AddHandler FranklinPegasusMenu.OnMenuClose, AddressOf PegasusConfirmMenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateTPegasusMenu()
        Try
            TrevorPegasusMenu = New UIMenu("", _Pegasus.ToUpper(), New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            TrevorPegasusMenu.SetBannerType(Rectangle)
            _menuPool.Add(TrevorPegasusMenu)
            TrevorPegasusMenu.MenuItems.Clear()
            For Each File As String In IO.Directory.GetFiles(TrevorPathDir, "*.cfg")
                Dim VehicleName As String = ReadCfgValue("VehicleName", File)
                Dim VehicleNick As String = ReadCfgValue("VehicleNick", File)
                Dim PlateNumber As String = ReadCfgValue("PlateNumber", File)
                Dim VehDispName As String
                If VehicleNick = "" Then VehDispName = VehicleName Else VehDispName = VehicleNick
                Dim item As New UIMenuItem(VehDispName & " (" & PlateNumber & ")", ChooseVehDesc)
                With item
                    .Car = File
                End With
                TrevorPegasusMenu.AddItem(item)
            Next
            TrevorPegasusMenu.RefreshIndex()
            AddHandler TrevorPegasusMenu.OnItemSelect, AddressOf PegasusItemSelectHandler
            AddHandler TrevorPegasusMenu.OnMenuClose, AddressOf PegasusConfirmMenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreatePPegasusMenu()
        Try
            Player3PegasusMenu = New UIMenu("", _Pegasus.ToUpper(), New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            Player3PegasusMenu.SetBannerType(Rectangle)
            _menuPool.Add(Player3PegasusMenu)
            Player3PegasusMenu.MenuItems.Clear()
            For Each File As String In IO.Directory.GetFiles(Player3PathDir, "*.cfg")
                Dim VehicleName As String = ReadCfgValue("VehicleName", File)
                Dim VehicleNick As String = ReadCfgValue("VehicleNick", File)
                Dim PlateNumber As String = ReadCfgValue("PlateNumber", File)
                Dim VehDispName As String
                If VehicleNick = "" Then VehDispName = VehicleName Else VehDispName = VehicleNick
                Dim item As New UIMenuItem(VehDispName & " (" & PlateNumber & ")", ChooseVehDesc)
                With item
                    .Car = File
                End With
                Player3PegasusMenu.AddItem(item)
            Next
            Player3PegasusMenu.RefreshIndex()
            AddHandler Player3PegasusMenu.OnItemSelect, AddressOf PegasusItemSelectHandler
            AddHandler Player3PegasusMenu.OnMenuClose, AddressOf PegasusConfirmMenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreatePhoneMenu()
        Try
            PhoneMenu = New UIMenu("", _Phone, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            PhoneMenu.SetBannerType(Rectangle)
            _menuPool.Add(PhoneMenu)
            PhoneMenu.AddItem(New UIMenuItem(_Mechanic))
            PhoneMenu.AddItem(New UIMenuItem(_Pegasus))
            PhoneMenu.AddItem(New UIMenuItem(Website.BennysOriginal))
            PhoneMenu.AddItem(New UIMenuItem(Website.DockTease))
            PhoneMenu.AddItem(New UIMenuItem(Website.ElitasTravel))
            PhoneMenu.AddItem(New UIMenuItem(Website.LegendaryMotorsport))
            PhoneMenu.AddItem(New UIMenuItem(Website.PedalToMetal))
            PhoneMenu.AddItem(New UIMenuItem(Website.SouthernSA))
            PhoneMenu.AddItem(New UIMenuItem(Website.WarstockCache))
            PhoneMenu.RefreshIndex()
            AddHandler PhoneMenu.OnItemSelect, AddressOf PhoneMenuItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateMechanicMenu()
        Try
            Dim Alta As Integer = IO.Directory.GetFiles(AltaPathDir, "*.cfg").Count
            Dim Integrity As Integer = IO.Directory.GetFiles(IntegrityPathDir, "*.cfg").Count
            Dim Integrity2 As Integer = IO.Directory.GetFiles(Integrity2PathDir, "*.cfg").Count
            Dim Perro As Integer = IO.Directory.GetFiles(PerroPathDir, "*.cfg").Count
            Dim Perro2 As Integer = IO.Directory.GetFiles(Perro2PathDir, "*.cfg").Count
            Dim Dream As Integer = IO.Directory.GetFiles(DreamPathDir, "*.cfg").Count
            Dim Eclipse As Integer = IO.Directory.GetFiles(EclipsePathDir, "*.cfg").Count
            Dim Eclipse2 As Integer = IO.Directory.GetFiles(Eclipse2PathDir, "*.cfg").Count
            Dim Richard As Integer = IO.Directory.GetFiles(RichardPathDir, "*.cfg").Count
            Dim Richard2 As Integer = IO.Directory.GetFiles(Richard2PathDir, "*.cfg").Count
            Dim Tinsel As Integer = IO.Directory.GetFiles(TinselPathDir, "*.cfg").Count
            Dim Tinsel2 As Integer = IO.Directory.GetFiles(Tinsel2PathDir, "*.cfg").Count
            Dim Weazel As Integer = IO.Directory.GetFiles(WeazelPathDir, "*.cfg").Count
            Dim Vespucci As Integer = IO.Directory.GetFiles(VespucciPathDir, "*.cfg").Count
            Dim NConker2044 As Integer = IO.Directory.GetFiles(NorthConker2044Dir, "*.cfg").Count
            Dim Hillcrest2862 As Integer = IO.Directory.GetFiles(HillcrestAve2862Dir, "*.cfg").Count
            Dim Hillcrest2868 As Integer = IO.Directory.GetFiles(HillcrestAve2868Dir, "*.cfg").Count
            Dim Wild3655 As Integer = IO.Directory.GetFiles(WildOats3655Dir, "*.cfg").Count
            Dim NConker2045 As Integer = IO.Directory.GetFiles(NorthConker2045Dir, "*.cfg").Count
            Dim MiltonR2117 As Integer = IO.Directory.GetFiles(MiltonRoad2117Dir, "*.cfg").Count
            Dim Hillcrest2874 As Integer = IO.Directory.GetFiles(HillcrestAve2874Dir, "*.cfg").Count
            Dim Whispymound3677 As Integer = IO.Directory.GetFiles(Whispymound3677Dir, "*.cfg").Count
            Dim MadWayne2113 As Integer = IO.Directory.GetFiles(MadWayne2113Dri, "*.cfg").Count
            Dim EclipseP1 As Integer = IO.Directory.GetFiles(EclipseP1PathDir, "*.cfg").Count
            Dim EclipseP2 As Integer = IO.Directory.GetFiles(EclipseP2PathDir, "*.cfg").Count
            Dim EclipseP3 As Integer = IO.Directory.GetFiles(EclipseP3PathDir, "*.cfg").Count

            MechanicMenu = New UIMenu("", ChooseApt, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MechanicMenu.SetBannerType(Rectangle)
            _menuPool.Add(MechanicMenu)
            MechanicMenu.MenuItems.Clear()
            If AS3 = playerName AndAlso Not Alta = 0 AndAlso ReadCfgValue("3AltaStreet", settingFile) = "Enable" Then MechanicMenu.AddItem(itemAS3)
            If IW4 = playerName AndAlso Not Integrity = 0 AndAlso ReadCfgValue("4IntegrityWay", settingFile) = "Enable" Then MechanicMenu.AddItem(itemIW4)
            If IW4HL = playerName AndAlso Not Integrity2 = 0 AndAlso ReadCfgValue("4IntegrityWay", settingFile) = "Enable" Then MechanicMenu.AddItem(itemIW4HL)
            If DPH = playerName AndAlso Not Perro = 0 AndAlso ReadCfgValue("DelPerroHeights", settingFile) = "Enable" Then MechanicMenu.AddItem(itemDPH)
            If DPHHL = playerName AndAlso Not Perro2 = 0 AndAlso ReadCfgValue("DelPerroHeights", settingFile) = "Enable" Then MechanicMenu.AddItem(itemDPHHL)
            If DT = playerName AndAlso Not Dream = 0 AndAlso ReadCfgValue("DreamTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemDT)
            If ET = playerName AndAlso Not Eclipse = 0 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemET)
            If ETHL = playerName AndAlso Not Eclipse2 = 0 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemETHL)
            If RM = playerName AndAlso Not Richard = 0 AndAlso ReadCfgValue("RichardMajestic", settingFile) = "Enable" Then MechanicMenu.AddItem(itemRM)
            If RMHL = playerName AndAlso Not Richard2 = 0 AndAlso ReadCfgValue("RichardMajestic", settingFile) = "Enable" Then MechanicMenu.AddItem(itemRMHL)
            If TT = playerName AndAlso Not Tinsel = 0 AndAlso ReadCfgValue("TinselTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemTT)
            If TTHL = playerName AndAlso Not Tinsel2 = 0 AndAlso ReadCfgValue("TinselTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemTTHL)
            If WP = playerName AndAlso Not Weazel = 0 AndAlso ReadCfgValue("WeazelPlaza", settingFile) = "Enable" Then MechanicMenu.AddItem(itemWP)
            If VB = playerName AndAlso Not Vespucci = 0 AndAlso ReadCfgValue("VespucciBlvd", settingFile) = "Enable" Then MechanicMenu.AddItem(itemVB)
            If NC2044 = playerName AndAlso Not NConker2044 = 0 AndAlso ReadCfgValue("2044NorthConker", settingFile) = "Enable" Then MechanicMenu.AddItem(itemNC2044)
            If HA2862 = playerName AndAlso Not Hillcrest2862 = 0 AndAlso ReadCfgValue("2862Hillcrest", settingFile) = "Enable" Then MechanicMenu.AddItem(itemHA2862)
            If HA2868 = playerName AndAlso Not Hillcrest2868 = 0 AndAlso ReadCfgValue("2868Hillcrest", settingFile) = "Enable" Then MechanicMenu.AddItem(itemHA2868)
            If WO3655 = playerName AndAlso Not Wild3655 = 0 AndAlso ReadCfgValue("3655WildOats", settingFile) = "Enable" Then MechanicMenu.AddItem(itemWO3655)
            If NC2045 = playerName AndAlso Not NConker2045 = 0 AndAlso ReadCfgValue("2045NorthConker", settingFile) = "Enable" Then MechanicMenu.AddItem(itemNC2045)
            If MR2117 = playerName AndAlso Not MiltonR2117 = 0 AndAlso ReadCfgValue("2117MiltonRd", settingFile) = "Enable" Then MechanicMenu.AddItem(itemMR2117)
            If HA2874 = playerName AndAlso Not Hillcrest2874 = 0 AndAlso ReadCfgValue("2874Hillcrest", settingFile) = "Enable" Then MechanicMenu.AddItem(itemHA2874)
            If WD3677 = playerName AndAlso Not Whispymound3677 = 0 AndAlso ReadCfgValue("3677Whispymound", settingFile) = "Enable" Then MechanicMenu.AddItem(itemWD3677)
            If MW2113 = playerName AndAlso Not MadWayne2113 = 0 AndAlso ReadCfgValue("2113MadWayne", settingFile) = "Enable" Then MechanicMenu.AddItem(itemMW2113)
            If ETP1 = playerName AndAlso Not EclipseP1 = 0 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemETP1)
            If ETP2 = playerName AndAlso Not EclipseP2 = 0 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemETP2)
            If ETP3 = playerName AndAlso Not EclipseP3 = 0 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemETP3)
            MechanicMenu.RefreshIndex()
            AddHandler MechanicMenu.OnMenuClose, AddressOf CategoryMenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

#Region "Create Apartment"
    Public Shared Sub CreateVehTransMenuApt()
        Try
            Dim Alta As Integer = IO.Directory.GetFiles(AltaPathDir, "*.cfg").Count
            Dim Integrity As Integer = IO.Directory.GetFiles(IntegrityPathDir, "*.cfg").Count
            Dim Integrity2 As Integer = IO.Directory.GetFiles(Integrity2PathDir, "*.cfg").Count
            Dim Perro As Integer = IO.Directory.GetFiles(PerroPathDir, "*.cfg").Count
            Dim Perro2 As Integer = IO.Directory.GetFiles(Perro2PathDir, "*.cfg").Count
            Dim Dream As Integer = IO.Directory.GetFiles(DreamPathDir, "*.cfg").Count
            Dim Eclipse As Integer = IO.Directory.GetFiles(EclipsePathDir, "*.cfg").Count
            Dim Eclipse2 As Integer = IO.Directory.GetFiles(Eclipse2PathDir, "*.cfg").Count
            Dim Richard As Integer = IO.Directory.GetFiles(RichardPathDir, "*.cfg").Count
            Dim Richard2 As Integer = IO.Directory.GetFiles(Richard2PathDir, "*.cfg").Count
            Dim Tinsel As Integer = IO.Directory.GetFiles(TinselPathDir, "*.cfg").Count
            Dim Tinsel2 As Integer = IO.Directory.GetFiles(Tinsel2PathDir, "*.cfg").Count
            Dim Weazel As Integer = IO.Directory.GetFiles(WeazelPathDir, "*.cfg").Count
            Dim Vespucci As Integer = IO.Directory.GetFiles(VespucciPathDir, "*.cfg").Count
            Dim NConker2044 As Integer = IO.Directory.GetFiles(NorthConker2044Dir, "*.cfg").Count
            Dim Hillcrest2862 As Integer = IO.Directory.GetFiles(HillcrestAve2862Dir, "*.cfg").Count
            Dim Hillcrest2868 As Integer = IO.Directory.GetFiles(HillcrestAve2868Dir, "*.cfg").Count
            Dim Wild3655 As Integer = IO.Directory.GetFiles(WildOats3655Dir, "*.cfg").Count
            Dim NConker2045 As Integer = IO.Directory.GetFiles(NorthConker2045Dir, "*.cfg").Count
            Dim MiltonR2117 As Integer = IO.Directory.GetFiles(MiltonRoad2117Dir, "*.cfg").Count
            Dim Hillcrest2874 As Integer = IO.Directory.GetFiles(HillcrestAve2874Dir, "*.cfg").Count
            Dim Whispymound3677 As Integer = IO.Directory.GetFiles(Whispymound3677Dir, "*.cfg").Count
            Dim MadWayne2113 As Integer = IO.Directory.GetFiles(MadWayne2113Dri, "*.cfg").Count
            Dim EclipseP1 As Integer = IO.Directory.GetFiles(EclipseP1PathDir, "*.cfg").Count
            Dim EclipseP2 As Integer = IO.Directory.GetFiles(EclipseP2PathDir, "*.cfg").Count
            Dim EclipseP3 As Integer = IO.Directory.GetFiles(EclipseP3PathDir, "*.cfg").Count

            GrgTransMenu = New UIMenu("", ChooseApt, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            GrgTransMenu.SetBannerType(Rectangle)
            _menuPool.Add(GrgTransMenu)
            GrgTransMenu.MenuItems.Clear()
            If AS3 = playerName AndAlso Not Alta = 10 AndAlso ReadCfgValue("3AltaStreet", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemAS3)
            If IW4 = playerName AndAlso Not Integrity = 10 AndAlso ReadCfgValue("4IntegrityWay", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemIW4)
            If IW4HL = playerName AndAlso Not Integrity2 = 10 AndAlso ReadCfgValue("4IntegrityWay", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemIW4HL)
            If DPH = playerName AndAlso Not Perro = 10 AndAlso ReadCfgValue("DelPerroHeights", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemDPH)
            If DPHHL = playerName AndAlso Not Perro2 = 10 AndAlso ReadCfgValue("DelPerroHeights", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemDPHHL)
            If DT = playerName AndAlso Not Dream = 10 AndAlso ReadCfgValue("DreamTower", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemDT)
            If ET = playerName AndAlso Not Eclipse = 10 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemET)
            If ETHL = playerName AndAlso Not Eclipse2 = 10 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemETHL)
            If RM = playerName AndAlso Not Richard = 10 AndAlso ReadCfgValue("RichardMajestic", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemRM)
            If RMHL = playerName AndAlso Not Richard2 = 10 AndAlso ReadCfgValue("RichardMajestic", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemRMHL)
            If TT = playerName AndAlso Not Tinsel = 10 AndAlso ReadCfgValue("TinselTower", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemTT)
            If TTHL = playerName AndAlso Not Tinsel2 = 10 AndAlso ReadCfgValue("TinselTower", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemTTHL)
            If WP = playerName AndAlso Not Weazel = 10 AndAlso ReadCfgValue("WeazelPlaza", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemWP)
            If VB = playerName AndAlso Not Vespucci = 6 AndAlso ReadCfgValue("VespucciBlvd", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemVB)
            If NC2044 = playerName AndAlso Not NConker2044 = 10 AndAlso ReadCfgValue("2044NorthConker", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemNC2044)
            If HA2862 = playerName AndAlso Not Hillcrest2862 = 10 AndAlso ReadCfgValue("2862Hillcrest", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemHA2862)
            If HA2868 = playerName AndAlso Not Hillcrest2868 = 10 AndAlso ReadCfgValue("2868Hillcrest", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemHA2868)
            If WO3655 = playerName AndAlso Not Wild3655 = 10 AndAlso ReadCfgValue("3655WildOats", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemWO3655)
            If NC2045 = playerName AndAlso Not NConker2045 = 10 AndAlso ReadCfgValue("2045NorthConker", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemNC2045)
            If MR2117 = playerName AndAlso Not MiltonR2117 = 10 AndAlso ReadCfgValue("2117MiltonRd", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemMR2117)
            If HA2874 = playerName AndAlso Not Hillcrest2874 = 10 AndAlso ReadCfgValue("2874Hillcrest", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemHA2874)
            If WD3677 = playerName AndAlso Not Whispymound3677 = 10 AndAlso ReadCfgValue("3677Whispymound", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemWD3677)
            If MW2113 = playerName AndAlso Not MadWayne2113 = 10 AndAlso ReadCfgValue("2113MadWayne", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemMW2113)
            If ETP1 = playerName AndAlso Not EclipseP1 = 10 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemETP1)
            If ETP2 = playerName AndAlso Not EclipseP2 = 10 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemETP2)
            If ETP3 = playerName AndAlso Not EclipseP3 = 10 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemETP3)
            GrgTransMenu.RefreshIndex()
            AddHandler GrgTransMenu.OnItemSelect, AddressOf TransVehItemSelectHandler
            AddHandler GrgTransMenu.OnMenuClose, AddressOf MenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateVehMenuApartments(MenuCategory As UIMenu, MenuItem As UIMenuItem, PathDir As String)
        Try
            MenuCategory = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MenuCategory.SetBannerType(Rectangle)
            _menuPool.Add(MenuCategory)
            MenuCategory.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_0.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(0) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
                MenuCategory.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_1.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(1) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
                MenuCategory.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_2.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(2) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
                MenuCategory.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_3.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(3) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
                MenuCategory.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_4.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(4) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
                MenuCategory.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_5.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(5) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
                MenuCategory.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_6.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_6.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(6) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")", ChooseVehDesc)
                MenuCategory.AddItem(item(6))
                With item(6)
                    .Car = PathDir & "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_7.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_7.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(7) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")", ChooseVehDesc)
                MenuCategory.AddItem(item(7))
                With item(7)
                    .Car = PathDir & "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_8.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_8.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(8) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")", ChooseVehDesc)
                MenuCategory.AddItem(item(8))
                With item(8)
                    .Car = PathDir & "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_9.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(9) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")", ChooseVehDesc)
                MenuCategory.AddItem(item(9))
                With item(9)
                    .Car = PathDir & "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            MenuCategory.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            MenuCategory.RefreshIndex()
            MechanicMenu.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf CategoryItemSelectHandler
            'AddHandler MenuCategory.OnMenuClose, AddressOf CategoryMenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateVehMenuVespucciBlvd()
        Try
            Dim PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\vespucci_blvd\"
            VBMenu = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            VBMenu.SetBannerType(Rectangle)
            _menuPool.Add(VBMenu)
            VBMenu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_0.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(0) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
                VBMenu.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_1.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(1) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
                VBMenu.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_2.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(2) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
                VBMenu.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_3.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(3) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
                VBMenu.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_4.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(4) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
                VBMenu.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_5.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(5) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
                VBMenu.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            VBMenu.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            VBMenu.RefreshIndex()
            MechanicMenu.BindMenuToItem(VBMenu, itemVB)
            AddHandler VBMenu.OnItemSelect, AddressOf CategoryItemSelectHandler
            'AddHandler VBMenu.OnMenuClose, AddressOf CategoryMenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub
#End Region

    Public Shared Sub CreateMoveMenu(file As String, SixOrTen As String)
        Try
            GrgMoveMenu = New UIMenu("", GrgOptions, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            GrgMoveMenu.SetBannerType(Rectangle)
            _menuPool.Add(GrgMoveMenu)
            GrgMoveMenu.MenuItems.Clear()
            If SixOrTen = "Ten" Then
                If IO.File.Exists(file & "vehicle_0.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_0.cfg")
                    GrgMoveMenuItem(0) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_0.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(0))
                    With GrgMoveMenuItem(0)
                        .Car = "vehicle_0.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(0) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(0))
                    With GrgMoveMenuItem(0)
                        .Car = "vehicle_0.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_1.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_1.cfg")
                    GrgMoveMenuItem(1) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_1.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(1))
                    With GrgMoveMenuItem(1)
                        .Car = "vehicle_1.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(1) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(1))
                    With GrgMoveMenuItem(1)
                        .Car = "vehicle_1.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_2.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_2.cfg")
                    GrgMoveMenuItem(2) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_2.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(2))
                    With GrgMoveMenuItem(2)
                        .Car = "vehicle_2.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(2) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(2))
                    With GrgMoveMenuItem(2)
                        .Car = "vehicle_2.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_3.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_3.cfg")
                    GrgMoveMenuItem(3) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_3.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(3))
                    With GrgMoveMenuItem(3)
                        .Car = "vehicle_3.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(3) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(3))
                    With GrgMoveMenuItem(3)
                        .Car = "vehicle_3.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_4.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_4.cfg")
                    GrgMoveMenuItem(4) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_4.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(4))
                    With GrgMoveMenuItem(4)
                        .Car = "vehicle_4.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(4) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(4))
                    With GrgMoveMenuItem(4)
                        .Car = "vehicle_4.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_5.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_5.cfg")
                    GrgMoveMenuItem(5) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_5.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(5))
                    With GrgMoveMenuItem(5)
                        .Car = "vehicle_5.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(5) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(5))
                    With GrgMoveMenuItem(5)
                        .Car = "vehicle_5.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_6.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_6.cfg")
                    GrgMoveMenuItem(6) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_6.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(6))
                    With GrgMoveMenuItem(6)
                        .Car = "vehicle_6.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(6) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(6))
                    With GrgMoveMenuItem(6)
                        .Car = "vehicle_6.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_7.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_7.cfg")
                    GrgMoveMenuItem(7) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_7.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(7))
                    With GrgMoveMenuItem(7)
                        .Car = "vehicle_7.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(7) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(7))
                    With GrgMoveMenuItem(7)
                        .Car = "vehicle_7.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_8.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_8.cfg")
                    GrgMoveMenuItem(8) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_8.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(8))
                    With GrgMoveMenuItem(8)
                        .Car = "vehicle_8.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(8) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(8))
                    With GrgMoveMenuItem(8)
                        .Car = "vehicle_8.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_9.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_9.cfg")
                    GrgMoveMenuItem(9) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_9.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(9))
                    With GrgMoveMenuItem(9)
                        .Car = "vehicle_9.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(9) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(9))
                    With GrgMoveMenuItem(9)
                        .Car = "vehicle_9.cfg"
                    End With
                End If
            ElseIf SelectedGarage = "Six"
                If IO.File.Exists(file & "vehicle_0.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_0.cfg")
                    GrgMoveMenuItem(0) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_0.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(0))
                    With GrgMoveMenuItem(0)
                        .Car = "vehicle_0.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(0) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(0))
                    With GrgMoveMenuItem(0)
                        .Car = "vehicle_0.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_1.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_1.cfg")
                    GrgMoveMenuItem(1) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_1.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(1))
                    With GrgMoveMenuItem(1)
                        .Car = "vehicle_1.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(1) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(1))
                    With GrgMoveMenuItem(1)
                        .Car = "vehicle_1.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_2.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_2.cfg")
                    GrgMoveMenuItem(2) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_2.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(2))
                    With GrgMoveMenuItem(2)
                        .Car = "vehicle_2.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(2) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(2))
                    With GrgMoveMenuItem(2)
                        .Car = "vehicle_2.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_3.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_3.cfg")
                    GrgMoveMenuItem(3) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_3.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(3))
                    With GrgMoveMenuItem(3)
                        .Car = "vehicle_3.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(3) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(3))
                    With GrgMoveMenuItem(3)
                        .Car = "vehicle_3.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_4.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_4.cfg")
                    GrgMoveMenuItem(4) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_4.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(4))
                    With GrgMoveMenuItem(4)
                        .Car = "vehicle_4.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(4) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(4))
                    With GrgMoveMenuItem(4)
                        .Car = "vehicle_4.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_5.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_5.cfg")
                    GrgMoveMenuItem(5) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_5.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(5))
                    With GrgMoveMenuItem(5)
                        .Car = "vehicle_5.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(5) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(5))
                    With GrgMoveMenuItem(5)
                        .Car = "vehicle_5.cfg"
                    End With
                End If
            End If
            GrgMoveMenu.RefreshIndex()
            AddHandler GrgMoveMenu.OnItemSelect, AddressOf GrgMoveItemSelectHandler
            AddHandler GrgMoveMenu.OnMenuClose, AddressOf GrgMoveMenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateGarageMenu2(SixOrTen As String)
        Try
            GarageMenu2 = New UIMenu("", GrgOptions, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            GarageMenu2.SetBannerType(Rectangle)
            _menuPool.Add(GarageMenu2)
            GarageMenu2.AddItem(New UIMenuItem(GrgRemove))
            GarageMenu2.AddItem(New UIMenuItem(GrgRemoveAndDrive))
            GarageMenu2.AddItem(New UIMenuItem(GrgSell))
            GarageMenu2.AddItem(New UIMenuItem(GrgMove))
            GarageMenu2.AddItem(New UIMenuItem(GrgTransfer))
            GarageMenu2.AddItem(New UIMenuItem(GrgPlate))
            GarageMenu2.AddItem(New UIMenuItem(GrgRename))
            GarageMenu2.RefreshIndex()
            If SixOrTen = "Ten" Then
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(0))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(1))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(2))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(3))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(4))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(5))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(6))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(7))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(8))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(9))
                SelectedGarage = "Ten"
            Else
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(0))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(1))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(2))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(3))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(4))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(5))
                SelectedGarage = "Six"
            End If
            AddHandler GarageMenu2.OnItemSelect, AddressOf ItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateGarageMenu(file As String)
        Try
            GarageMenu = New UIMenu("", GrgOptions, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            GarageMenu.SetBannerType(Rectangle)
            _menuPool.Add(GarageMenu)
            GarageMenu.MenuItems.Clear()
            If IO.File.Exists(file & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_0.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_0.cfg")
                If Nick <> "" Then
                    GarageMenuItem(0) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_0.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(0) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_0.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(0))
                With GarageMenuItem(0)
                    .Car = "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(0) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(0))
                With GarageMenuItem(0)
                    .Car = "vehicle_0.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_1.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_1.cfg")
                If Nick <> "" Then
                    GarageMenuItem(1) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_1.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(1) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_1.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(1))
                With GarageMenuItem(1)
                    .Car = "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(1) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(1))
                With GarageMenuItem(1)
                    .Car = "vehicle_1.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_2.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_2.cfg")
                If Nick <> "" Then
                    GarageMenuItem(2) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_2.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(2) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_2.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(2))
                With GarageMenuItem(2)
                    .Car = "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(2) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(2))
                With GarageMenuItem(2)
                    .Car = "vehicle_2.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_3.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_3.cfg")
                If Nick <> "" Then
                    GarageMenuItem(3) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_3.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(3) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_3.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(3))
                With GarageMenuItem(3)
                    .Car = "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(3) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(3))
                With GarageMenuItem(3)
                    .Car = "vehicle_3.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_4.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_4.cfg")
                If Nick <> "" Then
                    GarageMenuItem(4) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_4.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(4) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_4.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(4))
                With GarageMenuItem(4)
                    .Car = "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(4) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(4))
                With GarageMenuItem(4)
                    .Car = "vehicle_4.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_5.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_5.cfg")
                If Nick <> "" Then
                    GarageMenuItem(5) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_5.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(5) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_5.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(5))
                With GarageMenuItem(5)
                    .Car = "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(5) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(5))
                With GarageMenuItem(5)
                    .Car = "vehicle_5.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_6.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_6.cfg")
                If Nick <> "" Then
                    GarageMenuItem(6) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_6.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(6) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_6.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(6))
                With GarageMenuItem(6)
                    .Car = "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(6) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(6))
                With GarageMenuItem(6)
                    .Car = "vehicle_6.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_7.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_7.cfg")
                If Nick <> "" Then
                    GarageMenuItem(7) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_7.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(7) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_7.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(7))
                With GarageMenuItem(7)
                    .Car = "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(7) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(7))
                With GarageMenuItem(7)
                    .Car = "vehicle_7.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_8.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_8.cfg")
                If Nick <> "" Then
                    GarageMenuItem(8) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_8.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(8) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_8.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(8))
                With GarageMenuItem(8)
                    .Car = "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(8) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(8))
                With GarageMenuItem(8)
                    .Car = "vehicle_8.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_9.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_9.cfg")
                If Nick <> "" Then
                    GarageMenuItem(9) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_9.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(9) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_9.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(9))
                With GarageMenuItem(9)
                    .Car = "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(9) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(9))
                With GarageMenuItem(9)
                    .Car = "vehicle_9.cfg"
                    .Enabled = False
                End With
            End If
            GarageMenu.RefreshIndex()
            AddHandler GarageMenu.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler GarageMenu.OnMenuClose, AddressOf MenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateGarageMenu6CarGarage(file As String)
        Try
            GarageMenu = New UIMenu("", GrgOptions, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            GarageMenu.SetBannerType(Rectangle)
            _menuPool.Add(GarageMenu)
            GarageMenu.MenuItems.Clear()
            If IO.File.Exists(file & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_0.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_0.cfg")
                If Nick <> "" Then
                    GarageMenuItem(0) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_0.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(0) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_0.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(0))
                With GarageMenuItem(0)
                    .Car = "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(0) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(0))
                With GarageMenuItem(0)
                    .Car = "vehicle_0.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_1.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_1.cfg")
                If Nick <> "" Then
                    GarageMenuItem(1) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_1.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(1) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_1.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(1))
                With GarageMenuItem(1)
                    .Car = "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(1) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(1))
                With GarageMenuItem(1)
                    .Car = "vehicle_1.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_2.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_2.cfg")
                If Nick <> "" Then
                    GarageMenuItem(2) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_2.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(2) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_2.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(2))
                With GarageMenuItem(2)
                    .Car = "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(2) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(2))
                With GarageMenuItem(2)
                    .Car = "vehicle_2.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_3.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_3.cfg")
                If Nick <> "" Then
                    GarageMenuItem(3) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_3.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(3) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_3.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(3))
                With GarageMenuItem(3)
                    .Car = "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(3) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(3))
                With GarageMenuItem(3)
                    .Car = "vehicle_3.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_4.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_4.cfg")
                If Nick <> "" Then
                    GarageMenuItem(4) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_4.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(4) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_4.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(4))
                With GarageMenuItem(4)
                    .Car = "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(4) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(4))
                With GarageMenuItem(4)
                    .Car = "vehicle_4.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_5.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_5.cfg")
                If Nick <> "" Then
                    GarageMenuItem(5) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_5.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(5) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_5.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(5))
                With GarageMenuItem(5)
                    .Car = "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(5) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(5))
                With GarageMenuItem(5)
                    .Car = "vehicle_5.cfg"
                    .Enabled = False
                End With
            End If
            GarageMenu.RefreshIndex()
            AddHandler GarageMenu.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler GarageMenu.OnMenuClose, AddressOf MenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CategoryItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            If selectedItem.Text = ReturnVeh Then
                Mechanic2.ReturnVeh(selectedItem.Car)
            ElseIf Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.Car AndAlso Not selectedItem.Text = ReturnVeh Then
                Dim VehicleModel As String = ReadCfgValue("VehicleModel", selectedItem.Car)
                Dim Active As String = ReadCfgValue("Active", selectedItem.Car)
                Dim VehicleHash As Integer = ReadCfgValue("VehicleHash", selectedItem.Car)

                If playerName = "Michael" AndAlso Active = "False" Then
                    Mechanic2.Michael_SendVehicle(selectedItem.Car, VehicleModel, VehicleHash, selectedItem, sender)
                ElseIf playerName = "Franklin" AndAlso Active = "False" Then
                    Mechanic2.Franklin_SendVehicle(selectedItem.Car, VehicleModel, VehicleHash, selectedItem, sender)
                ElseIf playerName = “Trevor" AndAlso Active = "False" Then
                    Mechanic2.Trevor_SendVehicle(selectedItem.Car, VehicleModel, VehicleHash, selectedItem, sender)
                ElseIf playerName = "Player3" AndAlso Active = "False" Then
                    Mechanic2.Player3_SendVehicle(selectedItem.Car, VehicleModel, VehicleHash, selectedItem, sender)
                End If
                My.Computer.Audio.Play(SoundPathDir & "mechanic_get_there_as_soon_as_i_can.wav", AudioPlayMode.Background)
            End If
            sender.Visible = False
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub PhoneMenuItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Select Case selectedItem.Text
            Case _Mechanic
                Call_Mechanic()
            Case _Pegasus
                Call_Pegasus(True)
            Case Website.BennysOriginal
                Website.Call_Benny()
            Case Website.DockTease
                Website.Call_DockTease()
            Case Website.ElitasTravel
                Website.Call_ElitasTravel()
            Case Website.LegendaryMotorsport
                Website.Call_Legendary()
            Case Website.PedalToMetal
                Website.Call_PedalToMetal()
            Case Website.SouthernSA
                Website.Call_SouthernSA()
            Case Website.WarstockCache
                Website.Call_Warstock()
        End Select
        sender.Visible = False
    End Sub

    Public Shared Sub TransVehItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            Dim TargetPathDir As String = Nothing
            Select Case selectedItem.Text
                Case itemAS3.Text
                    TargetPathDir = AltaPathDir
                Case itemIW4.Text
                    TargetPathDir = IntegrityPathDir
                Case itemIW4HL.Text
                    TargetPathDir = Integrity2PathDir
                Case itemDPH.Text
                    TargetPathDir = PerroPathDir
                Case itemDPHHL.Text
                    TargetPathDir = Perro2PathDir
                Case itemDT.Text
                    TargetPathDir = DreamPathDir
                Case itemET.Text
                    TargetPathDir = EclipsePathDir
                Case itemETHL.Text
                    TargetPathDir = Eclipse2PathDir
                Case itemRM.Text
                    TargetPathDir = RichardPathDir
                Case itemRMHL.Text
                    TargetPathDir = Richard2PathDir
                Case itemTT.Text
                    TargetPathDir = TinselPathDir
                Case itemTTHL.Text
                    TargetPathDir = Tinsel2PathDir
                Case itemWP.Text
                    TargetPathDir = WeazelPathDir
                Case itemVB.Text
                    TargetPathDir = VespucciPathDir
                Case itemNC2044.Text
                    TargetPathDir = NorthConker2044Dir
                Case itemHA2862.Text
                    TargetPathDir = HillcrestAve2862Dir
                Case itemHA2868.Text
                    TargetPathDir = HillcrestAve2868Dir
                Case itemWO3655.Text
                    TargetPathDir = WildOats3655Dir
                Case itemNC2045.Text
                    TargetPathDir = NorthConker2045Dir
                Case itemMR2117.Text
                    TargetPathDir = MiltonRoad2117Dir
                Case itemHA2874.Text
                    TargetPathDir = HillcrestAve2874Dir
                Case itemWD3677.Text
                    TargetPathDir = Whispymound3677Dir
                Case itemMW2113.Text
                    TargetPathDir = MadWayne2113Dri
                Case itemETP1.Text
                    TargetPathDir = EclipseP1PathDir
                Case itemETP2.Text
                    TargetPathDir = EclipseP2PathDir
                Case itemETP3.Text
                    TargetPathDir = EclipseP3PathDir
            End Select

            If IO.File.Exists(TargetPathDir & "vehicle_0.cfg") = False Then
                IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_0.cfg")
            Else
                If IO.File.Exists(TargetPathDir & "vehicle_1.cfg") = False Then
                    IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_1.cfg")
                Else
                    If IO.File.Exists(TargetPathDir & "vehicle_2.cfg") = False Then
                        IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_2.cfg")
                    Else
                        If IO.File.Exists(TargetPathDir & "vehicle_3.cfg") = False Then
                            IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_3.cfg")
                        Else
                            If IO.File.Exists(TargetPathDir & "vehicle_4.cfg") = False Then
                                IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_4.cfg")
                            Else
                                If IO.File.Exists(TargetPathDir & "vehicle_5.cfg") = False Then
                                    IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_5.cfg")
                                Else
                                    If IO.File.Exists(TargetPathDir & "vehicle_6.cfg") = False Then
                                        IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_6.cfg")
                                    Else
                                        If IO.File.Exists(TargetPathDir & "vehicle_7.cfg") = False Then
                                            IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_7.cfg")
                                        Else
                                            If IO.File.Exists(TargetPathDir & "vehicle_8.cfg") = False Then
                                                IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_8.cfg")
                                            Else
                                                If IO.File.Exists(TargetPathDir & "vehicle_9.cfg") = False Then
                                                    IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_9.cfg")
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            If SelectedGarage = "Ten" Then TenCarGarage.LoadGarageVechicles(Path)
            If SelectedGarage = "Six" Then SixCarGarage.LoadGarageVechicles(Path)
            sender.Visible = False
            GarageMenu.Visible = True
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub GrgMoveItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            MoveMenuSelectedItem = selectedItem.Text
            MoveMenuSelectedFile = selectedItem.Car
            MoveMenuSelectedIndex = index

            If selectedItem.Text <> GarageMenuSelectedItem Then
                If IO.File.Exists(Path & GarageMenuSelectedFile) = True AndAlso IO.File.Exists(Path & MoveMenuSelectedFile) = True Then
                    IO.File.Move(Path & GarageMenuSelectedFile, Path & "vehicle.cfg")
                    IO.File.Move(Path & MoveMenuSelectedFile, Path & GarageMenuSelectedFile)
                    IO.File.Move(Path & "vehicle.cfg", Path & MoveMenuSelectedFile)
                    If SelectedGarage = "Ten" Then TenCarGarage.LoadGarageVechicles(Path)
                    If SelectedGarage = "Six" Then SixCarGarage.LoadGarageVechicles(Path)
                    sender.Visible = False
                    GarageMenu.Visible = True
                Else
                    IO.File.Move(Path & GarageMenuSelectedFile, Path & MoveMenuSelectedFile)
                    If SelectedGarage = "Ten" Then TenCarGarage.LoadGarageVechicles(Path)
                    If SelectedGarage = "Six" Then SixCarGarage.LoadGarageVechicles(Path)
                    sender.Visible = False
                    GarageMenu.Visible = True
                End If
            Else
                sender.Visible = False
                GarageMenu.Visible = True
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub PegasusConfirmItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        If selectedItem.Text = PegasusDeliver Then
            Dim VehicleModel As String = ReadCfgValue("VehicleModel", PegasusSelectedVehicleFile)
            Dim VehicleHash As Integer = ReadCfgValue("VehicleHash", PegasusSelectedVehicleFile)

            If playerName = "Michael" Then
                If Not MPV = Nothing Then
                    MPV.CurrentBlip.Remove()
                    MPV.Delete()
                End If
                If VehicleModel = "" Then
                    MPV = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                Else
                    MPV = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                End If
                If MPV.ClassType = VehicleClass.Boats Then MPV.Position = Resources.GetPlayerZoneForBoat(playerPed)
                If MPV.ClassType = VehicleClass.Planes Then MPV.Position = Resources.GetPlayerZoneForPlane(playerPed)
                If MPV.ClassType = VehicleClass.Helicopters Then MPV.Position = Resources.GetPlayerZoneForHeli(playerPed)
                MPV.PlaceOnGround()
                MPV.AddBlip()
                If MPV.ClassType = VehicleClass.Boats Then
                    MPV.CurrentBlip.Sprite = BlipSprite.Boat
                ElseIf MPV.ClassType = VehicleClass.Helicopters Then
                    MPV.CurrentBlip.Sprite = BlipSprite.Helicopter
                ElseIf MPV.ClassType = VehicleClass.Utility
                    MPV.CurrentBlip.Sprite = BlipSprite.ArmoredTruck
                ElseIf MPV.ClassType = VehicleClass.Planes Then
                    MPV.CurrentBlip.Sprite = BlipSprite.Plane
                ElseIf MPV.ClassType = VehicleClass.Military Then
                    MPV.CurrentBlip.Sprite = BlipSprite.Tank
                Else
                    MPV.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                End If
                MPV.CurrentBlip.Color = BlipColor.Blue
                SetBlipName(MPV.FriendlyName, MPV.CurrentBlip)
                Mechanic2.SetModKit(MPV, PegasusSelectedVehicleFile)
                MPV.FreezePosition = True
            ElseIf playerName = "Franklin" Then
                If Not FPV = Nothing Then
                    FPV.CurrentBlip.Remove()
                    FPV.Delete()
                End If
                If VehicleModel = "" Then
                    FPV = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                Else
                    FPV = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                End If
                If FPV.ClassType = VehicleClass.Boats Then FPV.Position = Resources.GetPlayerZoneForBoat(playerPed)
                If FPV.ClassType = VehicleClass.Planes Then FPV.Position = Resources.GetPlayerZoneForPlane(playerPed)
                If FPV.ClassType = VehicleClass.Helicopters Then FPV.Position = Resources.GetPlayerZoneForHeli(playerPed)
                FPV.PlaceOnGround()
                FPV.AddBlip()
                If FPV.ClassType = VehicleClass.Boats Then
                    FPV.CurrentBlip.Sprite = BlipSprite.Boat
                ElseIf FPV.ClassType = VehicleClass.Helicopters Then
                    FPV.CurrentBlip.Sprite = BlipSprite.Helicopter
                ElseIf FPV.ClassType = VehicleClass.Utility
                    FPV.CurrentBlip.Sprite = BlipSprite.ArmoredTruck
                ElseIf FPV.ClassType = VehicleClass.Planes Then
                    FPV.CurrentBlip.Sprite = BlipSprite.Plane
                ElseIf FPV.ClassType = VehicleClass.Military Then
                    FPV.CurrentBlip.Sprite = BlipSprite.Tank
                Else
                    FPV.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                End If
                FPV.CurrentBlip.Color = BlipColor.Green
                SetBlipName(FPV.FriendlyName, FPV.CurrentBlip)
                Mechanic2.SetModKit(FPV, PegasusSelectedVehicleFile)
                FPV.FreezePosition = True
            ElseIf playerName = “Trevor" Then
                If Not TPV = Nothing Then
                    TPV.CurrentBlip.Remove()
                    TPV.Delete()
                End If
                If VehicleModel = "" Then
                    TPV = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                Else
                    TPV = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                End If
                If TPV.ClassType = VehicleClass.Boats Then TPV.Position = Resources.GetPlayerZoneForBoat(playerPed)
                If TPV.ClassType = VehicleClass.Planes Then TPV.Position = Resources.GetPlayerZoneForPlane(playerPed)
                If TPV.ClassType = VehicleClass.Helicopters Then TPV.Position = Resources.GetPlayerZoneForHeli(playerPed)
                TPV.PlaceOnGround()
                TPV.AddBlip()
                If TPV.ClassType = VehicleClass.Boats Then
                    TPV.CurrentBlip.Sprite = BlipSprite.Boat
                ElseIf TPV.ClassType = VehicleClass.Helicopters Then
                    TPV.CurrentBlip.Sprite = BlipSprite.Helicopter
                ElseIf TPV.ClassType = VehicleClass.Utility
                    TPV.CurrentBlip.Sprite = BlipSprite.ArmoredTruck
                ElseIf TPV.ClassType = VehicleClass.Planes Then
                    TPV.CurrentBlip.Sprite = BlipSprite.Plane
                ElseIf TPV.ClassType = VehicleClass.Military Then
                    TPV.CurrentBlip.Sprite = BlipSprite.Tank
                Else
                    TPV.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                End If
                TPV.CurrentBlip.Color = 17
                SetBlipName(TPV.FriendlyName, TPV.CurrentBlip)
                Mechanic2.SetModKit(TPV, PegasusSelectedVehicleFile)
                TPV.FreezePosition = True
            ElseIf playerName = "Player3" Then
                If Not PPV = Nothing Then
                    PPV.CurrentBlip.Remove()
                    PPV.Delete()
                End If
                If VehicleModel = "" Then
                    PPV = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                Else
                    PPV = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                End If
                If PPV.ClassType = VehicleClass.Boats Then PPV.Position = Resources.GetPlayerZoneForBoat(playerPed)
                If PPV.ClassType = VehicleClass.Planes Then PPV.Position = Resources.GetPlayerZoneForPlane(playerPed)
                If PPV.ClassType = VehicleClass.Helicopters Then PPV.Position = Resources.GetPlayerZoneForHeli(playerPed)
                PPV.PlaceOnGround()
                PPV.AddBlip()
                If PPV.ClassType = VehicleClass.Boats Then
                    PPV.CurrentBlip.Sprite = BlipSprite.Boat
                ElseIf PPV.ClassType = VehicleClass.Helicopters Then
                    PPV.CurrentBlip.Sprite = BlipSprite.Helicopter
                ElseIf PPV.ClassType = VehicleClass.Utility
                    PPV.CurrentBlip.Sprite = BlipSprite.ArmoredTruck
                ElseIf PPV.ClassType = VehicleClass.Planes Then
                    PPV.CurrentBlip.Sprite = BlipSprite.Plane
                ElseIf PPV.ClassType = VehicleClass.Military Then
                    PPV.CurrentBlip.Sprite = BlipSprite.Tank
                Else
                    PPV.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                End If
                PPV.CurrentBlip.Color = BlipColor.Yellow
                SetBlipName(PPV.FriendlyName, PPV.CurrentBlip)
                Mechanic2.SetModKit(PPV, PegasusSelectedVehicleFile)
                PPV.FreezePosition = True
            End If
            SinglePlayerApartment.player.Money = (playerCash - 200)
            My.Computer.Audio.Play(SoundPathDir & "pegasus_we_are_locating_a_suitable_drop_off_location.wav", AudioPlayMode.Background)
        ElseIf selectedItem.Text = PegasusDelete Then
            IO.File.Delete(PegasusSelectedVehicleFile)
            Call_Pegasus(False)
        End If
        sender.Visible = False
    End Sub

    Public Shared Sub PegasusItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        PegasusSelectedVehicleFile = selectedItem.Car
        sender.Visible = False
        PegasusConfirmMenu.Visible = Not PegasusConfirmMenu.Visible
    End Sub

    Public Shared Sub ItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            If sender Is GarageMenu AndAlso Not selectedItem.Text = "Empty" Then
                GarageMenuSelectedItem = selectedItem.Text
                GarageMenuSelectedFile = selectedItem.Car
            End If

            If selectedItem.Text = GrgRemove Then
                IO.File.Delete(Path & GarageMenuSelectedFile)
                If SelectedGarage = "Ten" Then TenCarGarage.LoadGarageVechicles(Path)
                If SelectedGarage = "Six" Then SixCarGarage.LoadGarageVechicles(Path)
                sender.Visible = False
                GarageMenu.Visible = True
            ElseIf selectedItem.Text = GrgRemoveAndDrive Then
                If SelectedGarage = "Ten" Then
                    If IO.File.Exists(Path & GarageMenuSelectedFile) Then
                        Game.FadeScreenOut(500)
                        Script.Wait(&H3E8)
                        Dim tempVeh As Vehicle
                        playerPed.Position = TenCarGarage.lastLocationGarageOutVector
                        If ReadCfgValue("VehicleModel", Path & GarageMenuSelectedFile) = "" Then
                            tempVeh = World.CreateVehicle(CInt(ReadCfgValue("VehicleHash", Path & GarageMenuSelectedFile)), TenCarGarage.lastLocationGarageOutVector)
                        Else
                            tempVeh = World.CreateVehicle(ReadCfgValue("VehicleModel", Path & GarageMenuSelectedFile), TenCarGarage.lastLocationGarageOutVector)
                        End If
                        tempVeh.Heading = TenCarGarage.lastLocationGarageOutHeading
                        Mechanic2.SetModKit(tempVeh, Path & GarageMenuSelectedFile)
                        tempVeh.MarkAsNoLongerNeeded()
                        playerPed.SetIntoVehicle(tempVeh, VehicleSeat.Driver)
                        IO.File.Delete(Path & GarageMenuSelectedFile)
                        World.DestroyAllCameras()
                        World.RenderingCamera = Nothing
                        sender.Visible = False
                        Script.Wait(500)
                        Game.FadeScreenIn(500)
                        TenCarGarage.ShowAllHiddenMapObject()
                        UnLoadMPDLCMap()
                    End If
                ElseIf SelectedGarage = "Six" Then
                    If IO.File.Exists(Path & GarageMenuSelectedFile) Then
                        Game.FadeScreenOut(500)
                        Script.Wait(&H3E8)
                        Dim tempVeh As Vehicle
                        playerPed.Position = SixCarGarage.lastLocationGarageOutVector
                        If ReadCfgValue("VehicleModel", Path & GarageMenuSelectedFile) = "" Then
                            tempVeh = World.CreateVehicle(CInt(ReadCfgValue("VehicleHash", Path & GarageMenuSelectedFile)), TenCarGarage.lastLocationGarageOutVector)
                        Else
                            tempVeh = World.CreateVehicle(ReadCfgValue("VehicleModel", Path & GarageMenuSelectedFile), SixCarGarage.lastLocationGarageOutVector)
                        End If
                        tempVeh.Heading = SixCarGarage.lastLocationGarageOutHeading
                        Mechanic2.SetModKit(tempVeh, Path & GarageMenuSelectedFile)
                        tempVeh.MarkAsNoLongerNeeded()
                        playerPed.SetIntoVehicle(tempVeh, VehicleSeat.Driver)
                        IO.File.Delete(Path & GarageMenuSelectedFile)
                        World.DestroyAllCameras()
                        World.RenderingCamera = Nothing
                        sender.Visible = False
                        Script.Wait(500)
                        Game.FadeScreenIn(500)
                        UnLoadMPDLCMap()
                    End If
                End If
            ElseIf selectedItem.Text = GrgSell Then
                Dim VehModel As String = ReadCfgValue("VehicleModel", Path & GarageMenuSelectedFile)
                Dim VehPrice As Integer = Resources.GetVehiclePrice(Path & GarageMenuSelectedFile)
                If VehPrice = 0 Then
                    UI.ShowSubtitle(GrgTooHot)
                Else
                    Select Case GarageMenuSelectedFile
                        Case "vehicle_0.cfg"
                            If SelectedGarage = "Ten" Then TenCarGarage.veh0.Delete() Else SixCarGarage.veh0.Delete()
                        Case "vehicle_1.cfg"
                            If SelectedGarage = "Ten" Then TenCarGarage.veh1.Delete() Else SixCarGarage.veh1.Delete()
                        Case "vehicle_2.cfg"
                            If SelectedGarage = "Ten" Then TenCarGarage.veh2.Delete() Else SixCarGarage.veh2.Delete()
                        Case "vehicle_3.cfg"
                            If SelectedGarage = "Ten" Then TenCarGarage.veh3.Delete() Else SixCarGarage.veh3.Delete()
                        Case "vehicle_4.cfg"
                            If SelectedGarage = "Ten" Then TenCarGarage.veh4.Delete() Else SixCarGarage.veh4.Delete()
                        Case "vehicle_5.cfg"
                            If SelectedGarage = "Ten" Then TenCarGarage.veh5.Delete() Else SixCarGarage.veh5.Delete()
                        Case "vehicle_6.cfg"
                            TenCarGarage.veh6.Delete()
                        Case "vehicle_7.cfg"
                            TenCarGarage.veh7.Delete()
                        Case "vehicle_8.cfg"
                            TenCarGarage.veh8.Delete()
                        Case "vehicle_9.cfg"
                            TenCarGarage.veh9.Delete()
                    End Select
                    SinglePlayerApartment.player.Money = (playerCash + VehPrice)
                    CreateGarageMenu(Path)
                    IO.File.Delete(Path & GarageMenuSelectedFile)
                    If SelectedGarage = "Ten" Then TenCarGarage.LoadGarageVechicles(Path)
                    If SelectedGarage = "Six" Then SixCarGarage.LoadGarageVechicles(Path)
                    sender.Visible = False
                    GarageMenu.Visible = True
                End If
            ElseIf selectedItem.Text = GrgMove Then
                CreateMoveMenu(Path, SelectedGarage)
                sender.Visible = False
                GrgMoveMenu.Visible = True
            ElseIf selectedItem.Text = GrgPlate Then
                Dim VehPlate As String = Game.GetUserInput(ReadCfgValue("PlateNumber", Path & GarageMenuSelectedFile), 9)
                If VehPlate <> "" Then
                    Select Case GarageMenuSelectedFile
                        Case "vehicle_0.cfg"
                            If SelectedGarage = "Ten" Then
                                TenCarGarage.veh0.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", TenCarGarage.veh0.NumberPlate, Path & GarageMenuSelectedFile)
                            Else
                                SixCarGarage.veh0.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", SixCarGarage.veh0.NumberPlate, Path & GarageMenuSelectedFile)
                            End If
                        Case "vehicle_1.cfg"
                            If SelectedGarage = "Ten" Then
                                TenCarGarage.veh1.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", TenCarGarage.veh1.NumberPlate, Path & GarageMenuSelectedFile)
                            Else
                                SixCarGarage.veh1.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", SixCarGarage.veh1.NumberPlate, Path & GarageMenuSelectedFile)
                            End If
                        Case "vehicle_2.cfg"
                            If SelectedGarage = "Ten" Then
                                TenCarGarage.veh2.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", TenCarGarage.veh2.NumberPlate, Path & GarageMenuSelectedFile)
                            Else
                                SixCarGarage.veh2.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", SixCarGarage.veh2.NumberPlate, Path & GarageMenuSelectedFile)
                            End If
                        Case "vehicle_3.cfg"
                            If SelectedGarage = "Ten" Then
                                TenCarGarage.veh3.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", TenCarGarage.veh3.NumberPlate, Path & GarageMenuSelectedFile)
                            Else
                                SixCarGarage.veh3.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", SixCarGarage.veh3.NumberPlate, Path & GarageMenuSelectedFile)
                            End If
                        Case "vehicle_4.cfg"
                            If SelectedGarage = "Ten" Then
                                TenCarGarage.veh4.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", TenCarGarage.veh4.NumberPlate, Path & GarageMenuSelectedFile)
                            Else
                                SixCarGarage.veh4.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", SixCarGarage.veh4.NumberPlate, Path & GarageMenuSelectedFile)
                            End If
                        Case "vehicle_5.cfg"
                            If SelectedGarage = "Ten" Then
                                TenCarGarage.veh5.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", TenCarGarage.veh5.NumberPlate, Path & GarageMenuSelectedFile)
                            Else
                                SixCarGarage.veh5.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", SixCarGarage.veh5.NumberPlate, Path & GarageMenuSelectedFile)
                            End If
                        Case "vehicle_6.cfg"
                            TenCarGarage.veh6.NumberPlate = VehPlate
                            WriteCfgValue("PlateNumber", TenCarGarage.veh6.NumberPlate, Path & GarageMenuSelectedFile)
                        Case "vehicle_7.cfg"
                            TenCarGarage.veh7.NumberPlate = VehPlate
                            WriteCfgValue("PlateNumber", TenCarGarage.veh7.NumberPlate, Path & GarageMenuSelectedFile)
                        Case "vehicle_8.cfg"
                            TenCarGarage.veh8.NumberPlate = VehPlate
                            WriteCfgValue("PlateNumber", TenCarGarage.veh8.NumberPlate, Path & GarageMenuSelectedFile)
                        Case "vehicle_9.cfg"
                            TenCarGarage.veh9.NumberPlate = VehPlate
                            WriteCfgValue("PlateNumber", TenCarGarage.veh9.NumberPlate, Path & GarageMenuSelectedFile)
                    End Select
                End If
                If SelectedGarage = "Ten" Then TenCarGarage.LoadGarageVechicles(Path)
                If SelectedGarage = "Six" Then SixCarGarage.LoadGarageVechicles(Path)
                sender.Visible = False
                GarageMenu.Visible = True
            ElseIf selectedItem.Text = GrgRename Then
                Dim VehName As String = Game.GetUserInput(ReadCfgValue("VehicleNick", Path & GarageMenuSelectedFile), 29)
                If VehName <> "" Then
                    WriteCfgValue("VehicleNick", VehName, Path & GarageMenuSelectedFile)
                End If
                If SelectedGarage = "Ten" Then TenCarGarage.LoadGarageVechicles(Path)
                If SelectedGarage = "Six" Then SixCarGarage.LoadGarageVechicles(Path)
                sender.Visible = False
                GarageMenu.Visible = True
            ElseIf selectedItem.Text = GrgTransfer Then
                CreateVehTransMenuApt()
                sender.Visible = False
                GrgTransMenu.Visible = True
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub ItemSelectHandler6CarGarage(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            If Not selectedItem.Text = "Empty" Then
                Select Case selectedItem.Car
                    Case "vehicle_0.cfg"
                        SixCarGarage.veh0.Delete()
                    Case "vehicle_1.cfg"
                        SixCarGarage.veh1.Delete()
                    Case "vehicle_2.cfg"
                        SixCarGarage.veh2.Delete()
                    Case "vehicle_3.cfg"
                        SixCarGarage.veh3.Delete()
                    Case "vehicle_4.cfg"
                        SixCarGarage.veh4.Delete()
                    Case "vehicle_5.cfg"
                        SixCarGarage.veh5.Delete()
                End Select
                IO.File.Delete(Path & selectedItem.Car)
                selectedItem.Text = "Empty"
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub PegasusConfirmMenuCloseHandler(sender As UIMenu)
        My.Computer.Audio.Play(SoundPathDir & "pegasus_for_your_future_transport_need.wav", AudioPlayMode.Background)
    End Sub

    Public Shared Sub CategoryMenuCloseHandler(sender As UIMenu)
        My.Computer.Audio.Play(SoundPathDir & "mechanic_get_back_to_work_then.wav", AudioPlayMode.Background)
    End Sub

    Public Shared Sub GrgMoveMenuCloseHandler(sender As UIMenu)
        GarageMenu2.Visible = True
    End Sub

    Public Shared Sub MenuCloseHandler(sender As UIMenu)
        World.DestroyAllCameras()
        World.RenderingCamera = Nothing
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            _menuPool.ProcessMenus()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub Call_Mechanic()
        AS3 = ReadCfgValue("3ASowner", saveFile)
        IW4 = ReadCfgValue("4IWowner", saveFile)
        IW4HL = ReadCfgValue("4IWHLowner", saveFile)
        DPH = ReadCfgValue("DPHwoner", saveFile)
        DPHHL = ReadCfgValue("DPHHLowner", saveFile)
        DT = ReadCfgValue("SSowner", saveFile)
        ET = ReadCfgValue("ETowner", saveFile)
        ETHL = ReadCfgValue("ETHLowner", saveFile)
        RM = ReadCfgValue("RMowner", saveFile)
        RMHL = ReadCfgValue("RMHLowner", saveFile)
        TT = ReadCfgValue("TTowner", saveFile)
        TTHL = ReadCfgValue("TTHLowner", saveFile)
        WP = ReadCfgValue("WPowner", saveFile)
        VB = ReadCfgValue("VPBowner", saveFile2)
        NC2044 = ReadCfgValue("2044NCowner", saveFile2)
        HA2862 = ReadCfgValue("2862HAowner", saveFile2)
        HA2868 = ReadCfgValue("2868HAowner", saveFile2)
        WO3655 = ReadCfgValue("3655WODowner", saveFile2)
        NC2045 = ReadCfgValue("2045NCowner", saveFile2)
        MR2117 = ReadCfgValue("2117MRowner", saveFile2)
        HA2874 = ReadCfgValue("2874HAowner", saveFile2)
        WD3677 = ReadCfgValue("3677WDowner", saveFile2)
        MW2113 = ReadCfgValue("2113MWTowner", saveFile2)
        ETP1 = ReadCfgValue("ETP1owner", saveFile2)
        ETP2 = ReadCfgValue("ETP2owner", saveFile2)
        ETP3 = ReadCfgValue("ETP3owner", saveFile2)

        itemAS3 = New UIMenuItem(_3AltaStreet._Name & _3AltaStreet.Unit)
        itemIW4 = New UIMenuItem(_4IntegrityWay._Name & _4IntegrityWay.Unit)
        itemIW4HL = New UIMenuItem(HL4IntegrityWay._Name & HL4IntegrityWay.Unit)
        itemDPH = New UIMenuItem(DelPerroHeight._Name & DelPerroHeight.Unit)
        itemDPHHL = New UIMenuItem(HLDelPerro._Name & HLDelPerro.Unit)
        itemDT = New UIMenuItem(DreamTower._Name & DreamTower.Unit)
        itemET = New UIMenuItem(EclipseTower._Name & EclipseTower.Unit)
        itemETHL = New UIMenuItem(HLEclipseTower._Name & HLEclipseTower.Unit)
        itemRM = New UIMenuItem(RichardMajestic._Name & RichardMajestic.Unit)
        itemRMHL = New UIMenuItem(HLRichardMajestic._Name & HLRichardMajestic.Unit)
        itemTT = New UIMenuItem(TinselTower._Name & TinselTower.Unit)
        itemTTHL = New UIMenuItem(HLTinselTower._Name & HLTinselTower.Unit)
        itemWP = New UIMenuItem(WeazelPlaza._Name & WeazelPlaza.Unit)
        itemVB = New UIMenuItem(VespucciBlvd._Name & VespucciBlvd.Unit)
        itemNC2044 = New UIMenuItem(NorthConker2044._Name & NorthConker2044.Unit)
        itemHA2862 = New UIMenuItem(HillcrestAve2862._Name & HillcrestAve2862.Unit)
        itemHA2868 = New UIMenuItem(HillcrestAve2868._Name & HillcrestAve2868.Unit)
        itemWO3655 = New UIMenuItem(WildOats3655._Name & WildOats3655.Unit)
        itemNC2045 = New UIMenuItem(NorthConker2045._Name & NorthConker2045.Unit)
        itemMR2117 = New UIMenuItem(MiltonRd2117._Name & MiltonRd2117.Unit)
        itemHA2874 = New UIMenuItem(HillcrestAve2874._Name & HillcrestAve2874.Unit)
        itemWD3677 = New UIMenuItem(Whispymound3677._Name & Whispymound3677.Unit)
        itemMW2113 = New UIMenuItem(MadWayne2113._Name & MadWayne2113.Unit)
        itemETP1 = New UIMenuItem(EclipseTowerPS1._Name & EclipseTowerPS1.Unit)
        itemETP2 = New UIMenuItem(EclipseTowerPS2._Name & EclipseTowerPS2.Unit)
        itemETP3 = New UIMenuItem(EclipseTowerPS3._Name & EclipseTowerPS3.Unit)

        CreateMechanicMenu()
        CreateVehMenuApartments(AS3Menu, itemAS3, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3_alta_street\")
        CreateVehMenuApartments(DTMenu, itemDT, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\dream_tower\")
        CreateVehMenuApartments(ETMenu, itemET, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower\")
        CreateVehMenuApartments(ETHLMenu, itemETHL, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_hl\")
        CreateVehMenuApartments(IW4Menu, itemIW4, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4_integrity_way\")
        CreateVehMenuApartments(IW4HLMenu, itemIW4HL, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4_integrity_way_hl\")
        CreateVehMenuApartments(DPHMenu, itemDPH, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\del_perro_heights\")
        CreateVehMenuApartments(DPHHLMenu, itemDPHHL, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\del_perro_heights_hl\")
        CreateVehMenuApartments(RMMenu, itemRM, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\richard_majestic\")
        CreateVehMenuApartments(RMHLMenu, itemRMHL, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\richard_majestic_hl\")
        CreateVehMenuApartments(TTMenu, itemTT, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\tinsel_tower\")
        CreateVehMenuApartments(TTHLMenu, itemTTHL, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\tinsel_tower_hl\")
        CreateVehMenuApartments(WPMenu, itemWP, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\weazel_plaza\")
        CreateVehMenuVespucciBlvd()
        CreateVehMenuApartments(NC2044Menu, itemNC2044, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2044_north_conker\")
        CreateVehMenuApartments(HA2862Menu, itemHA2862, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2862_hillcreast_ave\")
        CreateVehMenuApartments(HA2868Menu, itemHA2868, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2868_hillcrest_ave\")
        CreateVehMenuApartments(WO3655Menu, itemWO3655, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3655_wild_oats\")
        CreateVehMenuApartments(NC2045Menu, itemNC2045, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2045_north_conker\")
        CreateVehMenuApartments(MR2117Menu, itemMR2117, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2117_milton_road\")
        CreateVehMenuApartments(HA2874Menu, itemHA2874, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2874_hillcreast_ave\")
        CreateVehMenuApartments(WD3677Menu, itemWD3677, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\")
        CreateVehMenuApartments(MW2113Menu, itemMW2113, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2113_mad_wayne\")
        CreateVehMenuApartments(ETP1Menu, itemETP1, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps1\")
        CreateVehMenuApartments(ETP2Menu, itemETP2, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps2\")
        CreateVehMenuApartments(ETP3Menu, itemETP3, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps3\")

        MechanicMenu.Visible = Not MechanicMenu.Visible
        My.Computer.Audio.Play(SoundPathDir & "mechanic_u_need_something_huh.wav", AudioPlayMode.Background)
    End Sub

    Public Shared Sub Call_Pegasus(PlaySound As Boolean)
        Try
            Select Case playerName
                Case "Michael"
                    CreateMPegasusMenu()
                    MichaelPegasusMenu.Visible = True
                Case "Franklin"
                    CreateFPegasusMenu()
                    FranklinPegasusMenu.Visible = True
                Case "Trevor"
                    CreateTPegasusMenu()
                    TrevorPegasusMenu.Visible = True
                Case "Player3"
                    CreatePPegasusMenu()
                    Player3PegasusMenu.Visible = True
            End Select
            If PlaySound = True Then
                My.Computer.Audio.Play(SoundPathDir & "pegasus_how_can_i_help_u.wav", AudioPlayMode.Background)
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnKeyDown(o As Object, e As KeyEventArgs)
        If e.KeyCode = My.Settings.Mechanic AndAlso Not _menuPool.IsAnyMenuOpen() AndAlso Not Website._menuPool.IsAnyMenuOpen() Then
            PhoneMenu.Visible = Not PhoneMenu.Visible
        End If
    End Sub

    Protected Overrides Sub Dispose(A_0 As Boolean)
        If (A_0) Then
            Try
                If Not MPV0 = Nothing Then MPV0.Delete()
                If Not MPV1 = Nothing Then MPV1.Delete()
                If Not MPV2 = Nothing Then MPV2.Delete()
                If Not MPV3 = Nothing Then MPV3.Delete()
                If Not MPV4 = Nothing Then MPV4.Delete()
                If Not MPV5 = Nothing Then MPV5.Delete()
                If Not MPV6 = Nothing Then MPV6.Delete()
                If Not MPV7 = Nothing Then MPV7.Delete()
                If Not MPV8 = Nothing Then MPV8.Delete()
                If Not MPV9 = Nothing Then MPV9.Delete()
                If Not FPV0 = Nothing Then FPV0.Delete()
                If Not FPV1 = Nothing Then FPV1.Delete()
                If Not FPV2 = Nothing Then FPV2.Delete()
                If Not FPV3 = Nothing Then FPV3.Delete()
                If Not FPV4 = Nothing Then FPV4.Delete()
                If Not FPV5 = Nothing Then FPV5.Delete()
                If Not FPV6 = Nothing Then FPV6.Delete()
                If Not FPV7 = Nothing Then FPV7.Delete()
                If Not FPV8 = Nothing Then FPV8.Delete()
                If Not FPV9 = Nothing Then FPV9.Delete()
                If Not TPV0 = Nothing Then TPV0.Delete()
                If Not TPV1 = Nothing Then TPV1.Delete()
                If Not TPV2 = Nothing Then TPV2.Delete()
                If Not TPV3 = Nothing Then TPV3.Delete()
                If Not TPV4 = Nothing Then TPV4.Delete()
                If Not TPV5 = Nothing Then TPV5.Delete()
                If Not TPV6 = Nothing Then TPV6.Delete()
                If Not TPV7 = Nothing Then TPV7.Delete()
                If Not TPV8 = Nothing Then TPV8.Delete()
                If Not TPV9 = Nothing Then TPV9.Delete()
                If Not PPV0 = Nothing Then PPV0.Delete()
                If Not PPV1 = Nothing Then PPV1.Delete()
                If Not PPV2 = Nothing Then PPV2.Delete()
                If Not PPV3 = Nothing Then PPV3.Delete()
                If Not PPV4 = Nothing Then PPV4.Delete()
                If Not PPV5 = Nothing Then PPV5.Delete()
                If Not PPV6 = Nothing Then PPV6.Delete()
                If Not PPV7 = Nothing Then PPV7.Delete()
                If Not PPV8 = Nothing Then PPV8.Delete()
                If Not PPV9 = Nothing Then PPV9.Delete()
                If Not MPV = Nothing Then MPV.Delete()
                If Not FPV = Nothing Then FPV.Delete()
                If Not TPV = Nothing Then TPV.Delete()
                If Not PPV = Nothing Then PPV.Delete()
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
