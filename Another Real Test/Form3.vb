Imports System.IO
Imports System.Windows.Forms.DataVisualization.Charting
Imports System
Imports System.Drawing
Imports System.Drawing.Graphics
Imports System.Drawing.Point
Public Class Form3
    '_________________________________________________________________________________

    '                                       Function List 
    '_________________________________________________________________________________ 
    'Function to solve the Helical amphipathy. Modeled after pSAAM'


    'Function to caluclate the moment using the eisenberg algorithm
    'For alpha-helix, angles in the range 90 - 100o are appropriate; for 310-helix, use 120o;
    'For extended chains (sheets), use 160 - 180o. 
    'High values calculated Using 0o As the residue rotation angle show the occurrence Of 
    'successive residues Of similar index value. The geometrical structural information 
    'On which these suggestions are based can be found 
    'In any standard text On protein Structure
    Function Eisenberg_Moment(ByRef sequence As String) As Integer
        'Calculations done using the mean hydrophobic moment. 

    End Function

    '4P Turnes'
    'Chou-Fasman Algorithm
    'Position turn dependent indices to test probability of turns'
    '2 smooths with a span of 3;
    Function Chau_Fasman_4PTurns(ByRef sequence As String) As Integer

    End Function
    'Function to calculate the hydropathy
    Function Hydropathy(ByVal fasta As String)

        'Scores being updated and added to their own unique dictionary. Upon choosing index the boolean values are set
        Dim scores As New Dictionary(Of Char, Double)
        Dim scores_hopp_woods As New Dictionary(Of Char, Double)
        Dim scores_Cornette As New Dictionary(Of Char, Double)
        Dim scores_Eisenberg As New Dictionary(Of Char, Double)
        Dim scores_Rose As New Dictionary(Of Char, Double)
        Dim scores_Janinn As New Dictionary(Of Char, Double)
        Dim scores_Engelman As New Dictionary(Of Char, Double)


        'Updating scoring dictionaries. Note that scores refers to kyle doolittle
        scores.Add("A", 1.8)
        scores.Add("R", -4.5)
        scores.Add("N", -3.5)
        scores.Add("D", -3.5)
        scores.Add("Q", -3.5)
        scores.Add("E", -3.5)
        scores.Add("G", -0.4)
        scores.Add("H", -3.2)
        scores.Add("L", 3.8)
        scores.Add("K", -3.9)
        scores.Add("M", 1.9)
        scores.Add("F", 2.8)
        scores.Add("S", -0.8)
        scores.Add("T", -0.7)
        scores.Add("W", -0.9)
        scores.Add("Y", -1.3)
        scores.Add("C", 2.5)
        scores.Add("I", 4.5)
        scores.Add("P", -1.6)
        scores.Add("V", 4.2)
        scores_Janinn.Add("A", 0.3)
        scores_Janinn.Add("C", 0.9)
        scores_Janinn.Add("D", -0.6)
        scores_Janinn.Add("E", -0.7)
        scores_Janinn.Add("F", 0.5)
        scores_Janinn.Add("G", 0.3)
        scores_Janinn.Add("H", -0.1)
        scores_Janinn.Add("I", 0.7)
        scores_Janinn.Add("K", -1.8)
        scores_Janinn.Add("L", 0.5)
        scores_Janinn.Add("M", 0.4)
        scores_Janinn.Add("N", -0.5)
        scores_Janinn.Add("P", -0.3)
        scores_Janinn.Add("Q", -0.7)
        scores_Janinn.Add("R", -1.4)
        scores_Janinn.Add("S", -0.1)
        scores_Janinn.Add("T", -0.2)
        scores_Janinn.Add("V", 0.6)
        scores_Janinn.Add("W", 0.3)
        scores_Janinn.Add("Y", -0.4)
        scores_Engelman.Add("A", 1.6)
        scores_Engelman.Add("C", 2)
        scores_Engelman.Add("D", -9.2)
        scores_Engelman.Add("E", -8.2)
        scores_Engelman.Add("F", 3.7)
        scores_Engelman.Add("G", 1)
        scores_Engelman.Add("H", -3.0)
        scores_Engelman.Add("I", 3.1)
        scores_Engelman.Add("K", -8.8)
        scores_Engelman.Add("L", 2.8)
        scores_Engelman.Add("M", 3.4)
        scores_Engelman.Add("N", -4.8)
        scores_Engelman.Add("P", -0.2)
        scores_Engelman.Add("Q", -4.1)
        scores_Engelman.Add("R", -12.3)
        scores_Engelman.Add("S", 0.6)
        scores_Engelman.Add("T", 1.2)
        scores_Engelman.Add("V", 2.6)
        scores_Engelman.Add("W", 1.9)
        scores_Engelman.Add("Y", -0.7)
        scores_hopp_woods.Add("A", -0.5)
        scores_hopp_woods.Add("C", -1)
        scores_hopp_woods.Add("D", 3)
        scores_hopp_woods.Add("E", 3)
        scores_hopp_woods.Add("F", -2.5)
        scores_hopp_woods.Add("G", 0)
        scores_hopp_woods.Add("H", -0.5)
        scores_hopp_woods.Add("I", -1.8)
        scores_hopp_woods.Add("K", 3)
        scores_hopp_woods.Add("L", -1.8)
        scores_hopp_woods.Add("M", -1.3)
        scores_hopp_woods.Add("N", 0.2)
        scores_hopp_woods.Add("P", 0)
        scores_hopp_woods.Add("Q", 0.2)
        scores_hopp_woods.Add("R", 3)
        scores_hopp_woods.Add("S", 0.3)
        scores_hopp_woods.Add("T", -0.4)
        scores_hopp_woods.Add("V", -1.5)
        scores_hopp_woods.Add("W", -3.4)
        scores_hopp_woods.Add("Y", -2.3)
        scores_Cornette.Add("A", 1.8)
        scores_Cornette.Add("C", -4.5)
        scores_Cornette.Add("D", -3.5)
        scores_Cornette.Add("E", -3.5)
        scores_Cornette.Add("F", -3.5)
        scores_Cornette.Add("G", -3.5)
        scores_Cornette.Add("H", -0.4)
        scores_Cornette.Add("I", -3.2)
        scores_Cornette.Add("K", 3.8)
        scores_Cornette.Add("L", -3.9)
        scores_Cornette.Add("M", 1.9)
        scores_Cornette.Add("N", 2.8)
        scores_Cornette.Add("P", -0.8)
        scores_Cornette.Add("Q", -0.7)
        scores_Cornette.Add("R", -0.9)
        scores_Cornette.Add("S", -1.3)
        scores_Cornette.Add("T", 2.5)
        scores_Cornette.Add("V", 4.5)
        scores_Cornette.Add("W", -1.6)
        scores_Cornette.Add("Y", 4.2)
        scores_Rose.Add("A", 1.8)
        scores_Rose.Add("C", -4.5)
        scores_Rose.Add("D", -3.5)
        scores_Rose.Add("E", -3.5)
        scores_Rose.Add("F", -3.5)
        scores_Rose.Add("G", -3.5)
        scores_Rose.Add("H", -0.4)
        scores_Rose.Add("I", -3.2)
        scores_Rose.Add("K", 3.8)
        scores_Rose.Add("L", 1.9)
        scores_Rose.Add("M", 2.8)
        scores_Rose.Add("N", -0.8)
        scores_Rose.Add("P", -0.7)
        scores_Rose.Add("Q", -0.9)
        scores_Rose.Add("R", -1.3)
        scores_Rose.Add("S", 2.5)
        scores_Rose.Add("T", 4.5)
        scores_Rose.Add("V", -1.6)
        scores_Rose.Add("W", 4.2)
        scores_Rose.Add("Y", -3.9)
        scores_Eisenberg.Add("A", 1.8)
        scores_Eisenberg.Add("C", -4.5)
        scores_Eisenberg.Add("D", -3.5)
        scores_Eisenberg.Add("E", -3.5)
        scores_Eisenberg.Add("F", -3.5)
        scores_Eisenberg.Add("G", -3.5)
        scores_Eisenberg.Add("H", -0.4)
        scores_Eisenberg.Add("I", -3.2)
        scores_Eisenberg.Add("K", 3.8)
        scores_Eisenberg.Add("L", -3.9)
        scores_Eisenberg.Add("M", 1.9)
        scores_Eisenberg.Add("N", 2.8)
        scores_Eisenberg.Add("P", -0.8)
        scores_Eisenberg.Add("Q", -0.7)
        scores_Eisenberg.Add("R", -0.9)
        scores_Eisenberg.Add("S", -1.3)
        scores_Eisenberg.Add("T", 2.5)
        scores_Eisenberg.Add("V", 4.5)
        scores_Eisenberg.Add("W", -1.6)
        scores_Eisenberg.Add("Y", 4.2)
        If Scoring_Indices.Cornette = True Then
            Global_List.sequence_list.scores_chosen = scores_Cornette
        End If
        If Scoring_Indices.Eisenberg = True Then
            Global_List.sequence_list.scores_chosen = scores_Eisenberg
        End If
        If Scoring_Indices.Engelmann = True Then
            Global_List.sequence_list.scores_chosen = scores_Engelman
        End If
        If Scoring_Indices.hopp_woods = True Then
            Global_List.sequence_list.scores_chosen = scores_hopp_woods
        End If
        If Scoring_Indices.Janin = True Then
            Global_List.sequence_list.scores_chosen = scores_Janinn
        End If
        If Scoring_Indices.Kyte_Doolittle = True Then
            Global_List.sequence_list.scores_chosen = scores
        End If
        If Scoring_Indices.Rose = True Then
            Global_List.sequence_list.scores_chosen = scores_Rose
        End If


        'Before starting the algorithm the scores need to chosen and updated'
        Dim myChar As Char
        Dim total_score As Double
        Dim count As Integer
        Dim score_array(fasta.Length) As Double
        Dim sum As Double = 0
        Dim average_six As Integer = 0
        Dim num_score As Integer = 0
        Dim count_ As Integer = 0
        Dim Hydrophobic_Array(fasta.Length) As Integer  'This contains the values for which ones are hydrophobic and which ones aren't' 'the 1's mean its hydrophobic region' '0 means its not'
        'Based on the sum average and if its >0'
        Dim scale As Integer = 0
        scale = NumericUpDown1.Value
        'Chart1.ChartAreas("Hydropathy1").CursorX.IsUserSelectionEnabled() = True
        'Chart1.ChartAreas("Hydropathy1").CursorY.IsUserSelectionEnabled() = True
        'Chart1.ChartAreas("Hydropathy1").AxisY.Maximum = 5
        'Chart1.ChartAreas("Hydropathy1").AxisY.Minimum = -4
        'Chart1.ChartAreas("Hydropathy1").AxisY.Interval = 0.5
        count = 0



        Using Str As StringReader = New StringReader(fasta)
            Do While count < fasta.Length
                myChar = fasta(count)
                If Global_List.sequence_list.scores_chosen.ContainsKey(myChar) Then
                    Dim num As Integer = Global_List.sequence_list.scores_chosen.Item(myChar)
                    score_array(count) = num
                    total_score = total_score + num
                End If
                'Using an average of 6 values to plot' 'Not implemented' ' This is for the other kind of plot i forgot the name of'
                If count Mod 6 = 0 And count <> 0 Then
                    num_score = (score_array(count - 5) + score_array(count - 4) + score_array(count - 3) + score_array(count - 2) + score_array(count - 1) + score_array(count)) / 6
                End If
                count = count + 1
            Loop
        End Using

        Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).Sequence_Hydropathy_Array = score_array
        Load_Hydropathy_Points(fasta, fasta.Length)

        For indexA = 0 To fasta.Length - scale
            For indexB = 0 To scale
                sum = score_array(indexB + indexA) + sum
            Next
            sum = sum / scale
            If sum > 0 Then
                Hydrophobic_Array(indexA) = 1
            End If
            'chart1.series("hydropathy").points.addy(sum)
            Draw_Hydropathy(PictureBox1, sum, indexA)
            sum = 0
        Next
        Dim x As Integer = 0
        For x = 0 To fasta.Length
            If Hydrophobic_Array(x).Equals(1) = False Then
                Hydrophobic_Array(x) = 0
            End If
        Next

        Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).Hydrophobic_array = Hydrophobic_Array

    End Function
    'Function to update global variables. Increments the sequence list with each additional sequence inputted
    Function Update_List(Sequence_ As Sequence)
        Dim UpdatedValue = Global_List.sequence_list.list_length * 2
        Global_List.sequence_list.current_amount = Global_List.sequence_list.current_amount + 1
        If Global_List.sequence_list.current_amount = Global_List.sequence_list.sequence_array.Length Then
            Global_List.sequence_list.Redimension() = UpdatedValue
        End If
    End Function

    'Function to assign scoring indices in class file
    Function Kyte_Dolittle() As Boolean
        Scoring_Indices.Kyte_Doolittle = True
        Scoring_Indices.Cornette = False
        Scoring_Indices.Eisenberg = False
        Scoring_Indices.hopp_woods = False
        Scoring_Indices.Janin = False
        Scoring_Indices.Engelmann = False
        Scoring_Indices.Rose = False
    End Function

    Function Rose() As Boolean
        Scoring_Indices.Kyte_Doolittle = False
        Scoring_Indices.Cornette = False
        Scoring_Indices.Eisenberg = False
        Scoring_Indices.hopp_woods = False
        Scoring_Indices.Janin = False
        Scoring_Indices.Engelmann = False
        Scoring_Indices.Rose = True
    End Function

    Function Engelmann() As Boolean
        Scoring_Indices.Kyte_Doolittle = False
        Scoring_Indices.Cornette = False
        Scoring_Indices.Eisenberg = False
        Scoring_Indices.hopp_woods = False
        Scoring_Indices.Janin = False
        Scoring_Indices.Engelmann = True
        Scoring_Indices.Rose = False
    End Function
    Function Hopp_Woods()
        Scoring_Indices.Kyte_Doolittle = False
        Scoring_Indices.Cornette = False
        Scoring_Indices.Eisenberg = False
        Scoring_Indices.hopp_woods = False
        Scoring_Indices.Janin = False
        Scoring_Indices.Engelmann = False
        Scoring_Indices.Rose = False
    End Function
    Function Janin() As Boolean
        Scoring_Indices.Kyte_Doolittle = False
        Scoring_Indices.Cornette = False
        Scoring_Indices.Eisenberg = False
        Scoring_Indices.hopp_woods = False
        Scoring_Indices.Janin = True
        Scoring_Indices.Engelmann = False
        Scoring_Indices.Rose = False
    End Function
    Function Cornette() As Boolean
        Scoring_Indices.Kyte_Doolittle = False
        Scoring_Indices.Cornette = True
        Scoring_Indices.Eisenberg = False
        Scoring_Indices.hopp_woods = False
        Scoring_Indices.Janin = False
        Scoring_Indices.Engelmann = False
        Scoring_Indices.Rose = False
    End Function
    Function Eisenberg() As Boolean
        Scoring_Indices.Kyte_Doolittle = False
        Scoring_Indices.Cornette = False
        Scoring_Indices.Eisenberg = True
        Scoring_Indices.hopp_woods = False
        Scoring_Indices.Janin = False
        Scoring_Indices.Engelmann = False
        Scoring_Indices.Rose = False
    End Function
    Function Profile_Neural_Networks(ByRef sequence)

    End Function
    Function MSA_Calculation(ByRef first_sequence, ByRef second_sequence)
        'To build our own MSA or to use online algorithms. That is the real question. 
        'Online tools - ClustalW'




        'Commented out is the original MSA function. Rewritten for clarities sake. 

        '        Int whoa_now(Char first_FASTA[100], Char second_FASTA[100])
        '{
        'Int scoring_match;
        'Int scoring_mismatch;


        '    Int count = 1; //This will be used for the matrix filling 
        '    struct Dynamic_Programming
        '	{
        '		Int matrix[100][100];
        '        Int gap_penalty;
        '        Char ifirst_FASTA[100];
        '        Char isecond_FASTA[100];
        '	}Dynamic_Programming;

        '	//Mallocing the fasta buffers And the double array matrix
        '	struct Dynamic_Programming * temp;
        '    temp = malloc(sizeof(Dynamic_Programming));

        '	/*
        '	For (Int() i= 0; i<100;i++){
        '		For (Int() j= 0; j<100; j++)
        '		{
        '			temp-> matrix[i][j] = malloc(sizeof(int));
        '		}
        '	}
        '	 */
        '	//Collecting the arguments passed into main 
        '	strncpy(temp -> ifirst_FASTA, first_FASTA, 100);
        '	strncpy(temp -> isecond_FASTA, second_FASTA, 100);      
        '	//char substitution_Matrix[50];
        '	/*
        '	first_FASTA = argv[1];
        '	second_FASTA = argv[2];
        '	substitution_Matrix = argv[3];
        '    temp-> gap_penalty = atoi(argv[4]); 
        '	*/
        '	//******************************************************************
        '	//Storing the first FASTA file into the temp.fasta buffer

        '	/*FILE *ptr_file;
        '	ptr_file = fopen(first_FASTA, "r");
        '	If (!ptr_file) Then
        '                    	{
        '		Return 1;
        '	}
        '	//skipping the first line as its the identifier of the sequence
        '	Char line_skip[100];
        '    fgets(line_skip, 100, ptr_file);

        '	//storing the first FASTA file into a local holder.
        '	fgets(temp -> ifirst_FASTA, 200, ptr_file);


        '	//Storing the second FASTA file into the temp.fasta buffer
        '	File * ptr_file_s;
        '	ptr_file_s = fopen(second_FASTA, "r");
        '	If (!ptr_file_s) Then
        '                        	{
        '		Return 1;
        '	}
        '	//skipping the first line as its the identifier
        '	Char line_skip_s[100];
        '    fgets(line_skip_s, 100, ptr_file_s);

        '	//storing the first FASTA file into a local holder.
        '	fgets(temp -> isecond_FASTA, 200, ptr_file_s);
        '	*/

        '	//********************************************************************

        '	//Assigning the Match And Mismatch values using the substitution matrix given And filling boundary with 0's

        '	/*
        '	matrix_read(substitution_Matrix);

        '	For (Int() i= 0; i<strlen(temp->ifirst_FASTA) + 1;i++){
        '		For (Int() j= 0; j<strlen(temp->isecond_FASTA) + 1; j++)
        '		{
        '			temp-> matrix[i][0] = 0;
        '			temp-> matrix[0][j] = 0;
        '		}
        '	}
        '	*/
        '	scoring_match = 100;
        '	temp-> gap_penalty = -500;
        '	scoring_mismatch = -100;

        '	//***************************************************************************
        '	//SCORING
        '	//Using the scoring matrix to assign values. Should be comparing n x n lengths. 
        '	Int score;
        '	//The last i,j values in the matrix. Will be used to designate the sink
        '	Int i_sink;
        '    Int j_sink;
        '    temp-> ifirst_FASTA[sizeof(temp->ifirst_FASTA)-1] = '\0';
        '	temp-> isecond_FASTA[sizeof(temp->isecond_FASTA)-1] = '\0';      
        '	For (Int() i= 1; i<strlen(temp->ifirst_FASTA)+1;i++){
        '		For (Int() j= 1; j<strlen(temp->isecond_FASTA)+1; j++)
        '		{
        '			//If there are no nucleotides it does nothing
        '			If ((temp -> ifirst_FASTA[i-1] == 'A' || temp->ifirst_FASTA[i-1] == 'G' ||temp->ifirst_FASTA[i-1] == 'T' || temp->ifirst_FASTA[i-1] == 'C') && 
        '				(temp->isecond_FASTA[j-1] == 'A' || temp->isecond_FASTA[j-1] == 'G' || temp->isecond_FASTA[j-1] == 'T' || temp->isecond_FASTA[j-1] == 'C'))
        '			{
        '				//calculating whether its a match Or mismatch
        '				If (temp -> isecond_FASTA[j-1] == temp->ifirst_FASTA[i-1]) {
        '					//printf("!");
        '					score = scoring_match;
        '				}
        '				ElseIf (temp -> ifirst_FASTA[i-1] != temp->isecond_FASTA[j-1])
        '				{
        '					score = scoring_mismatch;
        '					//printf("?");
        '				}

        '				//First 3 if statements are if the above Or left happen to be nucleotides eg i Or j = 0 then they must be given value of previous boundary point plus gap penalty.
        '				If (i == 1 && j == 1) Then{
        '					temp-> matrix[i][j] = max_int(temp->matrix[i-1][j-1] + score, 0 + temp -> gap_penalty, 0 + temp -> gap_penalty);	
        '				}
        '				If ((i - 1) == 0) Then{
        '					temp-> matrix[i][j] = temp->matrix[1][j-1] + temp->gap_penalty;
        '				}
        '				If ((j - 1) == 0) Then{
        '					temp-> matrix[i][j] = temp->matrix[i-1][1] + temp->gap_penalty;
        '				}

        '				//Not on the edge cases. 
        '				temp-> matrix[i][j] = max_int(temp->matrix[i-1][j-1] + score, temp -> matrix[i-1][j] + temp->gap_penalty, temp -> matrix[i][j-1] + temp->gap_penalty);

        '				//Resetting score to 0 since each case Is independent. 			
        '				score = 0;
        '			}
        '		}
        '	}


        '	//Nothing to do if there are no nucleotides to compare. We do Not subtract by 1 because the matrix starts at 1. the matrix[i_sink][j_sink] Is the last value. 		
        '	i_sink = strlen(temp -> ifirst_FASTA);
        '	j_sink = strlen(temp -> isecond_FASTA);

        '	//*********************************************************************************

        '	//Dynamically creating the total score. Working backwards from sink.
        '	//Also filling in the optimal allignment sequence to compare to the original
        '	Int total_dynamic_score = 0;
        '    Int i = i_sink;
        '    Int j = j_sink;
        '    Int count_pos = i_sink;


        '    Char return_value;
        '    Char optimal_alignment[200];
        '    Char original_alignment[200];

        '	//While loop that ends when the source Is met. 
        '	While (i!= 1 && j!= 1)
        '	{
        '		//Function will return which path has the greater number. Depending on the character returned that will be the New position of the i And j value. 
        '		//Want to stop when i And j are equal to 1. Located at source. If j Or i equals 1 And the other Is Not 1 it will continue until the other Is 1 
        '		return_value = max_char(temp -> matrix[i-1][j-1], temp -> matrix[i-1][j], temp -> matrix[i][j-1]);
        '		If (return_value == 'u' && j != 1){
        '            total_dynamic_score = total_dynamic_score + temp -> matrix[i][j-1];
        '			//If the retuned greatest value cooresponds to the matrix iterator going "up" then we know it Is a gap so the first sequence will have a gap in it
        '			optimal_alignment[count_pos] = second_FASTA[j-1];    
        '            original_alignment[count_pos] = '_';

        '                                                                    i = i;
        '			j = j - 1;

        '			count_pos --;
        '		}
        '		ElseIf (return_value == 'l' && i != 1){
        '            total_dynamic_score = total_dynamic_score + temp -> matrix[i-1][j];
        '			//If the returned greatest value cooresponds to a left shift then we just take the j'th value out of the second string and concatanate it into the optimal string. 
        '			//no shift in the j value And the second string Is alligned along the y axis. Original will print get its own value And Not a gap. 
        '			original_alignment[count_pos] = temp -> ifirst_FASTA[i-1];
        '			optimal_alignment[count_pos] = second_FASTA[j];
        '            i = i - 1;
        '			j = j;

        '			count_pos--;

        '		}
        '		ElseIf (return_value == 'd' && j != 1 && i != 1){
        '            total_dynamic_score = total_dynamic_score + temp -> matrix[i-1][j-1];
        '			//Shift in the j value since it goes across diagonally. Shift in the i value as well so the original alignment gets its value inputtedinto the string. 
        '			original_alignment[count_pos] = temp -> ifirst_FASTA[i-1]; 
        '			optimal_alignment[count_pos] = second_FASTA[j-1];
        '            i = i - 1;
        '			j = j - 1;

        '			count_pos--;
        '		}

        '	}

        '	Char mess[50];
        '    sprintf(mess, "Total Dynamic Score - %i\n", total_dynamic_score); 


        '	//***********************************************************************************

        '	File * fp;
        '	Char * seq_2 = "c:\\Users\\Evan\\Desktop\\aln.txt";
        '	fp = fopen(seq_2, "w");
        '	/*
        '	fprintf(fp, "This is the first sequence\n");
        '	fprintf(fp, first_FASTA);
        '	fprintf(fp, "\n");
        '	fprintf(fp, "This is for the second delete sequence\n");
        '	fprintf(fp, second_FASTA);
        '	fprintf(fp, "\n");
        '	*/
        '	fprintf(fp, mess);  
        '	//fprintf(fp, "Original - modified\n");
        '	fprintf(fp, original_alignment);
        '	fprintf(fp, "\n");
        '	//fprintf(fp, "Optimal\n");
        '	fprintf(fp, optimal_alignment);
        '	//fprintf(fp, "Total Dynamic Score\n");

        '	fclose(fp);


        '	Return total_dynamic_score;
        '}


        'Int matrix_read(Char * substitution_Matrix)
        '{
        '	File * ptr_file_matrix;
        '	ptr_file_matrix = fopen(substitution_Matrix, "r");
        '	If (!ptr_file_matrix) Then
        '                                                                        	{
        '		Return 1;
        '	}

        '	Char Buffer[40];
        '    Int matrix[5][5];
        '    matrix[0][0] = 0;
        '	Int count = 0;
        '    Int count1 = 0;
        '    Int scoring_match = 0;
        '    Int scoring_mismatch = 0;

        '	//Do this 4 times for the 4 by 4 substitution array. 
        '	For (Int() j = 0; j<4; j++){
        '		fgets(Buffer, 40, ptr_file_matrix);
        '		For (Int() i= 0; i<40; i++)
        '		{
        '			If (Buffer[i] != ' ' )
        '			{ 
        '				matrix[count][count1] = buffer[i];
        '                count1 ++;
        '			}
        '		}
        '		count ++;
        '		count1 = 0;
        '	}

        '	//Once the array Is filled, the scoring matrix can be deciphered
        '	If (matrix[0][0] == matrix[0][1]){
        '		scoring_match = matrix[1][1];
        '		Return scoring_match;
        '	} 
        '	Else{
        '		scoring_mismatch = matrix[1][1];
        '		Return scoring_mismatch;
        '	}
        '}

        '//Max function to be used in the scoring mechanism. 
        'Int max_int(Int a, Int b, Int c)
        '{
        '	//Conditionals
        '	If (a == b && b == c && a == c) Then
        '                                                                                            	{
        '		Return a;
        '	}
        '	If (a == b && a > c) Then
        '                                                                                                	{
        '		Return a;
        '	}
        '	If (a == c && a > b) Then
        '                                                                                                    	{
        '		Return a;
        '	}
        '	If (b == a && b > c) Then
        '                                                                                                        	{
        '		Return b;
        '	}
        '	If (b == c && b > a) Then
        '                                                                                                            	{
        '		Return b;
        '	}
        '	If (c == a && c > a) Then
        '                                                                                                                	{
        '		Return c;
        '	}
        '	If (c == b && c > a) Then
        '                                                                                                                    	{
        '		Return c;
        '	}

        '	If (a > b && a > c) Then
        '                                                                                                                        	{
        '		Return a;
        '	}

        '	If (b > a && b > c) Then
        '                                                                                                                            	{
        '		Return b;
        '	}

        '	If (c > a && c > b) Then
        '                                                                                                                                	{
        '		Return c;
        '	}
        '}
        '//Same as the max function but returns a character on location it should travel. 
        'Char max_char(Int a, Int b, Int c)
        '{
        '		//Conditionals
        '	If (a == b && b == c && a == c) Then
        '                                                                                                                                    	{
        '		Return 'd';
        '	}
        '	If (a == b && a > c) Then
        '                                                                                                                                        	{
        '		Return 'd';
        '	}
        '	If (a == c && a > b) Then
        '                                                                                                                                            	{
        '		Return 'd';
        '	}
        '	If (b == a && b > c) Then
        '                                                                                                                                                	{
        '		Return 'l';
        '	}
        '	If (b == c && b > a) Then
        '                                                                                                                                                    	{
        '		Return 'l';
        '	}
        '	If (c == a && c > a) Then
        '                                                                                                                                                        	{
        '		Return 'u';
        '	}
        '	If (c == b && c > a) Then
        '                                                                                                                                                            	{
        '		Return 'u';
        '	}

        '	If (a > b && a > c) Then
        '                                                                                                                                                                	{
        '		Return 'd';
        '	}

        '	If (b > a && b > c) Then
        '                                                                                                                                                                    	{
        '		Return 'l';
        '	}

        '	If (c > a && c > b) Then
        '                                                                                                                                                                        	{
        '		Return 'u';
        '	}
        '}
        '/*Write your C code here*/
        '#include <stdio.h>

        'Int Shoham_function2(void)
        '{
        '	Char seq[760];
        '    Char Buffer[50];
        '    File * ptrfile;
        '	fgets(Buffer, 100, ptrfile);
        '    ptrfile = fopen("c:\\Users\\Evan\\Desktop\\mel.fa", "r");
        '	fscanf(ptrfile, "%s", seq);
        '	fclose(ptrfile);

        '	Char seq_no_delete[760];
        '    Char buffer2[51];
        '    File * ptrfile1;
        '	fgets(buffer2, 100, ptrfile);
        '    ptrfile = fopen("c:\\Users\\Evan\\Desktop\\psd.fa", "r");
        '	fscanf(ptrfile1, "%s", seq_no_delete);
        '	fclose(ptrfile1);




        '    Int random_change_amount = L / 10;
        '    Int i2 = 0;
        '    For (i2 = 0; i2<random_change_amount; i2++)
        '    {
        '        Int random_change_pos = rand() % L;
        '        Int random_prob = rand() % 2;
        '        Int random_prob_delete = rand() % 2;

        '        If (random_prob == 0) Then
        '                                                                                                                                                                                        {
        '            Int Random = rand() % 4;
        '            If (Random == 1) Then{
        '                seq[random_change_pos] = 'A';
        '                seq_no_delete[random_change_pos] = 'A';
        '            }
        '            If (Random == 2) Then{
        '                seq[random_change_pos] = 'G';
        '                seq_no_delete[random_change_pos] = 'G';
        '            }
        '            If (Random == 3) Then{
        '                seq[random_change_pos] = 'C';
        '                seq_no_delete[random_change_pos] = 'C';
        '            }
        '            If (Random == 0) Then{
        '                seq[random_change_pos] = 'T';
        '                seq_no_delete[random_change_pos] = 'T';
        '            }


        '            If (random_prob_delete == 0) Then
        '                                                                                                                                                                                                                {
        '                Int i3 = 0;
        '                For (i3 = 0; i3 < random_change_pos; i3++){
        '                    seq[i3] = seq[i3];
        '                }
        '                Int i4 = 0;
        '                For (i4 = random_change_pos; i4 < L - 1; i4++){
        '                    seq[i4] = seq[i4+1];
        '                }
        '            }
        '        }
        '    }



        '	whoa_now(seq,seq_no_delete);


        '    return 0;
        '}
    End Function



    Function Profile_Calculation_AlphaHelices(ByRef sequence)
        'Utilizes a neural network method of backpropagation. To be built as it continues' 
        'Comparitive to the chou fasman method'
        'Methods to be used: Chou, Neural, Robson, Lim or DSSP hydrogen bond estimation'

        'Chou Fasman Algorithm. Fasta sequence passed in parameter'

        'Chou fasman indices. Describes alpha helices beta sheet coil and angles'

        Dim alpha_matrix = New Double() {142, 98, 101, 67, 70, 151, 111, 57, 100, 108, 121, 114, 145, 113, 57, 77, 83, 108, 69, 106}
        Dim beta_matrix = New Double() {83, 93, 54, 89, 119, 37, 110, 75, 87, 160, 130, 74, 105, 138, 55, 75, 119, 137, 147, 170}
        Dim turn_matrix = New Double() {66, 95, 146, 156, 119, 74, 98, 156, 95, 47, 59, 101, 60, 60, 152, 143, 96, 96, 114, 50}
        Dim function_i = New Double() {0.06, 0.07, 0.147, 0.161, 0.149, 0.056, 0.074, 0.102, 0.14, 0.043, 0.061, 0.055, 0.068, 0.059, 0.102, 0.12, 0.086, 0.077, 0.082, 0.062}
        Dim function_i1 = New Double() {0.076, 0.106, 0.11, 0.083, 0.05, 0.06, 0.098, 0.085, 0.047, 0.034, 0.025, 0.115, 0.082, 0.041, 0.301, 0.139, 0.108, 0.013, 0.065, 0.048}
        Dim function_i2 = New Double() {0.035, 0.099, 0.179, 0.191, 0.117, 0.077, 0.037, 0.19, 0.093, 0.013, 0.036, 0.072, 0.014, 0.065, 0.034, 0.125, 0.065, 0.064, 0.114, 0.028}
        Dim function_i3 = New Double() {0.058, 0.085, 0.081, 0.091, 0.128, 0.064, 0.098, 0.152, 0.054, 0.056, 0.07, 0.095, 0.055, 0.065, 0.068, 0.106, 0.079, 0.167, 0.125, 0.053}
        Dim scores As New Dictionary(Of Char, Integer)
        'scores is just a dictionary of the amino acid and the position'
        scores.Add("A", 0)
        scores.Add("R", 1)
        scores.Add("N", 2)
        scores.Add("D", 3)
        scores.Add("Q", 4)
        scores.Add("E", 5)
        scores.Add("G", 6)
        scores.Add("H", 7)
        scores.Add("L", 8)
        scores.Add("K", 9)
        scores.Add("M", 10)
        scores.Add("F", 11)
        scores.Add("S", 12)
        scores.Add("T", 13)
        scores.Add("W", 14)
        scores.Add("Y", 15)
        scores.Add("C", 16)
        scores.Add("I", 17)
        scores.Add("P", 18)
        scores.Add("V", 19)


        'Finding nucleation sites For Alpha helices the nucleation threshold is 4 residues < 1.
        'Its 4 in any set of 6 continuous amino acid. 

        'First step is to create an array with alpha values'
        'iterator'
        Dim empty_holder_array_alpha(sequence.length) As Integer
        Dim empty_holder_array_beta(sequence.length) As Integer
        Dim final_result(sequence.length) As Integer
        Dim iterator As Integer = 0
        Dim alpha_array(sequence.length) As Double
        Dim beta_array(sequence.length) As Double
        Dim myChar As Char
        Using str As StringReader = New StringReader(sequence)
            Do While iterator < sequence.length
                myChar = sequence(iterator)
                If scores.ContainsKey(myChar) Then
                    Dim position As Integer = scores.Item(myChar)
                    alpha_array(iterator) = alpha_matrix(position)
                    beta_array(iterator) = beta_matrix(position)
                    iterator = iterator + 1
                End If
            Loop
        End Using


        Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).score_array_alpha = alpha_array
        Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).score_array_beta = beta_array


        'alpha_array contains the values for each residue in the sequence. Need to
        'go through a window of 6 and calculate average of all 4 amino acid possibilities.
        'if any of the probabilities calcuated was less than 1.03 then its a nucleation site.
        'Extension array contains the end points to the array. The beginning and end will be extended until 4 
        Dim Extension_array() As Integer
        Dim windowed_array(6) As Integer
        Dim window As Integer = 6
        Dim count_4 As Integer = 0
        Dim extension_count As Integer = 0
        Dim last_fourth_position As Integer = 0
        For indexA = 0 To sequence.length - window - 1
            last_fourth_position = 0
            For index_nucleation = 0 To window - 1
                windowed_array(index_nucleation) = alpha_array(index_nucleation + indexA)
            Next
            'Looking  at the 6 amino acids in the window' 'note that we start extending once we hit the fourth position that is greater than 103. 
            For indexB = 0 To 5
                If windowed_array(indexB) > 103 And count_4 < 3 Then
                    count_4 = count_4 + 1
                    last_fourth_position = indexA + indexB
                End If
            Next
            'At this point the alpha helix nucleation has been found Anything in the if statement pertains to that. 
            'If count_4 reaches 3  the region is an alpha helix.Remember count starts at 0 hence goes to 3
            If count_4 = 3 Then

                Dim right_start As Integer = last_fourth_position + 1
                Dim count_4_right_contiguous As Integer = 0
                While count_4_right_contiguous <> 3
                    If right_start >= alpha_array.Length Then
                        'we've reached the end of the sequence array. 
                        Exit While
                    End If
                    If alpha_array(right_start) < 100 Then
                        count_4_right_contiguous = count_4_right_contiguous + 1
                    End If
                    If alpha_array(right_start) > 100 Then
                        count_4_right_contiguous = 0
                    End If
                    right_start = right_start + 1
                End While
                'the 4 contiguous amino acids have been found. The function is done.
                'The left side needs to be calculated. 

                'The left now needs to be extended.
                'Follows the same format as the righthand 
                Dim left_start As Integer = indexA - 1
                Dim count_4_left_contiguous As Integer = 0
                While count_4_left_contiguous <> 3
                    If left_start <= 0 Then
                        Exit While
                    End If
                    If alpha_array(left_start) < 100 Then
                        count_4_left_contiguous = count_4_left_contiguous + 1
                    End If
                    If alpha_array(left_start) > 100 Then
                        count_4_left_contiguous = 0
                    End If
                    left_start = left_start - 1
                End While

                'resetting them after the condition of the while loop was met. Did a while loop and not a do while loop
                left_start = left_start + 1
                right_start = right_start - 1

                'The last condition. If the region is at least 6 nucleotides long and has an average of P(a)>103 and its average is greater than P(b) than it is finally considered to be a helix. 
                'Left start to right start is the entire length of the helix. 
                Dim alpha_array_average As Double = 0
                Dim beta_array_average As Double = 0
                Dim helix_length = 0
                For indexF = left_start To right_start

                    helix_length = helix_length + 1
                    alpha_array_average = alpha_array_average + alpha_array(indexF)
                    beta_array_average = beta_array_average + beta_array(indexF)
                Next
                beta_array_average = beta_array_average / helix_length
                alpha_array_average = alpha_array_average / helix_length

                'Determines if the helix is considered or not 
                If helix_length >= 6 And alpha_array_average > 103 And alpha_array_average > beta_array_average Then
                    For indexG = left_start To right_start
                        'empty holder array is filled with 1's from the left start all the way to the end designated by rightstart 
                        empty_holder_array_alpha(indexG) = 1
                    Next
                End If
            End If
            'The alpha helix has been documented' Or not found
            'reset the count. The window moves forward. 
            count_4 = 0
        Next
        'The whole window has moved forward 
        'The empty holder array should now have 1's where the alpha helices are located'
        'If overlaps exist that is fine because they are all 1's
        For indexE = 0 To sequence.length
            If empty_holder_array_alpha(indexE).Equals(1) = False Then
                empty_holder_array_alpha(indexE) = 0
            End If
        Next

        'The beta sheets need to be calculated now'
        window = 5
        Dim windowed_array_beta(5) As Integer
        Dim last_third_position As Integer = 0
        Dim count_3 As Integer = 0
        For indexA = 0 To sequence.length - window - 1
            last_third_position = 0
            For nucleation_index = 0 To 4
                windowed_array_beta(nucleation_index) = beta_array(indexA + nucleation_index)
            Next
            For indexB = 0 To 4
                If count_3 < 2 And windowed_array_beta(indexB) > 100 Then
                    last_third_position = indexB + indexA
                    count_3 = count_3 + 1
                End If
            Next
            If count_3 = 2 Then
                Dim right_start As Integer = last_third_position + 1
                Dim count_four_right_contiguous As Integer = 0
                While count_four_right_contiguous <> 3
                    If right_start >= beta_array.Length Then
                        'we've reached the end of the sequence array. 
                        Exit While
                    End If
                    If beta_array(right_start) < 100 Then
                        count_four_right_contiguous = count_four_right_contiguous + 1
                    End If
                    If beta_array(right_start) > 100 Then
                        count_four_right_contiguous = 0
                    End If
                    right_start = right_start + 1
                End While

                Dim left_start As Integer = indexA - 1
                Dim count_four_left_contiguous As Integer = 0
                While count_four_left_contiguous <> 3
                    If left_start <= 0 Then
                        Exit While
                    End If
                    If beta_array(left_start) < 100 Then
                        count_four_left_contiguous = count_four_left_contiguous + 1
                    End If
                    If beta_array(left_start) > 100 Then
                        count_four_left_contiguous = 0
                    End If
                    left_start = left_start - 1
                End While

                'Same issues as before do while not while but will change later
                left_start = left_start + 1
                right_start = right_start - 1

                Dim alpha_array_average As Double = 0
                Dim beta_array_average As Double = 0
                Dim helix_length = 0
                For indexF = left_start To right_start
                    helix_length = helix_length + 1
                    alpha_array_average = alpha_array_average + alpha_array(indexF)
                    beta_array_average = beta_array_average + beta_array(indexF)
                Next
                beta_array_average = beta_array_average / helix_length
                alpha_array_average = alpha_array_average / helix_length
                If helix_length >= 5 And beta_array_average > 105 And beta_array_average > alpha_array_average Then
                    For indexH = left_start To right_start
                        empty_holder_array_beta(indexH) = 1
                    Next
                    For indexE = 0 To sequence.length
                        If empty_holder_array_beta(indexE).Equals(1) = False Then
                            empty_holder_array_beta(indexE) = 0
                        End If
                    Next
                End If
            End If
            count_3 = 0
        Next
        'Any region containing overlapping alpha-helical and beta-sheet assignments are taken to be helical if the average P(a-helix) > P(b-sheet) for that region. It is a beta sheet if the average P(b-sheet) > P(a-helix) for that region.
        'Since the alpha helices are already inputted. Can compare the beta sheet regions to the already in alpha helices. 
        'Need to establish disputed regions'
        Dim disputed_region(sequence.length) As Integer

        For disputed_index = 0 To sequence.length - 1
            If empty_holder_array_alpha(disputed_index) = 1 And empty_holder_array_beta(disputed_index) = 1 Then
                disputed_region(disputed_index) = 1
            End If
            If empty_holder_array_beta(disputed_index) = 0 Or empty_holder_array_alpha(disputed_index) = 0 Then
                disputed_region(disputed_index) = 0
            End If
        Next

        'Calculating the averages for all disputed regions. 
        Dim region As Integer = 0
        Dim index As Integer = 0
        Dim alpha_array_average_disputed As Double = 0
        Dim beta_array_average_disputed As Double = 0
        For indexB = 0 To sequence.length - 1
            If disputed_region(indexB) = 1 Then
                index = indexB
                'if a disputed region is encountered it calculates until its no longer disputed. 
                While (disputed_region(index)) = 1
                    region = region + 1
                    index = index + 1
                    alpha_array_average_disputed = alpha_array_average_disputed + alpha_array(index)
                    beta_array_average_disputed = beta_array_average_disputed + beta_array(index)
                End While
                'Comparing averages
                alpha_array_average_disputed = alpha_array_average_disputed / region
                beta_array_average_disputed = beta_array_average_disputed / region
                If alpha_array_average_disputed > beta_array_average_disputed Then
                    For indexC = indexB To index
                        'If the alpha array is larger it will block out the beta array and make it 0
                        empty_holder_array_beta(indexC) = 0
                    Next
                End If
                If beta_array_average_disputed > alpha_array_average_disputed Then
                    For indexC = indexB To index
                        empty_holder_array_alpha(indexC) = 0
                    Next
                End If
                'Returning to the end of the disputed region
                indexB = index
            End If
            'If its not a disputed region nothing happens. 
        Next

        Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).alpha_helix = empty_holder_array_alpha

        Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).beta_sheet = empty_holder_array_beta

        Load_Chau_Points()
        For indexZ = 0 To sequence.length - 2
            Draw_Chau_Lines(PictureBox1, indexZ)
        Next
        TextBox18.Clear()
        ' TextBox18.AppendText(Environment.NewLine)
        For indexZ = 0 To sequence.length - 1
            TextBox18.AppendText(Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).points_list(indexZ).Region)
        Next
    End Function
    'Function that loads the line in the picture box. The values being passed in are the picture box as well as the sum value calculated by the hydropathy function.
    'iterator is the current position in the sequence. 
    'Current list -1 because the list was updated after adding a new sequence. To look at the previous sequence subtract 1. Later change to checked or chosen sequence. 
    Function Draw_Hydropathy(ByRef PictureBox, ByVal point_value, ByVal iterator)
        Dim formGraphics As System.Drawing.Graphics = PictureBox1.CreateGraphics()
        Dim pen As New System.Drawing.Pen(System.Drawing.Color.Red)
        Dim fasta_length = Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).sequence_length
        Dim scale As Double = 0
        scale = NumericUpDown1.Value
        'index is the value multiplied by to scale the picture box. Subject to user manipulation
        Dim index As Double = 850 / (fasta_length - scale)
        Dim score_array = Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).Sequence_Hydropathy_Array



        'Plotting the individual points not taking into account the span
        Dim current_point = Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).points_list(iterator)
        Dim next_point = Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).points_list(iterator + 1)
        Dim starting_point_x As Single = Convert.ToSingle(current_point.Hydropathy_Position_x)
        Dim starting_point_y As Single = Convert.ToSingle(current_point.Hydropathy_Position_y)
        Dim end_point_x As Single = Convert.ToSingle(next_point.Hydropathy_Position_x)
        Dim end_point_y As Single = Convert.ToSingle(next_point.Hydropathy_Position_y)
        formGraphics.DrawRectangle(Pens.Green, starting_point_x, starting_point_y, 2, 2)



        'Plotting the points taking the span into account
        Dim starting_point_x_span As Single = Convert.ToSingle(Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).starting_point_x)
        Dim starting_point_y_span As Single = Convert.ToSingle(Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).starting_point_y)
        Dim end_point_x_span As Single = 0
        Dim end_point_y_span As Single = 0
        If iterator = 0 Then
            starting_point_x_span = 0
            starting_point_y_span = 300
        End If

        end_point_x_span = iterator * index
        end_point_y_span = 300 - (point_value * 60)

        If point_value > 0 Then
            formGraphics.DrawLine(pen, starting_point_x_span, starting_point_y_span, end_point_x_span, end_point_y_span)
        End If

        If point_value <= 0 Then
            formGraphics.DrawLine(Pens.Blue, starting_point_x_span, starting_point_y_span, end_point_x_span, end_point_y_span)
        End If
        starting_point_x_span = end_point_x_span
        starting_point_y_span = end_point_y_span

        formGraphics.DrawLine(Pens.Black, 0, 300, 850, 300)
        formGraphics.DrawLine(Pens.Black, 0, 0, 0, 600)
        'Updating the variable to hold the previous point'
        Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).starting_point_x = starting_point_x_span
        Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).starting_point_y = starting_point_y_span


        pen.Dispose()
        formGraphics.Dispose()

    End Function
    'Loads point positions into the point structure for a single sequence. Note it depends on the hydropathy value as well. 
    Function Load_Hydropathy_Points(ByRef Fasta_Sequene As String, ByVal Fasta_Length As Integer)
        Dim scale As Double = 0
        Dim score_array(Fasta_Length) As Double
        score_array = Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).Sequence_Hydropathy_Array
        scale = NumericUpDown1.Value

        'This is for the hydropathy'
        Dim point_x As Double
        Dim point_y As Double
        Dim Picture_Box_Scale = 850 / (Fasta_Length - scale)
        For iterator = 0 To (Fasta_Length - 1)
            If iterator = 0 Then
                point_x = 0
                point_y = 200
            End If
            If iterator <> 0 Then
                point_x = iterator * Picture_Box_Scale
                'the 60 will be altered for zooming functions. Look into later. Manipulate position. 
                point_y = 300 - (score_array(iterator) * 60)
            End If

            Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).points_list(iterator).Hydropathy_Position_x = point_x
            Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).points_list(iterator).Hydropathy_Position_y = point_y
        Next
    End Function
    Function Load_Sequence_Points(ByRef sequence As String, ByVal length As Integer)
        'Loads a set of null and empty points to be filled with the sequence creation. 
        'Creating a local temp value to work with'
        Dim Temp_Points As New Sequence_Points(length)
        Dim Error_Check As Integer = Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).points_list.Redimension(length)
        Error_Check = Temp_Points.Redimension(length)
        For iterator = 0 To (length - 1)
            Dim Temp As New Point(sequence(iterator))
            Temp_Points(iterator) = Temp
        Next
        Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).points_list = Temp_Points
    End Function
    'Loading and drawing chau points and lines. The chau loader assumes an already build point selection. That should be done in the open file set
    Function Load_Chau_Points()
        ' Load_Points(Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).sequence_no_title, Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).sequence_length)
        Dim sequence_length = Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).sequence_length
        Dim position_x_helix As Single = 0
        Dim position_y_helix As Single = 0
        Dim position_x_sheet As Single = 0
        Dim position_y_sheet As Single = 0
        Dim alpha_array() As Double = Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).score_array_alpha
        Dim beta_array() As Double = Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).score_array_beta
        Dim scale As Integer = NumericUpDown1.Value
        Dim Picture_Box_Scale = 850 / (sequence_length - scale)
        For iterator = 0 To sequence_length - 1
            If iterator = 0 Then
                position_x_helix = 0
                position_x_sheet = 0
                position_y_sheet = 300
                position_y_helix = 500
            End If

            If iterator <> 0 Then
                position_x_helix = iterator * Picture_Box_Scale
                position_x_sheet = iterator * Picture_Box_Scale
                'the 60 will be altered for zooming functions. Look into later. Manipulate position. 
                position_y_helix = 300 - (alpha_array(iterator))
                position_y_sheet = 500 - (beta_array(iterator))
            End If
            If Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).alpha_helix(iterator) = 1 Then
                Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).points_list(iterator).Region = "H"
            End If
            If Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).beta_sheet(iterator) = 1 Then
                Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).points_list(iterator).Region = "S"
            End If
            If Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).beta_sheet(iterator) <> 1 And Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).alpha_helix(iterator) <> 1 Then
                Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).points_list(iterator).Region = "C"
            End If

            Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).points_list(iterator).Chau_Position_x_alpha = position_x_helix
            Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).points_list(iterator).Chau_Position_y_alpha = position_y_helix
            Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).points_list(iterator).Chau_Position_x_sheet = position_x_sheet
            Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).points_list(iterator).Chau_Position_y_sheet = position_y_sheet
        Next
    End Function
    Function Draw_Chau_Lines(ByRef PictureBox, ByVal iterator)
        Dim formGraphics As System.Drawing.Graphics = PictureBox1.CreateGraphics()
        Dim pen As New System.Drawing.Pen(System.Drawing.Color.Red)
        Dim fasta_length = Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).sequence_length
        Dim scale As Double = 0
        scale = NumericUpDown1.Value
        'index is the value multiplied by to scale the picture box. Subject to user manipulation

        'Plotting the individual points not taking into account the span
        'Different than the previous draw function. Does not need to include in a span.
        Dim current_point = Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).points_list(iterator)
        Dim next_point = Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount - 1).points_list(iterator + 1)
        Dim starting_point_x_alpha As Single = Convert.ToSingle(current_point.Chau_Position_x_alpha)
        Dim starting_point_y_alpha As Single = Convert.ToSingle(current_point.Chau_Position_y_alpha)
        Dim starting_point_x_sheet As Single = Convert.ToSingle(current_point.Chau_Position_x_sheet)
        Dim starting_point_y_sheet As Single = Convert.ToSingle(current_point.Chau_Position_y_sheet)
        Dim end_point_x_alpha As Single = Convert.ToSingle(next_point.Chau_Position_x_alpha)
        Dim end_point_y_alpha As Single = Convert.ToSingle(next_point.Chau_Position_y_alpha)
        Dim end_point_x_sheet As Single = Convert.ToSingle(next_point.Chau_Position_x_sheet)
        Dim end_point_y_sheet As Single = Convert.ToSingle(next_point.Chau_Position_y_sheet)
        formGraphics.DrawRectangle(Pens.Green, starting_point_x_alpha, starting_point_y_alpha, 2, 2)
        formGraphics.DrawRectangle(Pens.Blue, starting_point_x_sheet, starting_point_y_sheet, 2, 2)

        formGraphics.DrawLine(pen, starting_point_x_alpha, starting_point_y_alpha, end_point_x_alpha, end_point_y_alpha)
        formGraphics.DrawLine(Pens.DarkSeaGreen, starting_point_x_sheet, starting_point_y_sheet, end_point_x_sheet, end_point_y_sheet)
        formGraphics.DrawLine(Pens.Black, 0, 300, 850, 300)
        formGraphics.DrawLine(Pens.Black, 0, 0, 0, 600)


        pen.Dispose()
        formGraphics.Dispose()


    End Function



    '__________________________________________________________________________________________________

    '                                           Sub Commands 
    '___________________________________________________________________________________________________
    'Sub to open file and incorporate into checked listbox
    Private Sub OpenToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem3.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            'Set the picture box axis'
            Dim formGraphics As System.Drawing.Graphics = PictureBox1.CreateGraphics()
            Dim pen As New System.Drawing.Pen(System.Drawing.Color.Black)
            formGraphics.Dispose()
            pen.Dispose()
            'Start file reading'
            Dim fileReader As System.IO.StreamReader = File.OpenText(OpenFileDialog1.FileName)
            Dim fileString As String
            Dim Temp_Sequence_Only As String
            Dim Temp_Name_String As String
            Temp_Name_String = fileReader.ReadLine()
            Do While fileReader.Peek() >= 0
                fileString = fileString + fileReader.ReadLine()
            Loop
            TextBox1.Clear()
            TextBox1.AppendText(Temp_Name_String)

            Temp_Sequence_Only = fileString

            fileReader.Close()



            Dim fastaReader As System.IO.StreamReader = File.OpenText(OpenFileDialog1.FileName)
            Dim fastaString As String
            Do While fastaReader.Peek() >= 0
                fastaString = fastaString + fastaReader.ReadLine()
            Loop
            Dim Temp As New Sequence(fastaString, Temp_Name_String)
            Temp.sequence_no_title = Temp_Sequence_Only
            Holder.Items.Add(Temp.Name).ToString()
            Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount) = Temp
            Global_List.sequence_list.sequence_array(Global_List.sequence_list.current_amount).sequence_length = Temp_Sequence_Only.Length
            TextBox2.Clear()
            TextBox2.AppendText(Temp_Sequence_Only)
            Update_List(Temp)

            fastaReader.Close()
            Load_Sequence_Points(Temp_Sequence_Only, Temp_Sequence_Only.Length)
            'PictureBox1.Load(OpenFileDialog1.FileName)'
        End If
    End Sub
    'Sub class that determines which parts of the graph should be plotted. Takes from index checked. 
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Going through the checked index
        Dim indexChecked As Integer
        Dim itemChecked As Object
        For Each indexChecked In FunctionBox.CheckedIndices
            'If hydropathy is selected the file is read and the sequence is removed to enter the hydropathy function
            If indexChecked = 2 Then
                Dim fileReader As System.IO.StreamReader = File.OpenText(OpenFileDialog1.FileName)
                Dim Sequence_Name As String
                Dim Sequence As String
                Sequence_Name = fileReader.ReadLine()
                Do While fileReader.Peek() >= 0
                    Sequence = Sequence + fileReader.ReadLine()
                Loop
                Hydropathy(Sequence)
            End If
            If indexChecked = 0 Then

            End If
            If indexChecked = 1 Then

            End If
            If indexChecked = 3 Then
                'chau fasman prediction'
                Dim fileReader As System.IO.StreamReader = File.OpenText(OpenFileDialog1.FileName)
                Dim Sequence_Name As String
                Dim Sequence As String
                Sequence_Name = fileReader.ReadLine()
                Do While fileReader.Peek() >= 0
                    Sequence = Sequence + fileReader.ReadLine()
                Loop
                Profile_Calculation_AlphaHelices(Sequence)
            End If
        Next
        'Checking to see if Moment has been selected

    End Sub
    'Sub that determines the scoring indices used. 
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim selected_value As Integer = ComboBox1.SelectedIndex
        If selected_value = 0 Then
            Kyte_Dolittle()
        End If
        If selected_value = 1 Then
            Rose()
        End If
        If selected_value = 2 Then
            Eisenberg()
        End If
        If selected_value = 3 Then
            Janin()
        End If
        If selected_value = 4 Then
            Engelmann()
        End If
        If selected_value = 5 Then
            Hopp_Woods()
        End If
        If selected_value = 6 Then
            Cornette()
        End If
    End Sub
    'Sub to close the program
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
    End Sub
    'Sub to clear graph
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Chart1.Series("Hydropathy").Points.Clear()
        PictureBox1.Image = Nothing
    End Sub
    'Sub to open the PDB search Function
    Private Sub OpenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem1.Click
        DataTables.Show()
    End Sub
    'Sub to display the scoring indices being used
    Private Sub DisplayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisplayToolStripMenuItem.Click

    End Sub
    'Sub to display the checked indices. 
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form4.Show()
        For Each indexChecked In Holder.CheckedIndices
            Dim current_checked_sequence As String = Holder.Items(indexChecked).ToString()
            Form4.TextBox1.AppendText(current_checked_sequence)
            Form4.TextBox1.AppendText(Environment.NewLine)
            Dim Compare_result = String.Compare(Global_List.sequence_list.sequence_array(indexChecked).Name, current_checked_sequence)
            If Compare_result = 0 Then
                Form4.TextBox1.AppendText(Global_List.sequence_list.sequence_array(indexChecked).sequence_no_title)
            End If
            Form4.TextBox1.AppendText(Environment.NewLine)
        Next
    End Sub

