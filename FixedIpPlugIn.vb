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
  Public Sub LookupReverse(ByVal req As JHSoftware.SimpleDNS.Plugin.IDNSRequest, ByRef resultName As JHSoftware.SimpleDNS.Plugin.DomainName, ByRef resultTTL As Integer) Implements JHSoftware.SimpleDNS.Plugin.IGetHostPlugIn.LookupReverse
    Throw New NotSupportedException
  End Sub

  Public Sub LookupTXT(ByVal req As JHSoftware.SimpleDNS.Plugin.IDNSRequest, ByRef resultText As String, ByRef resultTTL As Integer) Implements JHSoftware.SimpleDNS.Plugin.IGetHostPlugIn.LookupTXT
    Throw New NotSupportedException
  End Sub

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

  Public Function GetPlugInTypeInfo() As JHSoftware.SimpleDNS.Plugin.IPlugInBase.PlugInTypeInfo Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.GetPlugInTypeInfo
    With GetPlugInTypeInfo
      .Name = "Fixed IP Address"
      .Description = "Returns a fixed IP address"
      .InfoURL = "http://www.simpledns.com/plugin-fixedip"
      .ConfigFile = False
      .MultiThreaded = True
    End With
  End Function

  Public Function GetDNSAskAbout() As JHSoftware.SimpleDNS.Plugin.DNSAskAboutGH Implements JHSoftware.SimpleDNS.Plugin.IGetHostPlugIn.GetDNSAskAbout
    GetDNSAskAbout = New DNSAskAboutGH
    With GetDNSAskAbout
      .ForwardIPv4 = (cfg.IPv4 IsNot Nothing)
      .ForwardIPv6 = (cfg.IPv6 IsNot Nothing)
    End With
  End Function

  Public Sub Lookup(ByVal req As JHSoftware.SimpleDNS.Plugin.IDNSRequest, ByRef resultIP As JHSoftware.SimpleDNS.Plugin.IPAddress, ByRef resultTTL As Integer) Implements JHSoftware.SimpleDNS.Plugin.IGetHostPlugIn.Lookup
    If req.QType = 1US Then
      resultIP = cfg.IPv4
    Else
      resultIP = cfg.IPv6
    End If
    resultTTL = cfg.TTL
  End Sub

  Public Function GetOptionsUI(ByVal instanceID As Guid, ByVal dataPath As String) As JHSoftware.SimpleDNS.Plugin.OptionsUI Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.GetOptionsUI
    Return New FixedIPUI
  End Function

  Public Sub LoadConfig(ByVal config As String, ByVal instanceID As Guid, ByVal dataPath As String, ByRef maxThreads As Integer) Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.LoadConfig
    cfg = MyConfigIP.Load(config)
  End Sub

End Class
