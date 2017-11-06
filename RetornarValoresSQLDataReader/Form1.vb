Imports System.Data.SqlClient
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Creacion de la Cadena de Conexion
        Dim builder As New SqlConnectionStringBuilder
        builder("Data Source") = "SERVIDOR01\SQLEXPRESS"
        builder("Integrated Security") = True
        builder("Initial Catalog") = "AdventureWorks2012"

        ' Obtener mas de un valor de una tabla

        Using connection As New SqlConnection(builder.ConnectionString)

            Dim command As SqlCommand = New SqlCommand("Select DepartmentID, Name From HumanResources.Department", connection)
            connection.Open()

            Dim reader As SqlDataReader = command.ExecuteReader()

            If reader.HasRows Then
                Do While reader.Read()
                    MsgBox(reader.GetValue(0) & vbTab & reader.GetString(1))
                Loop

            End If
            reader.Close()



        End Using
    End Sub

End Class