End Class


'__________________________________________________________________'
''Code that might be relevant to structure'
'Gives the Helical amphipathy'
'Sub Command1_Click()
'    oldlincol% = lincol%
'    oldspan = span
'    oldsmspan = smspan
'    oldsmcycl = smcycl
'    oldstrcflag = strcflag
'    oldprofindex = profindex
'    predict% = 1
'    strcflag = 1
'    nres = seqsiz
'    'Set up spans
'    ispan(1) = 2        'for sheets, span is 5
'    isspan(1) = 1       'smooth span is 3
'    prof(1) = 18

'    ispan(2) = 2
'    isspan(2) = 1
'    prof(2) = 19

'    ispan(3) = 3        'for helix, span is 7
'    isspan(3) = 3       'smooth span is 7
'    prof(3) = 21

'    ispan(4) = 3
'    isspan(4) = 3
'    prof(4) = 22

'    ispan(5) = 1        'for turns, span is 3
'    isspan(5) = 1       'smooth span is 3
'    prof(5) = 28

'    For i = 1 To 5
'        span = ispan(i)
'        smcycl = 2
'        smspan = isspan(i)
'        lincol% = i
'        hydtype$ = Up$(prof(i))
'        For K = 1 To 20
'            currhydrop(K) = profval(prof(i), K)
'        Next
'        Call Hydrop(nres)
'        Call smoothit(nres)
'        zerop = 1.05
'        If scalflag% = 0 Then
'            maxval = -1000
'            minval = 1000
'            For j = 1 To nres
'                avhydrop = Displayval(j)
'                If avhydrop > maxval Then maxval = avhydrop
'                If avhydrop < minval Then minval = avhydrop
'            Next
'            If minval > zerop Then minval = zerop
'            If maxval < zerop Then maxval = zerop
'            maxscal = maxval
'            minscal = minval
'        End If
'        scal = maxscal - minscal

