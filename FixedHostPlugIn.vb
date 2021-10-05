Imports System.Threading.Tasks
Imports JHSoftware.SimpleDNS.Plugin

Public Class FixedHostPlugIn
  Implements IGetAnswerPlugIn

  Dim cfg As MyConfigHost
  Dim cfgHNDom As JHSoftware.SimpleDNS.DomName

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

#End Region

  Public Function GetPlugInTypeInfo() As JHSoftware.SimpleDNS.Plugin.IPlugInBase.PlugInTypeInfo Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.GetPlugInTypeInfo
    With GetPlugInTypeInfo
      .Name = "Fixed Host Name"
      .Description = "Returns a fixed host name"
      .InfoURL = "https://simpledns.plus/kb/175/fixed-host-name-plug-in"
    End With
  End Function

  Public Sub LoadConfig(config As String, instanceID As Guid, dataPath As String) Implements IPlugInBase.LoadConfig
    cfg = MyConfigHost.Load(config)
    cfgHNDom = JHSoftware.SimpleDNS.DomName.Parse(cfg.HostName)
  End Sub

  Public Function GetOptionsUI(ByVal instanceID As Guid, ByVal dataPath As String) As JHSoftware.SimpleDNS.Plugin.OptionsUI Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.GetOptionsUI
    Return New FixedHostUI
  End Function

  Private Function Lookup(request As IDNSRequest) As Task(Of DNSAnswer) Implements IGetAnswerPlugIn.Lookup
    If cfg.CNAME Then
      If request.QName = cfgHNDom Then Return Task.FromResult(Of DNSAnswer)(Nothing)
      Dim rec As New DNSRecord With {
        .Name = request.QName,
        .RRType = JHSoftware.SimpleDNS.DNSRecType.CNAME,
        .Data = cfg.HostName,
        .TTL = cfg.TTL
      }
      Dim rv As New DNSAnswer
      rv.RecordsAnswer.Add(rec)
      Return Task.FromResult(rv)
    ElseIf (cfg.MX AndAlso request.QType = DNSRecType.MX) OrElse
           (cfg.NS AndAlso request.QType = DNSRecType.NS) OrElse
           (cfg.PTR AndAlso request.QType = DNSRecType.PTR) Then
      Dim rec As New DNSRecord With {
        .Name = request.QName,
        .RRType = request.QType,
        .TTL = cfg.TTL
      }
      If request.QType = DNSRecType.MX Then
        'MX
        rec.Data = "10 " & cfg.HostName
      Else
        'NS,PTR
        rec.Data = cfg.HostName
      End If
      Dim rv As New DNSAnswer
      rv.RecordsAnswer.Add(rec)
      Return Task.FromResult(rv)
    Else
      Return Task.FromResult(Of DNSAnswer)(Nothing)
    End If
  End Function

End Class
