'Function Chau_Fasman(ByRef fasta As String)
'    Dim helix_beta_array(fasta.Length) As Integer 'This array contains the positions of the beta helices. 
'    Dim helix_array(fasta.Length) As Integer 'This array contains the positions of the alpha helices. Size of the fasta. 
'    Dim scores As New Dictionary(Of Char, Integer)
'    Dim helix_display(fasta.Length) As Char
'    Dim helix_beta_display(fasta.Length) As Char ' array holding the beta helices.
'    scores.Add("A", 0)
'    scores.Add("R", 1)
'    scores.Add("N", 2)
'    scores.Add("D", 3)
'    scores.Add("Q", 4)
'    scores.Add("E", 5)
'    scores.Add("G", 6)
'    scores.Add("H", 7)
'    scores.Add("L", 8)
'    scores.Add("K", 9)
'    scores.Add("M", 10)
'    scores.Add("F", 11)
'    scores.Add("S", 12)
'    scores.Add("T", 13)
'    scores.Add("W", 14)
'    scores.Add("Y", 15)
'    scores.Add("C", 16)
'    scores.Add("I", 17)
'    scores.Add("P", 18)
'    scores.Add("V", 19)

'    Dim alpha_matrix = New Double() {142, 98, 101, 67, 70, 151, 111, 57, 100, 108, 121, 114, 145, 113, 57, 77, 83, 108, 69, 106}
'    Dim beta_matrix = New Double() {83, 93, 54, 89, 119, 37, 110, 75, 87, 160, 130, 74, 105, 138, 55, 75, 119, 137, 147, 170}
'    Dim turn_matrix = New Double() {66, 95, 146, 156, 119, 74, 98, 156, 95, 47, 59, 101, 60, 60, 152, 143, 96, 96, 114, 50}
'    Dim function_i = New Double() {0.06, 0.07, 0.147, 0.161, 0.149, 0.056, 0.074, 0.102, 0.14, 0.043, 0.061, 0.055, 0.068, 0.059, 0.102, 0.12, 0.086, 0.077, 0.082, 0.062}
'    Dim function_i1 = New Double() {0.076, 0.106, 0.11, 0.083, 0.05, 0.06, 0.098, 0.085, 0.047, 0.034, 0.025, 0.115, 0.082, 0.041, 0.301, 0.139, 0.108, 0.013, 0.065, 0.048}
'    Dim function_i2 = New Double() {0.035, 0.099, 0.179, 0.191, 0.117, 0.077, 0.037, 0.19, 0.093, 0.013, 0.036, 0.072, 0.014, 0.065, 0.034, 0.125, 0.065, 0.064, 0.114, 0.028}
'    Dim function_i3 = New Double() {0.058, 0.085, 0.081, 0.091, 0.128, 0.064, 0.098, 0.152, 0.054, 0.056, 0.07, 0.095, 0.055, 0.065, 0.068, 0.106, 0.079, 0.167, 0.125, 0.053}

'    Dim alpha_array(fasta.Length) As Double
'    Dim beta_array(fasta.Length) As Double
'    Dim turn_array(fasta.Length) As Double

'    Dim count As Integer = 0
'    Dim myChar As Char
'    DataTables.Helices.AppendText("Alpha Helices: ")

'    Using Str As StringReader = New StringReader(fasta)
'        Do While count < fasta.Length
'            myChar = fasta(count)
'            If scores.ContainsKey(myChar) Then
'                Dim num As Integer = scores.Item(myChar)
'                alpha_array(count) = alpha_matrix(num)
'                beta_array(count) = beta_matrix(num)
'                turn_array(count) = turn_matrix(num)
'                count = count + 1
'            End If
'        Loop
'    End Using
'    'This is for the alpha helix'
'    Dim count_4 As Integer = 0
'    For indexA = 0 To fasta.Length - 6
'        For indexB = 0 To 6
'            If alpha_array(indexA + indexB) > 100 Then
'                count_4 = count_4 + 1
'                If count_4 = 4 Then
'                    'IndexA is the left side of the center. IndexB is the right side of the helix.'
'                    Extendfunc_alpha_left(indexA, indexB, alpha_array, beta_array, fasta, helix_array)
'                    Extendfunc_alpha_right(indexA, indexB, alpha_array, beta_array, fasta, helix_array)
'                End If
'            End If
'            If alpha_array(indexA + indexB) < 100 Then
'                count_4 = 0
'            End If
'        Next
'        count_4 = 0
'    Next
'    For x = 0 To helix_array.Length - 1
'        If helix_array(x).Equals(1) = False Then
'            helix_array(x) = 0
'        End If
'    Next

