Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Dim bounds As MapStitcherLibrary.Geo.LatLngBounds
            bounds.NorthEast = New MapStitcherLibrary.Geo.LatLng(CDbl(NE_Latitude.Text), CDbl(NE_Longitude.Text))
            bounds.SouthWest = New MapStitcherLibrary.Geo.LatLng(CDbl(SW_Latitude.Text), CDbl(SW_Longitude.Text))

            Dim job As New MapStitcherLibrary.StitchJob(bounds, CInt(Zoom.Text))


            Dim ms As New MemoryStream()
            job.Image.Save(ms, ImageFormat.Png)

            Dim base64Data As String = Convert.ToBase64String(ms.ToArray())
            result.ImageUrl = "data:image/gif;base64," + base64Data

        End If
    End Sub

End Class
