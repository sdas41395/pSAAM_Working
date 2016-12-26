Public Class Current_PDB
    Public sequence As String
    Public pdb_id As String
    Public pdb_describe As String
    Public pdb_chains As String
    Public pdb_structure As String
    Public pdb_BLAST As String
    Public pdb_relation As String
End Class




'Class to hold relevant sequence information'
Public Class Sequence
    Public Fasta_Info As String
    Public total_hydropathy As Integer
    Public total_sequence As String
    Public sequence_no_title As String
    Public sequence_length As Integer
    Public Name As String

    'Scoring from the hydropathy indices inputted based on character from fasta
    Public Sequence_Hydropathy_Array(sequence_length) As Double
    'This is the points holder -amino acid residues. Note every instance of a sequence aquires one. Update function still available. 
    Public points_list As New Sequence_Points(sequence_length)
    'The hydrophobic region. 1's are hydrophobic and 0's are not
    Public Hydrophobic_array(sequence_length) As Integer

    'Points for hydropathy graph handling'
    Public starting_point_x As Double
    Public starting_point_y As Double
    Public end_point_x As Double
    Public end_point_y As Double

    'For chau fasman prediction arrays'
    Public alpha_helix(sequence_length) As Integer
    Public beta_sheet(sequence_length) As Integer
    Public score_array_alpha(sequence_length) As Double
    Public score_array_beta(sequence_length) As Double
    'how to set and get sequence'
    Property Sequence_Return() As String
        Get
            Return total_sequence
        End Get
        Set(ByVal value As String)
            total_sequence = value
        End Set
    End Property

    ReadOnly Property Name_Return() As String
        Get
            Return Name
        End Get
    End Property

    Public Sub New(ByRef sequnce_ As String, ByVal Name_ As String)
        total_sequence = sequnce_
        Name = Name_
    End Sub

End Class

Public Class List_Sequences
    Public sequence_array(list_length) As Sequence
    Public sequence_name_array(list_length) As String
    Public list_length As Integer
    Public current_amount As Integer = 0
    'Which indices have been chosen and stored. Note it does not store all only the selected one. 
    Public scores_chosen As New Dictionary(Of Char, Double)
    Public Sub New(ByVal size As Integer)
        list_length = size
    End Sub

    WriteOnly Property Redimension() As Integer
        Set(value As Integer)
            ReDim Preserve sequence_array(value)
            list_length = value
        End Set
    End Property

End Class

Public Class Global_List
    '5 to begin with. Update functions available. This class just presents the sequence list and the 1 sequence point holder to the user. 
    Public Shared sequence_list As New List_Sequences(5)
End Class

Public Class Scoring_Indices
    Public Shared Kyte_Doolittle As Boolean = False
    Public Shared Rose As Boolean = False
    Public Shared hopp_woods As Boolean = False
    Public Shared Eisenberg As Boolean = False
    Public Shared Cornette As Boolean = False
    Public Shared Janin As Boolean = False
    Public Shared Engelmann As Boolean = False
End Class
'Array class to hold relevant information regarding the data structure for points-aminoacids. Note this is one sequence
Public Class Sequence_Points
    Public current_size As Integer = capacity
    Public capacity As Integer
    Public Sub New(ByVal fasta_length As Integer)
        capacity = fasta_length
    End Sub
    Public Sequence(capacity) As Point
    Default Property Amino_Acid_Count(indexA As Integer) As Point
        Get
            Return Sequence(indexA)
        End Get
        Set(value As Point)
            Sequence(indexA) = value
        End Set
    End Property
    'Default redimension property Really wont be needed' 'never mind its needed to set the length of the point array equal to the fasta length'
    ReadOnly Property Redimension(fasta_length As Integer) As Integer
        Get
            ReDim Preserve Sequence(fasta_length)
            capacity = fasta_length
            If Sequence.Length <> fasta_length Then
                Return 0
            End If
            Return 1
        End Get
    End Property
End Class
Public Class Point
    Public Residue_ As Char
    Public Hydropathy_Score As Double
    Public Allotted_Span As Integer
    Public Region As Char
    Public Hydropathy_Position_x As Single
    Public Hydropathy_Position_y As Single
    Public Chau_Position_x_alpha As Single
    Public Chau_Position_y_alpha As Single
    Public Chau_Position_x_sheet As Single
    Public Chau_Position_y_sheet As Single
    Public Sub New(ByVal Residue_Char As Char)
        Residue_ = Residue_Char
    End Sub
End Class
'______________________________________________________________________'
'                                   Neural Net
'______________________________________________________________________
Public Class Perceptron_List
    'Hidden Layer after input layer'
    'input layer will contain the scores from the MSA's and Chau Fasman algorithm'
    'Okay so its a directed graph. Input nodes and output nodes. 
    Public sequence_length As Single
    'This layer will hold all the nodes in a list. Each amino acid residue will hold a node
    'Its the directed graph. Note that there this an output list
    Public First_layer(sequence_length) As Perceptron_Node_residue
    Public Calculating_layer(6) As Perceptron_Structure
    'Note that the output list will connect to the input list of the hidden scoring layer
    'The input and output list are just held as positions in the directed graph. 
    Public input_list() As Integer
    Public Ouput_List() As Integer
End Class
'First example is going to be looking at alpha helices. 
Public Class Perceptron_Node_residue
    Public sequence_length As Single
    Public Threshold_ As Single
    'The connections being made are just positions. Its not a linked list. 
    Public input As Char
    Public local_window_alpha As Integer = 6
    Public local_window_beta As Single = 5
    Public input_weight_list(sequence_length) As Integer
    Public current_input_position As Single = 0

    Public output_ As Single
    Public answer_ As Char
    'Assigning 
    ReadOnly Property Output_Calculator() As Integer
        Get
            Dim total_weight As Integer = 0
            For indexA = 0 To input_list.Length - 1
                total_weight = weight_ * input_list(indexA)
            Next
            If total_weight > Threshold_ Then
                output_ = -1
            End If
            If total_weight < Threshold_ Then
                output_ = 1
            End If
        End Get
    End Property
    WriteOnly Property Insert_Input(value_ As Integer)
        Set(value)
            input_list(current_input_position + 1) = value_
            current_input_position = current_input_position + 1
        End Set
    End Property
    'Training manual'
    WriteOnly Property Guess_(value_ As Integer)
        Set(value)
            If answer_ <> value_ Then

            End If
        End Set
    End Property

End Class
Public Class Perceptron_Structure

End Class





