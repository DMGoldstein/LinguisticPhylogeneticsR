# Data and source code for the paper "Indo-European phylogenetics with R: A tutorial introduction"


## Overview

This repository contains the data and source code for the paper "Indo-European phylogenetics with R: A tutorial introduction," _Indo-European_ _Linguistics_ (Goldstein 2020).

## Data

The data used in the paper can be found in the folder `Data`. The file `Multistate_screened.txt` was downloaded from Luay Nakhleh's Computational Phylogenetics in Historical Linguistics website  (`https://www.cs.rice.edu/~nakhleh/CPHL/IEDATA_112603`). The code for downloading the file is provided in the R notebook `Code_PhylogeneticsRTutorial.Rmd`  in the `Code` folder. The file `Binary_Screened.txt` is a transformation of this dataset into binary traits. The script used to transform the data is provided in the folder `code`.

The binary phonological and morphological traits are described in the file `BinaryTraitDescriptions.pdf`.

## Code

The script `install.R`  will install the packages used in `Code_PhylogeneticsRTutorial.Rmd`.

`Code_PhylogeneticsRTutorial.Rmd` contains an R notebook with all of the code used in the tutorial (plus some additional snippets). The analyses were carried out with R version 3.5.3. Further version information is available in `versions.txt` in the `Code` folder.

`Program.cs`: This is the script used to convert the datasets with multistate characters in the file `Multistate_screened.txt` into binary character values in  `Binary_Screened.txt` . Characters P1, P3, and M1-M12 were subsequently recoded by hand. The code is written in C-Sharp and was created by Shawn McCreight.


