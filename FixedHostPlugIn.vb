Imports JHSoftware.SimpleDNS.Plugin

Public Class FixedHostPlugIn
  Implements IGetAnswerPlugIn

  Dim cfg As MyConfigHost
  Dim cfgHNDom As JHSoftware.SimpleDNS.Plugin.DomainName

#Region "events"
  Public Event LogLine(ByVal text As String) Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.LogLine
  Public Event SaveConfig(ByVal config As String) Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.SaveConfig
  Public Event AsyncError(ByVal ex As System.Exception) Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.AsyncError
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

  Public Function GetPlugInTypeInfo() As JHSoftware.SimpleDNS.Plugin.IPlugInBase.PlugInTypeInfo Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.GetPlugInTypeInfo
    With GetPlugInTypeInfo
      .Name = "Fixed Host Name"
      .Description = "Returns a fixed host name"
      .InfoURL = "http://www.simpledns.com/kb.aspx?kbid=1263"
      .ConfigFile = False
      .MultiThreaded = True
    End With
  End Function

  Public Sub LoadConfig(ByVal config As String, ByVal instanceID As Guid, ByVal dataPath As String, ByRef maxThreads As Integer) Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.LoadConfig
    cfg = MyConfigHost.Load(config)
    cfgHNDom = JHSoftware.SimpleDNS.Plugin.DomainName.Parse(cfg.HostName)
  End Sub

  Public Function GetDNSAskAbout() As JHSoftware.SimpleDNS.Plugin.DNSAskAbout Implements JHSoftware.SimpleDNS.Plugin.IGetAnswerPlugIn.GetDNSAskAbout
    If Not cfg.CNAME Then
      Dim lst As New List(Of DNSRRType)
      If cfg.MX Then lst.Add(DNSRRType.Parse("MX"))
      If cfg.NS Then lst.Add(DNSRRType.Parse("NS"))
      If cfg.PTR Then lst.Add(DNSRRType.Parse("PTR"))
      GetDNSAskAbout.RRTypes = lst.ToArray
    End If
  End Function

  Public Function GetOptionsUI(ByVal instanceID As Guid, ByVal dataPath As String) As JHSoftware.SimpleDNS.Plugin.OptionsUI Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.GetOptionsUI
    Return New FixedHostUI
  End Function

  Public Function Lookup(ByVal request As JHSoftware.SimpleDNS.Plugin.IDNSRequest) As JHSoftware.SimpleDNS.Plugin.DNSAnswer Implements JHSoftware.SimpleDNS.Plugin.IGetAnswerPlugIn.Lookup
    If cfg.CNAME Then
      If request.QName = cfgHNDom Then Return Nothing
      Dim rec As New DNSRecord
      rec.Name = request.QName
      rec.RRType = 5US 'CNAME
      rec.Data = cfg.HostName
      rec.TTL = cfg.TTL
      Dim rv As New DNSAnswer
      rv.Records.Add(rec)
      Return rv
    Else
      Dim rec As New DNSRecord
      rec.Name = request.QName
      rec.RRType = request.QType
      rec.TTL = cfg.TTL
      If request.QType = 15US Then
        'MX
        rec.Data = "10 " & cfg.HostName
      Else
        'NS,PTR
        rec.Data = cfg.HostName
      End If
      Dim rv As New DNSAnswer
      rv.Records.Add(rec)
      Return rv
    End If
  End Function

End Class
