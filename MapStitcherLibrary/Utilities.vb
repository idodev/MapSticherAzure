Module Utilities
    Function DegreeToRadian(ByVal Angle As Double) As Double
        Return Math.PI * Angle / 180.0
    End Function

    Function RadianToDegree(ByVal angle As Double) As Double
        Return angle * (180.0 / Math.PI)
    End Function


End Module
