Imports System.Net
Imports MaxMind.GeoIP2
Imports MaxMind.GeoIP2.Responses

Public Class Form1
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim ipValue As String = txtIp.Text
        Dim flags As String = Application.StartupPath & "\flags"
        If IsValidIP(ipValue) Then
            Using dbRead As New DatabaseReader(Application.StartupPath & "\GeoLite2-Country.mmdb")
                Dim cr As CountryResponse = dbRead.Country(ipValue)
                Dim img As Image = Image.FromFile($"{flags}\{cr.Country.IsoCode.ToLower}.png")
                imgList.Images.Add(cr.Country.IsoCode, img)
                Dim lv As New ListViewItem({cr.Country.Name, cr.Country.IsoCode, cr.Country.GeoNameId})
                lv.ImageKey = cr.Country.IsoCode
                ListView1.Items.Add(lv)
            End Using
        Else
            MessageBox.Show("Invalid IP")


        End If
    End Sub
    Private Function IsValidIP(address As String) As Boolean
        Return IPAddress.TryParse(address, New IPAddress(0))
    End Function
End Class
