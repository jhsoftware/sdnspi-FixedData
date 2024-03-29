﻿Imports System.Threading.Tasks
Imports JHSoftware.SimpleDNS
Imports JHSoftware.SimpleDNS.Plugin

Public Class FixedIpPlugIn
  Implements JHSoftware.SimpleDNS.Plugin.ILookupHost
  Implements IOptionsUI

  Dim cfg As MyConfigIP

  Public Property Host As IHost Implements IPlugInBase.Host

#Region "not implemented"

  Public Function InstanceConflict(ByVal config1 As String, ByVal config2 As String, ByRef errorMsg As String) As Boolean Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.InstanceConflict
    Return False
  End Function

  Public Sub StopService() Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.StopService
  End Sub

  Private Function StartService() As Task Implements IPlugInBase.StartService
    Return Task.CompletedTask
  End Function

#End Region

  Public Function GetPlugInTypeInfo() As TypeInfo Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.GetTypeInfo
    With GetPlugInTypeInfo
      .Name = "Fixed IP Address"
      .Description = "Returns a fixed IP address"
      .InfoURL = "https://simpledns.plus/plugin-fixedip"
    End With
  End Function

  Public Function Lookup(name As DomName, ipv6 As Boolean, req As IRequestContext) As Task(Of LookupResult(Of SdnsIP)) Implements ILookupHost.LookupHost
    If Not ipv6 AndAlso cfg.IPv4 IsNot Nothing Then
      Return Task.FromResult(New LookupResult(Of SdnsIP) With {.Value = cfg.IPv4, .TTL = cfg.TTL})
    ElseIf ipv6 AndAlso cfg.IPv6 IsNot Nothing Then
      Return Task.FromResult(New LookupResult(Of SdnsIP) With {.Value = cfg.IPv6, .TTL = cfg.TTL})
    End If
    Return Task.FromResult(Of LookupResult(Of SdnsIP))(Nothing)
  End Function

  Public Function GetOptionsUI(instanceID As Guid, dataPath As String) As JHSoftware.SimpleDNS.Plugin.OptionsUI Implements JHSoftware.SimpleDNS.Plugin.IOptionsUI.GetOptionsUI
    Return New FixedIPUI
  End Function

  Public Sub LoadConfig(config As String, instanceID As Guid, dataPath As String) Implements IPlugInBase.LoadConfig
    cfg = MyConfigIP.Load(config)
  End Sub

End Class