'        Select Case i
'            Case 1
'                DisplayIt Picture1
'            Text1.Text = hydtype$
'            Case 2
'                DisplayIt Picture2
'            Text2.Text = hydtype$
'            Case 3
'                DisplayIt Picture3
'            Text3.Text = hydtype$
'            Case 4
'                DisplayIt Picture4
'            Text4.Text = hydtype$
'            Case 5
'                DisplayIt Picture5
'            Text5.Text = hydtype$
'        End Select
'    Next
'    'Helical amphipathy
'    amphlag = 1
'    amphangl = 100
'    span = 5            'Span is 11
'    smcycl = 1
'    smspan = 3          'Smooth 1 x 7
'    lincol% = 7
'    'Index 5 is Kyte, 6 is von Heijne
'    hydtype$ = Up$(5)
'    For K = 1 To 20
'        currhydrop(K) = profval(5, K)
'    Next
'    Call setseq(nres)
'    Call calcamphi(nres, span, amphangl)
'    For j = 1 To nres
'        Displayval(j) = avamphi(j)
'    Next
'    Call smoothit(nres)
'    maxval = -1000
'    minval = 1000
'    For j = 1 To nres
'        avhydrop = Displayval(j)
'        If avhydrop > maxval Then maxval = avhydrop
'        If avhydrop < minval Then minval = avhydrop
'    Next
'    zerop = 1
'    If minval > zerop Then minval = zerop
'    If maxval < zerop Then maxval = zerop
'    maxscal = maxval
'    minscal = minval
'    scal = maxscal - minscal
'    DisplayIt Picture6
'    Text6.Text = "Amphi@100, " + hydtype$
'    'Now do sheet amphi
'    amphangl = 170
'    span = 2            'Span is 5
'    smcycl = 1
'    smspan = 1          'SmSpan is 3
'    Call calcamphi(nres, span, amphangl)
'    For j = 1 To nres
'        Displayval(j) = avamphi(j)
'    Next
'    Call smoothit(nres)
'    maxval = -1000
'    minval = 1000
'    For j = 1 To nres
'        avhydrop = Displayval(j)
'        If avhydrop > maxval Then maxval = avhydrop
'        If avhydrop < minval Then minval = avhydrop
'    Next
'    zerop = 1
'    If minval > zerop Then minval = zerop
'    If maxval < zerop Then maxval = zerop
'    maxscal = maxval
'    minscal = minval
'    scal = maxscal - minscal
'    DisplayIt Picture7
'    Text7.Text = "Amphi@170, " + hydtype$
'    'Reset old values when we finish
'    profindex = oldprofindex
'    hydtype$ = Up$(profindex)
'    For K = 1 To 20
'        currhydrop(K) = profval(profindex, K)
'    Next
'    lincol% = oldlincol%
'    strcflag = oldstrcflag
'    span = oldspan
'    smspan = oldsmspan
'    smcycl = oldsmcycl
'End Sub
'________________________________________________________________'


