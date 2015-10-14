Imports JHSoftware.SimpleDNS.Plugin

Friend Class MyConfigIP

  Friend IPv4 As IPAddressV4
  Friend IPv6 As IPAddressV6
  Friend TTL As Integer

  Shared Function Load(ByVal config As String) As MyConfigIP
    Dim rv As New MyConfigIP
    Dim sa = config.Split("|"c)
    rv.IPv4 = If(sa(1) = "-", Nothing, IPAddressV4.Parse(sa(1)))
    rv.IPv6 = If(sa(2) = "-", Nothing, IPAddressV6.Parse(sa(2)))
    rv.TTL = Integer.Parse(sa(3))
    Return rv
  End Function

  Function Save() As String
    Return "1|" & _
           If(IPv4 Is Nothing, "-", IPv4.ToString) & "|" & _
           If(IPv6 Is Nothing, "-", IPv6.ToString) & "|" & _
           TTL.ToString
  End Function

End Class

Friend Class MyConfigHost
  Friend HostName As String
  Friend CNAME As Boolean
  Friend MX As Boolean
  Friend NS As Boolean
  Friend PTR As Boolean
  Friend TTL As Integer

  Shared Function Load(ByVal config As String) As MyConfigHost
    Dim sa = PipeDecode(config)
    Dim rv As New MyConfigHost
    rv.HostName = sa(1)
    rv.CNAME = (sa(2) = "Y")
    rv.MX = (sa(3) = "Y")
    rv.NS = (sa(4) = "Y")
    rv.PTR = (sa(5) = "Y")
    rv.TTL = Integer.Parse(sa(6))
    Return rv
  End Function

  Function Save() As String
    Return "1|" & _
           PipeEncode(HostName) & "|" & _
           If(CNAME, "Y", "N") & "|" & _
           If(MX, "Y", "N") & "|" & _
           If(NS, "Y", "N") & "|" & _
           If(PTR, "Y", "N") & "|" & _
           TTL.ToString
  End Function

End Class