'    For x = 0 To helix_array.Length - 1
'        If helix_array(x) = 1 Then
'            DataTables.Helices.AppendText(fasta(x))
'            helix_display(x) = fasta(x)
'        End If
'        If helix_array(x) <> 1 Then
'            helix_display(x) = "_"
'            DataTables.Helices.AppendText("_")
'        End If
'    Next

'    'This is for the beta sheets'
'    DataTables.Helices.AppendText(Environment.NewLine)
'    DataTables.Helices.AppendText("Beta_Sheet:")

'    Dim count_3 As Integer = 0
'    For indexA = 0 To fasta.Length - 5
'        For indexB = 0 To 5
'            If beta_array(indexA + indexB) > 100 Then
'                count_3 = count_3 + 1
'                If count_3 = 3 Then
'                    'IndexA is the left side of the center. IndexB is the right side of the helix.'
'                    Extendfunc_beta_left(indexA, indexB, alpha_array, beta_array, fasta, helix_beta_array)
'                    Extendfunc_beta_right(indexA, indexB, alpha_array, beta_array, fasta, helix_beta_array)
'                End If
'            End If
'            If beta_array(indexA + indexB) < 100 Then
'                count_3 = 0
'            End If
'        Next
'        count_3 = 0
'    Next
'    For x = 0 To fasta.Length - 1
'        If helix_beta_array(x).Equals(1) = False Then
'            helix_beta_array(x) = 0
'        End If
'    Next
'    DataTables.Helices.AppendText(Environment.NewLine)
'    For x = 0 To fasta.Length - 1
'        If helix_beta_array(x) = 1 Then
'            DataTables.Helices.AppendText(fasta(x))
'            helix_beta_display(x) = fasta(x)
'        End If
'        If helix_array(x) <> 1 Then
'            helix_beta_display(x) = "_"
'            DataTables.Helices.AppendText("_")
'        End If
'    Next
'End Function
'Function Extendfunc_beta_left(ByVal indexA As Integer, ByVal indexB As Integer, ByRef alpha_array() As Double, ByRef beta_array() As Double, ByRef fasta As String, ByRef helix_array() As Integer)
'    Dim sum_avg_alpha As Integer = 0
'    Dim sum_avg_beta As Integer = 0
'    Dim residue_count As Integer = 0 ' Total amount of residues at the end of the helix
'    Dim indexD As Integer = 0 'End of the helix'
'    Dim indexC As Integer = indexA
'    Dim total_avg_alpha As Double = 0
'    Dim total_avg_beta As Double = 0
'    Dim count_residue = 0

