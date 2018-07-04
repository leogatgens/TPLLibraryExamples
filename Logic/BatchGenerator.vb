Public Class BatchGenerator
    Public ReadOnly batches As List(Of List(Of FormulaCodificada))

    Private Const MaxBatchSize As Integer = 100

    Private ReadOnly Property BatchCount As Integer








    Public Sub New(ByVal bigData As List(Of FormulaCodificada))
        BatchCount = bigData.Count / MaxBatchSize
        batches = GenerateBatches(bigData)


    End Sub

    Private Function GenerateBatches(ByVal bigData As List(Of FormulaCodificada)) As List(Of List(Of FormulaCodificada))

        Dim batches As New List(Of List(Of FormulaCodificada))

        For index = 0 To BatchCount - 1
            Dim skipSize As Integer = CalculateSkip(index)
            Dim tempList = bigData.Skip(skipSize).Take(MaxBatchSize).ToList()
            batches.Add(tempList)
        Next

        Return batches

    End Function

    Private Function CalculateSkip(ByVal index As Integer) As Integer

        Return index * MaxBatchSize

    End Function




End Class
