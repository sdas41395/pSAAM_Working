Imports System.IO
Imports System.Net
Imports System.Text

Public Class Form4
    Function KAlign()
        'Calls Kalign and delivers an MSA'
        'Parameter List'
        Dim post_data As String
        Dim email As String 'Needed for job submittal'
        email = "param1=sdas13@illinois.edu&"

        Dim title As String
        title = "param2=Work&"

        Dim stype As String
        'Type is string 
        stype = "param3=protein&"

        Dim Format As String
        'Type is string
        Format = "param4=fasta=true&"

        Dim gapopen As String
        gapopen = "param5=11&"
        '11

        'Can be altered later. Takes any integer value'
        Dim gapext As String
        gapext = "param6=.85&"

        'Type is real(?)
        Dim termgap As String
        termgap = "param7=.45&"

        'Type is real(?)
        Dim bonus As String
        bonus = "param8=0&"

        'Type is real(?)
        Dim sequence As String
        Dim sequence_start As String
        Dim sequence_end As String
        Dim sequence_total As String
        sequence_start = "Sequence="
        sequence = ""



        Dim indexChecked As Integer
        Dim itemChecked As Object
        '
        '     For Each indexChecked In Holder.CheckedIndices
        'Need to search the itemchecked in our list using the name. Work in progress'
        '           sequence = sequence + Environment.NewLine + Global_List.sequence_list.sequence_array(indexChecked).total_sequence
        'TextBox1.AppendText(Global_List.sequence_list.sequence_array(indexChecked).total_sequence)
        'TextBox1.AppendText(Environment.NewLine)
        '      Next

        sequence_total = sequence_start + sequence

        Dim strContents As String = "http://www.ebi.ac.uk/Tools/services/rest/kalign/run/"
        'strContents = strContents + email
        'strContents = strContents + title
        'strContents = strContents + stype
        'strContents = strContents + Format
        'strContents = strContents + gapopen
        'strContents = strContents + gapext
        'strContents = strContents + termgap
        'strContents = strContents + bonus
        'strContents = strContents + "sequence="
        'strContents = strContents + sequence
        'strContents.Trim(Environment.NewLine)
        'strContents.Trim(">")
        'strContents.Trim(" ")
        'Needs Post web request response to pass parameters'
        Dim request As HttpWebRequest = CType(WebRequest.Create(strContents), HttpWebRequest)
        request.Method = "POST"

        post_data = email + title + stype + Format + gapopen + gapext + termgap + bonus + sequence_total
        TextBox1.AppendText(post_data)
        post_data.Trim(" ")
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(post_data)
        request.ContentType = "application/x-www-form-urlencoded"
        request.ContentLength = byteArray.Length

        Dim dataStream As Stream = request.GetRequestStream()
        dataStream.Write(byteArray, 0, byteArray.Length)
        dataStream.Close()

        Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
        dataStream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)

        Dim responseFromServer As String = reader.ReadToEnd()
        Dim job_id As String = responseFromServer

        reader.Close()
        dataStream.Close()
        response.Close()


        TextBox1.AppendText(responseFromServer)


    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'event click calls function'
        KAlign()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Just testing the url output'
        Dim strContents As String = "http://www.ebi.ac.uk/Tools/services/generic/rest/kalign/run/param1=sdas13@illinois.edu&param2=Work&param3=protein&param4=fasta=true&param5=11&param6=.85&param7=.45&param8=0&Sequence=>BalneatrixalpicaMGWIDERFPATQMWEDHLSKYYAPKNFNFWYFFGSLALLVLVNQILTGVWLTMSFNPSAEGAFASVEYIMRDVEYGWLIRYLHSTGASAFFVVVYLHMFRGMLYGSYRKPRELVWIFGMTIYLALMAEAFMGYLLPWGQMSYWGAQVIISLFGAIPVVGEDLAQWVRGDFLISGITLNRFFSLHVIALPIVLLALVVLHIIALHEVGSNNPDGIEIKANKDENGIPVDGIPFHPYYTVKDIVGVVVFLMVFCTVVFFFPEMGGYFIEKPNFEPANPLKTPEHIAPVWYFTPFYAMLRAVTYPLFGVDAKFWGVVVMGAAIAILFVLPWLDRSPVKSIRYKGWLSKLWMVIFAVSFVILGVLGALPSTGARTVVSQICTTLYFAYFILMPFYTRMESTKPVPERVTG>ConchiformibiuskuhniaeMENQNNGTSKGKALLDWVDARFPLSKLMKEHVTEYYAPKNFNFWYFFGSLAMLVLVIQIVSGIFLTMNFKPDGTTNAQNLPVAFAAVEYIMRDVSGGWIIRYMHSTGASMFFIVVYLHMFRGLVYGSFKKPRELVWVFGSLIFLALMAEAFMGYLLPWGQMSFWGAQVIINLFGAIPVIGPDLSTWIRGDFNVSDATLNRFFALHVIALPLVLVGLVAAHLIALHEVGSNNPDGVEIKKLKDSNGIPLDGIPFHPYYTVKDILGVVVFLIFFCGVMFFAPEGGGYFLEKPNFDPADPLKTPPHIAPVWYFTPFYAILRAVPSFAGTQVWGVLAMGAAVVLIALLPWLDRSPTKSVRYRGPIFKTALVLFLISFIGLGILGAKVATDTRTLVSQILSVVYFAFFLGMPFYTKLDKDKPVPERVTMSTPKQKLMFFVYVAITLIGSYLFAVYI>HalomonassalinaMANPDKPKAERGVMRWVDDRFPATQMWQEHLSKYYAPKNFNFWYFFGSLALLVLVNQILTGVWLTMSFNPSAEGAFASVEYIMRDVEWGWLIRYMHSTGASAFFVVVYLHMFRGLLYGSYKAPRELVWIFGMAIYLALMAEAFMGYLLPWGQMSYWGAQVIISLFSAIPAIGPDLAQWVRGDYLISGITLNRFFALHVVALPIVILALVVLHIIALHEVGSNNPDGIDIKAKKDESGKPLDGIPFHPYYTVKDIVGVAVFLFVFCAVIFYFPEGGGYFLEKPNFEPANPLKTPDHIAPVWYFTPFYAILRAINFSLFGLDAKFLGVVCMGAAIAVLFVLPWLDRSPVRSIRYKGWISKLMLALFAVSFIVLGVLGVLPPTAARTALAQLCTVLYFAFFLLMPFYSRWEKTKPVPERVTG"

        TextBox1.AppendText(strContents.Length)
        TextBox1.AppendText(Environment.NewLine)
        TextBox1.AppendText(strContents(180))
        TextBox1.AppendText(strContents(181))
        TextBox1.AppendText(strContents(182))
        TextBox1.AppendText(strContents(183))
        TextBox1.AppendText(strContents(184))
        TextBox1.AppendText(strContents(185))
        TextBox1.AppendText(Environment.NewLine)
        TextBox1.AppendText(strContents)
    End Sub
    'Any other web service cause kalign doesnt want to cooperate with anything
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DataTables.Show()
        DataTables.FASTA.Clear()
        'For Each indexChecked In Holder.CheckedIndices
        '    'Need to search the itemchecked in our list using the name. Work in progress'
        '    DataTables.FASTA.AppendText(Global_List.sequence_list.sequence_array(indexChecked).sequence_no_title)
        '    DataTables.FASTA.AppendText(Environment.NewLine)
        '    Dim strContents As String = "www.rcsb.org/pdb/rest/getBlastPDB1?sequence="
        '    Dim sequence = Global_List.sequence_list.sequence_array(indexChecked).sequence_no_title
        '    strContents = strContents + sequence
        '    Dim endContents As String = "&eCutOff=10.0&matrix=BLOSUM62&outputFormat=HTML"
        '    strContents = strContents + endContents

        '    'Looking at Blast Results'
        '    '            Dim request As WebRequest = WebRequest.Create(strContents)
        '    'http://www.rcsb.org/pdb/rest/getblastpdb1?sequence=vlspadktnvkaawgkvgahageygaealermflsfpttktyfphfdlshgsaqvkghgkkvadaltavahvddmpnal&ecutoff=10.0&matrix=blosum62&outputformat=html'

        '    '            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

        '    '            Dim datastream As Stream = response.GetResponseStream()
        '    '            Dim reader As New StreamReader(datastream)
        '    '            Dim responsefromserver As String = reader.ReadToEnd()
        '    '            Dim job_id As String = responsefromserver

        '    '            reader.Close()
        '    '            datastream.Close()
        '    '            response.Close()


        '    '            DataTables.FASTA.AppendText(responseFromServer)
        'Next

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Clustal Results. Looks like the problems will remain the same. Format of the sequence='
        'Looking to implement python module'
        Dim strContents = "http://www.ebi.ac.uk/Tools/msa/clustalo/"
        Dim email, title, stype, guidetreeout, dismatout, dealign, mbed, mbediteration, iterations, gtiterations, hmmiterations, outfmt, sequence As String
        email = "sdas41395@gmail.com"
        title = "testJob"
        stype = "FASTA"

    End Sub
End Class