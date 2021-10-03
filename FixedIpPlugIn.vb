Imports System.Threading.Tasks
Imports JHSoftware.SimpleDNS
Imports JHSoftware.SimpleDNS.Plugin

Public Class FixedIpPlugIn
  Implements JHSoftware.SimpleDNS.Plugin.IGetHostPlugIn

  Dim cfg As MyConfigIP

#Region "events"
  Public Event AsyncError(ByVal ex As System.Exception) Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.AsyncError
  Public Event LogLine(ByVal text As String) Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.LogLine
  Public Event SaveConfig(ByVal config As String) Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.SaveConfig
#End Region

#Region "not implemented"

  Public Function InstanceConflict(ByVal config1 As String, ByVal config2 As String, ByRef errorMsg As String) As Boolean Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.InstanceConflict
    Return False
  End Function

  Public Sub LoadState(ByVal state As String) Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.LoadState
  End Sub

  Public Function SaveState() As String Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.SaveState
    Return ""
  End Function

  Public Sub StartService() Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.StartService
  End Sub

  Public Sub StopService() Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.StopService
  End Sub
#End Region

  Public Function LookupReverse(ip As SdnsIP, req As IDNSRequest) As Task(Of IGetHostPlugIn.Result(Of DomName)) Implements IGetHostPlugIn.LookupReverse
    Return Task.FromResult(Of IGetHostPlugIn.Result(Of DomName))(Nothing)
  End Function

  Public Function LookupTXT(req As IDNSRequest) As Task(Of IGetHostPlugIn.Result(Of String)) Implements IGetHostPlugIn.LookupTXT
    Return Task.FromResult(Of IGetHostPlugIn.Result(Of String))(Nothing)
  End Function

  Public Function GetPlugInTypeInfo() As JHSoftware.SimpleDNS.Plugin.IPlugInBase.PlugInTypeInfo Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.GetPlugInTypeInfo
    With GetPlugInTypeInfo
      .Name = "Fixed IP Address"
      .Description = "Returns a fixed IP address"
      .InfoURL = "https://simpledns.plus/kb/176/fixed-ip-address-plug-in"
    End With
  End Function

  Public Function Lookup(req As IDNSRequest) As Task(Of IGetHostPlugIn.Result(Of SdnsIP)) Implements IGetHostPlugIn.Lookup
    Return Task.FromResult(New IGetHostPlugIn.Result(Of SdnsIP) With {.Value = If(req.QType = DNSRecType.A, cfg.IPv4, cfg.IPv6), .TTL = cfg.TTL})
  End Function

  Public Function GetOptionsUI(instanceID As Guid, dataPath As String) As JHSoftware.SimpleDNS.Plugin.OptionsUI Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.GetOptionsUI
    Return New FixedIPUI
  End Function

  Public Sub LoadConfig(config As String, instanceID As Guid, dataPath As String) Implements IPlugInBase.LoadConfig
    cfg = MyConfigIP.Load(config)
  End Sub

End Class
