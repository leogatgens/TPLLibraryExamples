Public Class DataGenerator
    Implements IDataGenerator
    Dim dt As DataTable

    Sub New()

        dt = New DataTable
        dt.Columns.Add("Id", GetType(Integer))
        dt.Columns.Add("FirstName", GetType(String))
        dt.Columns.Add("LastName", GetType(String))


    End Sub

    Public ReadOnly Property GenerarTablaConMilRegistros As List(Of FormulaCodificada) Implements IDataGenerator.GenerarTablaConMilRegistros
        Get
            Dim Formulas As New List(Of FormulaCodificada)
            For index = 1 To 300010
                Dim columnsCodes As List(Of String) = New List(Of String)

                columnsCodes.Add(String.Concat("AB_Codigo", index.ToString))
                columnsCodes.Add(String.Concat("CD_Codigo", index.ToString))
                columnsCodes.Add(String.Concat("EF_Codigo", index.ToString))
                columnsCodes.Add(String.Concat("HI_Codigo", index.ToString))
                columnsCodes.Add(String.Concat("KL_Codigo", index.ToString))
                columnsCodes.Add(String.Concat("TT_Codigo", index.ToString))

                columnsCodes.Add(String.Concat("LK_Codigo", index.ToString))
                columnsCodes.Add(String.Concat("PO_Codigo", index.ToString))
                columnsCodes.Add(String.Concat("WE_Codigo", index.ToString))
                columnsCodes.Add(String.Concat("QW_Codigo", index.ToString))


                Dim nuevoFormulaCodificada As New FormulaCodificada With {
                    .IdFormulaCodificada = index,
                    .Descripcion = "Descripcin Prueba",
                    .Celda = String.Concat("A", index.ToString),
                    .Codes = columnsCodes
                }

                Formulas.Add(nuevoFormulaCodificada)

            Next



            Return Formulas
        End Get
    End Property


End Class

