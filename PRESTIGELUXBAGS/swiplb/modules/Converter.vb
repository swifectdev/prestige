Imports System.IO

Class Converter
    Public Shared Function GetBytes(ByVal imageIn As System.Drawing.Image) As Byte()
        Using ms = New MemoryStream()
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            Return ms.ToArray()
        End Using
    End Function

    Public Shared Function GetBytes(ByVal path As String) As Byte()
        Using ms = New MemoryStream()
            Dim img As Image = Image.FromFile(path)
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            Return ms.ToArray()
        End Using
    End Function

    Public Shared Function GetImage(ByVal buffer As Byte()) As Image
        Using ms = New MemoryStream(buffer)
            Return Image.FromStream(ms)
        End Using
    End Function
End Class
