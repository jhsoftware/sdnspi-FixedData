Imports System.Threading.Tasks
Imports JHSoftware.SimpleDNS
Imports JHSoftware.SimpleDNS.Plugin

Public Class FixedIpPlugIn
  Implements JHSoftware.SimpleDNS.Plugin.IGetHostPlugIn

  Dim cfg As MyConfigIP

  Public Property Host As IHost Implements IPlugInBase.Host

#Region "not implemented"

  Public Function InstanceConflict(ByVal config1 As String, ByVal config2 As String, ByRef errorMsg As String) As Boolean Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.InstanceConflict
    Return False
  End Function

  Public Sub LoadState(ByVal state As String) Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.LoadState
  End Sub

  Public Function SaveState() As String Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.SaveState
    Return ""
  End Function

  Public Sub StopService() Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.StopService
  End Sub

  Private Function StartService() As Task Implements IPlugInBase.StartService
    Return Task.CompletedTask
  End Function

  Public Function Signal(code As Integer, data As Object) As Task(Of Object) Implements IPlugInBase.Signal
    Return Task.FromResult(Of Object)(Nothing)
  End Function

  Public Function LookupReverse(ip As SdnsIP, req As IDNSRequest) As Task(Of IGetHostPlugIn.Result(Of DomName)) Implements IGetHostPlugIn.LookupReverse
    Return Task.FromResult(Of IGetHostPlugIn.Result(Of DomName))(Nothing)
  End Function

  Public Function LookupTXT(req As IDNSRequest) As Task(Of IGetHostPlugIn.Result(Of String)) Implements IGetHostPlugIn.LookupTXT
    Return Task.FromResult(Of IGetHostPlugIn.Result(Of String))(Nothing)
  End Function
#End Region

  Public Function GetPlugInTypeInfo() As JHSoftware.SimpleDNS.Plugin.IPlugInBase.PlugInTypeInfo Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.GetPlugInTypeInfo
    With GetPlugInTypeInfo
      .Name = "Fixed IP Address"
      .Description = "Returns a fixed IP address"
      .InfoURL = "https://simpledns.plus/kb/176/fixed-ip-address-plug-in"
    End With
  End Function

  Public Function Lookup(req As IDNSRequest) As Task(Of IGetHostPlugIn.Result(Of SdnsIP)) Implements IGetHostPlugIn.Lookup
    If req.QType = DNSRecType.A AndAlso cfg.IPv4 IsNot Nothing Then
      Return Task.FromResult(New IGetHostPlugIn.Result(Of SdnsIP) With {.Value = cfg.IPv4, .TTL = cfg.TTL})
    ElseIf req.QType = DNSRecType.AAAA AndAlso cfg.IPv6 IsNot Nothing Then
      Return Task.FromResult(New IGetHostPlugIn.Result(Of SdnsIP) With {.Value = cfg.IPv6, .TTL = cfg.TTL})
    End If
    Return Task.FromResult(Of IGetHostPlugIn.Result(Of SdnsIP))(Nothing)
  End Function

  Public Function GetOptionsUI(instanceID As Guid, dataPath As String) As JHSoftware.SimpleDNS.Plugin.OptionsUI Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.GetOptionsUI
    Return New FixedIPUI
  End Function

  Public Sub LoadConfig(config As String, instanceID As Guid, dataPath As String) Implements IPlugInBase.LoadConfig
    cfg = MyConfigIP.Load(config)
  End Sub

End Class