'    While indexC <> 0
'        'Extend from indexA behind region. Note that there are two conditionals to declaring the end of the helix
'        For indexD = 1 To 4
'            If (indexC - indexD) <= 0 Then
'                Exit For
'            End If
'            If (indexC - indexD) > 0 Then
'                sum_avg_alpha = (alpha_array(indexC - indexD) + sum_avg_alpha)
'                sum_avg_beta = (beta_array(indexC - indexD) + sum_avg_beta)
'                residue_count = residue_count + 1
'                total_avg_beta = 0
'                total_avg_alpha = 0
'                count_residue = 0
'                If residue_count >= 4 Then 'This calculates the total residue value from beginning to supposed end
'                    While count_residue <> residue_count
'                        total_avg_alpha = total_avg_alpha + alpha_array(indexA - count_residue)
'                        total_avg_beta = total_avg_beta + beta_array(indexA - count_residue)
'                        count_residue = count_residue + 1
'                    End While
'                    If total_avg_beta / residue_count > total_avg_alpha / residue_count And total_avg_beta / residue_count > 105 Then
'                        For x = (indexA - residue_count) To indexA
'                            helix_array(x) = 1
'                        Next
'                        Exit Function
'                    End If
'                End If
'            End If
'        Next
'        If sum_avg_beta / indexD < 100 And sum_avg_beta <> 0 Then
'            For x = (indexA - residue_count) To indexA
'                helix_array(x) = 1
'            Next
'            Exit Function
'        End If
'        sum_avg_alpha = 0
'        sum_avg_beta = 0
'        indexC = indexC - 1
'    End While
'End Function
'Function Extendfunc_beta_right(ByVal indexA As Integer, ByVal indexB As Integer, ByRef alpha_array() As Double, ByRef beta_array() As Double, ByRef fasta As String, ByRef helix_array() As Integer)
'    'Extend from IndexA + IndexB ahead of the region

'    Dim residue_count As Integer = 0 ' Total amount of residues at the end of the helix
'    Dim indexD As Integer = 0 'End of the helix'
'    Dim indexC As Integer = indexA
'    Dim count_residue = 0
'    Dim sum_avg_alpha1 As Integer = 0
'    Dim sum_avg_beta1 As Integer = 0
'    Dim total_avg_alpha1 As Double = 0
'    Dim total_avg_beta1 As Double = 0

'    While indexC <> fasta.Length
'        For indexD = 1 To 3
'            If (indexC + indexD) >= fasta.Length Then
'                Exit For
'            End If
'            If (indexC + indexD) < fasta.Length Then
'                sum_avg_alpha1 = (alpha_array(indexC + indexD) + sum_avg_alpha1)
'                sum_avg_beta1 = (beta_array(indexC + indexD) + sum_avg_beta1)
'                residue_count = residue_count + 1
'                total_avg_beta1 = 0
'                total_avg_alpha1 = 0
'                count_residue = 0

'                If residue_count >= 4 Then 'This calculates the total residue value from beginning to supposed end
'                    While count_residue <> residue_count
'                        total_avg_alpha1 = total_avg_alpha1 + alpha_array(indexA + count_residue - 1)
'                        total_avg_beta1 = total_avg_beta1 + beta_array(indexA + count_residue)
'                        count_residue = count_residue + 1
'                    End While
'                    If total_avg_alpha1 / residue_count < total_avg_beta1 / residue_count And total_avg_beta1 / residue_count > 105 Then
'                        'End of helix declared' This conditional is used if the residue count from center to left end is > 5
'                        For x = indexA To (indexA + residue_count)
'                            helix_array(x) = 1
'                        Next
'                        Exit Function
'                    End If
'                End If
'            End If
'        Next
'        If sum_avg_beta1 / indexD < 100 And sum_avg_beta1 <> 0 Then
'            For x = indexA To (indexA + residue_count)
'                helix_array(x) = 1
'            Next
'            Exit Function
'        End If
'        sum_avg_alpha1 = 0
'        sum_avg_beta1 = 0
'        indexC = indexC + 1
'    End While
'End Function
'Function Extendfunc_alpha_left(ByVal indexA As Integer, ByVal indexB As Integer, ByRef alpha_array() As Double, ByRef beta_array() As Double, ByRef fasta As String, ByRef helix_array() As Integer)
'    Dim sum_avg_alpha As Integer = 0
'    Dim sum_avg_beta As Integer = 0
'    Dim residue_count As Integer = 0 ' Total amount of residues at the end of the helix
'    Dim indexD As Integer = 0 'End of the helix'
'    Dim indexC As Integer = indexA
'    Dim total_avg_alpha As Double = 0
'    Dim total_avg_beta As Double = 0
'    Dim count_residue = 0

