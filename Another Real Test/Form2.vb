Imports System.Web
Imports System.Net.WebRequest
Imports System.Net
Imports System.IO
Imports System.Object
Imports System


Public Class DataTables
    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim pdbid As String = PDB_ID.Text
        PDB_Describe_Request(pdbid)
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim pdbid As String = PDB_ID.Text
        PDB_GET_Blast(pdbid)
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim pdbid As String = PDB_ID.Text
        PDB_Get_Ligands(pdbid)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim pdbid As String = PDB_ID.Text
        PDB_Get_Sequence_Cluster(pdbid)
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim pdbid As String = PDB_ID.Text
        Chain_Request(pdbid)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim pdbid As String = PDB_ID.Text
        Get_PDB_List()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim pdbid As String = PDB_ID.Text
        WebServices(pdbid)
    End Sub
    Function WebServices(ByVal pdb_id)
        Helices.Clear()
        Dim strContents As String = "http://www.rcsb.org/pdb/rest/representatives?structureId="
        strContents = strContents + pdb_id
        Dim request As WebRequest = WebRequest.Create(strContents)
        Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

        Helices.AppendText("PDB_Cluster Services")
        Helices.AppendText(Environment.NewLine)

        Dim dataStream As Stream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()
        'Dim xmlConvert As XElement = XElement.Load(responseFromServer)
        'FASTA.AppendText(responseFromServer)


        ' HtmlTagInnerTextParser(responseFromServer)

        reader.Close()
        dataStream.Close()
        response.Close()
        Helices.AppendText(responseFromServer)

    End Function
    Function Get_PDB_List()
        TextBox2.Clear()
        Dim strContents As String = "http://www.rcsb.org/pdb/rest/getCurrent"
        'strContents = strContents + PDB_ID
        Dim request As WebRequest = WebRequest.Create(strContents)
        Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

        TextBox2.AppendText("BLAST")
        TextBox2.AppendText(Environment.NewLine)

        Dim dataStream As Stream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()
        'Dim xmlConvert As XElement = XElement.Load(responseFromServer)
        'TextBox2.AppendText(responseFromServer)


        ' HtmlTagInnerTextParser(responseFromServer)

        reader.Close()
        dataStream.Close()
        response.Close()
        Get_PDB_Parser(responseFromServer)
    End Function
    Function Chain_Request(ByVal pdb_id)
        HydropathyBox.Clear()
        Dim strContents As String = "http://www.rcsb.org/pdb/rest/representatives?structureId="
        strContents = strContents + pdb_id
        Dim request As WebRequest = WebRequest.Create(strContents)
        Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

        ' FASTA.AppendText("PDB_Description")
        'FASTA.AppendText(Environment.NewLine)

        Dim dataStream As Stream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()
        'Dim xmlConvert As XElement = XElement.Load(responseFromServer)
        'FASTA.AppendText(responseFromServer)


        ' HtmlTagInnerTextParser(responseFromServer)

        reader.Close()
        dataStream.Close()
        response.Close()
        HydropathyBox.AppendText(responseFromServer)
        PDB_Chain_Parse(responseFromServer)
    End Function
    'PDB Request'
    Function PDB_Describe_Request(ByVal pdb_id)
        FASTA.Clear()
        Dim strContents As String = "http://www.rcsb.org/pdb/rest/describePDB?structureId="
        strContents = strContents + pdb_id
        Dim request As WebRequest = WebRequest.Create(strContents)
        Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

        ' FASTA.AppendText("PDB_Description")
        'FASTA.AppendText(Environment.NewLine)

        Dim dataStream As Stream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()
        'Dim xmlConvert As XElement = XElement.Load(responseFromServer)
        'FASTA.AppendText(responseFromServer)


        ' HtmlTagInnerTextParser(responseFromServer)

        reader.Close()
        dataStream.Close()
        response.Close()
        Parse_Describe(responseFromServer)

    End Function

    Function PDB_GET_Blast(ByVal pdb_id)
        HydropathyBox.Clear()
        Dim strContents As String = "http://www.rcsb.org/pdb/rest/getBlastPDB2?structureId="
        strContents = strContents + pdb_id
        Dim request As WebRequest = WebRequest.Create(strContents)
        Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

        HydropathyBox.AppendText("BLAST")
        HydropathyBox.AppendText(Environment.NewLine)

        Dim dataStream As Stream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()
        'Dim xmlConvert As XElement = XElement.Load(responseFromServer)
        HydropathyBox.AppendText(responseFromServer)


        ' HtmlTagInnerTextParser(responseFromServer)

        reader.Close()
        dataStream.Close()
        response.Close()

    End Function

    Function PDB_Get_Ligands(ByVal pdb_id)
        Helices.Clear()
        Dim strContents As String = "http://www.rcsb.org/pdb/rest/ligandInfo?structureId="
        strContents = strContents + pdb_id
        Dim request As WebRequest = WebRequest.Create(strContents)
        Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

        Helices.AppendText("PDB_Ligands")
        Helices.AppendText(Environment.NewLine)

        Dim dataStream As Stream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()
        'Dim xmlConvert As XElement = XElement.Load(responseFromServer)
        Helices.AppendText(responseFromServer)


        ' HtmlTagInnerTextParser(responseFromServer)

        reader.Close()
        dataStream.Close()
        response.Close()
    End Function
    Function PDB_Get_Sequence_Cluster(ByVal pdb_id)
        Helices.Clear()
        Dim strContents As String = "http://www.rcsb.org/pdb/rest/sequenceCluster?structureId="
        strContents = strContents + pdb_id
        Dim request As WebRequest = WebRequest.Create(strContents)
        Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

        Helices.AppendText("PDB_Sequence_Cluster")
        Helices.AppendText(Environment.NewLine)

        Dim dataStream As Stream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()
        'Dim xmlConvert As XElement = XElement.Load(responseFromServer)
        Helices.AppendText(responseFromServer)


        ' HtmlTagInnerTextParser(responseFromServer)

        reader.Close()
        dataStream.Close()
        response.Close()

    End Function
    Function Get_PDB_Parser(ByRef info As String)
        '     <?xml version='1.0' standalone='no' ?>
        '<current>
        '<PDB structureId = "100D" />
        '<PDB structureId="101D"/>
        '<PDB structureId = "101M" />
        '<PDB structureId="102D"/>
        '<PDB structureId = "102L" />
        '<PDB structureId="102M"/>
        '<PDB structureId = "103D" />
        '<PDB structureId="103L"/>
        '<PDB structureId = "103M" />
        '<PDB structureId="104D"/>
        '<PDB structureId = "104L" />
        '<PDB structureId="104M"/>
        '<PDB structureId = "105D" />
        '<PDB structureId="105M"/>
        '<PDB structureId = "106D" />
        '<PDB structureId="106M"/>
        '<PDB structureId = "107D" />
        '<PDB structureId="107L"/>
        '<PDB structureId = "107M" />
        '<PDB structureId="108D"/>
        TextBox2.Clear()
        Dim count_pubmedID As Integer
        Dim pubmedID_end As Integer
        Dim SString As String = "PDB structureId="
        Dim string_info As String
        pubmedID_end = InStrRev(info, SString) - 1
        count_pubmedID = InStr(info, SString) - 1
        Dim equal As Char = " "
        Dim count As Integer = 0
        For indexA = count_pubmedID To info.Length
            If info(indexA).Equals(equal) = True Then
                If count = 1 Then
                    pubmedID_end = indexA
                    Exit For
                End If
                count = count + 1
            End If
        Next

        For indexB = count_pubmedID To pubmedID_end
            TextBox2.AppendText(info(indexB))
        Next

        TextBox2.AppendText(Environment.NewLine)
        Dim Flag As Boolean = False
        While (Flag = False)
            count = 0
            count_pubmedID = InStr(pubmedID_end, info, SString) - 1
            equal = " "
            If count_pubmedID <= 0 Then
                Exit While
                Flag = True
            End If

            For indexA = count_pubmedID To info.Length
                If info(indexA).Equals(equal) = True Then
                    If count = 1 Then
                        pubmedID_end = indexA
                        Exit For
                    End If
                    count = count + 1
                End If
            Next

            For indexB = count_pubmedID To pubmedID_end
                TextBox2.AppendText(info(indexB))
                string_info = string_info + info(indexB)
            Next
            string_info = string_info + Environment.NewLine
            TextBox2.AppendText(Environment.NewLine)
        End While
        'TextBox2.AppendText(string_info)
    End Function
    Function PDB_Chain_Parse(ByRef info As String)
        HydropathyBox.Clear()
        '<representatives>
        '<pdbChain name = "3CX5.c" />
        '<pdbChain name="2QJY.B"/>
        ' <pdbChain name = "3CX5.e" />
        '</representatives>
        'pdbChain Name = "3CX5.c" />
        ' <pdbChain name="2QJY.B"/>
        ' <p
        'pdbChain
        Dim count_pubmedID As Integer
        Dim pubmedID_end As Integer
        Dim SString As String = "pdbChain name="
        pubmedID_end = InStrRev(info, SString) - 1
        count_pubmedID = InStr(info, SString) - 1
        Dim equal As Char = " "
        Dim count As Integer = 0
        For indexA = count_pubmedID To info.Length
            If info(indexA).Equals(equal) = True Then
                If count = 1 Then
                    pubmedID_end = indexA
                    Exit For
                End If
                count = count + 1
            End If
        Next

        For indexB = count_pubmedID To pubmedID_end
            HydropathyBox.AppendText(info(indexB))
        Next

        HydropathyBox.AppendText(Environment.NewLine)
        Dim Flag As Boolean = False
        While (Flag = False)
            count = 0
            count_pubmedID = InStr(pubmedID_end, info, SString) - 1
            equal = " "
            If count_pubmedID <= 0 Then
                Exit While
                Flag = True
            End If

            For indexA = count_pubmedID To info.Length
                If info(indexA).Equals(equal) = True Then
                    If count = 1 Then
                        pubmedID_end = indexA
                        Exit For
                    End If
                    count = count + 1
                End If
            Next

            For indexB = count_pubmedID To pubmedID_end
                HydropathyBox.AppendText(info(indexB))
            Next

            HydropathyBox.AppendText(Environment.NewLine)
        End While

    End Function
    Function Parse_Describe(ByRef info As String)
        'Text File to Parse. Lame.
        '<?xml version='1.0' standalone='no' ?>
        '<PDBdescription>
        ' <PDB structureId = "2QJY" title="Crystal structure of rhodobacter sphaeroides double mutant with stigmatellin and UQ2" pubmedId="18039651" expMethod="X-RAY DIFFRACTION" 
        'resolution = "2.40" keywords="OXIDOREDUCTASE" nr_entities="3" nr_residues="5406" nr_atoms="42656" 
        'deposition_date = "2007-07-09" release_date="2007-12-25" last_modification_date="2011-07-13" 
        'structure_authors = "Esser, L., Xia, D." citation_authors="Esser, L., Elberry, M., Zhou, F., Yu, C.A., Yu, L., Xia, D." status="CURRENT" />
        '</PDBdescription>
        'xpMethod="X-RAY 
        FASTA.Clear()
        Dim count_pubmedID As Integer
        Dim pubmedID_end As Integer
        Dim SString As String = "pubmedId="
        pubmedID_end = InStrRev(info, SString) - 1
        count_pubmedID = InStr(info, SString) - 1
        Dim equal As Char = " "

        For indexA = count_pubmedID To info.Length
            If info(indexA).Equals(equal) = True Then
                pubmedID_end = indexA
                Exit For
            End If
        Next

        For indexB = count_pubmedID To pubmedID_end
            FASTA.AppendText(info(indexB))
        Next

        FASTA.AppendText(Environment.NewLine)

        SString = "structureId="
        pubmedID_end = InStrRev(info, SString) - 1
        count_pubmedID = InStr(info, SString) - 1
        equal = " "

        For indexA = count_pubmedID To info.Length
            If info(indexA).Equals(equal) = True Then
                pubmedID_end = indexA
                Exit For
            End If
        Next

        For indexB = count_pubmedID To pubmedID_end
            FASTA.AppendText(info(indexB))
        Next

        FASTA.AppendText(Environment.NewLine)

        SString = "keywords="
        pubmedID_end = InStrRev(info, SString) - 1
        count_pubmedID = InStr(info, SString) - 1
        equal = " "

        For indexA = count_pubmedID To info.Length
            If info(indexA).Equals(equal) = True Then
                pubmedID_end = indexA
                Exit For
            End If
        Next

        For indexB = count_pubmedID To pubmedID_end
            FASTA.AppendText(info(indexB))
        Next

        FASTA.AppendText(Environment.NewLine)

        SString = "nr_entities="
        pubmedID_end = InStrRev(info, SString) - 1
        count_pubmedID = InStr(info, SString) - 1
        equal = " "

        For indexA = count_pubmedID To info.Length
            If info(indexA).Equals(equal) = True Then
                pubmedID_end = indexA
                Exit For
            End If
        Next

        For indexB = count_pubmedID To pubmedID_end
            FASTA.AppendText(info(indexB))
        Next

        FASTA.AppendText(Environment.NewLine)
        SString = "nr_residues="
        pubmedID_end = InStrRev(info, SString) - 1
        count_pubmedID = InStr(info, SString) - 1
        equal = " "

        For indexA = count_pubmedID To info.Length
            If info(indexA).Equals(equal) = True Then
                pubmedID_end = indexA
                Exit For
            End If
        Next

        For indexB = count_pubmedID To pubmedID_end
            FASTA.AppendText(info(indexB))
        Next


        FASTA.AppendText(Environment.NewLine)
        SString = "nr_atoms="
        pubmedID_end = InStrRev(info, SString) - 1
        count_pubmedID = InStr(info, SString) - 1
        equal = " "

        For indexA = count_pubmedID To info.Length
            If info(indexA).Equals(equal) = True Then
                pubmedID_end = indexA
                Exit For
            End If
        Next

        For indexB = count_pubmedID To pubmedID_end
            FASTA.AppendText(info(indexB))
        Next

    End Function

    Function Parse_Ligands(ByRef info As String)
        Helices.Clear()
        '<?xml version='1.0' standalone='no' ?>
        '<structureId id = "2QJY" >
        ' <ligandInfo>
        '    <ligand structureId="2QJY" chemicalID="BGL" type="saccharide" molecularWeight="292.369">
        '       <chemicalName>B-2-OCTYLGLUCOSIDE</chemicalName>
        '      <formula>C14 H28 O6</formula>
        '     <InChIKey>BVHPDIWLWHHJPD-RKQHYHRCSA-N</InChIKey>
        '    <InChI>InChI=1S/C14H28O6/c1-2-3-4-5-6-7-8-19-13-12(17)11(16)10(9-15)20-14(13)18/h10-18H,2-9H2,1H3/t10-,11-,12+,13-,14-/m1/s1</InChI>
        '   <smiles>CCCCCCCCO[C@@H]1[C@H]([C@@H]([C@H](O[C@H]1O)CO)O)O</smiles>
        '</ligand>
        '<ligand structureId="2QJY" chemicalID="CL" type="non-polymer" molecularWeight="35.453">
        '<chemicalName>CHLORIDE ION</chemicalName>
        '<formula>CL -1</formula>
        '<InChIKey>VEXZGXHMUGYJMC-UHFFFAOYSA-M</InChIKey>
        '<InChI>InChI=1S/ClH/h1H/p-1</InChI>
        '<smiles>[Cl-]</smiles>
        '</ligand>
        '<ligand structureId="2QJY" chemicalID="FES" type="non-polymer" molecularWeight="175.82">
        '<chemicalName>FE2/S2 (INORGANIC) CLUSTER</chemicalName>
        '<formula>FE2 S2</formula>
        '          <InChIKey>NIXDOXVAJZFRNF-UHFFFAOYSA-N</InChIKey>
        '<InChI>InChI=1S/2Fe.2S</InChI>
        '<smiles>S1[Fe]S[Fe]1</smiles>
        '</ligand>
        '<ligand structureId="2QJY" chemicalID="HEM" type="non-polymer" molecularWeight="616.487">
        '<chemicalName>PROTOPORPHYRIN IX CONTAINING FE</chemicalName>
        '<formula>C34 H32 FE N4 O4</formula>
        '<InChIKey>KABFMIBPWCXCRK-RGGAHWMASA-L</InChIKey>
        '<InChI>InChI=1S/C34H34N4O4.Fe/c1-7-21-17(3)25-13-26-19(5)23(9-11-33(39)40)31(37-26)16-32-24(10-12-34(41)42)20(6)28(38-32)15-30-22(8-2)18(4)27(36-30)14-29(21)35-25;/h7-8,13-16H,1-2,9-12H2,3-6H3,(H4,35,36,37,38,39,40,41,42);/q;+2/p-2/b25-13-,26-13-,27-14-,28-15-,29-14-,30-15-,31-16-,32-16-;</InChI>
        '<smiles>Cc1c2n3c(c1CCC(=O)O)C=C4C(=C(C5=[N]4[Fe]36[N]7=C(C=C8N6C(=C5)C(=C8C)C=C)C(=C(C7=C2)C)C=C)C)CCC(=O)O</smiles>
        '</ligand>
        '<ligand structureId="2QJY" chemicalID="LOP" type="non-polymer" molecularWeight="661.89">
        '<chemicalName>(1R)-2-{[(R)-(2-AMINOETHOXY)(HYDROXY)PHOSPHORYL]OXY}-1-[(DODECANOYLOXY)METHYL]ETHYL (9Z)-OCTADEC-9-ENOATE</chemicalName>
        '<formula>C35 H68 N O8 P</formula>
        '<InChIKey>FUUNMZKPCMPCHT-ILGKRYBBSA-N</InChIKey>
        '<InChI>InChI=1S/C35H68NO8P/c1-3-5-7-9-11-13-14-15-16-17-18-20-22-24-26-28-35(38)44-33(32-43-45(39,40)42-30-29-36)31-41-34(37)27-25-23-21-19-12-10-8-6-4-2/h15-16,33H,3-14,17-32,36H2,1-2H3,(H,39,40)/b16-15-/t33-/m1/s1</InChI>
        '<smiles>CCCCCCCCCCCC(=O)OC[C@H](CO[P@](=O)(O)OCCN)OC(=O)CCCCCCC\C=C/CCCCCCCC</smiles>
        '</ligand>
        '<ligand structureId="2QJY" chemicalID="NA" type="non-polymer" molecularWeight="22.99">
        '<chemicalName>SODIUM ION</chemicalName>
        '<formula>NA 1</formula>
        '<InChIKey>FKNQFGJONOIPTF-UHFFFAOYSA-N</InChIKey>
        '<InChI>InChI=1S/Na/q+1</InChI>
        '<smiles>[Na+]</smiles>
        '</ligand>
        '<ligand structureId="2QJY" chemicalID="SMA" type="non-polymer" molecularWeight="514.65">
        '<chemicalName>STIGMATELLIN A</chemicalName>
        '<formula>C30 H42 O7</formula>
        '<InChIKey>UZHDGDDPOPDJGM-WPPYOTIYSA-N</InChIKey>
        '<InChI>InChI=1S/C30H42O7/c1-10-18(2)13-11-12-14-22(33-6)21(5)29(36-9)19(3)15-16-23-20(4)27(31)26-24(34-7)17-25(35-8)28(32)30(26)37-


    End Function
End Class
