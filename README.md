#README

In progress, but currently working. Some of the files present are polypeptide files for proteins. Used in testing. 

Displays hydropathy of any loaded sequence taken from the PDB (using REST api) or manually inserted. 
Displays alpha helices and beta sheet organization based on sequence structure using Chau Fasman algorithm and others
ToDo: Query different alignment software and compare/analyze their results on inputted sequences

Algorithms not separate from UIR/GUI code. Present in both. 
Note that the code is located in the .vb files and are commented and noted.
The forms are not named with their functions. However Form3 contains the PDB lookup and parse. 
Forms 4,2, and 1 contain the algorithms, UIR interaction (self made Graphing and Drawing dependencies), and Protein Sequence Loader.

