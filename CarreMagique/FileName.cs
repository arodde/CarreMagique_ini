using System;
using System.Collections.Generic;
using System.Text;

namespace MagicSquare
{
    public class FileName
    {
        public int value;
        public int occurrence;
        public string prefix;
        public string shortFileType;
        public string labelFileType;
        public string pathFileType;
        public string suffix;

     

        public FileName(string s)
        {
            prefix = "cm";
            value = 0;
            shortFileType = "";
            labelFileType = "";
            pathFileType = @"";
            occurrence = 0;
            suffix = s;
        }

        public void getValues(string p, int n, string tFC, string tFL, string tFP, int o, string s)
        {
            prefix = "cm";
            value = 0;
            shortFileType = "";
            labelFileType = "";
            pathFileType = @"";
            occurrence = 0;
            suffix = ".txt";
        }
        public override string ToString()
        {
            string res = prefix + value.ToString() + shortFileType + occurrence + suffix;
            return res;
        }
        public string GivesFullFileName()
        {
            string res = prefix + value.ToString() + shortFileType + occurrence + suffix;
            return res;
        }
        public bool HasTtheSameFileName(string fileName)
        {
            if (this.ToString() == fileName)
            {
                Console.WriteLine("sont identiques");
                return true;
            }
            else
            {
                Console.WriteLine("sont différentes");
                return false;
            }
        }
        public override bool Equals(object obj)
        {
            FileName nf = obj as FileName;
            if (nf == null)
                return false;
            return prefix == nf.prefix
                && value == nf.value
                && shortFileType == nf.shortFileType
                && labelFileType == nf.labelFileType
                && pathFileType == nf.pathFileType
                && occurrence == nf.occurrence
                && suffix == nf.suffix;
        }
        public void FineNameDecomposition(string fileWithExtension)
        {/*
            fonction ventiler le nom du fichier dans les différentes propriétés 
            de l'objet de type NomFichier selon une structure 
            préfixe en lettres
            taille carré magique en chiffres
            type de carré magique en lettres
            occurrence en chiffres
            suffixe selon échantillon
             */
            Uti.Info("NomFichier", "DecompositionNomFichier", "");
            int fileSeparatorPosition = fileWithExtension.LastIndexOf(@"\");
            string file = fileWithExtension.Substring(fileSeparatorPosition, fileWithExtension.Length - (fileSeparatorPosition));
            int dotPosition = file.LastIndexOf('.');
            string extension = file.Substring(dotPosition, file.Length - dotPosition);
            char[] characterArray = file.ToCharArray();
            int iPos;
            string sVal = "";
            int iVal;
            // reconnaissance de l'extension
            if (extension == ".txt")
            {
                suffix = ".txt";
            }
            else
            {
                suffix = ".json";
            }
            iPos = 0;
            int i = iPos;
            // éviter les caractères de séparation de dossiers 
            while (!Char.IsLetterOrDigit(characterArray[i]))
            {
                i++;
            }
            // reconnaissance préfixe "cm"
            while (!Char.IsDigit(characterArray[i]))
            {
                sVal += characterArray[i];
                i++;
            }
            prefix = sVal;
            // reconnaissance du nombre (taille du carré magique)
            sVal = "";
            while (i < characterArray.Length)// commence après "cm"
            {
                if (Char.IsDigit(characterArray[i]))
                {
                    sVal += characterArray[i];
                }
                else
                {
                    break;// pour sortir à la première lettre rencontrée
                }
                i++;
            }
            if (int.TryParse(sVal, out iVal))
            {

                value = iVal;
            }
            else
            {

                Console.WriteLine("Conversion impossible");
            }
            value = iVal;
            // reconnaissance du type de fichier résolu ou en cours
            sVal = "";
            while (i < characterArray.Length)// commence après le nombre
            {
                if (!Char.IsDigit(characterArray[i]))
                {
                    sVal += characterArray[i];
                }
                else
                {
                    break;// pour sortir au premier chiffre rencontré
                }
                i++;
            }
            if (sVal == "ec")
            {
                shortFileType = "ec";
                labelFileType = "en cours";
                pathFileType = @"en-cours\";
            }
            else
            {
                shortFileType = "r";
                labelFileType = "résolus";
                pathFileType = @"resolus\";
            }
            // reconnaissance de l'occurrence
            sVal = "";
            while (i < characterArray.Length)// commence après "cm"
            {
                if (Char.IsDigit(characterArray[i]))
                {
                    sVal += characterArray[i];
                }
                else
                {
                    break;// pour sortir à la première lettre rencontrée
                }
                i++;
            }
            if (int.TryParse(sVal, out iVal))
            {
                occurrence = iVal;
            }
            else
            {
                Console.WriteLine("Conversion impossible");
            }
        }
        public void ResetFileName()
        {
            prefix = "cm";
            value = 0;
            occurrence = 0;
            suffix = "";
            shortFileType = "";
            labelFileType = "";
            pathFileType = @"";
        }
        public void Copier(FileName nf)
        {
            // nf le fichier dont les propriétés de  l'instance
            // sont copiés dans les propriétés de l'objet appelant
            prefix = nf.prefix;
            value = nf.value;
            shortFileType = nf.shortFileType;
            labelFileType = nf.labelFileType;
            pathFileType = nf.pathFileType;
            occurrence = nf.occurrence;
            suffix = nf.suffix;
        }
        public override int GetHashCode()
        {
            return prefix.GetHashCode() *
                value.GetHashCode() *
                shortFileType.GetHashCode() *
                labelFileType.GetHashCode() *
                pathFileType.GetHashCode() *
                occurrence.GetHashCode() *
                suffix.GetHashCode();
        }
    }

}
