﻿Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Reflection
Imports System.Windows.Forms
Imports SinglePlayerApartment.SinglePlayerApartment
Imports PDMCarShopGUI
Imports SinglePlayerApartment.Wardrobe

Public Class HLEclipseTower
    Inherits Script

    Public Shared Owner As String = ReadCfgValue("ETHLowner", saveFile)
    Public Shared _Name As String = "Eclipse Tower Apt. "
    Public Shared Desc As String = "Perfectly proportioned, beautifully presented lateral living opportunity on exquisite Eclipse Blvd. This apartment is as unique as the new cheekbones your surgeon just gave you... by that we mean you'll see them all over town. Includes a 10-car garage."
    Public Shared Unit As String = "3"
    Public Shared Cost As Integer = 800000
    Public Shared Save As Vector3 = New Vector3(-793.2186, 332.4132, 210.7966)
    Public Shared Teleport As Vector3 = New Vector3(-774.3142, 323.8076, 212.0325)
    Public Shared Teleport2 As Vector3 = New Vector3(-773.282, 312.275, 84.698)
    Public Shared _Exit As Vector3 = New Vector3(-777.6211, 323.5111, 211.9974)
    Public Shared Wardrobe As Vector3 = New Vector3(-793.4239, 326.7805, 210.7966)
    Public Shared WardrobeDistance As Single
    Public Shared SaveDistance As Single
    Public Shared ExitDistance As Single
    Public Shared WardrobeHeading As Single = 356.4841

    Public Shared ExitMenu As UIMenu
    Public Shared _menuPool As MenuPool

    Public Sub New()
        Try
            If ReadCfgValue("EclipseTower", settingFile) = "Enable" Then
                _Name = ReadCfgValue("EclipseHLName", langFile)
                Desc = ReadCfgValue("EclipseHLDesc", langFile)
                Garage = ReadCfgValue("Garage", langFile)
                AptOptions = ReadCfgValue("AptOptions", langFile)
                ExitApt = ReadCfgValue("ExitApt", langFile)
                SellApt = ReadCfgValue("SellApt", langFile)
                EnterGarage = ReadCfgValue("EnterGarage", langFile)
                GrgOptions = ReadCfgValue("GrgOptions", langFile)
                ForSale = ReadCfgValue("ForSale", langFile)
                PropPurchased = ReadCfgValue("PropPurchased", langFile)
                Maze = ReadCfgValue("Maze", langFile)
                Fleeca = ReadCfgValue("Fleeca", langFile)
                BOL = ReadCfgValue("BOL", langFile)
                InsFundApartment = ReadCfgValue("InsFundApartment", langFile)
                EnterApartment = ReadCfgValue("EnterApartment", langFile)
                SaveGame = ReadCfgValue("SaveGame", langFile)
                ExitApartment = ReadCfgValue("ExitApartment", langFile)
                ChangeClothes = ReadCfgValue("ChangeClothes", langFile)
                _EnterGarage = ReadCfgValue("_EnterGarage", langFile)
                CannotStore = ReadCfgValue("CannotStore", langFile)

                AddHandler Tick, AddressOf OnTick
                AddHandler KeyDown, AddressOf OnKeyDown

                _menuPool = New MenuPool()
                CreateExitMenu()
                AddHandler ExitMenu.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler ExitMenu.OnItemSelect, AddressOf ItemSelectHandler
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateExitMenu()
        Try
            ExitMenu = New UIMenu("", AptOptions, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            ExitMenu.SetBannerType(Rectangle)
            _menuPool.Add(ExitMenu)
            ExitMenu.AddItem(New UIMenuItem(ExitApt))
            ExitMenu.AddItem(New UIMenuItem(EnterGarage))
            ExitMenu.AddItem(New UIMenuItem(SellApt))
            ExitMenu.RefreshIndex()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub MenuCloseHandler(sender As UIMenu)
        Try
            hideHud = False
            World.DestroyAllCameras()
            World.RenderingCamera = Nothing
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            If selectedItem.Text = ExitApt Then
                'Exit Apt
                ExitMenu.Visible = False
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = Teleport2
                Script.Wait(500)
                Game.FadeScreenIn(500)
                UnLoadMPDLCMap()
                EclipseTower.IsAtHome = False
            ElseIf selectedItem.Text = SellApt Then
                'Sell Apt
                ExitMenu.Visible = False
                WriteCfgValue("ETHLowner", "None", saveFile)
                SavePosition2()
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SinglePlayerApartment.player.Money = (playerCash + Cost)
                Owner = "None"
                EclipseTower._Blip.Remove()
                If Not EclipseTower.Blip2 Is Nothing Then EclipseTower.Blip2.Remove()
                EclipseTower.CreateEclipseTower()
                Game.Player.Character.Position = Teleport2
                Script.Wait(500)
                Game.FadeScreenIn(500)
                EclipseTower.RefreshMenu()
                EclipseTower.RefreshGarageMenu()
                UnLoadMPDLCMap()
                EclipseTower.IsAtHome = False
            ElseIf selectedItem.Text = EnterGarage Then
                'Enter Garage
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SetInteriorActive2(222.592, -968.1, -99) '10 car garage
                playerPed.Position = TenCarGarage.Elevator
                TenCarGarage.LastLocationName = _Name & Unit
                TenCarGarage.lastLocationVector = _Exit
                TenCarGarage.lastLocationGarageVector = EclipseTower._Garage
                TenCarGarage.lastLocationGarageOutVector = EclipseTower.GarageOut
                TenCarGarage.lastLocationGarageOutHeading = EclipseTower.GarageOutHeading
                TenCarGarage.LoadGarageVechicles(Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_hl\")
                TenCarGarage.CurrentPath = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_hl\"
                ExitMenu.Visible = False
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            If ReadCfgValue("EclipseTower", settingFile) = "Enable" Then
                SaveDistance = World.GetDistance(playerPed.Position, Save)
                ExitDistance = World.GetDistance(playerPed.Position, _Exit)
                WardrobeDistance = World.GetDistance(playerPed.Position, Wardrobe)

                'Save Game
                If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso SaveDistance < 3.0 AndAlso Owner = playerName Then
                    DisplayHelpTextThisFrame(SaveGame)
                End If

                If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso ExitDistance < 2.0 AndAlso Owner = playerName Then
                    DisplayHelpTextThisFrame(ExitApartment & _Name & Unit)
                End If

                If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso WardrobeDistance < 1.0 AndAlso Owner = playerName Then
                    DisplayHelpTextThisFrame(ChangeClothes)
                End If

                'Controls
                If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso ExitDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead Then
                    ExitMenu.Visible = True
                End If

                If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso SaveDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso Owner = playerName Then
                    'Press E on hleclipse Bed
                    playerMap = "EclipseHL"
                    Game.FadeScreenOut(500)
                    Script.Wait(&H3E8)
                    TimeLapse(8)
                    Game.ShowSaveMenu()
                    SavePosition()
                    Script.Wait(500)
                    Game.FadeScreenIn(500)
                End If

                If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso WardrobeDistance < 1.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso Owner = playerName Then
                    WardrobeVector = Wardrobe
                    WardrobeHead = WardrobeHeading
                    If playerName = "Michael" Then
                        Player0W.Visible = True
                        MakeACamera()
                    ElseIf playerName = "Franklin" Then
                        Player1W.Visible = True
                        MakeACamera()
                    ElseIf playerName = “Trevor"
                        Player2W.Visible = True
                        MakeACamera()
                    ElseIf playerName = "Player3" Then
                        If playerHash = "1885233650" Then
                            Player3_MW.Visible = True
                            MakeACamera()
                        ElseIf playerHash = "-1667301416" Then
                            Player3_FW.Visible = True
                            MakeACamera()
                        End If
                    End If
                End If
                'End Controls

                _menuPool.ProcessMenus()
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnKeyDown(o As Object, e As KeyEventArgs)
        Try

        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Protected Overrides Sub Dispose(A_0 As Boolean)
        If (A_0) Then
            Try

            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