'    While indexC <> 0
'        'Extend from indexA behind region. Note that there are two conditionals to declaring the end of the helix
'        For indexD = 1 To 4
'            If (indexC - indexD) <= 0 Then
'                Exit For
'            End If
'            If (indexC - indexD) > 0 Then
'                sum_avg_alpha = (alpha_array(indexC - indexD) + sum_avg_alpha)
'                sum_avg_beta = (beta_array(indexC - indexD) + sum_avg_beta)
'                residue_count = residue_count + 1
'                total_avg_beta = 0
'                total_avg_alpha = 0
'                count_residue = 0
'                If residue_count >= 5 Then 'This calculates the total residue value from beginning to supposed end
'                    While count_residue <> residue_count
'                        total_avg_alpha = total_avg_alpha + alpha_array(indexA - count_residue)
'                        total_avg_beta = total_avg_beta + beta_array(indexA - count_residue)
'                        count_residue = count_residue + 1
'                    End While
'                    If total_avg_alpha / residue_count > total_avg_beta / residue_count Then
'                        For x = (indexA - residue_count) To indexA
'                            helix_array(x) = 1
'                        Next
'                        Exit Function
'                    End If
'                End If
'            End If
'        Next
'        If sum_avg_alpha / indexD < 100 And sum_avg_alpha <> 0 Then
'            For x = (indexA - residue_count) To indexA
'                helix_array(x) = 1
'            Next
'            Exit Function
'        End If
'        sum_avg_alpha = 0
'        sum_avg_beta = 0
'        indexC = indexC - 1
'    End While
'End Function
'Function Extendfunc_alpha_right(ByVal indexA As Integer, ByVal indexB As Integer, ByRef alpha_array() As Double, ByRef beta_array() As Double, ByRef fasta As String, ByRef helix_array() As Integer)
'    'Extend from IndexA + IndexB ahead of the region

'    Dim residue_count As Integer = 0 ' Total amount of residues at the end of the helix
'    Dim indexD As Integer = 0 'End of the helix'
'    Dim indexC As Integer = indexA
'    Dim count_residue = 0
'    Dim sum_avg_alpha1 As Integer = 0
'    Dim sum_avg_beta1 As Integer = 0
'    Dim total_avg_alpha1 As Double = 0
'    Dim total_avg_beta1 As Double = 0

'    While indexC <> fasta.Length
'        For indexD = 1 To 4
'            If (indexC + indexD) >= fasta.Length Then
'                Exit For
'            End If
'            If (indexC + indexD) < fasta.Length Then
'                sum_avg_alpha1 = (alpha_array(indexC + indexD) + sum_avg_alpha1)
'                sum_avg_beta1 = (beta_array(indexC + indexD) + sum_avg_beta1)
'                residue_count = residue_count + 1
'                total_avg_beta1 = 0
'                total_avg_alpha1 = 0
'                count_residue = 0

'                If residue_count >= 5 Then 'This calculates the total residue value from beginning to supposed end
'                    While count_residue <> residue_count
'                        total_avg_alpha1 = total_avg_alpha1 + alpha_array(indexA + count_residue)
'                        total_avg_beta1 = total_avg_beta1 + beta_array(indexA + count_residue)
'                        count_residue = count_residue + 1
'                    End While
'                    If total_avg_alpha1 / residue_count > total_avg_beta1 / residue_count Then
'                        'End of helix declared' This conditional is used if the residue count from center to left end is > 5
'                        For x = indexA To (indexA + residue_count)
'                            helix_array(x) = 1
'                        Next
'                        Exit Function
'                    End If
'                End If
'            End If
'        Next
'        If sum_avg_alpha1 / indexD < 100 And sum_avg_alpha1 <> 0 Then
'            For x = indexA To (indexA + residue_count)
'                helix_array(x) = 1
'            Next
'            Exit Function
'        End If
'        sum_avg_alpha1 = 0
'        sum_avg_beta1 = 0
'        indexC = indexC + 1
'    End While
'End Function