# KingWare
A ransomware built with C# and running in a VBA script embedded in a word document.

## Introduction
There is a VBA script that runs in the Doc file, encrypting a specific directory (you need to change it for your personnal needs).
The KingWare project is the class library containing the crypting algorithm, and the DecryptWare is a console application that 
decrypts the crypted files in the directory.

## Setup
Just open the solution in your fav IDE for C# and there you go.

The VBA script run automatically when you open the Doc file.

## Considerations
We use the SharpAESCrypt nuget package for encrypting and decrypting the files. If the VBA script fails to run because
the SharpAESCrypt does not have a strong name, you will need to go into the directory containing the .dll of the package 
and register a strong name. 
You can copy the KingWare.snk file in the KingWare folder into the SharpAESCrypt package and run:
```console
ildasm /all /out=SharpAESCrypt.il SharptAESCrypt.dll
ilasm /dll /key=KingWare.snk SharpAESCrypt.il
```

## Contributions
Fire a PR or issues to make this project go foward.

## License
This project has an Apache License
