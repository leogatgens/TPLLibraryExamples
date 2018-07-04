Public Class DataGenerator
    Dim dt As DataTable

    Sub New()

        dt = New DataTable
        dt.Columns.Add("Id", GetType(Integer))
        dt.Columns.Add("FirstName", GetType(String))
        dt.Columns.Add("LastName", GetType(String))


    End Sub

    Public ReadOnly Property TableOneThousandItems As List(Of FormulaCodificada)
        Get
            Dim Formulas As New List(Of FormulaCodificada)
            For index = 1 To 1000
                Dim nuevoFormulaCodificada As New FormulaCodificada With {
                    .IdFormulaCodificada = index,
                    .Descripcion = "Descripcin Prueba",
                    .Celda = String.Concat("A", index.ToString),
                    .Codigo1 = String.Concat("Codigo", index.ToString),
                    .Codigo2 = String.Concat("Codigo", index.ToString),
                    .Codigo3 = String.Concat("Codigo", index.ToString),
                    .Codigo4 = String.Concat("Codigo", index.ToString),
                    .Codigo5 = String.Concat("Codigo", index.ToString),
                    .Codigo6 = String.Concat("Codigo", index.ToString),
                    .Codigo7 = String.Concat("Codigo", index.ToString),
                    .Codigo8 = String.Concat("Codigo", index.ToString),
                    .Codigo9 = String.Concat("Codigo", index.ToString),
                    .Codigo10 = String.Concat("Codigo", index.ToString)
                }

                Formulas.Add(nuevoFormulaCodificada)

            Next



            Return Formulas
        End Get
    End Property
End Class

