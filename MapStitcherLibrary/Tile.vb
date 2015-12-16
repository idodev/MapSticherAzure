Namespace Map
    Public Class Tile

        Public Const Pixels As Integer = 256

        Public Property X As Decimal
        Public Property Y As Decimal
        Public Property Zoom As Integer

        Public ReadOnly Property Xint As Integer
            Get
                Return Math.Floor(X)
            End Get
        End Property

        Public ReadOnly Property Yint As Integer
            Get
                Return Math.Floor(Y)
            End Get
        End Property



        Public Shared Function FromLatLng(ByVal ll As Geo.LatLng, ByVal Zoom As Integer) As Tile
            Dim t As New Tile
            With t
                .Zoom = Zoom
                .X = (((ll.Longitude + 180) / 360) * Math.Pow(2, .Zoom))
                .Y = ((1 - Math.Log(Math.Tan(DegreeToRadian(ll.Latitude)) + 1 / Math.Cos(DegreeToRadian(ll.Latitude))) / Math.PI) / 2 * Math.Pow(2, .Zoom))
            End With
            Return t
        End Function

        Public Function LatLngBounds() As Geo.LatLngBounds
            ' calculate the north east and south west extremities of this tile

        End Function
    End Class


    Public Class TileRow
        Inherits List(Of Tile)

    End Class

    Public Class TileSet
        Inherits List(Of TileRow)

        Public Property NorthEastTile As Tile
        Public Property SouthWestTile As Tile

        Public Sub New(ByVal Bounds As Geo.LatLngBounds, ByVal Zoom As Integer)

            NorthEastTile = Tile.FromLatLng(Bounds.NorthEast, Zoom)
            SouthWestTile = Tile.FromLatLng(Bounds.SouthWest, Zoom)

            For y As Integer = SouthWestTile.Yint To NorthEastTile.Yint Step IIf(SouthWestTile.Yint > NorthEastTile.Yint, -1, 1)
                Dim row As New TileRow
                For x As Integer = NorthEastTile.Xint To SouthWestTile.Xint Step IIf(NorthEastTile.Xint > SouthWestTile.Xint, -1, 1)
                    row.Add(New Tile() With {.X = x, .Y = y, .Zoom = Zoom})
                Next
                Me.Add(row)
            Next

        End Sub
    End Class

End Namespace
